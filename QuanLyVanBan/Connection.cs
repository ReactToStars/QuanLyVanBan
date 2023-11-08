using System.Configuration;

namespace QuanLyVanBan
{
	public static class Connection
	{
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    }
}
