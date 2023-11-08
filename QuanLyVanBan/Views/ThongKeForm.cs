using OfficeOpenXml;
using QuanLyVanBan.Authentications;
using QuanLyVanBan.Commons;
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
	public partial class ThongKeForm : Form
	{
		private readonly ThongKeRepository _repository = new ThongKeRepository();
		public ThongKeForm()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				if (!customPrincipal.IsInRole("Cán bộ quản trị", "Cán bộ văn thư", "Lãnh đạo phòng"))
				{
					btnXuat.Enabled = false;
				}
			}
		}

		private void ThongKeForm_Load(object sender, EventArgs e)
		{
			LoadComboBox();
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm1();
			mainForm.ShowDialog();
		}

		private void btnXem_Click(object sender, EventArgs e)
		{
			HienThi();
		}

		private void btnXuat_Click(object sender, EventArgs e)
		{
			var danhMuc = cbBoxDanhMuc.SelectedValue.ToString();
			var from = dtFrom.Value;
			var to = dtTo.Value;
			string[] headers;

			switch (danhMuc)
			{
				case Constant.CongVanDen:
					headers = Constant.CongVanDenHeaders;
					Export<QuanLyVanBanDen>("QuanLyVanBanDen", "NgayVBden", headers, from, to);
					break;
				case Constant.CongVanDi:
					headers = Constant.CongVanDiHeaders;
					Export<QuanLyVanBanDi>("QuanLyVanBanDi", "NgayVBdi", headers, from, to);
					break;
				case Constant.YeuCauGuiCongVan:
					headers = Constant.YeuCauGuiCongVanHeaders;
					Export<YeuCauGuiVanBanDi>("YeuCauGuiVanBanDi", "NgayPG", headers, from, to);
					break;
			}
			MessageBox.Show("Xuất báo cáo thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void HienThi()
		{
			var danhMuc = cbBoxDanhMuc.SelectedValue.ToString();
			var from = dtFrom.Value;
			var to = dtTo.Value;
			string[] headers;
			string query = string.Empty;
			int i = 0;

			switch (danhMuc)
			{
				case Constant.CongVanDen:
					headers = headers = Constant.CongVanDenHeaders;
					query = $"select * from QuanLyVanBanDen where NgayVBden between '{from}' and '{to}'";
					dtgv.DataSource = _repository.Filter<QuanLyVanBanDen>(query) ?? new List<QuanLyVanBanDen>();
					foreach (var header in headers)
					{
						dtgv.Columns[i].HeaderText = header;
						dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						i++;
					}

					break;
				case Constant.CongVanDi:
					headers = Constant.CongVanDiHeaders;
					query = $"select * from QuanLyVanBanDi where NgayVBdi between '{from}' and '{to}'";
					dtgv.DataSource = _repository.Filter<QuanLyVanBanDi>(query) ?? new List<QuanLyVanBanDi>();
					foreach (var header in headers)
					{
						dtgv.Columns[i].HeaderText = header;
						dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						i++;
					}
					break;
				case Constant.YeuCauGuiCongVan:
					headers = Constant.YeuCauGuiCongVanHeaders;
					query = $"select * from YeuCauGuiVanBanDi where NgayPG between '{from}' and '{to}'";
					dtgv.DataSource = _repository.Filter<YeuCauGuiVanBanDi>(query) ?? new List<YeuCauGuiVanBanDi>();
					foreach (var header in headers)
					{
						dtgv.Columns[i].HeaderText = header;
						dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						i++;
					}
					break;
			}

		}

		public void Export<T>(string tableName, string columnName, string[] headers, DateTime from, DateTime to)
		{
			try
			{
				var data = _repository.GetContent<T>(tableName, columnName, from, to).ToList();
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

					// Add data to the worksheet

					int i = 1;
					foreach (var header in headers)
					{
						worksheet.Cells[1, i].Value = header;
						i++;
					}
					worksheet = LoadData<T>(worksheet, data);
					worksheet = ConfigHeaderAndColumnDataType(worksheet, typeof(T).Name);

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

		private ExcelWorksheet ConfigHeaderAndColumnDataType(ExcelWorksheet worksheet, string objectType)
		{
			var headerConfig = worksheet.Cells["A1:R1"];
			headerConfig.Style.Font.Bold = true;

			switch (objectType)
			{
				case "QuanLyVanBanDen":
					var ngayVBdenColumn = worksheet.Cells[2, 3, worksheet.Dimension.End.Row, 3];
					ngayVBdenColumn.Style.Numberformat.Format = "dd-mm-yyyy";
					break;
				case "QuanLyVanBanDi":
					var ngayVBdiColumn = worksheet.Cells[2, 4, worksheet.Dimension.End.Row, 4];
					ngayVBdiColumn.Style.Numberformat.Format = "dd-mm-yyyy";
					break;
				case "YeuCauGuiVanBanDi":
					var ngayPGColumn = worksheet.Cells[2, 2, worksheet.Dimension.End.Row, 2];
					ngayPGColumn.Style.Numberformat.Format = "dd-mm-yyyy";
					break;
			}

			return worksheet;
		}

		private ExcelWorksheet LoadData<T>(ExcelWorksheet worksheet, List<T> data)
		{

			if (typeof(T).Name is "QuanLyVanBanDen")
			{
				for (int j = 0; j < data.Count(); ++j)
				{
					var item = data[j] as QuanLyVanBanDen;
					worksheet.Cells[j + 2, 1].Value = item.SoVBden;
					worksheet.Cells[j + 2, 2].Value = item.Soden;
					worksheet.Cells[j + 2, 3].Value = item.NgayVBden;
					worksheet.Cells[j + 2, 4].Value = item.NoiGui;
					worksheet.Cells[j + 2, 5].Value = item.TrichYeu;
					worksheet.Cells[j + 2, 6].Value = item.DoMat;

					var tepDinhKemCell = worksheet.Cells[j + 2, 7];
					tepDinhKemCell.Hyperlink = new Uri(item.TepDinhKem);
					tepDinhKemCell.Style.Font.UnderLine = true;
					tepDinhKemCell.Style.Font.Color.SetColor(System.Drawing.Color.Blue);

					worksheet.Cells[j + 2, 8].Value = item.YKienChiDao;
					worksheet.Cells[j + 2, 9].Value = item.DonViThucHien;
					worksheet.Cells[j + 2, 10].Value = item.TrangThaiVB;
					worksheet.Cells[j + 2, 11].Value = item.GhiChu;
				}

			}
			else if (typeof(T).Name is "QuanLyVanBanDi")
			{
				for (int j = 0; j < data.Count(); ++j)
				{
					var item = data[j] as QuanLyVanBanDi;
					worksheet.Cells[j + 2, 1].Value = item.SoVBdi;
					worksheet.Cells[j + 2, 2].Value = item.SoPG;
					worksheet.Cells[j + 2, 3].Value = item.NoiNhan;
					worksheet.Cells[j + 2, 4].Value = item.NgayVBdi;
					worksheet.Cells[j + 2, 5].Value = item.MaDV;
					worksheet.Cells[j + 2, 6].Value = item.DoMat;
					worksheet.Cells[j + 2, 7].Value = item.NDtrichyeu;
					worksheet.Cells[j + 2, 8].Value = item.NguoiKy;
					worksheet.Cells[j + 2, 9].Value = item.SoBanDongDau;

					var tepDinhKemCell = worksheet.Cells[j + 2, 10];
					tepDinhKemCell.Hyperlink = new Uri(item.TepDinhKem);
					tepDinhKemCell.Style.Font.UnderLine = true;
					tepDinhKemCell.Style.Font.Color.SetColor(System.Drawing.Color.Blue);

					worksheet.Cells[j + 2, 11].Value = item.TrangThaiVB;
					worksheet.Cells[j + 2, 12].Value = item.GhiChu;
				}
			}
			else
			{
				for (int j = 0; j < data.Count(); ++j)
				{
					var item = data[j] as YeuCauGuiVanBanDi;
					worksheet.Cells[j + 2, 1].Value = item.SoPG;
					worksheet.Cells[j + 2, 2].Value = item.NgayPG;
					worksheet.Cells[j + 2, 3].Value = item.MaDV;
					worksheet.Cells[j + 2, 4].Value = item.TrichYeu;
					worksheet.Cells[j + 2, 5].Value = item.SL;
					worksheet.Cells[j + 2, 6].Value = item.DoKhan;
					worksheet.Cells[j + 2, 7].Value = item.DoMat;
					worksheet.Cells[j + 2, 8].Value = item.NoiNhan;
				}
			}


			return worksheet;
		}

		private void LoadComboBox()
		{
			List<string> comboSource = new List<string>();
			comboSource.Add(Constant.CongVanDen);
			comboSource.Add(Constant.CongVanDi);
			comboSource.Add(Constant.YeuCauGuiCongVan);
			cbBoxDanhMuc.DataSource = comboSource;
		}

		private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
