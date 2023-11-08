namespace QuanLyVanBan.Views
{
	partial class DoiMatKhauForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhauForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtOldPassword = new System.Windows.Forms.TextBox();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.txtCheckPassword = new System.Windows.Forms.TextBox();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblError = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(75, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mật khẩu cũ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(75, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mật khẩu mới";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(75, 237);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(139, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Nhập lại mật khẩu mới";
			// 
			// txtOldPassword
			// 
			this.txtOldPassword.Location = new System.Drawing.Point(78, 113);
			this.txtOldPassword.Name = "txtOldPassword";
			this.txtOldPassword.Size = new System.Drawing.Size(260, 22);
			this.txtOldPassword.TabIndex = 3;
			this.txtOldPassword.Enter += new System.EventHandler(this.txtOldPassword_Enter);
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.Location = new System.Drawing.Point(78, 196);
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.Size = new System.Drawing.Size(260, 22);
			this.txtNewPassword.TabIndex = 4;
			this.txtNewPassword.Enter += new System.EventHandler(this.txtNewPassword_Enter);
			// 
			// txtCheckPassword
			// 
			this.txtCheckPassword.Location = new System.Drawing.Point(78, 281);
			this.txtCheckPassword.Name = "txtCheckPassword";
			this.txtCheckPassword.Size = new System.Drawing.Size(260, 22);
			this.txtCheckPassword.TabIndex = 5;
			this.txtCheckPassword.Enter += new System.EventHandler(this.txtCheckPassword_Enter);
			// 
			// btnThoat
			// 
			this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
			this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThoat.Location = new System.Drawing.Point(245, 334);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(93, 38);
			this.btnThoat.TabIndex = 35;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnSave
			// 
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.Location = new System.Drawing.Point(69, 334);
			this.btnSave.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(115, 38);
			this.btnSave.TabIndex = 36;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(159, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 16);
			this.label4.TabIndex = 37;
			this.label4.Text = "*";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(172, 154);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 16);
			this.label5.TabIndex = 38;
			this.label5.Text = "*";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Red;
			this.label6.Location = new System.Drawing.Point(220, 237);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 16);
			this.label6.TabIndex = 39;
			this.label6.Text = "*";
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(75, 28);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(0, 16);
			this.lblError.TabIndex = 40;
			this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DoiMatKhauForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(407, 451);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.txtCheckPassword);
			this.Controls.Add(this.txtNewPassword);
			this.Controls.Add(this.txtOldPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "DoiMatKhauForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đổi mật khẩu";
			this.Load += new System.EventHandler(this.DoiMatKhauForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtOldPassword;
		private System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.TextBox txtCheckPassword;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblError;
	}
}