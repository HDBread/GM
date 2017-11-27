using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BWViewerCSharp
{
    public abstract class Filter
    {
        public readonly static int SOURCE = 0;
        public readonly static int DEST = 1;
		
        private Bitmap [] BM;
        // Bitmap data
        protected BitmapData [] Buffer;


        public Filter()
        {       
            BM = new Bitmap[2];
            Buffer = new BitmapData[2];
        }
		
		public static unsafe byte Y(byte * pPix)
		{
			return ((byte)(0.11*pPix[0] + 0.59*pPix[1] + 0.3*pPix[2]) );
		}


        public bool SetBuffers(Bitmap source,Bitmap dest)
        {           
            BM[SOURCE] = source;
            BM[DEST] = dest;

            if(BM[SOURCE] ==null || BM[DEST] == null)
                return false;

            // return result
            bool result = false;

            try
            {
                // Getting direct access to data            
                if (// indicating that source read only
                    (Buffer[SOURCE]=BM[SOURCE].LockBits(new Rectangle(Point.Empty,BM[SOURCE].Size),
                    ImageLockMode.ReadOnly, BM[SOURCE].PixelFormat))==null ||
                    // indicating that destination write mode
                    (Buffer[DEST]=BM[DEST].LockBits(new Rectangle(Point.Empty,BM[DEST].Size),
                    ImageLockMode.WriteOnly, BM[DEST].PixelFormat))==null )
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            
            return result;
        }

        public bool ReleaseBuffers()
        {
            // Check
            if(BM[SOURCE]==null || BM[DEST]==null)
                return false;
            // Releasing buffers
            BM[SOURCE].UnlockBits(Buffer[SOURCE]);
            BM[DEST].UnlockBits(Buffer[DEST]);

            return true;
        }

        public unsafe byte* GetPixelPointer(ushort x, int y, int source)
        {            
            if (source!=1 && source!=0)
				return null;

			if(Buffer[source].Scan0 == IntPtr.Zero || x >= Buffer[source].Width || y>= Buffer[source].Height) 
                return null;
        
            // Byte per pixel calculation
            byte bpp=0;
           
            unchecked
            {
                bpp = (byte)(((byte)((int)Buffer[source].PixelFormat>>8))/8);
            }
            
            // Address determination
            return ((byte*)Buffer[source].Scan0)+Buffer[source].Stride*y+x*bpp;
        }		

        public unsafe bool CopyPix(ushort x1, ushort x2, ushort y)
        {
			byte *pSPix1=GetPixelPointer(x1, y, SOURCE);
			byte *pSPix2=GetPixelPointer(x2, y, SOURCE);

			// Destination 
			byte *pDPix=GetPixelPointer(x1, y, DEST);
    
			if( pSPix1==null || pSPix2==null  || pDPix==null )
				return false;

			int lenght = (int) (pSPix2 - pSPix1);

			byte[] tempArray = new byte[lenght];
			Marshal.Copy(new IntPtr(pSPix1),tempArray,0,lenght);
			Marshal.Copy(tempArray,0,new IntPtr(pDPix),lenght);

			return true;
        }
        public abstract bool TransformPix(ushort x, ushort y);
    }   

    public class MatrixFilter: Filter
    {       
        protected int rangX; // X and Y size of matrix
        protected int rangY;
        protected int [,] matrix; // matrix pointer
    
        // Pixel transformation method
        public override unsafe bool TransformPix(ushort x, ushort y)
        {           
            int x_start=0;
            int dx=rangX/2, dy=rangY/2;
            if (x-dx<0) 
                x_start=dx-x;

            int y_start=0;
            if(y-dy<0) 
                y_start=dy-y;

            int x_finish=rangX;

            if(x+dx>Buffer[SOURCE].Width) 
                x_finish-=(x+dx-Buffer[SOURCE].Width);

            int y_finish=rangY;
            if(y+dy>Buffer[SOURCE].Height) 
                y_finish-=(y+dy-Buffer[SOURCE].Height);

            // Calculating new pixel color values taking into
            // account neighbors falling into the transformation
            // matrix coverage area.
            int [] NewBGR = new int[3];
            int count=0;
            for(int c=0, mx=0, my=0; c<3; c++)
            {
                NewBGR[c]=0; count=0;
                for(my=y_start; my<y_finish; my++)
                    for(mx=x_start; mx<x_finish; mx++)
                    {
                        // Source 
                        byte* pSPix = null;
                        if((pSPix=GetPixelPointer((ushort) (x+(mx-dx)), (ushort) (y+(my-dy)),SOURCE))!=null)
                        {
                            NewBGR[c]+=(matrix[my,mx] * pSPix[c]);
                            count+=matrix[my,mx];
                        }
                
                    }
            }
                 
            // Pixel address in the destination image
            byte *pDPix=GetPixelPointer(x, y, DEST);
                
            // Reducing the value to the allowed range and setting into the destination
            if(pDPix!=null)
                for(int c=0; c<3; c++)
                {
                    if(count!=0)
                        NewBGR[c]=NewBGR[c]/count;
                    if(NewBGR[c]<0)
                        NewBGR[c]=0;
                    else if(NewBGR[c]>255)
                        NewBGR[c]=255;
        
                    pDPix[c] = (byte) NewBGR[c];
                }

            return true;
             
        }
    }

    public class Blur: MatrixFilter
    {       
        public Blur()
        {
            this.rangX = 5;
            this.rangY = 5;
            this.matrix = new int[5,5]{
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1}};
        }
    }

    public class  Contour:MatrixFilter
    {
        public const int CONTOUR_COEFF = 3;
        
        public Contour()
        {
            this.matrix=new int[3,3] {
                {-1*CONTOUR_COEFF,   -1*CONTOUR_COEFF,   -1*CONTOUR_COEFF},
                {-1*CONTOUR_COEFF,   8*CONTOUR_COEFF,    -1*CONTOUR_COEFF},
                {-1*CONTOUR_COEFF,   -1*CONTOUR_COEFF,   -1*CONTOUR_COEFF}};
            this.rangX=3;
            this.rangY=3;
        }
    }

	public class  Sharp : MatrixFilter
	{		
		public const int SHARP_COEFF = 3;

		public Sharp()
		{
			this.rangX=5;
			this.rangY=5;
			this.matrix = new int[5,5]{
				{1,1,1,1,1},
				{1,1,1,1,1},
				{1,1,1,1,1},
				{1,1,1,1,1},
				{1,1,1,1,1}};
		}

		public override unsafe bool TransformPix(ushort x, ushort y)
		{
			// Dithering the pixel
			if(!base.TransformPix(x, y))
				return false;
            
			// Source
			byte *pSPix=GetPixelPointer(x, y, SOURCE);
			// Destination
			byte *pDPix=GetPixelPointer(x, y, DEST);
    
			if( pSPix==null || pDPix==null)   
				return false;

			int d=0;
			for(int c=0; c<3; c++)
			{
				// finding difference
				d=pSPix[c]-pDPix[c];
				// Amplifying the difference
				d*=SHARP_COEFF;
				// Assigning new value to pixel
				if ((int)pDPix[c]+d <0) 
					pDPix[c]=0;
				else if(pDPix[c]+d > 255)   
					pDPix[c]=255;
				else                    
					pDPix[c]+=(byte)d;        
			}
			return true;
		}

	}

	public class DeNoise : MatrixFilter
	{
		private double dK;
		private int WhatToDo;

		public DeNoise(int whatToDo,double dk)
		{
			rangX=5;
			rangY=5;
			
			dK=dk;
			WhatToDo=whatToDo;
		}
		
		public override unsafe bool TransformPix(ushort x, ushort y)
		{
			// Source
			byte *pSPix=GetPixelPointer(x, y, SOURCE);
			// Destination 
			byte *pDPix=GetPixelPointer(x, y, DEST);
    
			if( pSPix==null || pDPix==null)
				return false;

			// Determining the image/transformation matrix
			// overlap area. This is needed to process pixels
			// lying on the image edges.
			int x_start=0;
			int dx=rangX/2, dy=rangY/2;
    
			if(x-dx<0) x_start=dx-x;
    
			int y_start=0;
			if(y-dy<0) y_start=dy-y;

			int x_finish=rangX;
			if(x+dx>Buffer[SOURCE].Width) 
				x_finish-=(x+dx-Buffer[SOURCE].Width);
    
			int y_finish=rangY;
			if(y+dy>Buffer[SOURCE].Height ) 
				y_finish-=(y+dy-Buffer[SOURCE].Height);
    
			// Finding average brightness value
			int mx=0, my=0; 
			int avgY=0, count=0;
    
			for(my=y_start; my<y_finish; my++)
				for(mx=x_start; mx<x_finish; mx++)
				{
					if((pSPix=GetPixelPointer((ushort) (x+(mx-dx)), y+(my-dy), SOURCE))!=null)
					{
						avgY+=Y(pSPix);
						count++;
					}
				}
    
			// Finding the abmodality sum
			int sumVar=0;
			for(my=y_start; my<y_finish; my++)
				for(mx=x_start; mx<x_finish; mx++)
				{
					if((pSPix=GetPixelPointer((ushort) (x+(mx-dx)), y+(my-dy), SOURCE))!=null)
					{
						sumVar+=Math.Abs(avgY-count*Y(pSPix));
					}
				}
    
			// Pixel addres in source image
			pSPix=GetPixelPointer(x, y, SOURCE);
			double Pi= sumVar>0?Math.Abs((double)avgY-count*Y(pSPix))/sumVar:0;
        
			// Pixel addres in destination image
			pDPix=GetPixelPointer(x, y, DEST);
    
			byte NewValue=255;
        
			int [] NewBGR = new int[3];
			int count2=0; 
    
			switch(WhatToDo)
			{
				case 0: // Denoising
					if(Pi> dK/count) // noise
					{
						NewBGR[0]=NewBGR[1]=NewBGR[2]=0;
						count2=0;
						// Finding the sum of "quiet" pixel values
						for(my=y_start; my<y_finish; my++)
							for(mx=x_start; mx<x_finish; mx++)
							{
								if((pSPix=GetPixelPointer((ushort) (x+(mx-dx)), y+(my-dy), SOURCE))!=null &&
									((sumVar>0?Math.Abs((double)avgY-count*Y(pSPix))/sumVar:0)<= dK/count))
								{
									for(int c=0; c<3; c++)  NewBGR[c]+=pSPix[c];
									count2++;
								}
							}

						// Replacing noise with the new value
						pSPix=GetPixelPointer(x, y, SOURCE);
						for(int c=0; c<3; c++)  
							if(count2!=0)
								pDPix[c]=(byte) (NewBGR[c]/count2); // averaged value of "quiet" pixels
							else
								pDPix[c]=pSPix[c];         // no "quiet" pixels found -- taking  initial value
					}
					else // not noise
						// Simply copying pixel value
						for(int c=0; c<3; c++)  pDPix[c]=pSPix[c];
					break;
				case 1:     // Separating noise
					if(Pi> dK*1.0/count) // noise pixel - select
						NewValue=128;
					for(int c=0; c<3; c++)  pDPix[c]=NewValue;
					break;
			}
            
			return true;
    
		}
	}

	public class DotFilter : Filter
	{
		protected byte [,] BGRTransTable = new byte[3,256];

		public override unsafe bool TransformPix(ushort x, ushort y)
		{
			// Source
			byte *pSPix=GetPixelPointer(x, y, SOURCE);
			// Destination
			byte *pDPix=GetPixelPointer(x, y, DEST);
    
			if( pSPix==null || pDPix==null)
				return false;
    
			// Transforming and setting pixel in the source image
			pDPix[0]=BGRTransTable[0,pSPix[0]];
			pDPix[1]=BGRTransTable[1,pSPix[1]];
			pDPix[2]=BGRTransTable[2,pSPix[2]];

			return true;
		}
	}

	public class InvertColors : DotFilter
	{
		public InvertColors()
		{
			for(int i=0, t=0; t<3; t++)
				for(i=0; i<256; i++)		
					this.BGRTransTable[t,i]=(byte)(255-i);				
		}
	}

	public class Histogram : DotFilter
	{
		public bool Init(int offset_b, int offset_t)
		{			
			// Setting to 0 all table elements with indices 
			// from 0 to the lower boundary
			for(int i=0, t=0; t<3; t++)
				for(i=0; i<offset_b; i++)
				{
					this.BGRTransTable[t,i]=0;
				}
			// Setting to 255 all table elements with indices 
			// from 255 to  the upper boundary
			for(int t=0; t<3; t++)
				for(int i=255; i>=256-offset_t; i--)
				{
					BGRTransTable[t,i]=255;
				}
			// Uniformly distributing over the 0 to 255 range all table elements
			// with indices from the lower to the upper boundaries
			double step=256.0/(256-(offset_b+offset_t));
			for(int t=0; t<3; t++)
			{
				double value=.0;
				for(int i=offset_b; i<256-offset_t; i++)
				{
					BGRTransTable[t,i]=(byte) ((value)+0.5);
					value+=step;
				}
			}
			return true;
		}
	}

	public class Emboss : DotFilter
	{
		public const int  STONE_OFFSET_X =  3;
		public const int  STONE_OFFSET_Y = -3;

		public override unsafe bool TransformPix(ushort x, ushort y)
		{
			// Source
			byte *pSPix=GetPixelPointer(x, y, SOURCE);
			// Destination
			byte *pDPix=GetPixelPointer(x, y, DEST);
	
			if(	pSPix==null || pDPix==null)	
				return false;

			int x2=x+STONE_OFFSET_X; if(x2<0) x2=0;
			int y2=y+STONE_OFFSET_Y; if(y2<0) y2=0;

			// Offset pixel
			byte *pSPix2=null;
			if(	(pSPix2=GetPixelPointer((ushort) x2, y2, SOURCE))==null)
				pSPix2=pSPix;
	
			// Brightness calculation	
			byte Y1, Y2;
			Y1=Y(pSPix);
			Y2=Y(pSPix2);
	
			// Finding the difference and moving it into the gray area
			byte d = (byte)((Y1-Y2+255)/2);

			// Pixel gets new values
			pDPix[0]=d;
			pDPix[1]=d;
			pDPix[2]=d;

			return true;
		}
	}

	public class BrightnessAndContrast : DotFilter
	{
		public const int CONTRAST_MEDIAN  = 159;
		public bool Init(int b_offset, int c_offset)
		{
			int i=0,	// transformation table color index
				t=0,	// table index
				t_index=0, // index of the color corresponding to the lower brightness boundary
				b_index=0, // index of the color corresponding to the upper brightness boundary
				value_offset; // color value offset
			double value=.0;  // new color value
			// changing brightness
			for(t=0; t<3; t++)
				for(i=0; i<256; i++)
				{
					if( i+b_offset>255) 
						BGRTransTable[t,i]=255;
					else if( i+b_offset<0) 
						BGRTransTable[t,i]=0;
					else 
						BGRTransTable[t,i]=(byte) (i+b_offset);
				}
			// Changing contrast
			if(c_offset<0)	 // reducing contrast
			{
				for(i=0, t=0; t<3; t++)
					for(i=0; i<256; i++)
						if(BGRTransTable[t,i]<CONTRAST_MEDIAN)
						{
							// Calculating offset depending on the color's distance
							// from the gray median from below
							value_offset=(CONTRAST_MEDIAN-BGRTransTable[t,i])*c_offset/128;
							if(BGRTransTable[t,i]-value_offset>CONTRAST_MEDIAN) BGRTransTable[t,i]=CONTRAST_MEDIAN;
							else BGRTransTable[t,i]=(byte)(BGRTransTable[t,i]-value_offset);
						}
						else
						{
							// Calculating offset depending on the color's distance 
							// from the gray median from above
							value_offset=(BGRTransTable[t,i]-CONTRAST_MEDIAN)*c_offset/128;
							if(BGRTransTable[t,i]+value_offset<CONTRAST_MEDIAN) BGRTransTable[t,i]=CONTRAST_MEDIAN;
							else BGRTransTable[t,i]=(byte)(value_offset+BGRTransTable[t,i]);
						}
			}
			else	if(c_offset>0)
				// Increasing contrast
			{
				// Calculating lower color boundary
				int offset_b=c_offset*CONTRAST_MEDIAN/128;
				// All table values below the lower boundary will be given value 0
				for(t=0; t<3; t++)
					for(b_index=0; b_index<256; b_index++)
					{
						if(BGRTransTable[t,b_index]<offset_b)
							BGRTransTable[t,b_index]=0;
						else break;
					}
				// Calculating upper color boundary
				int offset_t=c_offset*128/CONTRAST_MEDIAN;
				// All table values above the upper boundary will be given value 255
				for(t=0; t<3; t++)
					for(t_index=255; t_index>=0; t_index--)
					{
						if(	BGRTransTable[t,t_index]+offset_t>255)
							BGRTransTable[t,t_index]=255;
						else break;
					}
				// Calculating color intensity change step
				double step=256.0/(256-(offset_b+offset_t));
				// Stretching color intensity between the lower and upper boundaries
				// to cover the entire 0 to 255 range.
				for(t=0; t<3; t++)
				{
					value=.0;
					for(i=b_index; i<=t_index; i++)
					{
						if(BGRTransTable[t,i]>=offset_b || BGRTransTable[t,i]<256-offset_t)
						{
							value=(int)((BGRTransTable[t,i]-offset_b)*step+0.5);	
							if(value>255) value=255;
							BGRTransTable[t,i]=(byte) (value);
						}
					}
				}
			}

			return true;
		}
	
	}
}
