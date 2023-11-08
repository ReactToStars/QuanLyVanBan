using System;

namespace QuanLyVanBan.Models
{
	public class TaiKhoan
	{
        public string MaTK { get; set; }
		public string TenTK { get; set; }
		public string Ten { get; set; }
		public string MatKhau { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public string DienThoai { get; set; }
		public string MaDV { get; set; }
		public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
	}
}
