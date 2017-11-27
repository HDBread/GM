using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace BWViewerCSharp
{
	/// <summary>
	/// Represents a view for BMDocument class
	/// </summary>
	public class ChildForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		// document field
		private BMDocument doc = null;
        // required when update percent of current operation
		private string originalText = "";
        // timer
		private Timer timer = new Timer();
        // current bitmap
		private Bitmap drawBitmap = null;
        // scale factor
        private double scaleFactor = 1.0;
    
		private InterpolationMode currentMode = InterpolationMode.HighQualityBicubic;
        // index of the document
        private int docIndex;

		public ChildForm(BMDocument document)
		{						
			InitializeComponent();		
			this.doc = document;
			
			// subscribing to Document events
            this.doc.TransactionBegin+=new EventHandler(doc_TransactionBegin);
			this.doc.TransactionEnd+=new EventHandler(doc_TransactionEnd);
			this.doc.DocumentInvalid+=new EventHandler(doc_DocumentInvalid);

            docIndex = this.doc.ViewCount;
            this.Text = Path.GetFileName(this.doc.FileName)+" : "+this.docIndex.ToString();

			this.timer.Interval = 100; //100ms
			this.timer.Tick+=new EventHandler(timer_Tick);

			//create own buffer image
            this.UpdateBuffer();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // if this is last view of the document
            // ask for save if its have modified status
            if (this.doc.ViewCount == 1 && this.doc.Modified)
            {                
                DialogResult result = MessageBox.Show(String.Format("Save changes in the file \"{0}\"?",System.IO.Path.GetFileName(this.doc.FileName)),
                    "BWViewer",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.Yes)
                {
                    // saves file
                    this.doc.SaveFile();
                }
            }                        
        }        

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.doc.RemoveView(this);
        }

		protected override void OnPaint(PaintEventArgs e)
		{			
			base.OnPaint (e);
			// pait with grey invalid region
			e.Graphics.FillRectangle(Brushes.Gray, e.ClipRectangle);

			// calculating image width			
			int width = (int)(drawBitmap.Width*this.scaleFactor);
			int height = (int)(drawBitmap.Height*this.scaleFactor);
			// set correspondent interpolation nmode
			e.Graphics.InterpolationMode = this.currentMode;
			// draing image
			e.Graphics.DrawImage(drawBitmap,new Rectangle(this.AutoScrollPosition.X,this.AutoScrollPosition.Y,width,height),new Rectangle(Point.Empty,drawBitmap.Size),GraphicsUnit.Pixel);
		}
		
		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			Size bitmapSize = this.doc.CurrentBMSize;
            // set correct scrollbars
			this.AutoScrollMinSize = new Size((int)(bitmapSize.Width*this.scaleFactor),
				(int)(bitmapSize.Height*this.scaleFactor));
			base.OnInvalidated (e);
		}

        /// <summary>
        /// Get document
        /// </summary>
		public BMDocument Document
		{
			get { return doc; }
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // ChildForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(325, 260);
            this.Name = "ChildForm";
            this.Text = "ChildForm";
            this.ResumeLayout(false);

		}

		/// <summary>
		/// Zoom in
		/// </summary>
        public void ZoomIn()
		{
			this.scaleFactor*=2;
			this.Refresh();
		}

		/// <summary>
		/// Zoom out
		/// </summary>
        public void ZoomOut()
		{
			this.scaleFactor/=2;
			this.Refresh();
		}

		/// <summary>
		/// Get current mode
		/// </summary>
        public InterpolationMode CurrentMode
		{
			get { return currentMode; }
		}

		public void StrecthBublic()
		{
			this.currentMode = InterpolationMode.HighQualityBicubic;		
			this.Refresh();			
		}

		public void StrecthNeighbor()
		{
			this.currentMode = InterpolationMode.NearestNeighbor;			
			this.Refresh();
		}

		#endregion

		public void UpdateBuffer()
		{
			this.drawBitmap = new Bitmap(this.doc.CurrentBM);			
		}

        // transaction begin event handler
        private void doc_TransactionBegin(object sender, EventArgs e)
        {
            this.originalText = this.Text;
            // starts timer
            timer.Start();
        }
        // transaction end event handler
        private void doc_TransactionEnd(object sender, EventArgs e)
        {
            // stops timer
            timer.Stop();
            this.Text = this.originalText;
            // updating buffer
            this.UpdateBuffer();
            this.Invalidate();
        }

		private void doc_DocumentInvalid(object sender, EventArgs e)
		{
            this.Text = Path.GetFileName(this.doc.FileName) + " : " + this.docIndex.ToString();
            // updating buffer image
            this.UpdateBuffer();
			this.Invalidate();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			// show current document transaction percent
            this.Text = String.Format("{0} : {1}",this.originalText,doc.ExecutedPercent);				
		}
	}
}
