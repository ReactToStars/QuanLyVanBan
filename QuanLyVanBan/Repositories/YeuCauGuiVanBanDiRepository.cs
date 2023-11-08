using QuanLyVanBan.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Linq;
using QuanLyVanBan.DTOs;

namespace QuanLyVanBan.Repositories
{
	public class YeuCauGuiVanBanDiRepository
	{
		public IDbConnection Db => new SqlConnection(Connection.ConnectionString);

		public void Add(YeuCauGuiVanBanDi entity)
		{
			Db.Open();

			string query = $"insert into YeuCauGuiVanBanDi(SoPG, NgayPG, MaDV, TrichYeu, SL, DoKhan, DoMat, NoiNhan) values (N'{entity.SoPG}', '{entity.NgayPG}', N'{entity.MaDV}', N'{entity.TrichYeu}', '{entity.SL}', N'{entity.DoKhan}', N'{entity.DoMat}', N'{entity.NoiNhan}')";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public void Delete(string condition)
		{
			Db.Open();

			string query = $"delete from YeuCauGuiVanBanDi where SoPG = '{condition}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public IEnumerable<YeuCauVBDiDto> Find(string filter)
		{
			Db.Open();

			string query = $"select y.SoPG, y.NgayPG, p.TenDV, y.TrichYeu, y.SL, y.DoKhan, y.DoMat, y.NoiNhan from YeuCauGuiVanBanDi y join PhongBan p on y.MaDV = p.MaDV where SoPG = '{filter}' or NoiNhan like N'%{filter}%' or p.TenDV like N'%{filter}%' or y.TrichYeu like N'%{filter}%' y.NoiNhan like N'%{filter}%'";

			var result = Db.Query<YeuCauVBDiDto>(
				query,
				commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public YeuCauVBDiDto Get(string id)
		{
			Db.Open();

			string query = $"select y.SoPG, y.NgayPG, p.TenDV, y.TrichYeu, y.SL, y.DoKhan, y.DoMat, y.NoiNhan from YeuCauGuiVanBanDi y join PhongBan p on y.MaDV = p.MaDV where SoPG = '{id}'";
			var result = Db.Query<YeuCauVBDiDto>
				(
					query,
					commandType: CommandType.Text
				).FirstOrDefault();

			Db.Close();

			return result;
		}

		public YeuCauGuiVanBanDi GetExist(string id)
		{
			Db.Open();

			string query = $"select y.SoPG, y.NgayPG, p.TenDV, y.TrichYeu, y.SL, y.DoKhan, y.DoMat, y.NoiNhan from YeuCauGuiVanBanDi y join PhongBan p on y.MaDV = p.MaDV where SoPG = '{id}'";
			var result = Db.Query<YeuCauGuiVanBanDi>
				(
					query,
					commandType: CommandType.Text
				).FirstOrDefault();

			Db.Close();

			return result;
		}

		public IEnumerable<YeuCauVBDiDto> GetAll()
		{
			Db.Open();

			string query = $"select y.SoPG, y.NgayPG, p.TenDV, y.TrichYeu, y.SL, y.DoKhan, y.DoMat, y.NoiNhan from YeuCauGuiVanBanDi y join PhongBan p on y.MaDV = p.MaDV";
			var result = Db.Query<YeuCauVBDiDto>
				(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public void Update(YeuCauGuiVanBanDi entity)
		{
			Db.Open();

			string query = $"update YeuCauGuiVanBanDi set NgayPG = '{entity.NgayPG}', MaDV = N'{entity.MaDV}', TrichYeu = N'{entity.TrichYeu}', SL = '{entity.SL}', DoKhan = N'{entity.DoKhan}', DoMat = N'{entity.DoMat}', NoiNhan = N'{entity.NoiNhan}' where SoPG = '{entity.SoPG}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}
	}
}
