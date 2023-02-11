--Delete CTHD_X
go 
create proc delete_CTHD_X
@sohd varchar(15),
@tenhh nvarchar(30),
@slkho int,
@sl int
as
begin
	DECLARE @MAHH VARCHAR(15)
		SET @MAHH =(select MAHH from HANGHOA where TENHH = @tenhh)
	delete from CHITIET_HD_XUAT where SO_HD_XUAT = @sohd and MAHH = @MAHH
	update KHO set SOLUONG = @slkho+@sl
	where MAHH = @MAHH
end
--exec delete_CTHD_X @sohd = '',@tenhh = N''

--update CTHD_X            
go
create proc Update_CTHD_X
@sohd varchar(15),
@tenhh nvarchar(30),
@slkho int,
@sl int,
@dongia int
as
begin 
	DECLARE @MAHH VARCHAR(15)
		SET @MAHH =(select MAHH from HANGHOA where TENHH = @tenhh)
	update CHITIET_HD_XUAT set  SOLUONG_XUAT = @sl, DONGIA_XUAT = @dongia
	where SO_HD_XUAT = @sohd and MAHH = @MAHH
	update KHO set SOLUONG = @slkho-@sl
	where MAHH = @MAHH
end
--exec Update_CTHD_X @sohd = '', @tenhh = N'',@slkho = 0,@sl = 0, @dongia = 0

--Insert CTHH_X
go 
create proc Insert_CTHD_X
@sohd varchar(15),
@tenhh nvarchar(30),
@slkho int,
@sl int,
@dongia int
as
begin 
	DECLARE @MAHH VARCHAR(15)
		SET @MAHH =(select MAHH from HANGHOA where TENHH = @tenhh)
	DECLARE @idkho VARCHAR(15)
		SET @idkho =(select IDKHO from KHO where MAHH = @MAHH)
	
	insert into CHITIET_HD_XUAT(IDKHO,SO_HD_XUAT,MAHH,SOLUONG_XUAT,DONGIA_XUAT) values (@idkho,@sohd,@MAHH,@sl,@dongia)
	
	update KHO set SOLUONG = @slkho-@sl
	where MAHH = @MAHH
end

--Delete CTHD_N
go 
create proc delete_CTHD_N
@sohd varchar(15),
@tenhh nvarchar(30)
as
begin
	DECLARE @MAHH VARCHAR(15)
		SET @MAHH =(select MAHH from HANGHOA where TENHH = @tenhh)
	delete from CHITIET_HD_NHAP where SO_HD_NHAP = @sohd and MAHH = @MAHH
end

--exec delete_CTHD_X @sohd = '',@tenhh = N''

--update CTHD_X            
go
create proc Update_CTHD_N
@sohd varchar(15),
@tenhh nvarchar(30),
@sl int,
@dongia int
as
begin 
	DECLARE @MAHH VARCHAR(15)
		SET @MAHH =(select MAHH from HANGHOA where TENHH = @tenhh)
	update CHITIET_HD_NHAP set  SOLUONG_NHAP = @sl, DONGIA_NHAP = @dongia
	where SO_HD_NHAP = @sohd and MAHH = @MAHH
end
--exec Update_CTHD_X @sohd = '', @tenhh = N'',@slkho = 0,@sl = 0, @dongia = 0

--Insert CTHH_X
go 
create proc Insert_CTHD_N
@sohd varchar(15),
@tenhh nvarchar(30),
@sl int,
@dongia int
as
begin 
	DECLARE @MAHH VARCHAR(15)
		SET @MAHH =(select MAHH from HANGHOA where TENHH = @tenhh)
	DECLARE @idkho VARCHAR(15)
		SET @idkho =(select IDKHO from KHO where MAHH = @MAHH)
	
	insert into CHITIET_HD_NHAP(MAHH,SO_HD_NHAP,SOLUONG_NHAP,DONGIA_NHAP) values (@mahh,@sohd,@sl,@dongia)
	
end
