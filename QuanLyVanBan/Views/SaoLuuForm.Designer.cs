namespace QuanLyVanBan.Views
{
	partial class SaoLuuForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaoLuuForm));
			this.dtgv = new System.Windows.Forms.DataGridView();
			this.btnThoat = new System.Windows.Forms.Button();
			this.cbxDanhMuc = new System.Windows.Forms.ComboBox();
			this.btnNhap = new System.Windows.Forms.Button();
			this.btnXuat = new System.Windows.Forms.Button();
			this.txtChon = new System.Windows.Forms.TextBox();
			this.btnChon = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnReset = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtgv
			// 
			this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgv.Location = new System.Drawing.Point(1, 208);
			this.dtgv.Name = "dtgv";
			this.dtgv.RowHeadersWidth = 51;
			this.dtgv.RowTemplate.Height = 24;
			this.dtgv.Size = new System.Drawing.Size(1290, 523);
			this.dtgv.TabIndex = 0;
			// 
			// btnThoat
			// 
			this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
			this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThoat.Location = new System.Drawing.Point(1159, 0);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(93, 38);
			this.btnThoat.TabIndex = 29;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// cbxDanhMuc
			// 
			this.cbxDanhMuc.FormattingEnabled = true;
			this.cbxDanhMuc.Location = new System.Drawing.Point(84, 74);
			this.cbxDanhMuc.Name = "cbxDanhMuc";
			this.cbxDanhMuc.Size = new System.Drawing.Size(365, 24);
			this.cbxDanhMuc.TabIndex = 14;
			this.cbxDanhMuc.SelectedValueChanged += new System.EventHandler(this.cbxDanhMuc_SelectedValueChanged);
			// 
			// btnNhap
			// 
			this.btnNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnNhap.Image")));
			this.btnNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNhap.Location = new System.Drawing.Point(497, 23);
			this.btnNhap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnNhap.Name = "btnNhap";
			this.btnNhap.Size = new System.Drawing.Size(145, 37);
			this.btnNhap.TabIndex = 13;
			this.btnNhap.Text = "Nhập";
			this.btnNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNhap.UseVisualStyleBackColor = true;
			this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
			// 
			// btnXuat
			// 
			this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnXuat.Image")));
			this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuat.Location = new System.Drawing.Point(497, 66);
			this.btnXuat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnXuat.Name = "btnXuat";
			this.btnXuat.Size = new System.Drawing.Size(145, 36);
			this.btnXuat.TabIndex = 15;
			this.btnXuat.Text = "Xuất";
			this.btnXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXuat.UseVisualStyleBackColor = true;
			this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
			// 
			// txtChon
			// 
			this.txtChon.Location = new System.Drawing.Point(84, 33);
			this.txtChon.Name = "txtChon";
			this.txtChon.Size = new System.Drawing.Size(247, 22);
			this.txtChon.TabIndex = 30;
			// 
			// btnChon
			// 
			this.btnChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnChon.Location = new System.Drawing.Point(338, 23);
			this.btnChon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnChon.Name = "btnChon";
			this.btnChon.Size = new System.Drawing.Size(111, 32);
			this.btnChon.TabIndex = 31;
			this.btnChon.Text = "Chọn";
			this.btnChon.UseVisualStyleBackColor = true;
			this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel1.Controls.Add(this.btnReset);
			this.panel1.Controls.Add(this.btnChon);
			this.panel1.Controls.Add(this.cbxDanhMuc);
			this.panel1.Controls.Add(this.txtChon);
			this.panel1.Controls.Add(this.btnNhap);
			this.panel1.Controls.Add(this.btnXuat);
			this.panel1.Location = new System.Drawing.Point(243, 36);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(796, 122);
			this.panel1.TabIndex = 32;
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
			this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnReset.Location = new System.Drawing.Point(666, 23);
			this.btnReset.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(115, 32);
			this.btnReset.TabIndex = 32;
			this.btnReset.Text = "Làm mới";
			this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// SaoLuuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(1296, 743);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.dtgv);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "SaoLuuForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SaoLuuForm";
			this.Load += new System.EventHandler(this.SaoLuuForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtgv;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.ComboBox cbxDanhMuc;
		private System.Windows.Forms.Button btnNhap;
		private System.Windows.Forms.Button btnXuat;
		private System.Windows.Forms.TextBox txtChon;
		private System.Windows.Forms.Button btnChon;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnReset;
	}
}