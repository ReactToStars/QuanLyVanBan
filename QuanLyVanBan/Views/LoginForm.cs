using QuanLyVanBan.Authentications;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class LoginForm : Form
	{
		private readonly TaiKhoanRepository _repository = new TaiKhoanRepository();
		public LoginForm()
		{
			InitializeComponent();
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			// Retrieve the current principal from the current thread
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;

			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				// Access the custom identity and retrieve the TaiKhoan object
				CustomIdentity customIdentity = (CustomIdentity)customPrincipal.Identity;
				if (customIdentity.IsSavedPassword)
				{
					txtTenTK.Text = customIdentity.TenTK;
					txtMatKhau.Text = customIdentity.Password;
					txtMatKhau.UseSystemPasswordChar = true;
					ckBoxLuuMK.Checked = customIdentity.IsSavedPassword;
				}
			}
		}

		private void btnThoat_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void btnDangNhap_Click(object sender, System.EventArgs e)
		{
			try
			{
				var tenTK = txtTenTK.Text;
				var matKhau = txtMatKhau.Text;
				if (!CheckNullOrWhiteSpace(tenTK, matKhau))
				{
					throw new Exception("Tài khoản hoặc mật khẩu bạn vừa nhập không hợp lệ");
				}

				var taiKhoan = _repository.GetUser(tenTK);

				if (taiKhoan == null)
				{
					throw new Exception("Tài khoản bạn vừa nhập không tồn tại");
				}

				if (matKhau != taiKhoan.MatKhau)
				{
					throw new Exception("Mật khẩu không chính xác");
				}

				var currentUser = new CurrentUser()
				{
					MaTK = taiKhoan.MaTK,
					TenTK = taiKhoan.TenTK,
					Ten = taiKhoan.Ten,
					MatKhau = taiKhoan.MatKhau,
					ChucVu = taiKhoan.ChucVu,
					IsSavedPassword = ckBoxLuuMK.Checked
				};


				// Create a custom identity using your current user instance
				var customIdentity = new CustomIdentity(currentUser);

				// Create a custom principal using the custom identity
				var customPrincipal = new CustomPrincipal(customIdentity);

				// Set the custom principal for the current thread
				Thread.CurrentPrincipal = customPrincipal;

				this.Hide();
				var mainForm = new MainForm1();
				mainForm.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void txtMatKhau_Enter(object sender, EventArgs e)
		{
			txtMatKhau.Text = "";

			txtMatKhau.UseSystemPasswordChar = true;
		}

		private void txtMatKhau_Leave(object sender, EventArgs e)
		{

		}

		private bool CheckNullOrWhiteSpace(params string[] value)
		{
			foreach (var item in value)
			{
				if (string.IsNullOrWhiteSpace(item))
				{
					return false;
				}
			}

			return true;
		}

	}
}
