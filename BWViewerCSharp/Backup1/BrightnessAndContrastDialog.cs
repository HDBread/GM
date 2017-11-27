using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BWViewerCSharp
{
	/// <summary>
	/// Summary description for BrightnessAndContrastDialog.
	/// </summary>
	public class BrightnessAndContrastDialog : Form
	{
		public const int MAX_CORRECTION_OFFSET = 100;
		
		private Label brightnessLabel;
		private Label contrastLabel;
		private TrackBar brightnessTrackBar;
		private TrackBar contrastTrackBar;
		private Button okButton;
		private Button cancelButton;
		private Label brightnessValueLabel;
		private Label contrastValueLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public BrightnessAndContrastDialog()
		{
			InitializeComponent();
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
			this.brightnessLabel = new System.Windows.Forms.Label();
			this.contrastLabel = new System.Windows.Forms.Label();
			this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
			this.contrastTrackBar = new System.Windows.Forms.TrackBar();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.brightnessValueLabel = new System.Windows.Forms.Label();
			this.contrastValueLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// brightnessLabel
			// 
			this.brightnessLabel.Location = new System.Drawing.Point(8, 8);
			this.brightnessLabel.Name = "brightnessLabel";
			this.brightnessLabel.TabIndex = 0;
			this.brightnessLabel.Text = "Brightness";
			// 
			// contrastLabel
			// 
			this.contrastLabel.Location = new System.Drawing.Point(8, 80);
			this.contrastLabel.Name = "contrastLabel";
			this.contrastLabel.TabIndex = 1;
			this.contrastLabel.Text = "Contast";
			// 
			// brightnessTrackBar
			// 
			this.brightnessTrackBar.LargeChange = 20;
			this.brightnessTrackBar.Location = new System.Drawing.Point(8, 32);
			this.brightnessTrackBar.Maximum = 200;
			this.brightnessTrackBar.Name = "brightnessTrackBar";
			this.brightnessTrackBar.Size = new System.Drawing.Size(392, 45);
			this.brightnessTrackBar.TabIndex = 2;
			this.brightnessTrackBar.TickFrequency = 100;
			this.brightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.brightnessTrackBar.Value = 100;
			this.brightnessTrackBar.Scroll += new System.EventHandler(this.brightnessTrackBar_Scroll);
			// 
			// contrastTrackBar
			// 
			this.contrastTrackBar.LargeChange = 20;
			this.contrastTrackBar.Location = new System.Drawing.Point(8, 104);
			this.contrastTrackBar.Maximum = 200;
			this.contrastTrackBar.Name = "contrastTrackBar";
			this.contrastTrackBar.Size = new System.Drawing.Size(392, 45);
			this.contrastTrackBar.TabIndex = 3;
			this.contrastTrackBar.TickFrequency = 100;
			this.contrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.contrastTrackBar.Value = 100;
			this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(101, 168);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(112, 24);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(245, 168);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(112, 24);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// brightnessValueLabel
			// 
			this.brightnessValueLabel.Location = new System.Drawing.Point(408, 40);
			this.brightnessValueLabel.Name = "brightnessValueLabel";
			this.brightnessValueLabel.Size = new System.Drawing.Size(32, 24);
			this.brightnessValueLabel.TabIndex = 6;
			this.brightnessValueLabel.Text = "0";
			this.brightnessValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// contrastValueLabel
			// 
			this.contrastValueLabel.Location = new System.Drawing.Point(408, 120);
			this.contrastValueLabel.Name = "contrastValueLabel";
			this.contrastValueLabel.Size = new System.Drawing.Size(32, 24);
			this.contrastValueLabel.TabIndex = 7;
			this.contrastValueLabel.Text = "0";
			this.contrastValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BrightnessAndContrastDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(458, 208);
			this.Controls.Add(this.contrastValueLabel);
			this.Controls.Add(this.brightnessValueLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.contrastTrackBar);
			this.Controls.Add(this.brightnessTrackBar);
			this.Controls.Add(this.contrastLabel);
			this.Controls.Add(this.brightnessLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BrightnessAndContrastDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Brightness & Contrast";
			((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public int BrightnessOffset
		{
			get
			{
				return (this.brightnessTrackBar.Value- MAX_CORRECTION_OFFSET)*127/MAX_CORRECTION_OFFSET;
			}
		}

		public int ContrastOffset
		{
			get
			{
				return (this.contrastTrackBar.Value- MAX_CORRECTION_OFFSET)*127/MAX_CORRECTION_OFFSET;
			}
		}

		private void contrastTrackBar_Scroll(object sender, EventArgs e)
		{
			this.contrastValueLabel.Text = (this.contrastTrackBar.Value - MAX_CORRECTION_OFFSET).ToString();
		}

		private void brightnessTrackBar_Scroll(object sender, EventArgs e)
		{
			this.brightnessValueLabel.Text = (this.brightnessTrackBar.Value - MAX_CORRECTION_OFFSET).ToString();
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
	}
}
