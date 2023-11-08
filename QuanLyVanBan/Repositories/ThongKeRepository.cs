using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyVanBan.Repositories
{
	public class ThongKeRepository
	{
		public IDbConnection Db => new SqlConnection(Connection.ConnectionString);
		
		public IEnumerable<T> Filter<T>(string query)
		{
			Db.Open();

			var result = Db.Query<T>(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public IEnumerable<T> GetContent<T>(string tableName, string columnName, DateTime from, DateTime to)
		{
			var query = $"select * from {tableName} where {columnName} between '{from}' and '{to}'";

			Db.Open();

			var result = Db.Query<T>
				(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}
	}
}
