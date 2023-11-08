using QuanLyVanBan.Authentications;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class MainForm1 : Form
	{
		private CurrentUser _currentUser;
		public MainForm1()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				// Access the custom identity and retrieve the NguoiDung object
				CustomIdentity customIdentity = (CustomIdentity)customPrincipal.Identity;
				_currentUser = new CurrentUser();
				_currentUser.MaTK = customIdentity.MaTK;
				_currentUser.Ten = customIdentity.Name;
				_currentUser.ChucVu = customIdentity.Role;
				if (currentPrincipal.IsInRole("Cán bộ hành chính"))
				{
					btnThongKe.Enabled = false;
					btnCongVanDen.Enabled = false;
					btnCongVanDi.Enabled = false;
					btnPhongBan.Enabled = false;
					btnNguoiDung.Enabled = false;
					btnSaoLuu.Enabled = false;
				}else if(currentPrincipal.IsInRole("Ban giám hiệu"))
				{
					btnPhongBan.Enabled = false;
					btnCongVanDi.Enabled = false;
					btnYeuCau.Enabled = false;
					btnThongKe.Enabled = false;
					btnSaoLuu.Enabled = false;
				}else if (currentPrincipal.IsInRole("Lãnh đạo phòng"))
				{
					btnYeuCau.Enabled = false;
					btnCongVanDi.Enabled = false;
					btnSaoLuu.Enabled = false;
				}else if(currentPrincipal.IsInRole("Cán bộ văn thư"))
				{
					btnNguoiDung.Enabled = false;
				}
			}
		}

		private void MainForm1_Load(object sender, EventArgs e)
		{
			lblWelcome.Text = "Xin chào, " + _currentUser.Ten;
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
			var loginForm = new LoginForm();
			loginForm.ShowDialog();
		}

		private void btnNguoiDung_Click(object sender, EventArgs e)
		{
			this.Hide();
			var nguoiDungForm = new NguoiDungForm();
			nguoiDungForm.ShowDialog();
		}

		private void btnPhongBan_Click(object sender, EventArgs e)
		{
			this.Hide();
			var phongBanForm = new PhongBanForm();
			phongBanForm.ShowDialog();
		}

		private void btnCongVanDen_Click(object sender, EventArgs e)
		{
			this.Hide();
			var congVanDenForm = new CongVanDenForm();
			congVanDenForm.ShowDialog();
		}

		private void btnCongVanDi_Click(object sender, EventArgs e)
		{
			this.Hide();
			var congVanDiForm = new CongVanDiForm();
			congVanDiForm.ShowDialog();
		}

		private void btnThongKe_Click(object sender, EventArgs e)
		{
			this.Hide();
			var thongKeForm = new ThongKeForm();
			thongKeForm.ShowDialog();
		}

		private void btnYeuCau_Click(object sender, EventArgs e)
		{
			this.Hide();
			var yeuCauGuiForm = new YeuCauGuiVanBanForm();
			yeuCauGuiForm.ShowDialog();
		}

		private void btnTaiKhoan_Click(object sender, EventArgs e)
		{
			this.Hide();
			var taiKhoanForm = new TaiKhoanForm();
			taiKhoanForm.ShowDialog();
		}

		private void btnSaoLuu_Click(object sender, EventArgs e)
		{
			this.Hide();
			var saoLuuForm = new SaoLuuForm();
			saoLuuForm.ShowDialog();
		}
	}
}
