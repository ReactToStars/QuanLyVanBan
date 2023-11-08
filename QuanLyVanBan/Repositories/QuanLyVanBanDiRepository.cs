using Dapper;
using QuanLyVanBan.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyVanBan.Repositories
{
	public class QuanLyVanBanDiRepository
	{
		public IDbConnection Db => new SqlConnection(Connection.ConnectionString);

		public void Add(QuanLyVanBanDi entity)
		{
			Db.Open();

			string query = $"insert into QuanLyVanBanDi(SoVBdi, SoPG, NoiNhan, NgayVBdi, MaDV, DoMat, NDtrichyeu, NguoiKy, SoBanDongDau, TepDinhKem, TrangThaiVB, GhiChu) values (N'{entity.SoVBdi}', N'{entity.SoPG}', N'{entity.NoiNhan}', '{entity.NgayVBdi}', N'{entity.MaDV}', N'{entity.DoMat}', N'{entity.NDtrichyeu}', N'{entity.NguoiKy}', N'{entity.SoBanDongDau}', N'{entity.TepDinhKem}', N'{entity.TrangThaiVB}', N'{entity.GhiChu}')";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public void Delete(string condition)
		{
			Db.Open();

			string query = $"delete from QuanLyVanBanDi where SoVBdi = '{condition}' or SoPG = '{condition}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public void Delete(string soVBdi, string soPG, string noiNhan)
		{
			Db.Open();

			string query = $"delete from QuanLyVanBanDi where SoVBdi= '{soVBdi}' and SoPG = '{soPG}' and NoiNhan = '{noiNhan}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public IEnumerable<QuanLyVanBanDi> Find(string filter)
		{
			Db.Open();

			string query = $"select d.SoVBdi, d.SoPG, d.NoiNhan, d.NgayVBdi, d.MaDV, d.DoMat, d.NDtrichyeu, d.NguoiKy, d.SoBanDongDau, d.TepDinhKem, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDi d where SoVBdi like '%{filter}%' or SoPG like '%{filter}%' or NoiNhan like N'{filter}' or d.NDtrichyeu like N'%{filter}%' or d.NguoiKy like N'%{filter}%' or d.MaDV like N'%{filter}%'";

			var result = Db.Query<QuanLyVanBanDi>(
				query,
				commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public IEnumerable<QuanLyVanBanDi> Get(string id)
		{
			Db.Open();

			string query = $"select d.SoVBdi, d.SoPG, d.NoiNhan, d.NgayVBdi, d.MaDV, d.DoMat, d.NDtrichyeu, d.NguoiKy, d.SoBanDongDau, d.TepDinhKem, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDi d where SoVBdi='{id}' or SoPG='{id}' or d.NoiNhan= '{id}'";
			var result = Db.Query<QuanLyVanBanDi>
				(
					query,
					commandType: CommandType.Text
				);

			Db.Close();

			return result;
		}

		public QuanLyVanBanDi Get(string soVBdi, string soPG, string noiNhan)
		{
			Db.Open();

			string query = $"select d.SoVBdi, d.SoPG, d.NoiNhan, d.NgayVBdi, d.MaDV, d.DoMat, d.NDtrichyeu, d.NguoiKy, d.SoBanDongDau, d.TepDinhKem, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDi d where SoVBdi= '{soVBdi}' and SoPG = '{soPG}' and NoiNhan = '{noiNhan}'";
			var result = Db.Query<QuanLyVanBanDi>
				(
					query,
					commandType: CommandType.Text
				).FirstOrDefault();

			Db.Close();

			return result;
		}

		public IEnumerable<QuanLyVanBanDi> GetAll()
		{
			Db.Open();

			string query = $"select d.SoVBdi, d.SoPG, d.NoiNhan, d.NgayVBdi, d.MaDV, d.DoMat, d.NDtrichyeu, d.NguoiKy, d.SoBanDongDau, d.TepDinhKem, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDi d";
			var result = Db.Query<QuanLyVanBanDi>
				(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public void Update(QuanLyVanBanDi entity)
		{
			Db.Open();

			string query = $"update QuanLyVanBanDi set NgayVBdi = '{entity.NgayVBdi}', MaDV = N'{entity.MaDV}', DoMat = N'{entity.DoMat}', NDtrichyeu = N'{entity.NDtrichyeu}', NguoiKy = N'{entity.NguoiKy}', SoBanDongDau = N'{entity.SoBanDongDau}', TepDinhKem = N'{entity.TepDinhKem}', TrangThaiVB = N'{entity.TrangThaiVB}', GhiChu = N'{entity.GhiChu}' where SoVBdi = '{entity.SoVBdi}' and SoPG = '{entity.SoPG}' and NoiNhan = N'{entity.NoiNhan}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}
	}
}
