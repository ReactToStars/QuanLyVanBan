using OfficeOpenXml;
using QuanLyVanBan.Authentications;
using QuanLyVanBan.Commons;
using QuanLyVanBan.DTOs;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class NguoiDungForm : Form
	{
		private readonly TaiKhoanRepository _repository = new TaiKhoanRepository();
		private readonly PhongBanRepository _phongBanRepository = new PhongBanRepository();
		private CurrentUser _currentUser;

		public NguoiDungForm()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				if (!currentPrincipal.IsInRole("Cán bộ quản trị"))
				{
					btnThem.Enabled = false;
					btnSua.Enabled = false;
					btnXoa.Enabled = false;
				}

				// Access the custom identity and retrieve the NguoiDung object
				CustomIdentity customIdentity = (CustomIdentity)customPrincipal.Identity;
				_currentUser = new CurrentUser();
				_currentUser.MaTK = customIdentity.MaTK;
				_currentUser.ChucVu = customIdentity.Role;
			}

		}

		private void NguoiDungForm_Load(object sender, EventArgs e)
		{
			HienThi();
			LoadComboBox();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!CheckNullOrWhiteSpace(txtMaTK.Text, txtTenTK.Text, txtTen.Text))
				{
					throw new Exception("Thông tin tài khoản không hợp lệ! Vui lòng điền đầy đủ thông tin");
				}

				if (!CheckBirthDay(dtNgaySinh.Value))
				{
					throw new Exception("Năm sinh không hợp lệ");
				}

				if (!CheckNullOrWhiteSpace(txtDienThoai.Text) || !CheckPhoneNumber(txtDienThoai.Text))
				{
					throw new Exception("Số điện thoại không hợp lệ");
				}

				var existUser = _repository.Get(txtMaTK.Text);

				if(existUser != null)
				{
					throw new Exception("Người dùng này đã tồn tại");
				}

				var nguoiDung = new TaiKhoan()
				{
					MaTK = txtMaTK.Text.Trim(),
					TenTK = txtTenTK.Text.Trim(),
					Ten = txtTen.Text.Trim(),
					MatKhau = "Password1",
					NgaySinh = dtNgaySinh.Value,
					ChucVu = cbBoxChucVu.SelectedValue.ToString(),
					DienThoai = txtDienThoai.Text.Trim(),
					MaDV = cbBoxDonVi.SelectedValue.ToString(),
					NgayTao = DateTime.Now,
					NguoiTao = _repository.GetUser(_currentUser.MaTK).Ten
				};

				_repository.Add(nguoiDung);
				MessageBox.Show("Thêm thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				HienThi();
				Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			try
			{
				if (!CheckNullOrWhiteSpace(txtMaTK.Text, txtTenTK.Text, txtTen.Text))
				{
					throw new Exception("Thông tin tài khoản không hợp lệ! Vui lòng điền đầy đủ thông tin");
				}

				if (!CheckBirthDay(dtNgaySinh.Value))
				{
					throw new Exception("Năm sinh không hợp lệ");
				}

				if (!CheckNullOrWhiteSpace(txtDienThoai.Text) || !CheckPhoneNumber(txtDienThoai.Text))
				{
					throw new Exception("Số điện thoại không hợp lệ");
				}

				var existUser = _repository.GetUser(txtMaTK.Text);

				if (existUser == null)
				{
					throw new Exception("Người dùng này không tồn tại");
				}

				if (existUser.ChucVu == "Cán bộ quản trị" && existUser.MaTK != _currentUser.MaTK)
				{
					throw new Exception("Đây là cán bộ quản trị, bạn không được phép thay đổi thông tin");
				}

				existUser.TenTK = txtTenTK.Text.Trim();
				existUser.Ten = txtTen.Text.Trim();
				existUser.NgaySinh = dtNgaySinh.Value;
				existUser.ChucVu = cbBoxChucVu.SelectedValue.ToString();
				existUser.DienThoai = txtDienThoai.Text.Trim();
				existUser.MaDV = cbBoxDonVi.SelectedValue.ToString();

				_repository.Update(existUser);
				MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				HienThi();
				Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				if (CheckNullOrWhiteSpace(txtMaTK.Text))
				{
					var maTK = txtMaTK.Text;
					var existUser = _repository.GetUser(maTK);
					if (existUser == null)
					{
						throw new Exception("Người dùng này không tồn tại");
					}

					if (existUser.ChucVu == "Cán bộ quản trị")
					{
						throw new Exception("Đây là cán bộ quản trị, bạn không được phép xóa");
					}

					DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (result == DialogResult.Yes)
					{
						_repository.Delete(maTK);
						MessageBox.Show("Xóa thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						HienThi();
						Clear();
					}
				}
				else if (CheckNullOrWhiteSpace(txtTenTK.Text))
				{
					var tenTK = txtTenTK.Text;
					var existUser = _repository.GetUser(tenTK);
					if (existUser == null)
					{
						throw new Exception("Người dùng này không tồn tại");
					}
					if (existUser.ChucVu == "Cán bộ quản trị")
					{
						throw new Exception("Đây là cán bộ quản trị, bạn không được phép xóa");
					}

					DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (result == DialogResult.Yes)
					{
						_repository.Delete(tenTK);
						MessageBox.Show("Xóa thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						HienThi();
						Clear();
					}
				}
				else
				{
					throw new Exception("Thông tin không hợp lệ");
				}
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

		private void btnReset_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void dtgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				var selectedRow = e.RowIndex;
				txtMaTK.Enabled = false;

				txtMaTK.Text = dtgv.Rows[selectedRow].Cells[0].Value.ToString();
				txtTenTK.Text = dtgv.Rows[selectedRow].Cells[1].Value.ToString();
				txtTen.Text = dtgv.Rows[selectedRow].Cells[2].Value.ToString();
				dtNgaySinh.Value = (DateTime)dtgv.Rows[selectedRow].Cells[3].Value;
				var chucVu = dtgv.Rows[selectedRow].Cells[4].Value.ToString();
				cbBoxChucVu.SelectedIndex = Constant.ChucVu.IndexOf(chucVu);
				txtDienThoai.Text = dtgv.Rows[selectedRow].Cells[5].Value.ToString();
				var tenDV = dtgv.Rows[selectedRow].Cells[6].Value.ToString();
				var phongBans = _phongBanRepository.GetAll().Select(x => x.TenDV).ToList();
				cbBoxDonVi.SelectedIndex = phongBans.IndexOf(tenDV);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				var filter = txtTim.Text.Trim();
				if (!CheckNullOrWhiteSpace(filter))
				{
					throw new Exception("Dữ liệu bạn nhập không hợp lệ");
				}

				dtgv.DataSource = _repository.Find(filter);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbxFilter.SelectedValue.ToString().Equals("Tất cả"))
				{
					HienThi();
					return;
				}
				var filter = cbxFilter.SelectedValue.ToString();
				
				dtgv.DataSource = _repository.Find(filter);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void HienThi()
		{
			dtgv.DataSource = _repository.GetAll() ?? new List<TaiKhoanDto>();

			int i = 0;
			foreach (var header in Constant.NguoiDungHeaders)
			{
				dtgv.Columns[i].HeaderText = header;
				dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				i++;
			}
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

		private void Clear()
		{
			txtMaTK.Enabled = true;

			txtMaTK.Text = string.Empty;
			txtTenTK.Text = string.Empty;
			txtTen.Text = string.Empty;
			dtNgaySinh.Value = DateTime.Now;
			cbBoxChucVu.SelectedIndex = 0;
			txtDienThoai.Text = "";
			cbBoxDonVi.SelectedIndex = 0;
			cbxFilter.SelectedIndex = 0;
			txtTim.Text = string.Empty;
			HienThi();
		}

		private void LoadComboBox()
		{
			cbBoxChucVu.DataSource = Constant.ChucVu;

			var donViDataSource = new Dictionary<string, string>();
			var donViDataSourceFilter = new Dictionary<string, string>()
			{
				{"Tất cả", "Tất cả"}
			};
			var phongBans = _phongBanRepository.GetAll().ToList();
			foreach (var phongBan in phongBans)
			{
				donViDataSource.Add(phongBan.MaDV, phongBan.TenDV);
				donViDataSourceFilter.Add(phongBan.MaDV, phongBan.TenDV);
			}

			cbBoxDonVi.DataSource = new BindingSource(donViDataSource, null);
			cbBoxDonVi.DisplayMember = "Value";
			cbBoxDonVi.ValueMember = "Key";

			cbxFilter.DataSource = new BindingSource(donViDataSourceFilter, null);
			cbxFilter.DisplayMember = "Value";
			cbxFilter.ValueMember = "Key";
		}

		public void BackUp()
		{
			try
			{
				var data = _repository.GetData().ToList();
				if (data == null || data.Count() == 0)
				{
					throw new Exception("Không có dữ liệu");
				}

				// Create a new Excel package
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
				using (var package = new ExcelPackage())
				{
					// Add a new worksheet to the Excel package
					var worksheet = package.Workbook.Worksheets.Add("Sheet1");

					string[] headers = new string[] { "Mã tài khoản", "Tên tài khoản", "Mật khẩu", "Quyền", "Ngày tạo", "Đơn vị" };
					// Add data to the worksheet
					int i = 1;
					foreach (var header in headers)
					{
						worksheet.Cells[1, i].Value = header;
						i++;
					}
					worksheet = LoadData(worksheet, data);
					worksheet = ConfigHeaderAndColumnDataType(worksheet);

					var saveFileDialog = new SaveFileDialog();
					saveFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
					saveFileDialog.FilterIndex = 2;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						package.SaveAs(saveFileDialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private ExcelWorksheet ConfigHeaderAndColumnDataType(ExcelWorksheet worksheet)
		{
			var headerConfig = worksheet.Cells["A1:R1"];
			headerConfig.Style.Font.Bold = true;

			var ngayVBdenColumn = worksheet.Cells[2, 5, worksheet.Dimension.End.Row, 5];
			ngayVBdenColumn.Style.Numberformat.Format = "dd-mm-yyyy";

			return worksheet;
		}

		private ExcelWorksheet LoadData(ExcelWorksheet worksheet, List<TaiKhoan> data)
		{
			for (int j = 0; j < data.Count(); ++j)
			{
				worksheet.Cells[j + 2, 1].Value = data[j].MaTK;
				worksheet.Cells[j + 2, 2].Value = data[j].TenTK;
				worksheet.Cells[j + 2, 3].Value = data[j].MatKhau;
				worksheet.Cells[j + 2, 5].Value = data[j].NgayTao;
				worksheet.Cells[j + 2, 6].Value = data[j].MaDV;
			}
			return worksheet;
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
