go
CREATE PROC TK_KH
AS
BEGIN
	SELECT DISTINCT MAKH, TENKH, DIACHI, SDT  FROM dbo.KHACHHANG
END

go
CREATE PROC TK_NCC
AS
BEGIN
	SELECT DISTINCT MANCC, TENNCC, DIACHI, SDT  FROM dbo.NHACUNGCAP
END
exec TK_NCC
go
CREATE PROC TK_LH
AS
BEGIN
	SELECT DISTINCT MALOAI, TENLOAI, DIENGIAI, FLAG  FROM dbo.LOAIHANG
END
exec TK_LH
go
CREATE PROC TK_HH
AS
BEGIN
	SELECT DISTINCT H.MAHH, H.TENHH, LH.TENLOAI, H.DONVI_TINH, h.XUATXU  FROM dbo.HANGHOA H, dbo.LOAIHANG LH
	where H.MALOAI =LH.MALOAI
END

exec TK_HH

Go 
create PROC BC_XUAT
AS
BEGIN
	SELECT DISTINCT ct.MAHH, h.TENHH, h.DONVI_TINH, ct.SOLUONG_XUAT,ct.DONGIA_XUAT, hd.NGAYLAP_XUAT 
	FROM dbo.CHITIET_HD_XUAT ct, dbo.HANGHOA h, dbo.HOADON_XUAT hd
	where 
	
	ct.MAHH = h.MAHH and 
	ct.SO_HD_XUAT = hd.SO_HD_XUAT 
END
Go 
create PROC BC_XUAT_TheoTenKH
@tungay date,
@toingay date,
@tenkh nvarchar(30)
AS
BEGIN
	DECLARE @MAKH VARCHAR(15)
		SET @MAKH =(select MAKH from KHACHHANG where TENKH = @tenkh)
	SELECT DISTINCT ct.MAHH, h.TENHH, h.DONVI_TINH, ct.SOLUONG_XUAT,ct.DONGIA_XUAT, hd.NGAYLAP_XUAT 
	FROM dbo.CHITIET_HD_XUAT ct, dbo.HANGHOA h, dbo.HOADON_XUAT hd
	where 
	ct.MAHH = h.MAHH and 
	ct.SO_HD_XUAT = hd.SO_HD_XUAT and
	NGAYLAP_XUAT > @tungay and NGAYLAP_XUAT < @toingay
	and MAKH = @MAKH
END
--drop proc BC_XUAT_TheoTenKH 

update NGUOIDUNG set PASSWORD = 123
           WHERE NGUOIDUNG.USERNAME = 'Em' 
Go 
create PROC DELETE_ND
@USERNAME VARCHAR (15)
AS
BEGIN
	delete from NGUOIDUNG
	where USERNAME = @USERNAME
END
Go 
create PROC DELETE_TK_ND
@USERNAME VARCHAR (15)
AS
BEGIN
	delete from NGUOIDUNG_NHANVIEN
	where USERNAME = @USERNAME
END
Go 
create PROC UPDATE_ND1
@USERNAME VARCHAR(15)
AS
BEGIN
	update NGUOIDUNG set ACTIVE  =  N'Chưa thể sử dụng'
           WHERE NGUOIDUNG.USERNAME = @USERNAME
END
Go 
create PROC UPDATE_ND2
@USERNAME VARCHAR(15)
AS
BEGIN
	update NGUOIDUNG set ACTIVE  =  N'Đang hoạt động'
           WHERE NGUOIDUNG.USERNAME = @USERNAME
END
Go 
create PROC UPDATE_ND
@PASSWORD VARCHAR (15),
@USERNAME VARCHAR (15)
AS
BEGIN
	update NGUOIDUNG set PASSWORD = @PASSWORD
           WHERE NGUOIDUNG.USERNAME = @USERNAME
END
go
delete from NGUOIDUNG_NHANVIEN
where ID_NHANVIEN = 11
go
create PROC INSERT_TK_ND
@TENNV NVARCHAR(50) 
AS
BEGIN
	DECLARE @MANV VARCHAR(15)
	SET @MANV =(
	select MANV from NHANVIEN
	where TENNV = @TENNV)
END
go
create PROC INSERT_TK_ND
@USERNAME VARCHAR(15),
@TENNV NVARCHAR(50) 
AS
BEGIN
	DECLARE @MANV VARCHAR(15)
	SET @MANV =(
	select MANV from NHANVIEN
	where TENNV = @TENNV)
	insert into NGUOIDUNG_NHANVIEN (USERNAME,MANV)
	values (@USERNAME, @MANV)
END
--exec INSERT_TK_ND @USERNAME = 'Em', @TENNV =N'Anh Tuấn'
go
create PROC INSERT_ND
@1 VARCHAR(15),
@2 varchar (15),
@3 varchar(15),
@4  NVARCHAR(30)
AS
BEGIN
	insert into NGUOIDUNG
	values (@1,@2,@3,@4 )
END
go
--exec INSERT_ND @1 = 'nhi1',@2 = '123',@3 = 'Admin',@4 = N'Đang hoạt động'
go
--exec DELETE_ND @username = 'nhi1'
go
create proc data_TK_ND
as
begin
	select NN.USERNAME, NV.TENNV from NGUOIDUNG_NHANVIEN NN, NHANVIEN NV
	where NN.MANV = NV.MANV
end
--exec data_TK_ND
go
create proc UPDATE_TK_NV
@TENNV Nvarchar(50),
@USERNAME varchar(30)
as
begin
	DECLARE @MANV VARCHAR(15)
		SET @MANV =(select MANV from NHANVIEN where TENNV = @TENNV)
	Update NGUOIDUNG_NHANVIEN set MANV =  @MANV
	where USERNAME = @USERNAME
end
--exec UPDATE_TK_NV @TENNV = N'Anh Tuấn' , @username = 'Em'
--UPDATE PASSWORD
go 
create proc Change_password
@1 varchar (30), 
@2 varchar (15)
as 
begin
	UPDATE NGUOIDUNG set  PASSWORD = @2
	where USERNAME = @1
end
drop proc Change_password
--exec Change_password  @1 = 'Em' , @2 = 'anhtuan#!*'
--xuat mat khau cu
go 
create proc old_password
@USERNAME varchar(30)
as
begin
	select PASSWORD from NGUOIDUNG
	where USERNAME = @USERNAME
end
--exec old_password @USERNAME = 'sdasf' 
--drop proc BC_Nhap
go 
create proc BC_Kho
as
begin
	select k.MAHH, h.TENHH, k.SOLUONG, h.XUATXU from KHO k , HANGHOA h
	where k.MAHH = h.MAHH
end
go
create proc BC_Nhap
as
begin
SELECT DISTINCT ncc.TENNCC, h.TENHH, h.DONVI_TINH, ct.SOLUONG_NHAP,ct.DONGIA_NHAP, hd.NGAYLAP_NHAP
	FROM dbo.CHITIET_HD_NHAP ct, dbo.HANGHOA h, dbo.HOADON_NHAP hd,NHACUNGCAP ncc
	where 
	hd.MANCC = ncc.MANCC and
	ct.MAHH = h.MAHH and 
	ct.SO_HD_NHAP = hd.SO_HD_NHAP
end
