using QuanLyVanBan.Authentications;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class TaiKhoanForm : Form
	{
		private CurrentUser _currentUser;
		private readonly TaiKhoanRepository _repository = new TaiKhoanRepository();
		public TaiKhoanForm()
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
				_currentUser.ChucVu = customIdentity.Role;
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			try
			{
				var user = _repository.GetUser(_currentUser.MaTK);
				if (!CheckNullOrWhiteSpace(txtTen.Text))
				{
					throw new Exception("Thông tin tài khoản không hợp lệ! Vui lòng điền đầy đủ thông tin");
				}

				if (!CheckNullOrWhiteSpace(txtDienThoai.Text) || !CheckPhoneNumber(txtDienThoai.Text))
				{
					throw new Exception("Số điện thoại không hợp lệ");
				}

				if (!CheckBirthDay(dtNgaySinh.Value))
				{
					throw new Exception("Năm sinh không hợp lệ");
				}

				user.Ten = txtTen.Text;
				user.NgaySinh = dtNgaySinh.Value;
				user.DienThoai = txtDienThoai.Text;

				_repository.Update(user);
				MessageBox.Show("Lưu thành công", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
				HienThi();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm1();
			mainForm.ShowDialog();
		}

		private void btnDoiMatKhau_Click(object sender, EventArgs e)
		{
			var doiMatKhauForm = new DoiMatKhauForm();
			doiMatKhauForm.ShowDialog();
		}

		private void TaiKhoanForm_Load(object sender, EventArgs e)
		{
			HienThi();
		}

		private void HienThi()
		{
			var user = _repository.Get(_currentUser.MaTK);
			txtTenTK.Text = user.TenTK;
			txtTen.Text = user.Ten;
			dtNgaySinh.Value = user.NgaySinh;
			txtChucVu.Text = user.ChucVu;
			txtDienThoai.Text = user.DienThoai;
			txtDonVi.Text = user.TenDV;
			dtNgayTao.Value = user.NgayTao;
			txtNguoiTao.Text = user.NguoiTao;

			txtTenTK.Enabled = false;
			txtChucVu.Enabled = false;
			txtDonVi.Enabled = false;
			dtNgayTao.Enabled = false;
			txtNguoiTao.Enabled = false;
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

		private bool CheckPhoneNumber(string phoneNumber)
		{
			string pattern = @"^(\+\d{1,4}-?)?(\d{9,11}|\d{3}-\d{3}-\d{4})$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(phoneNumber);
		}

		private bool CheckBirthDay(DateTime birthday)
		{
			// Define two DateTime objects

			// Calculate the difference in years
			TimeSpan difference = DateTime.Now.Subtract(birthday);
			int yearsDifference = (int)(difference.TotalDays / 365);

			return yearsDifference >= 18;
		}

	}
}
