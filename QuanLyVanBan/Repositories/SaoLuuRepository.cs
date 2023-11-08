using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace QuanLyVanBan.Repositories
{
	public class SaoLuuRepository
	{
		public IDbConnection Db => new SqlConnection(Connection.ConnectionString);

		public IEnumerable<T> GetAll<T>(string tableName)
		{
			Db.Open();

			var result = Db.Query<T>(
							$"select * from {tableName}",
							commandType: CommandType.Text
						);

			Db.Close();
			return result;
		}
	}
}
