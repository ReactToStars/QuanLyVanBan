using QuanLyVanBan.Authentications;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class DoiMatKhauForm : Form
	{
		private readonly TaiKhoanRepository _repository = new TaiKhoanRepository();
		private CurrentUser _currentUser;
		public DoiMatKhauForm()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				// Access the custom identity and retrieve the TaiKhoan object
				CustomIdentity customIdentity = (CustomIdentity)customPrincipal.Identity;
				_currentUser = new CurrentUser();
				_currentUser.MaTK = customIdentity.MaTK;
				_currentUser.ChucVu = customIdentity.Role;
				_currentUser.MatKhau = customIdentity.Password;
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void DoiMatKhauForm_Load(object sender, EventArgs e)
		{

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				var oldPassword = txtOldPassword.Text.Trim();
				var newPassword = txtNewPassword.Text.Trim();
				var checkPassword = txtCheckPassword.Text.Trim();
				if(!CheckNullOrWhiteSpace(oldPassword, newPassword, checkPassword) || newPassword.Any(char.IsWhiteSpace))
				{
					throw new Exception("Mật khẩu không chứa dấu cách hay khoảng trắng");
				}

				if (oldPassword != _currentUser.MatKhau)
				{
					throw new Exception("Mật khẩu của bạn không chính xác");
				}

				if (!PasswordValidation(newPassword))
				{
					throw new Exception("Mật khẩu có 8-10 ký tự, 1 hoa, 1 thường và số");
				}

				if(newPassword != checkPassword)
				{
					throw new Exception("Mật khẩu mới không trùng khớp");
				}

				var user = _repository.GetUser(_currentUser.MaTK);
				user.MatKhau = newPassword;

				_repository.Update(user);
				MessageBox.Show("Đổi mật khẩu thành công", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Hide();
			}
			catch (Exception ex)
			{
				lblError.Text = ex.Message;
			}
		}

		private void txtOldPassword_Enter(object sender, EventArgs e)
		{
			txtOldPassword.Text = "";
			txtOldPassword.UseSystemPasswordChar = true;
		}

		private void txtNewPassword_Enter(object sender, EventArgs e)
		{
			txtNewPassword.Text = "";
			txtNewPassword.UseSystemPasswordChar = true;
		}

		private void txtCheckPassword_Enter(object sender, EventArgs e)
		{
			txtCheckPassword.Text = "";
			txtCheckPassword.UseSystemPasswordChar = true;
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

		private bool PasswordValidation(string password)
		{
			string pattern = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,10}$";
			Regex regex = new Regex(pattern);

			if (regex.IsMatch(password))
			{
				return true;
			}
			return false;
		}
	}
}
