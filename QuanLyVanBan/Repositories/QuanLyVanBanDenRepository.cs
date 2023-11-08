using QuanLyVanBan.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Linq;
using QuanLyVanBan.DTOs;

namespace QuanLyVanBan.Repositories
{
	public class QuanLyVanBanDenRepository
	{
		public IDbConnection Db => new SqlConnection(Connection.ConnectionString);

		public void Add(QuanLyVanBanDen entity)
		{
			Db.Open();

			string query = $"insert into QuanLyVanBanDen(SoVBden, Soden, NgayVBden, NoiGui, TrichYeu, DoMat, TepDinhKem, YKienChiDao, DonViThucHien, TrangThaiVB, GhiChu) values (N'{entity.SoVBden}', N'{entity.Soden}', '{entity.NgayVBden}', N'{entity.NoiGui}', N'{entity.TrichYeu}', N'{entity.DoMat}', N'{entity.TepDinhKem}', N'{entity.YKienChiDao}', N'{entity.DonViThucHien}', N'{entity.TrangThaiVB}', N'{entity.GhiChu}')";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public void Delete(string condition)
		{
			Db.Open();

			string query = $"delete from QuanLyVanBanDen where SoVBden = '{condition}' or Soden = '{condition}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public void Delete(string soVBden, string soDen)
		{
			Db.Open();

			string query = $"delete from QuanLyVanBanDen where SoVBden= '{soVBden}' and soDen = '{soDen}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public IEnumerable<QuanLyVanBanDen> Find(string filter)
		{
			Db.Open();

			string query = $"select d.SoVBden, d.Soden, d.NgayVBden, d.NoiGui, d.TrichYeu, d.DoMat, d.TepDinhKem, d.YKienChiDao, d.DonViThucHien, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDen d where d.SoVBden like '%{filter}%' or d.Soden like '%{filter}%' or d.NoiGui like N'%{filter}%' or d.TrichYeu like N'%{filter}%' or d.YKienChiDao like N'%{filter}%' or d.DonViThucHien like N'%{filter}%'";

			var result = Db.Query<QuanLyVanBanDen>(
				query,
				commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public IEnumerable<QuanLyVanBanDen> Get(string id)
		{
			Db.Open();

			string query = $"select d.SoVBden, d.Soden, d.NgayVBden, d.NoiGui, d.TrichYeu, d.DoMat, d.TepDinhKem, d.YKienChiDao, d.DonViThucHien, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDen d where d.SoVBden='{id}' or d.Soden='{id}'";
			var result = Db.Query<QuanLyVanBanDen>
				(
					query,
					commandType: CommandType.Text
				);

			Db.Close();

			return result;
		}

		public QuanLyVanBanDen Get(string soVBden, string soDen)
		{
			Db.Open();

			string query = $"select d.SoVBden, d.Soden, d.NgayVBden, d.NoiGui, d.TrichYeu, d.DoMat, d.TepDinhKem, d.YKienChiDao, d.DonViThucHien, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDen d where d.SoVBden= '{soVBden}' and d.soDen = '{soDen}'";
			var result = Db.Query<QuanLyVanBanDen>
				(
					query,
					commandType: CommandType.Text
				).FirstOrDefault();

			Db.Close();

			return result;
		}

		public IEnumerable<QuanLyVanBanDen> GetAll()
		{
			Db.Open();

			string query = $"select d.SoVBden, d.Soden, d.NgayVBden, d.NoiGui, d.TrichYeu, d.DoMat, d.TepDinhKem, d.YKienChiDao, d.DonViThucHien, d.TrangThaiVB, d.GhiChu from QuanLyVanBanDen d";
			var result = Db.Query<QuanLyVanBanDen>
				(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public void Update(QuanLyVanBanDen entity)
		{
			Db.Open();

			string query = $"update QuanLyVanBanDen set NgayVBden = '{entity.NgayVBden}', NoiGui = N'{entity.NoiGui}', TrichYeu = N'{entity.TrichYeu}', DoMat = N'{entity.DoMat}', TepDinhKem = N'{entity.TepDinhKem}', YKienChiDao = N'{entity.YKienChiDao}', DonViThucHien = N'{entity.DonViThucHien}', TrangThaiVB = N'{entity.TrangThaiVB}', GhiChu = N'{entity.GhiChu}' where SoVBden = '{entity.SoVBden}' and Soden = '{entity.Soden}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}
	}
}
