using QuanLyVanBan.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Linq;

namespace QuanLyVanBan.Repositories
{
	public class PhongBanRepository : IBaseRepository<PhongBan>
	{
		public IDbConnection Db => new SqlConnection(Connection.ConnectionString);
		public IEnumerable<PhongBan> GetAll()
		{
			Db.Open();

			string query = $"select * from PhongBan";
			var result = Db.Query<PhongBan>
				(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();
			return result;
		}

		public PhongBan Get(string id)
		{
			Db.Open();

			string query = $"select * from PhongBan where MaDV='{id}'";
			var result = Db.Query<PhongBan>
				(
					query,
					commandType: CommandType.Text
				).FirstOrDefault();

			Db.Close();

			return result;
		}

		public void Add(PhongBan entity)
		{
			Db.Open();

			string query = $"insert into PhongBan(MaDV, TenDV, MoTa) values (N'{entity.MaDV}', N'{entity.TenDV}', N'{entity.MoTa}')";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}


		public void Update(PhongBan entity)
		{
			Db.Open();

			string query = $"update PhongBan set TenDV = N'{entity.TenDV}', MoTa = N'{entity.MoTa}' where MaDV='{entity.MaDV}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public void Delete(string condition)
		{
			Db.Open();

			string query = $"delete from PhongBan where MaDV = '{condition}' or TenDV = '{condition}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public IEnumerable<PhongBan> Find(string filter)
		{
			Db.Open();

			string query = $"select * from PhongBan where MaDV like N'%{filter}%' or TenDV like N'%{filter}%'";

			var result = Db.Query<PhongBan>(
				query,
				commandType: CommandType.Text
				).ToList() ;

			Db.Close();

			return result;
		}
	}
}
