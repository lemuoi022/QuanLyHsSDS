use SINHVIEN

CREATE TABLE SinhVien  (
    id  INT IDENTITY(1,1) PRIMARY KEY ,
    ten varchar(255) not null,
    ngaysinh date not null,
	diachi varchar(255) not null,
	id_lophoc int not null,
	CONSTRAINT fk_sv_id_lophoc
  FOREIGN KEY (id_lophoc)
  REFERENCES LopHoc (id)
);

CREATE TABLE LopHoc  (
    id  INT IDENTITY(1,1) PRIMARY KEY ,
    tenlop varchar(255) not null,
	monhoc varchar(255) not null,
	id_giaovien int not null
	CONSTRAINT fk_lh_id_giaovien
  FOREIGN KEY (id_giaovien)
  REFERENCES GiaoVien (id)
);

CREATE TABLE GiaoVien  (
    id  INT IDENTITY(1,1) PRIMARY KEY ,
    ten varchar(255) not null,
	ngaysinh date not null,
	
);

INSERT INTO GiaoVien (ten, ngaysinh) VALUES ('Nguyen Van Minh','04/06/1986'),('Tran Van Tuan','04/06/1986'),
('Le Van Binh','04/06/1986'),('Nguyen Thi Hoa','04/06/1986'),('Tran Thi Nhung','04/06/1986'),
('Le Xuan Minh','04/06/1986');

INSERT INTO LopHoc(tenlop,monhoc,id_giaovien) VALUES ('65IT1','Dai so',1),('65IT2','Giai tich',2),
('65IT3','Toan roi rac',3),('65IT4','Lap trinh Web',4),('Lap trinh OOP','04/06/1986',5),
('Tin hoc dai cuong','04/06/1986',6);