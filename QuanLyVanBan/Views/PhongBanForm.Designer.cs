namespace QuanLyVanBan.Views
{
	partial class PhongBanForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhongBanForm));
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.txtTim = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtMaDV = new System.Windows.Forms.TextBox();
			this.txtTenDV = new System.Windows.Forms.TextBox();
			this.txtMoTa = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.dtgvPhongBan = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnTim = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgvPhongBan)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnXoa
			// 
			this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
			this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXoa.Location = new System.Drawing.Point(34, 139);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(127, 47);
			this.btnXoa.TabIndex = 9;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnSua
			// 
			this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
			this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSua.Location = new System.Drawing.Point(34, 77);
			this.btnSua.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(127, 47);
			this.btnSua.TabIndex = 8;
			this.btnSua.Text = "Sửa";
			this.btnSua.UseVisualStyleBackColor = true;
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(34, 18);
			this.btnThem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(127, 47);
			this.btnThem.TabIndex = 7;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// txtTim
			// 
			this.txtTim.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtTim.Location = new System.Drawing.Point(555, 3);
			this.txtTim.Name = "txtTim";
			this.txtTim.Size = new System.Drawing.Size(296, 22);
			this.txtTim.TabIndex = 20;
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtMaDV);
			this.panel1.Controls.Add(this.txtTenDV);
			this.panel1.Controls.Add(this.txtMoTa);
			this.panel1.Location = new System.Drawing.Point(3, 105);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(478, 208);
			this.panel1.TabIndex = 18;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Red;
			this.label6.Location = new System.Drawing.Point(104, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 16);
			this.label6.TabIndex = 23;
			this.label6.Text = "*";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(99, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 16);
			this.label2.TabIndex = 22;
			this.label2.Text = "*";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "Mã đơn vị";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "Tên đơn vị";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(28, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 16;
			this.label5.Text = "Mô tả";
			// 
			// txtMaDV
			// 
			this.txtMaDV.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtMaDV.Location = new System.Drawing.Point(136, 30);
			this.txtMaDV.Name = "txtMaDV";
			this.txtMaDV.Size = new System.Drawing.Size(305, 22);
			this.txtMaDV.TabIndex = 1;
			// 
			// txtTenDV
			// 
			this.txtTenDV.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtTenDV.Location = new System.Drawing.Point(136, 80);
			this.txtTenDV.Name = "txtTenDV";
			this.txtTenDV.Size = new System.Drawing.Size(305, 22);
			this.txtTenDV.TabIndex = 2;
			// 
			// txtMoTa
			// 
			this.txtMoTa.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtMoTa.Location = new System.Drawing.Point(136, 130);
			this.txtMoTa.Name = "txtMoTa";
			this.txtMoTa.Size = new System.Drawing.Size(305, 22);
			this.txtMoTa.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "Thông tin phòng ban";
			// 
			// btnThoat
			// 
			this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
			this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThoat.Location = new System.Drawing.Point(1126, -3);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(104, 44);
			this.btnThoat.TabIndex = 22;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnReset
			// 
			this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
			this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnReset.Location = new System.Drawing.Point(34, 196);
			this.btnReset.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(127, 47);
			this.btnReset.TabIndex = 23;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// dtgvPhongBan
			// 
			this.dtgvPhongBan.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtgvPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvPhongBan.Location = new System.Drawing.Point(3, 354);
			this.dtgvPhongBan.Name = "dtgvPhongBan";
			this.dtgvPhongBan.RowHeadersWidth = 51;
			this.dtgvPhongBan.RowTemplate.Height = 24;
			this.dtgvPhongBan.Size = new System.Drawing.Size(1255, 382);
			this.dtgvPhongBan.TabIndex = 24;
			this.dtgvPhongBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhongBan_CellClick);
			this.dtgvPhongBan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhongBan_CellDoubleClick);
			// 
			// panel2
			// 
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel2.Controls.Add(this.btnThem);
			this.panel2.Controls.Add(this.btnSua);
			this.panel2.Controls.Add(this.btnReset);
			this.panel2.Controls.Add(this.btnXoa);
			this.panel2.Location = new System.Drawing.Point(1037, 49);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(193, 264);
			this.panel2.TabIndex = 19;
			// 
			// btnTim
			// 
			this.btnTim.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
			this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTim.Location = new System.Drawing.Point(863, -3);
			this.btnTim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnTim.Name = "btnTim";
			this.btnTim.Size = new System.Drawing.Size(133, 34);
			this.btnTim.TabIndex = 25;
			this.btnTim.Text = "Tìm";
			this.btnTim.UseVisualStyleBackColor = true;
			this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
			// 
			// PhongBanForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(1270, 748);
			this.Controls.Add(this.btnTim);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.dtgvPhongBan);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.txtTim);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "PhongBanForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý phòng ban";
			this.Load += new System.EventHandler(this.PhongBanForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgvPhongBan)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.TextBox txtTim;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMaDV;
		private System.Windows.Forms.TextBox txtTenDV;
		private System.Windows.Forms.TextBox txtMoTa;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.DataGridView dtgvPhongBan;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnTim;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
	}
}