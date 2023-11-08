namespace QuanLyVanBan.Views
{
	partial class ThongKeForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeForm));
			this.btnThoat = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnXem = new System.Windows.Forms.Button();
			this.btnXuat = new System.Windows.Forms.Button();
			this.dtTo = new System.Windows.Forms.DateTimePicker();
			this.dtFrom = new System.Windows.Forms.DateTimePicker();
			this.cbBoxDanhMuc = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dtgv = new System.Windows.Forms.DataGridView();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
			this.SuspendLayout();
			// 
			// btnThoat
			// 
			this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
			this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThoat.Location = new System.Drawing.Point(1190, -1);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(86, 39);
			this.btnThoat.TabIndex = 51;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// panel3
			// 
			this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel3.Controls.Add(this.btnXem);
			this.panel3.Controls.Add(this.btnXuat);
			this.panel3.Controls.Add(this.dtTo);
			this.panel3.Controls.Add(this.dtFrom);
			this.panel3.Controls.Add(this.cbBoxDanhMuc);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Location = new System.Drawing.Point(159, 32);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(951, 270);
			this.panel3.TabIndex = 53;
			// 
			// btnXem
			// 
			this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXem.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.Image")));
			this.btnXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXem.Location = new System.Drawing.Point(113, 198);
			this.btnXem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnXem.Name = "btnXem";
			this.btnXem.Size = new System.Drawing.Size(218, 44);
			this.btnXem.TabIndex = 10;
			this.btnXem.Text = "Xem thống kê";
			this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXem.UseVisualStyleBackColor = true;
			this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
			// 
			// btnXuat
			// 
			this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnXuat.Image")));
			this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuat.Location = new System.Drawing.Point(662, 198);
			this.btnXuat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnXuat.Name = "btnXuat";
			this.btnXuat.Size = new System.Drawing.Size(200, 44);
			this.btnXuat.TabIndex = 9;
			this.btnXuat.Text = "Xuất báo cáo";
			this.btnXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXuat.UseVisualStyleBackColor = true;
			this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
			// 
			// dtTo
			// 
			this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtTo.Location = new System.Drawing.Point(662, 108);
			this.dtTo.Name = "dtTo";
			this.dtTo.Size = new System.Drawing.Size(200, 22);
			this.dtTo.TabIndex = 5;
			// 
			// dtFrom
			// 
			this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFrom.Location = new System.Drawing.Point(131, 108);
			this.dtFrom.Name = "dtFrom";
			this.dtFrom.Size = new System.Drawing.Size(200, 22);
			this.dtFrom.TabIndex = 4;
			// 
			// cbBoxDanhMuc
			// 
			this.cbBoxDanhMuc.FormattingEnabled = true;
			this.cbBoxDanhMuc.Location = new System.Drawing.Point(379, 50);
			this.cbBoxDanhMuc.Name = "cbBoxDanhMuc";
			this.cbBoxDanhMuc.Size = new System.Drawing.Size(483, 24);
			this.cbBoxDanhMuc.TabIndex = 3;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(584, 111);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 2;
			this.label11.Text = "Đến ngày";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(61, 111);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 1;
			this.label10.Text = "Từ ngày";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(64, 50);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(209, 16);
			this.label9.TabIndex = 0;
			this.label9.Text = "Chọn danh mục thống kê, báo cáo";
			// 
			// dtgv
			// 
			this.dtgv.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgv.Location = new System.Drawing.Point(12, 332);
			this.dtgv.Name = "dtgv";
			this.dtgv.RowHeadersWidth = 51;
			this.dtgv.RowTemplate.Height = 24;
			this.dtgv.Size = new System.Drawing.Size(1296, 402);
			this.dtgv.TabIndex = 54;
			this.dtgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_CellContentClick);
			// 
			// ThongKeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(1320, 746);
			this.Controls.Add(this.dtgv);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.btnThoat);
			this.Name = "ThongKeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thống kê, báo cáo";
			this.Load += new System.EventHandler(this.ThongKeForm_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnXem;
		private System.Windows.Forms.Button btnXuat;
		private System.Windows.Forms.DateTimePicker dtTo;
		private System.Windows.Forms.DateTimePicker dtFrom;
		private System.Windows.Forms.ComboBox cbBoxDanhMuc;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DataGridView dtgv;
	}
}