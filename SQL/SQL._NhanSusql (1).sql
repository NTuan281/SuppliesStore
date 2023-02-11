--Xóa mã nhân viên 
go 
create proc DELETE_NV
@MANV varchar(15)
as 
begin 
	delete from NGUOIDUNG_NHANVIEN
	where MANV = @MANV
	delete from NHANVIEN
	where MANV = @MANV
end
--exec DELETE_NV @manv = 'NV06'

--update nhân viên 
go
create proc update_nv
@manv varchar(30),
@tennv nvarchar(50),
@diachi nvarchar(50),
@gioitinh nvarchar(10),
@ngaysinh datetime,
@sdt varchar(10)
as
begin
	update NHANVIEN set TENNV =@tennv,DIACHI = @diachi, GIOITINH =@gioitinh,NGAYSINH =@ngaysinh,SDT =@sdt
	where MANV =@manv
end
--exec update_nv @manv = '',
--			   @tennv = '',
--			   @diachi = '',
--			   @gioitinh = '',
--			   @ngaysinh = '',
--			   @sdt= ''
go
create proc insert_nv
@manv varchar(30),
@tennv nvarchar(50),
@diachi nvarchar(50),
@gioitinh nvarchar(10),
@ngaysinh datetime,
@sdt varchar(10)
as
begin
	insert into NHANVIEN values( @manv, @tennv,@gioitinh, @ngaysinh, @diachi,  @sdt , 'Nhân viên')
end

go 
create proc TuoiNV
@ngaysinh datetime
as
begin
	select year (GETDATE()) - YEAR(@ngaysinh) 
end
--drop proc TuoiNV
exec TuoiNV @ngaysinh = '19900312'
delete from HANGHOA where MAHH = 'Xm01'