-- =================================================================
-- MOCK DATA TRANSACTIONS (BẢN FIX TỐI THƯỢNG - BƯỚC 6)
-- Tương thích 100% với Database_DaiNamv2 Schema
-- =================================================================
USE Database_DaiNamv2;
GO

IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
GO
BEGIN TRANSACTION;

-- =================================================================
-- 1. DỌN DẸP SẠCH RÁC CŨ ĐỂ KHÔNG BỊ TRÙNG MÃ (UNIQUE KEY)
-- =================================================================
DELETE FROM TaiChinh.ChiTietThanhToan WHERE IdChungTu IN (SELECT Id FROM TaiChinh.ChungTuTC WHERE MaChungTu LIKE 'PT-TX%');
DELETE FROM TaiChinh.ChungTuTC WHERE MaChungTu LIKE 'PT-TX%';
DELETE FROM BanHang.LichSuHoanHang;
DELETE FROM BanHang.VeDienTu WHERE MaVach LIKE 'VDT-TX%';
DELETE FROM BanHang.ChiTietDatPhong;
DELETE FROM BanHang.PhieuDatPhong;
DELETE FROM BanHang.ChiTietDonHang WHERE IdDonHang IN (SELECT Id FROM BanHang.DonHang WHERE MaDonHang LIKE 'DH-TX-%');
DELETE FROM BanHang.DonHang WHERE MaDonHang LIKE 'DH-TX-%';
DELETE FROM BanHang.KhuyenMai_DieuKien;
DELETE FROM BanHang.KhuyenMai_LichSu;
DELETE FROM BanHang.KhuyenMai WHERE MaKhuyenMai = 'TET2024';
DELETE FROM Kho.ChiTietKiemKe;
DELETE FROM Kho.ChiTietChungTu WHERE IdChungTu IN (SELECT Id FROM Kho.ChungTu WHERE MaChungTu LIKE 'NK-24%' OR MaChungTu LIKE 'CK-24%');
DELETE FROM Kho.ChungTu WHERE MaChungTu LIKE 'NK-24%' OR MaChungTu LIKE 'CK-24%';

-- =================================================================
-- 2. ĐẢM BẢO CÓ ĐỦ DỮ LIỆU NỀN TẢNG (KHO, SP, NV, KH)
-- =================================================================
DECLARE @KhoThuc INT = (SELECT TOP 1 Id FROM Kho.KhoHang WHERE LaKhoAo = 0);
IF @KhoThuc IS NULL BEGIN
    INSERT INTO Kho.KhoHang (MaKho, TenKho, LaKhoAo, TrangThai) VALUES ('KHO_CHINH', N'Kho Chính', 0, 'HoatDong');
    SET @KhoThuc = SCOPE_IDENTITY();
END
DECLARE @KhoNCC INT = (SELECT TOP 1 Id FROM Kho.KhoHang WHERE MaKho = 'KHO_NCC');

DECLARE @IdNV INT = (SELECT TOP 1 IdDoiTac FROM DoiTac.NhanVien);
DECLARE @IdKH INT = (SELECT TOP 1 IdDoiTac FROM DoiTac.KhachHang);

DECLARE @IdDVT INT = (SELECT TOP 1 Id FROM DanhMuc.DonViTinh);

DECLARE @SP_Ve INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE LoaiSanPham = 'VeVaoKhu');
IF @SP_Ve IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('SP_VE_TX', N'Vé (TX)', 'VeVaoKhu', @IdDVT, 100000);
    SET @SP_Ve = SCOPE_IDENTITY();
END

DECLARE @SP_Phong INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE LoaiSanPham = 'LuuTru');
IF @SP_Phong IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('SP_PHONG_TX', N'Phòng (TX)', 'LuuTru', @IdDVT, 1000000);
    SET @SP_Phong = SCOPE_IDENTITY();
    INSERT INTO DanhMuc.LoaiPhong (IdSanPham, TenLoai) VALUES (@SP_Phong, N'Phòng Standard (TX)');
END

DECLARE @SP_HH INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE LoaiSanPham = 'DoUong' OR LoaiSanPham = 'AnUong');
IF @SP_HH IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('SP_NUOC_TX', N'Nước (TX)', 'DoUong', @IdDVT, 15000);
    SET @SP_HH = SCOPE_IDENTITY();
END

-- =================================================================
-- 3. GIAO DỊCH 1: TẠO KHUYẾN MÃI (Schema V2)
-- =================================================================
INSERT INTO BanHang.KhuyenMai (MaKhuyenMai, TenKhuyenMai, LoaiGiamGia, GiaTriGiam, DonToiThieu, NgayBatDau, NgayKetThuc, UuTien, TrangThai)
VALUES ('TET2024', N'Khuyến mãi Tết', 'PhanTram', 20, 0, '2024-01-01', '2026-12-31', 1, 1);

-- =================================================================
-- 4. GIAO DỊCH 2: NHẬP KHO TỪ NHÀ CUNG CẤP (Schema V3)
-- =================================================================
INSERT INTO Kho.ChungTu (MaChungTu, LoaiChungTu, NgayChungTu, TrangThai, IdNguoiTao)
VALUES ('NK-240115-001', 'NHAP_MUA', GETDATE(), 'DaDuyet', @IdNV);
DECLARE @IdPN INT = SCOPE_IDENTITY();

INSERT INTO Kho.ChiTietChungTu (IdChungTu, IdSanPham, IdKhoXuat, IdKhoNhap, SoLuong, DonGia)
VALUES (@IdPN, @SP_HH, @KhoNCC, @KhoThuc, 500, 10000);

-- =================================================================
-- 5. GIAO DỊCH 3: ĐẶT PHÒNG KHÁCH SẠN (Schema V2)
-- =================================================================
-- Thu tiền cọc phòng
INSERT INTO TaiChinh.ChungTuTC (MaChungTu, LoaiChungTu, IdDoiTac, SoTien, PhuongThuc, IdNguoiTao, TrangThai)
VALUES ('PT-TX-COC01', 'THU_COC', @IdKH, 500000, 'ChuyenKhoan', @IdNV, 'DaDuyet');
DECLARE @IdThuCoc INT = SCOPE_IDENTITY();

-- Tạo Header Đặt Phòng
INSERT INTO BanHang.PhieuDatPhong (MaDatPhong, IdKhachHang, NgayNhanPhong, NgayTraPhong, TienPhongTraTruoc, TrangThai, IdPhieuThuCoc)
VALUES ('DP-TX-001', @IdKH, CAST(GETDATE() AS DATE), CAST(DATEADD(DAY, 2, GETDATE()) AS DATE), 500000, 'DatTruoc', @IdThuCoc);
DECLARE @IdDP INT = SCOPE_IDENTITY();

-- Tạo Bill chờ thanh toán cho phòng này
INSERT INTO BanHang.DonHang (MaDonHang, IdKhachHang, IdNhanVien, NguonBan, TongTienHang, TongThanhToan, TrangThai)
VALUES ('DH-TX-001', @IdKH, @IdNV, 'TrucTiep', 2000000, 2000000, 'DangMo');
DECLARE @IdBillDP INT = SCOPE_IDENTITY();

INSERT INTO BanHang.ChiTietDonHang (IdDonHang, IdSanPham, SoLuong, DonGiaThucTe, TienThue)
VALUES (@IdBillDP, @SP_Phong, 2, 1000000, 0);
DECLARE @IdCTDP_Bill INT = SCOPE_IDENTITY();

-- Gắn phòng vào Booking
INSERT INTO BanHang.ChiTietDatPhong (IdPhieuDatPhong, IdChiTietDonHang, IdLoaiPhong, GiaBanDem, TrangThai)
VALUES (@IdDP, @IdCTDP_Bill, @SP_Phong, 1000000, 'ChoDen');

-- =================================================================
-- 6. GIAO DỊCH 4: BÁN VÉ QR CODE (Schema V2)
-- =================================================================
INSERT INTO BanHang.DonHang (MaDonHang, IdKhachHang, IdNhanVien, NguonBan, TongTienHang, TongThanhToan, TrangThai)
VALUES ('DH-TX-002', @IdKH, @IdNV, 'TrucTiep', 200000, 200000, 'DaThanhToan');
DECLARE @IdBillVe INT = SCOPE_IDENTITY();

INSERT INTO BanHang.ChiTietDonHang (IdDonHang, IdSanPham, SoLuong, DonGiaThucTe, TienThue)
VALUES (@IdBillVe, @SP_Ve, 2, 100000, 0);
DECLARE @IdCT_Ve INT = SCOPE_IDENTITY();

-- Sinh mã QR cho vé
INSERT INTO BanHang.VeDienTu (IdChiTietDonHang, IdSanPham, MaVach, SoLuotConLai, TrangThai)
VALUES 
(@IdCT_Ve, @SP_Ve, 'VDT-TX-001', 1, 'ChuaSuDung'),
(@IdCT_Ve, @SP_Ve, 'VDT-TX-002', 1, 'ChuaSuDung');

COMMIT TRANSACTION;
PRINT N'✅ BƯỚC 6 (TRANSACTIONS) HOÀN TẤT - Database của bạn đã đầy đủ dữ liệu xịn!';