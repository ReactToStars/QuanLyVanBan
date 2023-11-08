using QuanLyVanBan.Authentications;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class PhongBanForm : Form
	{
		private readonly PhongBanRepository _repository = new PhongBanRepository();
		public PhongBanForm()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				if (!customPrincipal.IsInRole("Cán bộ quản trị", "Cán bộ văn thư", "Lãnh đạo phòng"))
				{
					btnThem.Enabled = false;
					btnSua.Enabled = false;
					btnXoa.Enabled = false;
				}
			}
		}

		private void PhongBanForm_Load(object sender, EventArgs e)
		{
			HienThi();
		}

		private void HienThi()
		{
			dtgvPhongBan.DataSource = _repository.GetAll();
			dtgvPhongBan.Columns[0].HeaderText = "Mã phòng ban";
			dtgvPhongBan.Columns[1].HeaderText = "Tên phòng ban";
			dtgvPhongBan.Columns[2].HeaderText = "Mô tả";
			dtgvPhongBan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dtgvPhongBan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dtgvPhongBan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void dtgvPhongBan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dtgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				var selectedRow = e.RowIndex;
				txtMaDV.Enabled = false;
				txtMaDV.Text = dtgvPhongBan.Rows[selectedRow].Cells[0].Value.ToString();
				txtTenDV.Text = dtgvPhongBan.Rows[selectedRow].Cells[1].Value.ToString();
				txtMoTa.Text = dtgvPhongBan.Rows[selectedRow].Cells[2].Value.ToString();
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!CheckNullOrWhiteSpace(txtMaDV.Text, txtTenDV.Text))
				{
					throw new Exception("Thông tin phòng ban không hợp lệ");
				}

				var exist = _repository.Get(txtMaDV.Text);
				if (exist != null)
				{
					throw new Exception("Đơn vị này đã tồn tại");
				}

				var phongBan = new PhongBan()
				{
					MaDV = txtMaDV.Text.Trim(),
					TenDV = txtTenDV.Text.Trim(),
					MoTa = txtMoTa.Text.Trim()
				};
				_repository.Add(phongBan);
				MessageBox.Show("Thêm thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				HienThi();
				Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			HienThi();
			Clear();
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm1();
			mainForm.ShowDialog();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			try
			{
				if (!CheckNullOrWhiteSpace(txtMaDV.Text, txtTenDV.Text))
				{
					throw new Exception("Thông tin phòng ban không hợp lệ");
				}

				var phongBan = _repository.Get(txtMaDV.Text);
				if(phongBan == null)
				{
					throw new Exception("Phòng ban này không tồn tại");
				}

				phongBan.TenDV = txtTenDV.Text;
				phongBan.MoTa = txtMoTa.Text;
				
				_repository.Update(phongBan);
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
				if (!CheckNullOrWhiteSpace(txtMaDV.Text))
				{
					throw new Exception("Mã phòng ban không hợp lệ");
				}
				var phongBan = _repository.Get(txtMaDV.Text);
				if (phongBan == null)
				{
					throw new Exception("Phòng ban này không tồn tại");
				}
				DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					_repository.Delete(txtMaDV.Text);
					MessageBox.Show("Xóa thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					HienThi();
					Clear();
				}
					
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

		private void btnTim_Click(object sender, EventArgs e)
		{
			try
			{
				var filter = txtTim.Text.Trim();
				if (!CheckNullOrWhiteSpace(filter))
				{
					throw new Exception("Dữ liệu bạn nhập không hợp lệ");
				}
				
				dtgvPhongBan.DataSource = _repository.Find(filter);
				dtgvPhongBan.Columns[0].HeaderText = "Mã phòng ban";
				dtgvPhongBan.Columns[1].HeaderText = "Tên phòng ban";
				dtgvPhongBan.Columns[2].HeaderText = "Mô tả";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			txtMaDV.Enabled = true;
			txtMaDV.Text = string.Empty;
			txtTenDV.Text = string.Empty;
			txtMoTa.Text = string.Empty;
			txtTim.Text = string.Empty;
		}
	}
}
