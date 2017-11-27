using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BWViewerCSharp
{
	public class AboutForm : Form
	{
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Button okButton;
		private Container components = null;

		public AboutForm()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "BWViewer version 3.0";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 32);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Copyright(c) 2005";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 56);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Polyakov Alexey";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(176, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "C# version by Dmitry Rutcovsky";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(240, 16);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 4;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// AboutForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(328, 101);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About BWViewer";
			this.ResumeLayout(false);

		}
		#endregion

		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
