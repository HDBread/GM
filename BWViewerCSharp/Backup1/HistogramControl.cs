using System.Drawing;
using System.Windows.Forms;

namespace BWViewerCSharp
{
	public class HistogramControl : Panel
	{
		private int Range = 0;
		private uint[] Hist;

		private Color foreColor;

		public HistogramControl()
		{
			foreColor = Color.Black;
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion

		public void SetData(uint[] hist,int range)
		{
			this.Hist = hist;
			this.Range = range;
		}

		public void SetColor(Color foreColor)
		{
			this.foreColor = foreColor;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			
			if (this.Hist == null || this.Range == 0)
				return;

			// Finding the average value
			uint MaxBright=0, SumBright=0;
			for(int i=0; i<Range; i++)
				SumBright+=Hist[i];
	
			// Let the maximum (shown in the picture) value
			// be three times the average
			MaxBright=(uint) (3*SumBright/Range);
			if(MaxBright==0) 
				return;
	
			using(Pen histPen = new Pen(this.foreColor,2))
			{
				Rectangle rect = this.ClientRectangle;
				
				double kx=((double)rect.Width)/Range;
				double ky=((double)rect.Height)/MaxBright;
	
				e.Graphics.DrawRectangle(histPen,rect);

				int x=0, y=0,y2=0;
				for(int i=0; i<Range; i++)
				{					
					x = (int) (rect.Left+(kx*i));
					y=rect.Bottom;
					
					y2=(int) (rect.Bottom -(ky*Hist[i]));
					if(y2<rect.Top) y=rect.Top;
					
					e.Graphics.DrawLine(histPen,x,y,x,y2);					
				}			
			}
		}

	}
}
