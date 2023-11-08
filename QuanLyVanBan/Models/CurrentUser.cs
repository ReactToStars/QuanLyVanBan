namespace QuanLyVanBan.Models
{
	public class CurrentUser
	{
        public string MaTK { get; set; }
        public string TenTK { get; set; }
        public string Ten { get; set; }
		public string MatKhau { get; set; }
		public string ChucVu { get; set; }
		public bool IsSavedPassword { get; set; }
	}
}
