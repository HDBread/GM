using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BWViewerCSharp
{
	public class DeNoiseDialog : Form
	{
		private GroupBox groupBox;
		private Label label;
		private NumericUpDown numericUpDown;
		private Button okButton;
		private Button cancelButton;
		private RadioButton clearRadioButton;
		private RadioButton showRadioButton;
		private Container components = null;

		public DeNoiseDialog()
		{
			InitializeComponent();
		}

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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.label = new System.Windows.Forms.Label();
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.clearRadioButton = new System.Windows.Forms.RadioButton();
			this.showRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox.Controls.Add(this.showRadioButton);
			this.groupBox.Controls.Add(this.clearRadioButton);
			this.groupBox.Location = new System.Drawing.Point(8, 12);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(264, 64);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "What to do with Noise";
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(24, 92);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(112, 20);
			this.label.TabIndex = 1;
			this.label.Text = "Threshold coefficient";
			// 
			// numericUpDown
			// 
			this.numericUpDown.DecimalPlaces = 1;
			this.numericUpDown.Increment = new System.Decimal(new int[] {
																			2,
																			0,
																			0,
																			65536});
			this.numericUpDown.Location = new System.Drawing.Point(152, 92);
			this.numericUpDown.Maximum = new System.Decimal(new int[] {
																		  10,
																		  0,
																		  0,
																		  0});
			this.numericUpDown.Name = "numericUpDown";
			this.numericUpDown.Size = new System.Drawing.Size(112, 20);
			this.numericUpDown.TabIndex = 2;
			this.numericUpDown.Value = new System.Decimal(new int[] {
																		2,
																		0,
																		0,
																		0});
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(48, 124);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(160, 124);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// clearRadioButton
			// 
			this.clearRadioButton.Checked = true;
			this.clearRadioButton.Location = new System.Drawing.Point(24, 24);
			this.clearRadioButton.Name = "clearRadioButton";
			this.clearRadioButton.TabIndex = 0;
			this.clearRadioButton.TabStop = true;
			this.clearRadioButton.Text = "Clear";
			// 
			// showRadioButton
			// 
			this.showRadioButton.Location = new System.Drawing.Point(136, 24);
			this.showRadioButton.Name = "showRadioButton";
			this.showRadioButton.TabIndex = 1;
			this.showRadioButton.Text = "Show";
			// 
			// DeNoiseDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(280, 159);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.numericUpDown);
			this.Controls.Add(this.label);
			this.Controls.Add(this.groupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeNoiseDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DeNoise";
			this.groupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public int WhatToDo
		{
			get
			{
				if( this.clearRadioButton.Checked)
					return 0;
				else 
					return 1;
			}
			set
			{
				this.clearRadioButton.Checked = (value == 0);
			}
		}

		public double DK
		{
			get
			{
				return (double)this.numericUpDown.Value;
			}
			set
			{
				this.numericUpDown.Value = (decimal) value;
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
