-- Thể loại sách
INSERT INTO TheLoai (TenTheLoai) VALUES
(N'Tiểu thuyết'), (N'Truyện ngắn'), (N'Khoa học'),
(N'Lịch sử'), (N'Giáo trình'), (N'Công nghệ'), (N'Thiếu nhi');

-- Nhà xuất bản
INSERT INTO NhaXuatBan (TenNXB) VALUES
(N'NXB Kim Đồng'), (N'NXB Giáo Dục'), (N'NXB Trẻ'),
(N'NXB Lao Động'), (N'NXB Chính Trị Quốc Gia'), (N'NXB Khoa Học & Kỹ Thuật');

-- Tác giả
INSERT INTO TacGia (TenTacGia) VALUES
(N'Nguyễn Nhật Ánh'), (N'Trịnh Hữu Tuệ'), (N'J.K. Rowling'),
(N'Dan Brown'), (N'Lev Tolstoy'), (N'Nguyễn Du');

-- Ngôn ngữ
INSERT INTO NgonNgu (TenNgonNgu) VALUES
(N'Tiếng Việt'), (N'Tiếng Anh'), (N'Tiếng Pháp'),
(N'Tiếng Trung'), (N'Tiếng Nhật'), (N'Tiếng Đức');

-- Sách
INSERT INTO Sach (MaSach, MaNXB, TenSach, MoTa, MaTacGia, MaTheLoai, NamXuatBan, MaNgonNgu, AnhBia, TrangThai, Gia, SoLuong) VALUES
('S001', 1, N'Mắt Biếc', N'Truyện tình học trò cảm động', 1, 1, '2010-05-01', 1, NULL, N'Còn hàng', 50000, 20),
('S002', 3, N'Harry Potter và Hòn đá Phù thủy', N'Truyện giả tưởng nổi tiếng toàn cầu', 3, 1, '2001-06-26', 2, NULL, N'Còn hàng', 120000, 15),
('S003', 2, N'Toán học phổ thông', N'Sách giáo khoa lớp 12', 2, 5, '2018-08-01', 1, NULL, N'Còn hàng', 40000, 30),
('S004', 4, N'Mật mã Da Vinci', N'Tiểu thuyết trinh thám nổi tiếng', 4, 1, '2003-04-01', 2, NULL, N'Còn hàng', 90000, 12),
('S005', 5, N'Chiến tranh và Hòa bình', N'Tác phẩm kinh điển của Nga', 5, 4, '1869-01-01', 2, NULL, N'Còn hàng', 150000, 10);

-- Độc giả
INSERT INTO DocGia (TenDocGia, GioiTinh, NgaySinh, DiaChi, Email, SoDienThoai, MatKhau, Avartar) VALUES
(N'Nguyễn Văn A', N'Nam', '2000-01-01', N'Hà Nội', 'vana@gmail.com', '0123456789', '123456', NULL),
(N'Trần Thị B', N'Nữ', '1999-03-15', N'Hồ Chí Minh', 'thib@gmail.com', '0987654321', 'abcdef', NULL),
(N'Lê Minh C', N'Nam', '2001-07-10', N'Đà Nẵng', 'minhc@gmail.com', '0911111111', 'minhpass', NULL);

-- Thẻ thư viện (phải lấy đúng MaDocGia vừa tạo)
INSERT INTO TheThuVien (MaThe, MaDocGia, NgayCapThe, NgayHetHan, TrangThai, SoSachDuocMuon, SoSachDangMuon) VALUES
('T001', 1, GETDATE(), '2026-12-31', 1, 5, 1),
('T002', 2, GETDATE(), '2026-12-31', 1, 5, 0),
('T003', 3, GETDATE(), '2026-12-31', 1, 5, 2);

-- Mượn - Trả sách
INSERT INTO MuonTraSach (MaThe, GhiChu) VALUES
('T001', N'Mượn sách lần đầu'),
('T002', N'Mượn sách giáo trình'),
('T003', N'Mượn tiểu thuyết');

-- Chi tiết mượn - trả sách
INSERT INTO MuonTraSachChiTiet (MaMuonSach, MaSach, NgayMuon, NgayHenTra, NgayTra, TrangThai, SoLuong) VALUES
(1, 'S001', '2025-04-01', '2025-04-10', NULL, N'Đang mượn', 1),
(2, 'S003', '2025-04-05', '2025-04-15', NULL, N'Đang mượn', 1),
(3, 'S005', '2025-04-07', '2025-04-20', NULL, N'Đang mượn', 1);

-- Quyền hạn
INSERT INTO QuyenHan (TenQuyen) VALUES
(N'Quản trị viên'), (N'Thủ thư'), (N'Nhân viên');

-- Nhân viên (IDQuyen: 1=Admin, 2=Thủ thư, 3=Nhân viên)
INSERT INTO NhanVien (HoVaTen, Email, SoDienThoai, NgaySinh, Avartar, MatKhau, IDQuyen) VALUES
(N'Lê Văn Thư', 'vanthu@elibrary.com', '0901234567', '1990-02-20', NULL, 'admin123', 1),
(N'Hồ Hữu Lộc', 'locnv@elibrary.com', '0912345678', '1992-05-10', NULL, '123456', 2),
(N'Nguyễn Văn Khoa', 'khoa@elibrary.com', '0922334455', '1995-08-08', NULL, 'nvkhoa', 3);

-- Nhật ký hệ thống (tham chiếu theo MaDocGia, MaNhanVien là INT)
INSERT INTO LogHoatDong (MaNguoiDung, LoaiNguoiDung, HanhDong, BangLienQuan, KhoaChinh, GhiChu) VALUES
(1, 'NhanVien', N'Thêm sách mới', 'Sach', 'S001', N'Tên sách: Mắt Biếc'),
(1, 'DocGia', N'Mượn sách', 'MuonTraSach', '1', N'Mượn sách Mắt Biếc'),
(2, 'NhanVien', N'Cập nhật thông tin sách', 'Sach', 'S002', N'Cập nhật mô tả chi tiết'),
(3, 'DocGia', N'Mượn sách', 'MuonTraSach', '3', N'Mượn sách Chiến tranh và Hòa bình');
