using QuanLyVanBan.Authentications;
using QuanLyVanBan.Commons;
using QuanLyVanBan.DTOs;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class YeuCauGuiVanBanForm : Form
	{
		private readonly YeuCauGuiVanBanDiRepository _repository = new YeuCauGuiVanBanDiRepository();
		private readonly PhongBanRepository _phongBanRepository = new PhongBanRepository();
		public YeuCauGuiVanBanForm()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				if (!customPrincipal.IsInRole("Cán bộ quản trị", "Cán bộ văn thư", "Cán bộ hành chính"))
				{
					btnThem.Enabled = false;
					btnSua.Enabled = false;
					btnXoa.Enabled = false;
				}
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!CheckNullOrWhiteSpace(txtSoPG.Text, txtTrichYeu.Text, txtSL.Text, txtNoiNhan.Text))
				{
					throw new Exception("Thông tin công văn không hợp lệ");
				}

				if (!int.TryParse(txtSL.Text.Trim(), out var soLuong) || soLuong < 0)
				{
					throw new Exception("Số lượng bản đóng dấu phải là số nguyên dương");
				}

				var exist = _repository.Get(txtSoPG.Text);
				if (exist != null)
				{
					throw new Exception("Đơn yêu cầu này đã tồn tại");
				}

				var yeuCau = new YeuCauGuiVanBanDi()
				{
					SoPG = txtSoPG.Text.Trim(),
					NgayPG = dtNgay.Value,
					MaDV = cbBoxDonVi.SelectedValue.ToString(),
					TrichYeu = txtTrichYeu.Text.Trim(),
					SL = soLuong,
					DoKhan = cbBoxDoKhan.SelectedValue.ToString(),
					DoMat = cbBoxDoMat.SelectedValue.ToString(),
					NoiNhan = txtNoiNhan.Text.Trim()
				};

				_repository.Add(yeuCau);
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
				if (!CheckNullOrWhiteSpace(txtSoPG.Text, txtTrichYeu.Text, txtSL.Text, txtNoiNhan.Text))
				{
					throw new Exception("Thông tin công văn không hợp lệ");
				}

				if (!int.TryParse(txtSL.Text.Trim(), out var soLuong) || soLuong < 0)
				{
					throw new Exception("Số lượng bản đóng dấu phải là số nguyên dương");
				}

				var exist = _repository.GetExist(txtSoPG.Text);

				if (exist == null)
				{
					throw new Exception("Đơn yêu cầu này chưa tồn tại");
				}

				exist.NgayPG = dtNgay.Value;
				exist.MaDV = cbBoxDonVi.SelectedValue.ToString();
				exist.TrichYeu = txtTrichYeu.Text.Trim();
				exist.SL = soLuong;
				exist.DoKhan = cbBoxDoKhan.SelectedValue.ToString();
				exist.DoMat = cbBoxDoMat.SelectedValue.ToString();
				exist.NoiNhan = txtNoiNhan.Text.Trim();

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
				if (CheckNullOrWhiteSpace(txtSoPG.Text))
				{
					var exist = _repository.GetExist(txtSoPG.Text);
					if (exist == null)
					{
						throw new Exception("Đơn yêu cầu này không tồn tại");
					}

					DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (result == DialogResult.Yes)
					{
						_repository.Delete(txtSoPG.Text);
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
			HienThi();
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

		private void YeuCauGuiVanBanForm_Load(object sender, EventArgs e)
		{
			HienThi();
			LoadComboBox();
		}

		private void dtgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex > -1)
			{
				var selectedRow = e.RowIndex;
				txtSoPG.Enabled = false;

				txtSoPG.Text = dtgv.Rows[selectedRow].Cells[0].Value.ToString();
				dtNgay.Value = (DateTime)dtgv.Rows[selectedRow].Cells[1].Value;
				var tenDV = dtgv.Rows[selectedRow].Cells[2].Value.ToString();
				var phongBans = _phongBanRepository.GetAll().Select(x => x.TenDV).ToList();
				cbBoxDonVi.SelectedIndex = phongBans.IndexOf(tenDV);
				txtTrichYeu.Text = dtgv.Rows[selectedRow].Cells[3].Value.ToString();
				txtSL.Text = dtgv.Rows[selectedRow].Cells[4].Value.ToString();
				var doKhan = dtgv.Rows[selectedRow].Cells[5].Value.ToString();
				cbBoxDoKhan.SelectedIndex = Constant.DoKhan.IndexOf(doKhan);
				var doMat = dtgv.Rows[selectedRow].Cells[6].Value.ToString();
				cbBoxDoMat.SelectedIndex = Constant.DoMat.IndexOf(doMat);
				txtNoiNhan.Text = dtgv.Rows[selectedRow].Cells[7].Value.ToString();
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
			txtSoPG.Enabled = true;

			cbBoxDonVi.SelectedIndex = 0;
			txtSoPG.Text = string.Empty;
			dtNgay.Value = DateTime.Now;
			txtTrichYeu.Text = string.Empty;
			txtSL.Text = string.Empty;
			cbBoxDoKhan.SelectedIndex = 0;
			cbBoxDoMat.SelectedIndex = 0;
			txtNoiNhan.Text = string.Empty;
			txtTim.Text = string.Empty;
			HienThi();
		}

		private void LoadComboBox()
		{
			cbBoxDoKhan.DataSource = Constant.DoKhan;
			cbBoxDoMat.DataSource = Constant.DoMat;

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
		}

		private void HienThi()
		{
			dtgv.DataSource = _repository.GetAll() ?? new List<YeuCauVBDiDto>();
			string[] headers = Constant.YeuCauGuiCongVanHeaders;
			int i = 0;
			foreach (var header in headers)
			{
				dtgv.Columns[i].HeaderText = header;
				dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				i++;
			}
		}
	}
}
