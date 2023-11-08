namespace QuanLyVanBan.Views
{
	partial class LoginForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTenTK = new System.Windows.Forms.TextBox();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.ckBoxLuuMK = new System.Windows.Forms.CheckBox();
			this.btnDangNhap = new System.Windows.Forms.Button();
			this.btnThoat = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.taiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(239, 350);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên tài khoản";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(266, 394);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mật khẩu";
			// 
			// txtTenTK
			// 
			this.txtTenTK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtTenTK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTenTK.Location = new System.Drawing.Point(351, 350);
			this.txtTenTK.Name = "txtTenTK";
			this.txtTenTK.Size = new System.Drawing.Size(268, 22);
			this.txtTenTK.TabIndex = 2;
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMatKhau.Location = new System.Drawing.Point(351, 394);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new System.Drawing.Size(268, 22);
			this.txtMatKhau.TabIndex = 3;
			this.txtMatKhau.Enter += new System.EventHandler(this.txtMatKhau_Enter);
			this.txtMatKhau.Leave += new System.EventHandler(this.txtMatKhau_Leave);
			// 
			// ckBoxLuuMK
			// 
			this.ckBoxLuuMK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ckBoxLuuMK.AutoSize = true;
			this.ckBoxLuuMK.Location = new System.Drawing.Point(398, 435);
			this.ckBoxLuuMK.Name = "ckBoxLuuMK";
			this.ckBoxLuuMK.Size = new System.Drawing.Size(107, 20);
			this.ckBoxLuuMK.TabIndex = 4;
			this.ckBoxLuuMK.Text = "Lưu mật khẩu";
			this.ckBoxLuuMK.UseVisualStyleBackColor = true;
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDangNhap.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDangNhap.Location = new System.Drawing.Point(364, 475);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(103, 30);
			this.btnDangNhap.TabIndex = 5;
			this.btnDangNhap.Text = "Đăng nhập";
			this.btnDangNhap.UseVisualStyleBackColor = false;
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			// 
			// btnThoat
			// 
			this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnThoat.Location = new System.Drawing.Point(511, 475);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(75, 30);
			this.btnThoat.TabIndex = 6;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = false;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Firebrick;
			this.label3.Location = new System.Drawing.Point(181, 291);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(539, 39);
			this.label3.TabIndex = 7;
			this.label3.Text = "HỆ THỐNG QUẢN LÝ VĂN BẢN";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(321, 41);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(220, 190);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// taiKhoanBindingSource
			// 
			this.taiKhoanBindingSource.DataSource = typeof(QuanLyVanBan.Models.TaiKhoan);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(898, 583);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnDangNhap);
			this.Controls.Add(this.ckBoxLuuMK);
			this.Controls.Add(this.txtMatKhau);
			this.Controls.Add(this.txtTenTK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đăng nhập";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.BindingSource taiKhoanBindingSource;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTenTK;
		private System.Windows.Forms.TextBox txtMatKhau;
		private System.Windows.Forms.CheckBox ckBoxLuuMK;
		private System.Windows.Forms.Button btnDangNhap;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

