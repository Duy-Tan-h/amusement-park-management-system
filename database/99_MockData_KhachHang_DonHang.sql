-- =================================================================
-- MOCK DATA KHACH HANG & DON HANG (BẢN FIX TỐI THƯỢNG - BƯỚC 5)
-- =================================================================
USE Database_DaiNamv2;
GO

IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
GO

BEGIN TRANSACTION;

-- 1. Dọn dẹp dữ liệu cũ rác
DECLARE @OldOrderIds TABLE (Id INT);
INSERT INTO @OldOrderIds SELECT Id FROM BanHang.DonHang WHERE MaDonHang LIKE 'DH-2604%';

DELETE FROM TaiChinh.ChiTietThanhToan WHERE IdChungTu IN (SELECT Id FROM TaiChinh.ChungTuTC WHERE IdDonHang IN (SELECT Id FROM @OldOrderIds));
DELETE FROM TaiChinh.ChungTuTC WHERE IdDonHang IN (SELECT Id FROM @OldOrderIds);
DELETE FROM BanHang.VeDienTu WHERE IdChiTietDonHang IN (SELECT Id FROM BanHang.ChiTietDonHang WHERE IdDonHang IN (SELECT Id FROM @OldOrderIds));
DELETE FROM BanHang.ChiTietDonHang WHERE IdDonHang IN (SELECT Id FROM @OldOrderIds);
DELETE FROM BanHang.DonHang WHERE Id IN (SELECT Id FROM @OldOrderIds);

-- 2. Đảm bảo Khách Hàng tồn tại
DECLARE @IdKH1 INT = (SELECT Id FROM DoiTac.ThongTin WHERE Cccd = '079090001234');
IF @IdKH1 IS NULL BEGIN
    INSERT INTO DoiTac.ThongTin (HoTen, DienThoai, Cccd, LoaiDoiTac) VALUES (N'Nguyễn Văn An', '0901234567', '079090001234', 'CaNhan');
    SET @IdKH1 = SCOPE_IDENTITY();
    INSERT INTO DoiTac.KhachHang (IdDoiTac, MaKhachHang) VALUES (@IdKH1, 'KH00001');
END

DECLARE @IdKH2 INT = (SELECT Id FROM DoiTac.ThongTin WHERE Cccd = '079080005678');
IF @IdKH2 IS NULL BEGIN
    INSERT INTO DoiTac.ThongTin (HoTen, DienThoai, Cccd, LoaiDoiTac) VALUES (N'Trần Thị Bích Ngọc', '0912345678', '079080005678', 'CaNhan');
    SET @IdKH2 = SCOPE_IDENTITY();
    INSERT INTO DoiTac.KhachHang (IdDoiTac, MaKhachHang) VALUES (@IdKH2, 'KH00002');
END

-- 3. BẮT ĐUỢC SẢN PHẨM HOẶC TỰ TẠO (CHỐNG LỖI NULL)
DECLARE @IdDVT INT = (SELECT TOP 1 Id FROM DanhMuc.DonViTinh);
IF @IdDVT IS NULL BEGIN
    INSERT INTO DanhMuc.DonViTinh (MaDonVi, TenDonVi) VALUES ('DVT_TAM', N'Cái');
    SET @IdDVT = SCOPE_IDENTITY();
END

DECLARE @IdNV INT = (SELECT TOP 1 IdDoiTac FROM DoiTac.NhanVien WHERE MaNhanVien = 'NV002');
IF @IdNV IS NULL SET @IdNV = (SELECT TOP 1 IdDoiTac FROM DoiTac.NhanVien);

-- Tự tạo sản phẩm nếu chưa có
DECLARE @SP_VeNL INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE MaSanPham = 'VE-NL-001' OR LoaiSanPham = 'VeVaoKhu');
IF @SP_VeNL IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('TEMP_VENL', N'Vé người lớn (Tạm)', 'VeVaoKhu', @IdDVT, 150000);
    SET @SP_VeNL = SCOPE_IDENTITY();
END

DECLARE @SP_VeTE INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE MaSanPham = 'VE-TE-001' OR LoaiSanPham = 'VeVaoKhu');
IF @SP_VeTE IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('TEMP_VETE', N'Vé trẻ em (Tạm)', 'VeVaoKhu', @IdDVT, 100000);
    SET @SP_VeTE = SCOPE_IDENTITY();
END

DECLARE @SP_ComBo INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE MaSanPham = 'VE-NL-CMB' OR LoaiSanPham = 'Combo');
IF @SP_ComBo IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('TEMP_CMB', N'Combo (Tạm)', 'VeVaoKhu', @IdDVT, 250000);
    SET @SP_ComBo = SCOPE_IDENTITY();
END

DECLARE @SP_Pho INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE MaSanPham = 'DA-PHO-01' OR LoaiSanPham = 'AnUong');
IF @SP_Pho IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('TEMP_PHO', N'Phở (Tạm)', 'AnUong', @IdDVT, 60000);
    SET @SP_Pho = SCOPE_IDENTITY();
END

DECLARE @SP_Pepsi INT = (SELECT TOP 1 Id FROM DanhMuc.SanPham WHERE MaSanPham = 'DU-PEPSI-01' OR LoaiSanPham = 'DoUong');
IF @SP_Pepsi IS NULL BEGIN
    INSERT INTO DanhMuc.SanPham (MaSanPham, TenSanPham, LoaiSanPham, IdDonViTinh, DonGia) VALUES ('TEMP_PEPSI', N'Pepsi (Tạm)', 'DoUong', @IdDVT, 15000);
    SET @SP_Pepsi = SCOPE_IDENTITY();
END

-- 4. TẠO ĐƠN HÀNG AN TOÀN
-- Đơn hàng 1
INSERT INTO BanHang.DonHang (MaDonHang, IdKhachHang, IdNhanVien, NguonBan, TongTienHang, TongThanhToan, TrangThai)
VALUES ('DH-260401-001', @IdKH1, @IdNV, 'TrucTiep', 300000, 300000, 'DaThanhToan');
DECLARE @IdDH1 INT = SCOPE_IDENTITY();

INSERT INTO BanHang.ChiTietDonHang (IdDonHang, IdSanPham, SoLuong, DonGiaThucTe, TienThue, GhiChu)
VALUES (@IdDH1, @SP_VeNL, 2.00, 150000, 0, N'Vé lẻ');

-- Đơn hàng 3 (Phở + Pepsi mà bạn bị kẹt)
INSERT INTO BanHang.DonHang (MaDonHang, IdKhachHang, IdNhanVien, NguonBan, TongTienHang, TongThanhToan, TrangThai)
VALUES ('DH-260403-003', @IdKH2, @IdNV, 'TrucTiep', 150000, 135000, 'DaThanhToan');
DECLARE @IdDH3 INT = SCOPE_IDENTITY();

INSERT INTO BanHang.ChiTietDonHang (IdDonHang, IdSanPham, SoLuong, DonGiaThucTe, TienThue, GhiChu)
VALUES 
(@IdDH3, @SP_Pho, 2.00, 60000, 0, N'Phở'),
(@IdDH3, @SP_Pepsi, 2.00, 15000, 0, N'Nước ngọt');

COMMIT TRANSACTION;
PRINT N'✅ ĐÃ FIX XONG - BƯỚC 5 ĐÃ HOÀN TẤT!';