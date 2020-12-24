use QLTV
create table DOCGIA
(
	MaDG nvarchar(10) primary key,
	TenDG nvarchar(50),
	DiaChi nvarchar(100),
	MaThe nvarchar(10),
	GhiChu nvarchar(100)
)

create table NGONNGU
(
	MaNN nvarchar(10) primary key,
	TenNN nvarchar(50)
)

create table NHANVIEN
(
	UserName nvarchar(50) primary key,
	HoTen nvarchar (100),
	NgaySinh date,
	SoDT nvarchar(10)
)

create table NHAXUATBAN
(
	MaNXB nvarchar(10) primary key,
	TenNXB nvarchar(100),
	DiaChi nvarchar(100),
	Email nvarchar(50),
	ThongTin nvarchar(100)
)

create table SACH
(
	MaSach nvarchar(10) primary key,
	Ten nvarchar(100),
	NamXB date,
	MaXB nvarchar(10),
	MaTG nvarchar(10),
	MaTL nvarchar(10),
	MaVT nvarchar(10),
	TinhTrang nvarchar(50),
	MaNN nvarchar(10)
)
create table TACGIA
(
	MaTG nvarchar(10) primary key,
	TenTG nvarchar(100),
	Website nvarchar(100),
	GhiChu nvarchar(100)
)

create table THELOAI
(
	MaTL nvarchar(10) primary key,
	TenTL nvarchar(100)
)

create table THETHUVIEN
(
	MaThe nvarchar(10) primary key,
	NgayBatDau datetime,
	NgayHetHan datetime,
	GhiChu nvarchar(100),
	TrangThai nvarchar(100)
)

create table VITRI
(
	MaVT nvarchar(10) primary key,
	Khu nvarchar(10),
	Ke nvarchar(10),
	Ngan nvarchar(10)
)

create table MUONTRA
(
	MaMuon nvarchar(10) primary key,
	MaThe nvarchar(10),
	UserName nvarchar(50),
	NgayMuon datetime,
	NgayHan datetime,
	
)

create table CTMT
(
	MaMuon nvarchar(10),
	MaSach nvarchar(10),
	NgayTra datetime,
	TrangThai bit,
	GhiChu nvarchar(100)
	primary key(MaMuon,MaSach)
)

create table USERS
(
	UserName nvarchar(50) primary key,
	PassWord nvarchar(50)
)

alter table DOCGIA add constraint FK_DG_THE foreign key(MaThe) references THETHUVIEN(MaThe)
alter table MUONTRA add constraint FK_MT_THE foreign key(MaThe) references THETHUVIEN(MaThe)
alter table MUONTRA add constraint FK_MT_NV foreign key(UserName) references NHANVIEN(UserName)
alter table CTMT add constraint FK_CTMT_MT foreign key(MaMuon) references MUONTRA(MaMuon)
alter table CTMT add constraint FK_CTMT_SACH foreign key(MaSach) references SACH(MaSach)
alter table SACH add constraint FK_SACH_NXB foreign key(MaXB) references NHAXUATBAN(MaNXB)
alter table SACH add constraint FK_SACH_TG foreign key(MaTG) references TACGIA(MaTG)
alter table SACH add constraint FK_SACH_TL foreign key(MaTL) references THELOAI(MaTL)
alter table SACH add constraint FK_SACH_VITRI foreign key(MaVT) references VITRI(MaVT)
alter table SACH add constraint FK_SACH_NN foreign key(MaNN) references NGONNGU(MaNN)
alter table USERS add constraint FK_User_NHANVIEN foreign key(UserName) references NHANVIEN(UserName)






