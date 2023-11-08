using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyVanBan.Commons
{
	public static class Constant
	{
		public const string CongVanDen = "Công văn đến";
		public const string CongVanDi = "Công văn đi";
		public const string YeuCauGuiCongVan = "Yêu cầu gửi công văn";
		public static string[] CongVanDenHeaders => new string[] { "Số, ký hiệu văn bản", "Số, ký hiệu văn bản đến do văn thư tạo", "Ngày đến", "Nơi gửi", "Nội dung trích yếu", "Độ mật", "Tệp đính kèm", "Ý kiến chỉ đạo", "Đơn vị thực hiện", "Trạng thái", "Ghi chú" };
		public static string[] CongVanDiHeaders => new string[] { "Số, ký hiệu văn bản", "Số, ký hiệu phiếu gửi", "Nơi nhận", "Ngày đi", "Đơn vị gửi", "Độ mật", "Nội dung trích yếu", "Người ký", "Số bản đóng dấu", "Tệp đính kèm", "Trạng thái văn bản", "Ghi chú" };
		public static string[] YeuCauGuiCongVanHeaders => new string[] { "Số, ký hiệu phiếu gửi", "Ngày", "Đơn vị gửi", "Nội dung trích yếu", "Số lượng bản đóng dấu", "Độ khẩn", "Độ mật", "nơi nhận" };

		public static string[] NguoiDungHeaders => new string[] { "Mã tài khoản", "Tên tài khoản", "Họ tên", "Ngày sinh", "Chức vụ", "Điện thoại", "Tên đơn vị", "Ngày tạo", "Người tạo" };

		public static List<string> TrangThai = new List<string> { "Đang xử lý", "Đã xử lý" };
		public static List<string> DoMat = new List<string> { "Không", "Mật", "Tối mật" };
		public static List<string> DoKhan = new List<string> { "Không", "Gấp", "Rất gấp" };
		public static List<string> ChucVu = new List<string> { "Cán bộ văn thư", "Cán bộ hành chính", "Ban giám hiệu", "Lãnh đạo đơn vị", "Cán bộ quản trị"};

		public static string[] CongVanDenItems => new string[] { "SoVBden", "Soden", "NgayVBden", "NoiGui", "TrichYeu", "DoMat", "TepDinhKem", "YKienChiDao", "DonViThucHien", "TrangThaiVB", "GhiChu" };

		public static string[] CongVanDiItems => new string[] { "SoVBdi", "SoPG", "NoiNhan", "NgayVBdi", "MaDV", "DoMat", "NDtrichyeu", "NguoiKy", "SoBanDongDau", "TepDinhKem", "TrangThaiVB", "GhiChu" };

		public static string[] YeuCauGuiCongVanItems => new string[] { "SoPG", "NgayPG", "MaDV", "TrichYeu", "SL", "DoKhan", "DoMat", "NoiNhan" };
	}
}
