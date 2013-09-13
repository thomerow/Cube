namespace Quader
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
         this._btnCalc = new System.Windows.Forms.Button();
         this._txtSolutions = new System.Windows.Forms.TextBox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.lblDesc = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnCalc
         // 
         this._btnCalc.Location = new System.Drawing.Point(643, 405);
         this._btnCalc.Name = "_btnCalc";
         this._btnCalc.Size = new System.Drawing.Size(75, 23);
         this._btnCalc.TabIndex = 0;
         this._btnCalc.Text = "Calculate";
         this._btnCalc.UseVisualStyleBackColor = true;
         this._btnCalc.Click += new System.EventHandler(this.BtnCalc_Click);
         // 
         // _txtSolutions
         // 
         this._txtSolutions.Location = new System.Drawing.Point(218, 12);
         this._txtSolutions.Multiline = true;
         this._txtSolutions.Name = "_txtSolutions";
         this._txtSolutions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this._txtSolutions.Size = new System.Drawing.Size(500, 387);
         this._txtSolutions.TabIndex = 1;
         this._txtSolutions.WordWrap = false;
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::Quader.Properties.Resources.Untitled;
         this.pictureBox1.Location = new System.Drawing.Point(12, 12);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(200, 192);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.pictureBox1.TabIndex = 2;
         this.pictureBox1.TabStop = false;
         // 
         // lblDesc
         // 
         this.lblDesc.AutoSize = true;
         this.lblDesc.Location = new System.Drawing.Point(9, 220);
         this.lblDesc.Name = "lblDesc";
         this.lblDesc.Size = new System.Drawing.Size(153, 117);
         this.lblDesc.TabIndex = 3;
         this.lblDesc.Text = resources.GetString("lblDesc.Text");
         // 
         // frmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(730, 434);
         this.Controls.Add(this.lblDesc);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this._txtSolutions);
         this.Controls.Add(this._btnCalc);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.Name = "frmMain";
         this.Text = "Das \"Bierkastenproblem\"";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnCalc;
		private System.Windows.Forms.TextBox _txtSolutions;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblDesc;
	}
}

