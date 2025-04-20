--create database eLibrary
-- Tạo các bảng dữ liệu chuẩn hóa

-- Bảng Thể loại
CREATE TABLE TheLoai (
    MaTheLoai INT IDENTITY(1,1) PRIMARY KEY,  
    TenTheLoai NVARCHAR(100) UNIQUE NOT NULL
);

-- Bảng Nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNXB INT IDENTITY(1,1) PRIMARY KEY,
    TenNXB NVARCHAR(100) NOT NULL UNIQUE
);

-- Bảng Tác giả
CREATE TABLE TacGia (
    MaTacGia INT IDENTITY(1,1) PRIMARY KEY,
    TenTacGia NVARCHAR(100) NOT NULL UNIQUE
);

-- Bảng Ngôn ngữ
CREATE TABLE NgonNgu (
    MaNgonNgu INT IDENTITY(1,1) PRIMARY KEY,
    TenNgonNgu NVARCHAR(100) NOT NULL UNIQUE
);

-- Bảng Sách
CREATE TABLE Sach (
    MaSach NVARCHAR(10) NOT NULL PRIMARY KEY,
    MaNXB INT,
    TenSach NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500),
    MaTacGia INT,
    MaTheLoai INT,
    NamXuatBan DATE,
    MaNgonNgu INT,
    AnhBia NVARCHAR(255),
    TrangThai NVARCHAR(100),
    Gia INT,
    SoLuong INT,
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB),
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia),
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai) ON DELETE CASCADE,
    FOREIGN KEY (MaNgonNgu) REFERENCES NgonNgu(MaNgonNgu)
);

-- Bảng Độc giả
CREATE TABLE DocGia (
    MaDocGia NVARCHAR(10) NOT NULL PRIMARY KEY,
    TenDocGia NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    SoDienThoai NVARCHAR(20) UNIQUE,
    MatKhau NVARCHAR(100),
    Avartar NVARCHAR(MAX)
);

-- Bảng Thẻ thư viện
CREATE TABLE TheThuVien (
    MaThe NVARCHAR(10) NOT NULL PRIMARY KEY,
    MaDocGia NVARCHAR(10),
    NgayCapThe DATETIME DEFAULT GETDATE(),
    NgayHetHan DATE,
    TrangThai BIT,
    SoSachDuocMuon INT DEFAULT 0,
    SoSachDangMuon INT DEFAULT 0,
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia) ON DELETE CASCADE
);

-- Bảng Mượn - Trả sách
CREATE TABLE MuonTraSach (
    MaMuonSach INT IDENTITY(1,1) PRIMARY KEY,
    MaThe NVARCHAR(10),
    GhiChu NVARCHAR(1500),
    FOREIGN KEY (MaThe) REFERENCES TheThuVien(MaThe) ON DELETE CASCADE
);

-- Bảng Chi tiết Mượn - Trả sách
CREATE TABLE MuonTraSachChiTiet (
    MaMuonSach INT NOT NULL,
    MaSach NVARCHAR(10) NOT NULL,
    NgayMuon DATE,
    NgayHenTra DATE,
    NgayTra DATE,
    TrangThai NVARCHAR(100),
    SoLuong INT,
    PRIMARY KEY (MaMuonSach, MaSach),
    FOREIGN KEY (MaMuonSach) REFERENCES MuonTraSach(MaMuonSach) ON DELETE CASCADE,
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach) ON DELETE CASCADE
);

-- Bảng Quyền hạn
CREATE TABLE QuyenHan (
    IDQuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenQuyen NVARCHAR(100) NOT NULL UNIQUE
);

-- Bảng Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien NVARCHAR(10) NOT NULL PRIMARY KEY,
    HoVaTen NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    SoDienThoai NVARCHAR(20) UNIQUE,
    NgaySinh DATE,
    Avartar NVARCHAR(MAX),
    MatKhau NVARCHAR(100),
    IDQuyen INT,
    FOREIGN KEY (IDQuyen) REFERENCES QuyenHan(IDQuyen)
);

-- Bảng Log hoạt động (nhật ký thao tác)
CREATE TABLE LogHoatDong (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ThoiGian DATETIME DEFAULT GETDATE(),
    MaNguoiDung NVARCHAR(10),
    LoaiNguoiDung NVARCHAR(20), -- 'DocGia' hoặc 'NhanVien'
    HanhDong NVARCHAR(255),     -- VD: 'Đăng nhập', 'Mượn sách'
    BangLienQuan NVARCHAR(100), -- VD: 'Sach', 'DocGia'
    KhoaChinh NVARCHAR(50),     -- VD: 'S001', 'DG001'
    GhiChu NVARCHAR(1000)
);






