using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BWViewerCSharp
{
	/// <summary>
	/// Summary description for HistogramDialog.
	/// </summary>
	public class HistogramDialog : Form
	{
		private HistogramControl histPanel;
		private TrackBar offsetBTrackBar;
		private TrackBar offsetTTrackBar;
		private Label offsetBLabel;
		private Label offsetTLabel;
		private Button okButton;
		private Button cancelButton;
        private RadioButton radioButtonRedColor;
        private RadioButton radioButtonGreenColor;
        private RadioButton radioButtonBlueColor;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

		public HistogramDialog()
		{
			InitializeComponent();
			this.histPanel.SetColor(Color.FromArgb(0,50,50));
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.histPanel = new BWViewerCSharp.HistogramControl();
            this.offsetBTrackBar = new System.Windows.Forms.TrackBar();
            this.offsetTTrackBar = new System.Windows.Forms.TrackBar();
            this.offsetBLabel = new System.Windows.Forms.Label();
            this.offsetTLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.radioButtonRedColor = new System.Windows.Forms.RadioButton();
            this.radioButtonGreenColor = new System.Windows.Forms.RadioButton();
            this.radioButtonBlueColor = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.offsetBTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // histPanel
            // 
            this.histPanel.Location = new System.Drawing.Point(16, 8);
            this.histPanel.Name = "histPanel";
            this.histPanel.Size = new System.Drawing.Size(532, 136);
            this.histPanel.TabIndex = 0;
            // 
            // offsetBTrackBar
            // 
            this.offsetBTrackBar.AutoSize = false;
            this.offsetBTrackBar.LargeChange = 10;
            this.offsetBTrackBar.Location = new System.Drawing.Point(2, 152);
            this.offsetBTrackBar.Maximum = 127;
            this.offsetBTrackBar.Name = "offsetBTrackBar";
            this.offsetBTrackBar.Size = new System.Drawing.Size(277, 40);
            this.offsetBTrackBar.TabIndex = 1;
            this.offsetBTrackBar.TickFrequency = 0;
            this.offsetBTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.offsetBTrackBar.Scroll += new System.EventHandler(this.offsetBTrackBar_Scroll);
            // 
            // offsetTTrackBar
            // 
            this.offsetTTrackBar.AutoSize = false;
            this.offsetTTrackBar.LargeChange = 10;
            this.offsetTTrackBar.Location = new System.Drawing.Point(284, 152);
            this.offsetTTrackBar.Maximum = 255;
            this.offsetTTrackBar.Minimum = 128;
            this.offsetTTrackBar.Name = "offsetTTrackBar";
            this.offsetTTrackBar.Size = new System.Drawing.Size(277, 40);
            this.offsetTTrackBar.TabIndex = 2;
            this.offsetTTrackBar.TickFrequency = 0;
            this.offsetTTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.offsetTTrackBar.Value = 255;
            this.offsetTTrackBar.Scroll += new System.EventHandler(this.offsetTTrackBar_Scroll);
            // 
            // offsetBLabel
            // 
            this.offsetBLabel.Location = new System.Drawing.Point(72, 192);
            this.offsetBLabel.Name = "offsetBLabel";
            this.offsetBLabel.Size = new System.Drawing.Size(100, 23);
            this.offsetBLabel.TabIndex = 3;
            this.offsetBLabel.Text = "0";
            this.offsetBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // offsetTLabel
            // 
            this.offsetTLabel.Location = new System.Drawing.Point(384, 192);
            this.offsetTLabel.Name = "offsetTLabel";
            this.offsetTLabel.Size = new System.Drawing.Size(100, 23);
            this.offsetTLabel.TabIndex = 4;
            this.offsetTLabel.Text = "0";
            this.offsetTLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(175, 278);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 24);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(296, 278);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 24);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // radioButtonRedColor
            // 
            this.radioButtonRedColor.Location = new System.Drawing.Point(16, 236);
            this.radioButtonRedColor.Name = "radioButtonRedColor";
            this.radioButtonRedColor.Size = new System.Drawing.Size(45, 17);
            this.radioButtonRedColor.TabIndex = 7;
            this.radioButtonRedColor.TabStop = true;
            this.radioButtonRedColor.Text = "Red";
            this.radioButtonRedColor.UseVisualStyleBackColor = true;
            this.radioButtonRedColor.Click += new System.EventHandler(this.radioButtonRedCollor_Click);
            // 
            // radioButtonGreenColor
            // 
            this.radioButtonGreenColor.AutoSize = true;
            this.radioButtonGreenColor.Location = new System.Drawing.Point(256, 236);
            this.radioButtonGreenColor.Name = "radioButtonGreenColor";
            this.radioButtonGreenColor.Size = new System.Drawing.Size(54, 17);
            this.radioButtonGreenColor.TabIndex = 8;
            this.radioButtonGreenColor.TabStop = true;
            this.radioButtonGreenColor.Text = "Green";
            this.radioButtonGreenColor.UseVisualStyleBackColor = true;
            this.radioButtonGreenColor.Click += new System.EventHandler(this.radioButtonGreenColor_Click);
            // 
            // radioButtonBlueColor
            // 
            this.radioButtonBlueColor.AutoSize = true;
            this.radioButtonBlueColor.Location = new System.Drawing.Point(502, 236);
            this.radioButtonBlueColor.Name = "radioButtonBlueColor";
            this.radioButtonBlueColor.Size = new System.Drawing.Size(46, 17);
            this.radioButtonBlueColor.TabIndex = 9;
            this.radioButtonBlueColor.TabStop = true;
            this.radioButtonBlueColor.Text = "Blue";
            this.radioButtonBlueColor.UseVisualStyleBackColor = true;
            this.radioButtonBlueColor.Click += new System.EventHandler(this.radioButtonBlueColor_Click);
            // 
            // HistogramDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(570, 314);
            this.Controls.Add(this.radioButtonBlueColor);
            this.Controls.Add(this.radioButtonGreenColor);
            this.Controls.Add(this.radioButtonRedColor);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.offsetTLabel);
            this.Controls.Add(this.offsetBLabel);
            this.Controls.Add(this.offsetTTrackBar);
            this.Controls.Add(this.offsetBTrackBar);
            this.Controls.Add(this.histPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistogramDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image histogram";
            ((System.ComponentModel.ISupportInitialize)(this.offsetBTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

	    public int OffsetB
		{
			get
			{
				return this.offsetBTrackBar.Value;
			}
		}

		public int OffsetT
		{
			get
			{
				return this.offsetTTrackBar.Value;
			}
		}

        
        private int _selectColor;

        public int SelectedColor
	    {
	        get { return _selectColor; }
	        set { SelectedColor = value; }
	    }

	    public void SetData(uint [] hist,int range)
		{
			this.histPanel.SetData(hist,range);
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void offsetBTrackBar_Scroll(object sender, System.EventArgs e)
		{
			this.offsetBLabel.Text = this.offsetBTrackBar.Value.ToString();
		}

		private void offsetTTrackBar_Scroll(object sender, System.EventArgs e)
		{
			this.offsetTLabel.Text = (255-this.offsetTTrackBar.Value).ToString();
		}

        private void radioButtonRedCollor_Click(object sender, System.EventArgs e)
        {
            this.okButton.Enabled = true;
            _selectColor = 2;
        }

        private void radioButtonGreenColor_Click(object sender, System.EventArgs e)
        {
            this.okButton.Enabled = true;
            _selectColor = 1;
        }

        private void radioButtonBlueColor_Click(object sender, System.EventArgs e)
        {
            this.okButton.Enabled = true;
            _selectColor = 0;
        }
    }
}
