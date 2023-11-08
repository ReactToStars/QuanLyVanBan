using Dapper;
using QuanLyVanBan.DTOs;
using QuanLyVanBan.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyVanBan.Repositories
{
	public class TaiKhoanRepository
	{
		public IDbConnection Db => new SqlConnection(Connection.ConnectionString);

		public void Add(TaiKhoan entity)
		{
			Db.Open();

			string query = $"insert into TaiKhoan(MaTK, TenTK, Ten, MatKhau, NgaySinh, ChucVu, DienThoai, MaDV, NgayTao, NguoiTao) values (N'{entity.MaTK}', N'{entity.TenTK}', N'{entity.Ten}', N'{entity.MatKhau}', '{entity.NgaySinh}', N'{entity.ChucVu}', '{entity.DienThoai}', '{entity.MaDV}', '{entity.NgayTao}', N'{entity.NguoiTao}')";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public void Delete(string condition)
		{
			Db.Open();

			string query = $"delete from TaiKhoan where TenTK = '{condition}' or MaTK = '{condition}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}

		public IEnumerable<TaiKhoanDto> Find(string filter)
		{
			Db.Open();

			string query = $"select n.MaTK, n.TenTk, n.Ten, n.NgaySinh, n.ChucVu, n.DienThoai, p.TenDV, n.NgayTao, n.NguoiTao from TaiKhoan n join PhongBan p on n.MaDV = p.MaDV where MaTK like N'%{filter}%' or TenTK like N'%{filter}%' or n.Ten like N'%{filter}%' or n.MaDV = '{filter}' or n.DienThoai like '%{filter}%' or n.NguoiTao like N'%{filter}%' or n.ChucVu like N'%{filter}%'";

			var result = Db.Query<TaiKhoanDto>(
				query,
				commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public TaiKhoanDto Get(string id)
		{
			Db.Open();

			string query = $"select n.MaTK, n.TenTk, n.Ten, n.NgaySinh, n.ChucVu, n.DienThoai, p.TenDV, n.NgayTao, n.NguoiTao from TaiKhoan n join PhongBan p on n.MaDV = p.MaDV where TenTK = '{id}' or MaTK = '{id}'";
			var result = Db.Query<TaiKhoanDto>
				(
					query,
					commandType: CommandType.Text
				).FirstOrDefault();

			Db.Close();

			return result;
		}

		public TaiKhoan GetUser(string id)
		{
			Db.Open();

			string query = $"select * from TaiKhoan where TenTK = '{id}' or MaTK = '{id}'";
			var result = Db.Query<TaiKhoan>
				(
					query,
					commandType: CommandType.Text
				).FirstOrDefault();

			Db.Close();

			return result;
		}

		public IEnumerable<TaiKhoanDto> GetAll()
		{
			Db.Open();

			string query = $"select n.MaTK, n.TenTk, n.Ten, n.NgaySinh, n.ChucVu, n.DienThoai, p.TenDV, n.NgayTao, n.NguoiTao from TaiKhoan n join PhongBan p on n.MaDV = p.MaDV order by n.NgayTao desc";
			var result = Db.Query<TaiKhoanDto>
				(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public IEnumerable<TaiKhoan> GetData()
		{
			Db.Open();

			string query = $"select * from TaiKhoan";
			var result = Db.Query<TaiKhoan>
				(
					query,
					commandType: CommandType.Text
				).ToList();

			Db.Close();

			return result;
		}

		public void Update(TaiKhoan entity)
		{
			Db.Open();

			string query = $"update TaiKhoan set TenTK = N'{entity.TenTK}', Ten = N'{entity.Ten}', MatKhau = N'{entity.MatKhau}', NgaySinh = N'{entity.NgaySinh}', ChucVu = N'{entity.ChucVu}', DienThoai = N'{entity.DienThoai}', MaDV = N'{entity.MaDV}' where MaTK = '{entity.MaTK}'";

			Db.Execute(
				query,
				commandType: CommandType.Text
				);

			Db.Close();
		}
	}
}
