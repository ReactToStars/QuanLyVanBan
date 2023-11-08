using QuanLyVanBan.Authentications;
using QuanLyVanBan.Commons;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class CongVanDiForm : Form
	{
		private readonly QuanLyVanBanDiRepository _repository = new QuanLyVanBanDiRepository();
		private readonly PhongBanRepository _phongBanRepository = new PhongBanRepository();
		private readonly TaiKhoanRepository _nguoiDungRepository = new TaiKhoanRepository();
		private readonly YeuCauGuiVanBanDiRepository _yeuCauRepository = new YeuCauGuiVanBanDiRepository();

		public CongVanDiForm()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				if (!customPrincipal.IsInRole("Cán bộ quản trị", "Cán bộ văn thư"))
				{
					btnThem.Enabled = false;
					btnSua.Enabled = false;
					btnXoa.Enabled = false;
				}
			}
		}

		private void CongVanDiForm_Load(object sender, EventArgs e)
		{
			LoadComboBox();
			HienThi();
		}

		private void dtgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			foreach (DataGridViewRow row in dtgv.Rows)
			{
				if (dtgv.Columns[10].HeaderText == "Trạng thái văn bản" && row.Cells[10].Value.ToString() == "Đang xử lý")
				{
					row.DefaultCellStyle.ForeColor = Color.Red;
				}
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!CheckNullOrWhiteSpace(txtSoVBDi.Text, txtNoiNhan.Text, txtTrichYeu.Text, txtSoBan.Text, txtTepDinhKem.Text, cbBoxDonVi.Text, cbBoxNguoiKy.Text))
				{
					throw new Exception("Thông tin công văn không hợp lệ");
				}

				if (!int.TryParse(txtSoBan.Text, out var soBan) || soBan < 1)
				{
					throw new Exception("Số bản đóng dấu phải là số nguyên dương lớn hơn 1");
				}

				var exist = _repository.Get(txtSoVBDi.Text, cbxSoPG.SelectedValue.ToString(), txtNoiNhan.Text);
				if (exist != null)
				{
					throw new Exception("Công văn này đã tồn tại");
				}

				var congVanDi = new QuanLyVanBanDi()
				{
					SoVBdi = txtSoVBDi.Text.Trim(),
					SoPG = cbxSoPG.SelectedValue.ToString(),
					NoiNhan = txtNoiNhan.Text.Trim(),
					NgayVBdi = dtNgay.Value,
					MaDV = cbBoxDonVi.SelectedValue.ToString(),
					DoMat = cbBoxDoMat.Text,
					NDtrichyeu = txtTrichYeu.Text.Trim(),
					NguoiKy = cbBoxNguoiKy.Text.Trim(),
					SoBanDongDau = int.Parse(txtSoBan.Text),
					TepDinhKem = txtTepDinhKem.Text.Trim(),
					TrangThaiVB = cbxTrangThai.SelectedValue.ToString(),
					GhiChu = txtGhiChu.Text.Trim()
				};

				congVanDi.TepDinhKem = SaveAttached(txtTepDinhKem.Text);
				_repository.Add(congVanDi);
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
				if (!CheckNullOrWhiteSpace(txtSoVBDi.Text, txtNoiNhan.Text, txtTrichYeu.Text, txtSoBan.Text, txtTepDinhKem.Text, cbBoxDonVi.Text, cbBoxNguoiKy.Text))
				{
					throw new Exception("Thông tin công văn không hợp lệ");
				}

				if (!int.TryParse(txtSoBan.Text, out var soBan) || soBan < 1)
				{
					throw new Exception("Số bản đóng dấu phải là số nguyên dương lớn hơn 1");
				}

				var exist = _repository.Get(txtSoVBDi.Text, cbxSoPG.SelectedValue.ToString(), txtNoiNhan.Text);

				if (exist == null)
				{
					throw new Exception("Công văn này không tồn tại");
				}

				exist.NgayVBdi = dtNgay.Value;
				exist.MaDV = cbBoxDonVi.SelectedValue.ToString();
				exist.DoMat = cbBoxDoMat.Text;
				exist.NDtrichyeu = txtTrichYeu.Text.Trim();
				exist.NguoiKy = cbBoxNguoiKy.Text.Trim();
				exist.SoBanDongDau = soBan;
				exist.TepDinhKem = txtTepDinhKem.Text.Trim();
				exist.TrangThaiVB = cbxTrangThai.SelectedValue.ToString();
				exist.GhiChu = txtGhiChu.Text.Trim();

				exist.TepDinhKem = SaveAttached(txtTepDinhKem.Text);
				_repository.Update(exist);
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
				if (CheckNullOrWhiteSpace(txtSoVBDi.Text, txtNoiNhan.Text))
				{
					var exist = _repository.Get(txtSoVBDi.Text, cbxSoPG.SelectedValue.ToString(), txtNoiNhan.Text);
					if (exist == null)
					{
						throw new Exception("Công văn này không tồn tại");
					}
					DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (result == DialogResult.Yes)
					{
						_repository.Delete(txtSoVBDi.Text, cbxSoPG.SelectedValue.ToString(), txtNoiNhan.Text);
						DeleteAttachedFile(txtTepDinhKem.Text);
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

		private void btnReset_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm1();
			mainForm.ShowDialog();
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dtgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex > -1)
			{
				var selectedRow = e.RowIndex;
				txtSoVBDi.Enabled = false;
				cbxSoPG.Enabled = false;
				txtNoiNhan.Enabled = false;

				txtSoVBDi.Text = dtgv.Rows[selectedRow].Cells[0].Value.ToString();
				var soPG = dtgv.Rows[selectedRow].Cells[1].Value.ToString();
				var soPGs = _yeuCauRepository.GetAll().Select(x => x.SoPG).ToList();
				cbxSoPG.SelectedIndex = soPGs.IndexOf(soPG);
				txtNoiNhan.Text = dtgv.Rows[selectedRow].Cells[2].Value.ToString();
				dtNgay.Value = (DateTime)dtgv.Rows[selectedRow].Cells[3].Value;
				var maDV = dtgv.Rows[selectedRow].Cells[4].Value.ToString();
				var phongBans = _phongBanRepository.GetAll().Select(x => x.MaDV).ToList();
				cbBoxDonVi.SelectedIndex = phongBans.IndexOf(maDV);
				var doMat = dtgv.Rows[selectedRow].Cells[5].Value.ToString();
				cbBoxDoMat.SelectedIndex = Constant.DoMat.IndexOf(doMat);
				txtTrichYeu.Text = dtgv.Rows[selectedRow].Cells[6].Value.ToString();
				cbBoxNguoiKy.Text = dtgv.Rows[selectedRow].Cells[7].Value.ToString();
				txtSoBan.Text = dtgv.Rows[selectedRow].Cells[8].Value.ToString();
				txtTepDinhKem.Text = dtgv.Rows[selectedRow].Cells[9].Value.ToString();
				var trangThai = dtgv.Rows[selectedRow].Cells[10].Value.ToString();
				cbxTrangThai.SelectedIndex = Constant.TrangThai.IndexOf(trangThai);
				txtGhiChu.Text = dtgv.Rows[selectedRow].Cells[11].Value.ToString();
			}
		}

		private void btnChon_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Text Files (*.txt)|*.txt|Doc Files (*.docx)|*.docx|XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|All files (*.*)|*.*";

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				txtTepDinhKem.Text = fileDialog.FileName;
			}
		}

		private void HienThi()
		{
			dtgv.DataSource = _repository.GetAll() ?? new List<QuanLyVanBanDi>();
			string[] headers = Constant.CongVanDiHeaders;
			int i = 0;
			foreach (var header in headers)
			{
				dtgv.Columns[i].HeaderText = header;
				i++;
			}
		}

		private string SaveAttached(string filePath)
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string destinationFolder = Path.Combine(baseDirectory, "CongVanDi");

			// Ensure the "Attached" folder exists; create it if it doesn't.
			if (!Directory.Exists(destinationFolder))
			{
				Directory.CreateDirectory(destinationFolder);
			}

			var fileName = Path.GetFileNameWithoutExtension(filePath);
			var extension = Path.GetExtension(filePath);
			var path = Path.GetFullPath(filePath);
			var destinationFilePath = Path.Combine(destinationFolder, fileName + extension);
			if (!filePath.Contains(destinationFolder))
			{
				File.Copy(path, destinationFilePath, true);
			}
			return destinationFilePath;
		}

		private void DeleteAttachedFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
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
			txtSoVBDi.Enabled = true;
			cbxSoPG.Enabled = true;
			txtNoiNhan.Enabled = true;

			txtSoVBDi.Text = string.Empty;
			cbxSoPG.SelectedIndex = 0;
			txtNoiNhan.Text = string.Empty;
			dtNgay.Value = DateTime.Now;
			cbBoxDoMat.SelectedIndex = 0;
			cbBoxNguoiKy.SelectedIndex = 0;
			txtTrichYeu.Text = string.Empty;
			cbBoxDonVi.SelectedIndex = 0;
			txtSoBan.Text = string.Empty;
			txtTepDinhKem.Text = string.Empty;
			cbxTrangThai.SelectedIndex = 0;
			txtGhiChu.Text = string.Empty;
			txtTim.Text = string.Empty;
			HienThi();
		}

		private void LoadComboBox()
		{
			cbBoxDoMat.DataSource = Constant.DoMat;
			cbxTrangThai.DataSource = Constant.TrangThai;

			var phongBans = _phongBanRepository.GetAll().ToList();
			var donViDataSource = new Dictionary<string, string>();
			foreach (var phongBan in phongBans)
			{
				donViDataSource.Add(phongBan.MaDV, phongBan.TenDV);
			}

			cbBoxDonVi.DataSource = new BindingSource(donViDataSource, null);
			cbBoxDonVi.DisplayMember = "Value";
			cbBoxDonVi.ValueMember = "Key";
			cbBoxDonVi.DropDownHeight = cbBoxDonVi.Font.Height * 10;


			var nguoiDungs = _nguoiDungRepository.GetAll().ToList();
			var nguoiDungDataSource = new Dictionary<string, string>() { {"", ""} };
			foreach (var nguoiDung in nguoiDungs)
			{
				nguoiDungDataSource.Add(nguoiDung.MaTK, nguoiDung.Ten);
			}

			cbBoxNguoiKy.DataSource = new BindingSource(nguoiDungDataSource, null);
			cbBoxNguoiKy.DisplayMember = "Value";
			cbBoxNguoiKy.ValueMember = "Key";
			cbBoxNguoiKy.DropDownHeight = cbBoxNguoiKy.Font.Height * 10;

			var soPGs = _yeuCauRepository.GetAll().Select(x => x.SoPG).ToList();
			cbxSoPG.DataSource = soPGs;

		}
	}
}
