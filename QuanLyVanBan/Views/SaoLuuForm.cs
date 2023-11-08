using QuanLyVanBan.Authentications;
using QuanLyVanBan.Commons;
using QuanLyVanBan.Models;
using QuanLyVanBan.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace QuanLyVanBan.Views
{
	public partial class SaoLuuForm : Form
	{
		private readonly SaoLuuRepository _repository = new SaoLuuRepository();
		private readonly QuanLyVanBanDenRepository _congVanDenrepository = new QuanLyVanBanDenRepository();
		private readonly QuanLyVanBanDiRepository _congVanDirepository = new QuanLyVanBanDiRepository();
		private readonly YeuCauGuiVanBanDiRepository _yeuCauDirepository = new YeuCauGuiVanBanDiRepository();
		private List<QuanLyVanBanDen> _congVanDens = new List<QuanLyVanBanDen>();
		private List<QuanLyVanBanDi> _congVanDis = new List<QuanLyVanBanDi>();
		private List<YeuCauGuiVanBanDi> _yeuCaus = new List<YeuCauGuiVanBanDi>();
		private string xmlFileType;

		public SaoLuuForm()
		{
			InitializeComponent();
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			// Check if the current principal is of the custom principal type
			if (currentPrincipal is CustomPrincipal customPrincipal)
			{
				if (!customPrincipal.IsInRole("Cán bộ quản trị", "Cán bộ văn thư"))
				{
					btnChon.Enabled = false;
					btnNhap.Enabled = false;
					btnXuat.Enabled = false;
				}
			}
		}

		private void SaoLuuForm_Load(object sender, EventArgs e)
		{
			LoadComboBox();
			txtChon.Enabled = false;
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm1();
			mainForm.ShowDialog();
		}


		private void btnChon_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog obj = new OpenFileDialog();
				obj.Filter = "XML files (*.xml)|*.xml";
				obj.ShowDialog();

				txtChon.Text = obj.FileName;
				
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(txtChon.Text);
				int i = 0;
				XmlNodeList itemNodes;
				xmlFileType = xmlDoc.FirstChild.Name;
				switch (xmlDoc.FirstChild.Name)
				{
					case "QuanLyVanBanDen":
						itemNodes = xmlDoc.SelectNodes("/QuanLyVanBanDen/item");
						_congVanDens = LoadCongVanDen(itemNodes);
						dtgv.DataSource = _congVanDens;
						foreach (var header in Constant.CongVanDenHeaders)
						{
							dtgv.Columns[i].HeaderText = header;
							dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
							i++;
						}
						break;
					case "QuanLyVanBanDi":
						itemNodes = xmlDoc.SelectNodes("/QuanLyVanBanDi/item");
						_congVanDis = LoadCongVanDi(itemNodes);
						dtgv.DataSource = _congVanDis;
						foreach (var header in Constant.CongVanDiHeaders)
						{
							dtgv.Columns[i].HeaderText = header;
							dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
							i++;
						}
						break;
					case "YeuCauGuiVanBanDi":
						itemNodes = xmlDoc.SelectNodes("/YeuCauGuiVanBanDi/item");
						_yeuCaus = LoadYeuCau(itemNodes);
						dtgv.DataSource = _yeuCaus;
						foreach (var header in Constant.YeuCauGuiCongVanHeaders)
						{
							dtgv.Columns[i].HeaderText = header;
							dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
							i++;
						}
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnNhap_Click(object sender, EventArgs e)
		{
			try
			{
				if(txtChon.Text == string.Empty)
				{
					throw new Exception("Bạn phải chọn file trước");
				}
				DialogResult result = MessageBox.Show("Dữ liệu hiện tại có thể sẽ bị thay đổi, bạn có muốn tiếp tục không?", "Nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					switch (xmlFileType)
					{
						case "QuanLyVanBanDen":
							foreach (var item in _congVanDens)
							{
								var exist = _congVanDenrepository.Get(item.SoVBden, item.Soden);
								if(exist == null)
								{
									_congVanDenrepository.Add(item);
									continue;
								}
								_congVanDenrepository.Update(item);
							}
							break;
						case "QuanLyVanBanDi":
							foreach (var item in _congVanDis)
							{
								var exist = _congVanDirepository.Get(item.SoVBdi, item.SoPG, item.NoiNhan);
								if (exist == null)
								{
									_congVanDirepository.Add(item);
									continue;
								}
								_congVanDirepository.Update(item);
							}
							break;
						case "YeuCauGuiVanBanDi":
							foreach (var item in _yeuCaus)
							{
								var exist = _yeuCauDirepository.GetExist(item.SoPG);
								if (exist == null)
								{
									_yeuCauDirepository.Add(item);
									continue;
								}
								_yeuCauDirepository.Update(item);
							}
							break;
					}
					MessageBox.Show("Nhập dữ liệu thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Clear();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXuat_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbxDanhMuc.SelectedIndex == 0)
				{
					throw new Exception("Bạn phải chọn danh mục trước");
				}
				var danhMuc = cbxDanhMuc.SelectedValue.ToString();
				XmlDocument xmlDoc = new XmlDocument();
				switch (danhMuc)
				{
					case Constant.CongVanDen:
						BackUpCongVanDen(xmlDoc);
						SaveFileDialog(xmlDoc);
						break;
					case Constant.CongVanDi:
						BackUpCongVanDi(xmlDoc);
						SaveFileDialog(xmlDoc);
						break;
					case Constant.YeuCauGuiCongVan:
						BackUpYeuCauGuiCongVan(xmlDoc);
						SaveFileDialog(xmlDoc);
						break;
					default:
						break;
				}
				MessageBox.Show("Xuất dữ liệu thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cbxDanhMuc_SelectedValueChanged(object sender, EventArgs e)
		{
			HienThi();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void HienThi()
		{
			var danhMuc = cbxDanhMuc.SelectedValue.ToString();
			string[] headers;
			int i = 0;

			switch (danhMuc)
			{
				case Constant.CongVanDen:
					headers = Constant.CongVanDenHeaders;
					dtgv.DataSource = _repository.GetAll<QuanLyVanBanDen>("QuanLyVanBanDen") ?? new List<QuanLyVanBanDen>();
					foreach (var header in headers)
					{
						dtgv.Columns[i].HeaderText = header;
						dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						i++;
					}

					break;
				case Constant.CongVanDi:
					headers = Constant.CongVanDiHeaders;
					dtgv.DataSource = _repository.GetAll<QuanLyVanBanDi>("QuanLyVanBanDi") ?? new List<QuanLyVanBanDi>();
					foreach (var header in headers)
					{
						dtgv.Columns[i].HeaderText = header;
						dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						i++;
					}
					break;
				case Constant.YeuCauGuiCongVan:
					headers = Constant.YeuCauGuiCongVanHeaders;
					dtgv.DataSource = _repository.GetAll<YeuCauGuiVanBanDi>("YeuCauGuiVanBanDi") ?? new List<YeuCauGuiVanBanDi>();
					foreach (var header in headers)
					{
						dtgv.Columns[i].HeaderText = header;
						dtgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						i++;
					}
					break;
				default:
					dtgv.DataSource = null;
					break;
			}
		}

		private void LoadComboBox()
		{
			List<string> comboSource = new List<string>() { string.Empty };
			comboSource.Add(Constant.CongVanDen);
			comboSource.Add(Constant.CongVanDi);
			comboSource.Add(Constant.YeuCauGuiCongVan);
			cbxDanhMuc.DataSource = comboSource;
		}

		private void Clear()
		{
			txtChon.Text = string.Empty;
			cbxDanhMuc.SelectedIndex = 0;
			dtgv.DataSource = null;
		}

		private void SaveFileDialog(XmlDocument xmlDoc)
		{
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				xmlDoc.Save(saveFileDialog.FileName);
			}
		}

		private void BackUpCongVanDen(XmlDocument xmlDoc)
		{
			var cvDens = _repository.GetAll<QuanLyVanBanDen>("QuanLyVanBanDen") ?? new List<QuanLyVanBanDen>();
			// Create the root element
			XmlElement root = xmlDoc.CreateElement("QuanLyVanBanDen");
			xmlDoc.AppendChild(root);

			foreach (var cvDen in cvDens)
			{
				// Create item elements and attributes
				XmlElement item = xmlDoc.CreateElement("item");
				root.AppendChild(item);

				XmlElement soVBden = xmlDoc.CreateElement("SoVBden");
				soVBden.InnerText = cvDen.SoVBden;
				item.AppendChild(soVBden);

				XmlElement soden = xmlDoc.CreateElement("Soden");
				soden.InnerText = cvDen.Soden;
				item.AppendChild(soden);

				XmlElement ngayVBden = xmlDoc.CreateElement("NgayVBden");
				ngayVBden.InnerText = cvDen.NgayVBden.ToString();
				item.AppendChild(ngayVBden);

				XmlElement noiGui = xmlDoc.CreateElement("NoiGui");
				noiGui.InnerText = cvDen.NoiGui;
				item.AppendChild(noiGui);

				XmlElement trichYeu = xmlDoc.CreateElement("TrichYeu");
				trichYeu.InnerText = cvDen.TrichYeu;
				item.AppendChild(trichYeu);

				XmlElement doMat = xmlDoc.CreateElement("DoMat");
				doMat.InnerText = cvDen.DoMat;
				item.AppendChild(doMat);

				XmlElement tepDinhKem = xmlDoc.CreateElement("TepDinhKem");
				tepDinhKem.InnerText = cvDen.TepDinhKem;
				item.AppendChild(tepDinhKem);

				XmlElement yKienChiDao = xmlDoc.CreateElement("YKienChiDao");
				yKienChiDao.InnerText = cvDen.YKienChiDao;
				item.AppendChild(yKienChiDao);

				XmlElement donViThucHien = xmlDoc.CreateElement("DonViThucHien");
				donViThucHien.InnerText = cvDen.DonViThucHien;
				item.AppendChild(donViThucHien);

				XmlElement trangThaiVB = xmlDoc.CreateElement("TrangThaiVB");
				trangThaiVB.InnerText = cvDen.TrangThaiVB;
				item.AppendChild(trangThaiVB);

				XmlElement ghiChu = xmlDoc.CreateElement("GhiChu");
				ghiChu.InnerText = cvDen.GhiChu;
				item.AppendChild(ghiChu);
			}
		}

		private void BackUpCongVanDi(XmlDocument xmlDoc)
		{
			var cvDis = _repository.GetAll<QuanLyVanBanDi>("QuanLyVanBanDi") ?? new List<QuanLyVanBanDi>();

			// Create the root element
			XmlElement root = xmlDoc.CreateElement("QuanLyVanBanDi");
			xmlDoc.AppendChild(root);

			foreach (var cvDi in cvDis)
			{
				// Create item elements and attributes
				XmlElement item = xmlDoc.CreateElement("item");
				root.AppendChild(item);

				XmlElement soVBdi = xmlDoc.CreateElement("SoVBdi");
				soVBdi.InnerText = cvDi.SoVBdi;
				item.AppendChild(soVBdi);

				XmlElement SoPG = xmlDoc.CreateElement("SoPG");
				SoPG.InnerText = cvDi.SoPG;
				item.AppendChild(SoPG);

				XmlElement NoiNhan = xmlDoc.CreateElement("NoiNhan");
				NoiNhan.InnerText = cvDi.NoiNhan;
				item.AppendChild(NoiNhan);

				XmlElement NgayVBdi = xmlDoc.CreateElement("NgayVBdi");
				NgayVBdi.InnerText = cvDi.NgayVBdi.ToString();
				item.AppendChild(NgayVBdi);

				XmlElement MaDV = xmlDoc.CreateElement("MaDV");
				MaDV.InnerText = cvDi.MaDV;
				item.AppendChild(MaDV);

				XmlElement DoMat = xmlDoc.CreateElement("DoMat");
				DoMat.InnerText = cvDi.DoMat;
				item.AppendChild(DoMat);

				XmlElement NDtrichyeu = xmlDoc.CreateElement("NDtrichyeu");
				NDtrichyeu.InnerText = cvDi.NDtrichyeu;
				item.AppendChild(NDtrichyeu);

				XmlElement NguoiKy = xmlDoc.CreateElement("NguoiKy");
				NguoiKy.InnerText = cvDi.NguoiKy;
				item.AppendChild(NguoiKy);

				XmlElement SoBanDongDau = xmlDoc.CreateElement("SoBanDongDau");
				SoBanDongDau.InnerText = cvDi.SoBanDongDau.ToString();
				item.AppendChild(SoBanDongDau);

				XmlElement TepDinhKem = xmlDoc.CreateElement("TepDinhKem");
				TepDinhKem.InnerText = cvDi.TepDinhKem;
				item.AppendChild(TepDinhKem);

				XmlElement TrangThaiVB = xmlDoc.CreateElement("TrangThaiVB");
				TrangThaiVB.InnerText = cvDi.TrangThaiVB;
				item.AppendChild(TrangThaiVB);

				XmlElement ghiChu = xmlDoc.CreateElement("GhiChu");
				ghiChu.InnerText = cvDi.GhiChu;
				item.AppendChild(ghiChu);
			}
		}

		private void BackUpYeuCauGuiCongVan(XmlDocument xmlDoc)
		{ 
			var data = _repository.GetAll<YeuCauGuiVanBanDi>("YeuCauGuiVanBanDi") ?? new List<YeuCauGuiVanBanDi>();

			// Create the root element
			XmlElement root = xmlDoc.CreateElement("YeuCauGuiVanBanDi");
			xmlDoc.AppendChild(root);

			foreach (var i in data)
			{
				// Create item elements and attributes
				XmlElement item = xmlDoc.CreateElement("item");
				root.AppendChild(item);

				XmlElement SoPG = xmlDoc.CreateElement("SoPG");
				SoPG.InnerText = i.SoPG;
				item.AppendChild(SoPG);

				XmlElement NgayPG = xmlDoc.CreateElement("NgayPG");
				NgayPG.InnerText = i.NgayPG.ToString();
				item.AppendChild(NgayPG);

				XmlElement MaDV = xmlDoc.CreateElement("MaDV");
				MaDV.InnerText = i.MaDV;
				item.AppendChild(MaDV);

				XmlElement TrichYeu = xmlDoc.CreateElement("TrichYeu");
				TrichYeu.InnerText = i.TrichYeu;
				item.AppendChild(TrichYeu);

				XmlElement SL = xmlDoc.CreateElement("SL");
				SL.InnerText = i.SL.ToString();
				item.AppendChild(SL);

				XmlElement DoKhan = xmlDoc.CreateElement("DoKhan");
				DoKhan.InnerText = i.DoKhan;
				item.AppendChild(DoKhan);

				XmlElement DoMat = xmlDoc.CreateElement("DoMat");
				DoMat.InnerText = i.DoMat;
				item.AppendChild(DoMat);

				XmlElement NoiNhan = xmlDoc.CreateElement("NoiNhan");
				NoiNhan.InnerText = i.NoiNhan;
				item.AppendChild(NoiNhan);
			}
		}

		private List<QuanLyVanBanDen> LoadCongVanDen(XmlNodeList itemNodes)
		{
			var dataSource = new List<QuanLyVanBanDen>();
			foreach (XmlNode itemNode in itemNodes)
			{
				var congVanDen = new QuanLyVanBanDen()
				{
					SoVBden = itemNode.SelectSingleNode("SoVBden").InnerText,
					Soden = itemNode.SelectSingleNode("Soden").InnerText,
					NgayVBden = DateTime.Parse(itemNode.SelectSingleNode("NgayVBden").InnerText),
					NoiGui = itemNode.SelectSingleNode("NoiGui").InnerText,
					DoMat = itemNode.SelectSingleNode("DoMat").InnerText,
					DonViThucHien = itemNode.SelectSingleNode("DonViThucHien").InnerText,
					GhiChu = itemNode.SelectSingleNode("GhiChu").InnerText,
					TepDinhKem = itemNode.SelectSingleNode("TepDinhKem").InnerText,
					TrangThaiVB = itemNode.SelectSingleNode("TrangThaiVB").InnerText,
					TrichYeu = itemNode.SelectSingleNode("TrichYeu").InnerText,
					YKienChiDao = itemNode.SelectSingleNode("YKienChiDao").InnerText
				};
				// Process or store the data as needed
				dataSource.Add(congVanDen);
			}

			return dataSource;
		}

		private List<QuanLyVanBanDi> LoadCongVanDi(XmlNodeList itemNodes)
		{
			var dataSource = new List<QuanLyVanBanDi>();
			foreach (XmlNode itemNode in itemNodes)
			{
				var congVanDi = new QuanLyVanBanDi()
				{
					SoVBdi = itemNode.SelectSingleNode("SoVBdi").InnerText,
					SoPG = itemNode.SelectSingleNode("SoPG").InnerText,
					DoMat = itemNode.SelectSingleNode("DoMat").InnerText,
					GhiChu = itemNode.SelectSingleNode("GhiChu").InnerText,
					MaDV = itemNode.SelectSingleNode("MaDV").InnerText,
					NDtrichyeu = itemNode.SelectSingleNode("NDtrichyeu").InnerText,
					NgayVBdi = DateTime.Parse(itemNode.SelectSingleNode("NgayVBdi").InnerText),
					NguoiKy = itemNode.SelectSingleNode("NguoiKy").InnerText,
					NoiNhan = itemNode.SelectSingleNode("NoiNhan").InnerText,
					SoBanDongDau = int.Parse(itemNode.SelectSingleNode("SoBanDongDau").InnerText),
					TepDinhKem = itemNode.SelectSingleNode("TepDinhKem").InnerText,
					TrangThaiVB = itemNode.SelectSingleNode("TrangThaiVB").InnerText
				};
				dataSource.Add(congVanDi);
			}

			return dataSource;
		}

		private List<YeuCauGuiVanBanDi> LoadYeuCau(XmlNodeList itemNodes)
		{
			var dataSource = new List<YeuCauGuiVanBanDi>();
			foreach (XmlNode itemNode in itemNodes)
			{
				var yeuCau = new YeuCauGuiVanBanDi()
				{
					SoPG = itemNode.SelectSingleNode("SoPG").InnerText,
					DoKhan = itemNode.SelectSingleNode("DoKhan").InnerText,
					DoMat = itemNode.SelectSingleNode("DoMat").InnerText,
					MaDV = itemNode.SelectSingleNode("MaDV").InnerText,
					NgayPG = DateTime.Parse(itemNode.SelectSingleNode("NgayPG").InnerText),
					NoiNhan = itemNode.SelectSingleNode("NoiNhan").InnerText,
					SL = int.Parse(itemNode.SelectSingleNode("SL").InnerText),
					TrichYeu = itemNode.SelectSingleNode("TrichYeu").InnerText
				};
				dataSource.Add(yeuCau);
			}

			return dataSource;
		}

	}
}
