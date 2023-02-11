--lấy dữ liêuj cho bảng tạo hóa đơn xuất
go 
create proc LoadDataHD_X
as
begin
	select distinct SO_HD_XUAT, NGAYLAP_XUAT, TENKH , TENNV , FLAGXUAT from HOADON_XUAT hd , KHACHHANG kh, NHANVIEN nv
	where hd.MAKH = kh.MAKH and hd.MANV = nv.MANV
end
go 
create proc LoadDataHD_N
as
begin
	select distinct SO_HD_NHAP, NGAYLAP_NHAP, TENNCC , TENNV ,FLAGNHAP from HOADON_NHAP hd , NHACUNGCAP cc, NHANVIEN nv
	where hd.MANCC = cc.MANCC and hd.MANV = nv.MANV
end
exec LoadDataHD_N
go
create proc update_kh
@maKH varchar(30),
@tenkh nvarchar(50),
@diachi nvarchar(50),
@gioitinh nvarchar(10),
@sdt varchar(10)
as
begin
	update KHACHHANG set TENKH =@tenkh,DIACHI = @diachi, GIOITINH =@gioitinh,SDT =@sdt
	where MAKH =@maKH
end
exec update_KH @makh = 'NV01',@tenkh = N'Tuan',@diachi = N'nha',@gioitinh = 'Nam',@sdt= '4234'
go
create proc LoadData_Kho
as 
begin
	select h.TENHH, h.DONVI_TINH, k.SOLUONG, h.XUATXU from KHO k, HANGHOA h
	where k.MAHH = h.MAHH
end
go
create proc Search_ID_KH
@Search VARCHAR(10)
AS
BEGIN
	select * from KHACHHANG k
	where k.MAKH = @Search
END
drop proc LoadDataHD_X

go
create proc Search_Ten_KH
@Search NVARCHAR(10)
AS
BEGIN
	select * from KHACHHANG k
	where k.TENKH = @Search
END
--them  hoa don xuat
go 
create proc insert_HDX
@SOHD varchar(10),
@TenKH nvarchar(30),
@TenNV nvarchar(30),
@ngaylap date,
@trangthai nvarchar(20)
as
begin
	DECLARE @MANV VARCHAR(15)
		SET @MANV =(select MANV from NHANVIEN where TENNV = @TENNV)
	DECLARE @MAKH VARCHAR(15)
		SET @MAKH =(select MAKH from KHACHHANG where TENKH = @TenKH)
	insert into HOADON_XUAT values (@SOHD,@MAKH,@MANV,@ngaylap,@trangthai)
end
--exec insert_HDX @Sohd = '',@tenkh = N'',@tennv= N'', @ngaylap = '',@trangthai = N''
--Xuat hang theo ten loai
go 
create proc Hang_LoaiHang
@tenloai varchar(10)
as
begin
	DECLARE @maloai VARCHAR(15)
		SET @maloai =(select MALOAI from LOAIHANG where TENLOAI = @tenloai)
	select h.TENHH, h.DONVI_TINH, k.SOLUONG, h.XUATXU from KHO k, HANGHOA h, LOAIHANG l
	where k.MAHH = h.MAHH and l.MALOAI = h.MALOAI and l.MALOAI = @maloai
end
--drop proc Hang_LoaiHang
--exec Hang_LoaiHang @tenloai = N'Tôn'
go 
create proc update_hdx

@TenKH nvarchar(30),
@TenNV nvarchar(30),
@ngaylap date,
@trangthai nvarchar(20)
as
begin
	DECLARE @MANV VARCHAR(15)
		SET @MANV =(select MANV from NHANVIEN where TENNV = @TENNV)
	DECLARE @MAKH VARCHAR(15)
		SET @MAKH =(select MAKH from KHACHHANG where TENKH = @TenKH)
	update HOADON_XUAT set MAKH=@MAKH,MANV=@MANV,NGAYLAP_XUAT=@ngaylap, FLAGXUAT = @trangthai
end
--exec update_hdx @tenkh = N'',@tenNV = N'',@ngaylap = '', @trangthai=N''
go
create proc Chitiet_HDX
@So_hdx varchar(10)
as 
begin
	select h.TENHH, h.DONVI_TINH, ct.SOLUONG_XUAT, DONGIA_XUAT, DONGIA_XUAT*SOLUONG_XUAT as thanhtien,h.XUATXU,k.SOLUONG 
	from HANGHOA h ,CHITIET_HD_XUAT ct , HOADON_XUAT hd,KHO k
	where h.MAHH = ct.MAHH and hd.SO_HD_XUAT = ct.SO_HD_XUAT and ct.IDKHO = k.IDKHO and k.MAHH = h.MAHH and hd.SO_HD_XUAT = @So_hdx
end
--exec Chitiet_HDX @So_hdx = 'HĐX05' 
--Them Hoa don nhap
go 
create proc insert_HDN
@SOHD varchar(10),
@Tenncc nvarchar(30),
@TenNV nvarchar(30),
@ngaylap date,
@trangthai nvarchar(20)
as
begin
	DECLARE @MANV VARCHAR(15)
		SET @MANV =(select MANV from NHANVIEN where TENNV = @TENNV)
	DECLARE @MAncc VARCHAR(15)
		SET @MAncc =(select @MAncc from NHACUNGCAP where TENNCC = @Tenncc)
	insert into HOADON_XUAT values (@SOHD,@MAncc,@MANV,@ngaylap,@trangthai)
end


insert into HANGHOA (MAHH, TENHH, DONVI_TINH,XUATXU, MALOAI) values ('',N'',N'',N'','')
go 
create proc LoadData_HH
as
begin
	select distinct l.MALOAI, h.MAHH, h.TENHH, h.DONVI_TINH, h.XUATXU
	from HANGHOA h, LOAIHANG l
	where l.MALOAI = h.MALOAI

end
exec LoadData_HH
exec Chitiet_HDX @So_hdx = 'HĐX05'

select distinct k.TENKH, k.DIACHI ,k.SDT,nv.TENNV,hd.NGAYLAP_XUAT
from HOADON_XUAT hd, KHACHHANG k, NHANVIEN nv
where 
	  hd.MANV = nv.MANV and
	  hd.MAKH = k.MAKH and
	  hd.SO_HD_XUAT = 'HDX01'
go
create proc LoadLabel_HDX
@Sohd varchar(15)
as
begin
	select distinct k.TENKH, k.DIACHI ,k.SDT,nv.TENNV,hd.NGAYLAP_XUAT, hd.FLAGXUAT
from HOADON_XUAT hd, KHACHHANG k, NHANVIEN nv
where 
	  hd.MANV = nv.MANV and
	  hd.MAKH = k.MAKH and
	  hd.SO_HD_XUAT = @Sohd
end
--exec LoadLabel_HDX @sohd = 'HDX05'
go
create proc Chitiet_HDN
@Sohd varchar(10)
as 
begin
	select  h.TENHH, h.DONVI_TINH, ct.SOLUONG_NHAP, ct.DONGIA_NHAP, ct.DONGIA_NHAP*ct.SOLUONG_NHAP as thanhtien, hd.FLAGNHAP
	from  HOADON_NHAP hd, HANGHOA h, CHITIET_HD_NHAP ct 
	where h.MAHH = ct.MAHH and hd.SO_HD_NHAP = ct.SO_HD_NHAP and hd.SO_HD_NHAP = @Sohd
end
--exec Chitiet_HDN @sohd = 'HDN05'
go
create proc LoadLabel_HDN
@Sohd varchar(15)
as
begin
	select distinct cc.TENNCC, nv.TENNV, hd.NGAYLAP_NHAP, hd.FLAGNHAP
from HOADON_NHAP hd, NHACUNGCAP cc, NHANVIEN nv
where 
	  hd.MANV = nv.MANV and
	  hd.MANCC = cc.MANCC and
	  hd.SO_HD_NHAP = @Sohd
end
exec LoadLabel_HDN @sohd = 'HDN05'