--CREATE DATABASE
USE master
GO
IF EXISTS (SELECT name FROM sysdatabases WHERE name = N'QuanLyVanBan')
BEGIN
    DROP DATABASE QuanLyVanBan
END

CREATE DATABASE QuanLyVanBan
GO

USE QuanLyVanBan
GO

CREATE TABLE TaiKhoan
(
	MaTK		NVARCHAR(10) PRIMARY KEY
	,TenTK		NVARCHAR(50) UNIQUE NOT NULL
	,Ten		NVARCHAR(50)
	,MatKhau	NVARCHAR(10)
	,NgaySinh	DATE
	,ChucVu		NVARCHAR(50)
	,DienThoai	NVARCHAR(20)
	,MaDV		NVARCHAR(10)
	,NgayTao	DATE
	,NguoiTao	NVARCHAR(50)
)
GO

CREATE TABLE PhongBan
(
	MaDV		NVARCHAR(10) PRIMARY KEY
	,TenDV		NVARCHAR(50)
	,MoTa		NVARCHAR(100)
)
GO

CREATE TABLE QuanLyVanBanDi
(
	SoVBdi			NVARCHAR(10) 
	,SoPG			NVARCHAR(10) 
	,NoiNhan		NVARCHAR(50) 
	,NgayVBdi		Date
	,MaDV			NVARCHAR(10)
	,DoMat			NVARCHAR(10)
	,NDtrichyeu		NVARCHAR(50)
	,NguoiKy		NVARCHAR(50)
	,SoBanDongDau	INT
	,TepDinhKem		TEXT
	,TrangThaiVB	NVARCHAR(10)
	,GhiChu			NVARCHAR(50)
	,CONSTRAINT PK_QuanLyVanBanDi PRIMARY KEY CLUSTERED (SoVBdi, SoPG, NoiNhan)
)
GO

CREATE TABLE QuanLyVanBanDen
(
	SoVBden			NVARCHAR(10) 
	,Soden			NVARCHAR(10) 
	,NgayVBden		Date
	,NoiGui			NVARCHAR(50)
	,TrichYeu		NVARCHAR(50)
	,DoMat			NVARCHAR(10)
	,TepDinhKem		TEXT
	,YKienChiDao	NVARCHAR(50)
	,DonViThucHien	NVARCHAR(10) 
	,TrangThaiVB	NVARCHAR(10)
	,GhiChu			NVARCHAR(50)
	,CONSTRAINT PK_QuanLyVanBanDen PRIMARY KEY CLUSTERED(SoVBden, Soden)
)
GO

CREATE TABLE YeuCauGuiVanBanDi
(
	SoPG		NVARCHAR(10) PRIMARY KEY
	,NgayPG		Date
	,MaDV		NVARCHAR(10) NOT NULL
	,TrichYeu	NVARCHAR(50)
	,SL			INT
	,DoKhan		NVARCHAR(10)
	,DoMat		NVARCHAR(10)
	,NoiNhan	NVARCHAR(50)
)
GO

--CREATE TABLE GiaoVanBanDen
--(
--	Soden		NVARCHAR(10)
--	,SoVBden	NVARCHAR(10)
--	,MaDV		NVARCHAR(10)
--	,NgayGiao	Date
--	,TenDV		NVARCHAR(50)
--	,TrichYeu	NVARCHAR(50)
--	,TepDinhKem	TEXT
--	,DoKhan		NVARCHAR(10)
--	,DoMat		NVARCHAR(10)
--	,SoTrang	INT
--	,CONSTRAINT PK_GiaoVanBanDen PRIMARY KEY CLUSTERED (Soden, SoVBden, MaDV)
--)
--GO

--ADD FOREIGN KEY
ALTER TABLE TaiKhoan
ADD FOREIGN KEY (MaDV) REFERENCES PhongBan(MaDV);
GO

ALTER TABLE YeuCauGuiVanBanDi
ADD FOREIGN KEY (MaDV) REFERENCES PhongBan(MaDV);
GO

--ALTER TABLE GiaoVanBanDen
--ADD FOREIGN KEY (MaDV) REFERENCES PhongBan(MaDV);
--GO

ALTER TABLE QuanLyVanBanDi
ADD FOREIGN KEY (SoPG) REFERENCES YeuCauGuiVanBanDi(SoPG);
GO

--ALTER TABLE GiaoVanBanDen
--ADD FOREIGN KEY (SoVBden) REFERENCES QuanLyVanBanDen(SoVBden);
GO

--INITIAL VALUE
INSERT INTO PhongBan (MaDV, TenDV, MoTa) VALUES 
('DV1', N'Don Vi 1', N'Don Vi 1')
,('DV2', N'Don Vi 2', N'Don Vi 2')
,('DV3', N'Don Vi 3', N'Don Vi 3')
,('DV4', N'Don Vi 4', N'Don Vi 4')
,('DV5', N'Don Vi 5', N'Don Vi 5')
GO

INSERT INTO TaiKhoan (MaTK, TenTK, Ten, MatKhau, NgaySinh, ChucVu, DienThoai, MaDV, NgayTao, NguoiTao) VALUES
('user', 'user', N'Phan Thị Mỹ Lộc', 'Password1', '1998-03-24', N'Cán bộ văn thư', '0123456789', 'DV1', '2023-01-15', N'Nguyễn Văn Hùng')
,('user1', 'user1', N'Nguyễn Mậu Thịnh', 'Password1', '1997-03-24', N'Cán bộ hành chính', '0126586789', 'DV2', '2023-01-15', N'Nguyễn Văn Hùng')
,('user2', 'user2', N'Phan Thị Mỹ Lộc', 'Password1', '1998-04-25', N'Cán bộ văn thư', '0123486789', 'DV3', '2023-01-15', N'Nguyễn Văn Hùng')
,('user3', 'user3', N'Nguyễn Văn A', 'Password1', '1991-03-24', N'Lãnh đạo phòng', '0123434899', 'DV1', '2014-02-15', N'Nguyễn Văn Hùng')
,('user4', 'user4', N'Nguyễn Văn B', 'Password1', '1991-03-24', N'Ban giám hiệu', '0123434899', 'DV2', '2014-02-15', N'Nguyễn Văn Hùng')
,('admin', 'admin', N'Nguyễn Văn Hùng', 'Password1', '1992-03-24', N'Cán bộ quản trị', '0123453485', 'DV1', '2015-01-15', N'')
GO

INSERT INTO YeuCauGuiVanBanDi (SoPG, NgayPG, MaDV, TrichYeu, SL, DoKhan, DoMat, NoiNhan)
VALUES
('01', '2023-04-25', 'DV1', N'Đây là nội dung quan trọng', 6, N'Không', N'Mật', N'Phòng 1')
,('02', '2023-04-25', 'DV1', N'Đây là nội dung quan trọng', 4, N'Khẩn', N'Không', N'Phòng 1')
,('03', '2023-04-25', 'DV2', N'Đây là nội dung quan trọng', 5, N'Không', N'Mật', N'Phòng 1')
GO

INSERT INTO QuanLyVanBanDen (SoVBden, Soden, NgayVBden, NoiGui, TrichYeu, DoMat, TepDinhKem, YKienChiDao, DonViThucHien, TrangThaiVB, GhiChu)
VALUES 
('01', '01', '2023-05-24', 'Phòng 1', N'Đây là nội dung quan trọng', N'Mật', 'D:\Docs\tep.txt', N'Làm y như thế là được', 'DV1', N'Đã nhận', '')
,('02', '02', '2023-05-24', 'Phòng 2', N'Đây là nội dung quan trọng', N'Không', 'D:\Docs\tep1.txt', N'Làm y như thế là được', 'DV1', N'Đã nhận', '')
,('03', '03', '2023-05-24', 'Phòng 3', N'Đây là nội dung quan trọng', N'Mật', 'D:\Docs\tep2.txt', N'Làm y như thế là được', 'DV2', N'Đã nhận', '')
GO

INSERT INTO QuanLyVanBanDi (SoVBdi, SoPG, NoiNhan, NgayVBdi, MaDV, DoMat, NDtrichyeu, NguoiKy, SoBanDongDau, TepDinhKem, TrangThaiVB, GhiChu)
VALUES
('01', '01', N'Phòng 1', '2023-04-28', 'DV1', N'Mật', N'Đây là nội dung quan trọng', 'admin', 5, 'D:\Docs\tep.txt', N'Đã gửi', '')
,('02', '02', N'Phòng 1', '2023-04-28', 'DV1', N'Mật', N'Đây là nội dung quan trọng', 'admin', 4, 'D:\Docs\tep.txt', N'Đã gửi', '')
,('03', '03', N'Phòng 1', '2023-04-28', 'DV1', N'Mật', N'Đây là nội dung quan trọng', 'admin', 10, 'D:\Docs\tep.txt', N'Đã gửi', '')
