using DAL.Repositories.DanhMuc;
using ET.Models.DanhMuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BUS.Services.DanhMuc
{
    public class BUS_KhuVuc
    {
        #region Khởi tạo (Singleton)

        // singleton dùng chung toàn hệ thống
        public static BUS_KhuVuc Instance { get; } = new BUS_KhuVuc();

        private readonly DAL_KhuVuc _dal = DAL_KhuVuc.Instance;
        #endregion

        #region Truy vấn dữ liệu
        /// <summary>
        /// Lấy danh sách khu vực.
        /// Có hỗ trợ đa ngôn ngữ.
        /// </summary>
        public List<ET_KhuVuc> LayDanhSach(string langCode = "vi-VN")
        {
            return _dal.LayDanhSach(langCode).Select(k => new ET_KhuVuc
            {
                Id = k.Id,
                MaKhuVuc = k.MaKhuVuc,
                TenKhuVuc = k.TenKhuVuc,
                SucChua = k.SucChua,
                TrangThai = k.TrangThai,
                LoaiKhuVuc = k.LoaiKhuVuc,
                MoTa = k.MoTa,
            }).ToList();
        }
        #endregion

        #region Thêm / Sửa / Xóa
        /// <summary>
        /// Thêm khu vực mới.
        /// Validate dữ liệu trước khi thêm.
        /// </summary>
        public bool ThemKhuVuc(ET_KhuVuc et)
        {
            Validate(et, false);
            return DAL_KhuVuc.Instance.ThemKhuVuc(et);
        }
        /// <summary>
        /// Cập nhật khu vực.
        /// </summary>
        public bool SuaKhuVuc(ET_KhuVuc et)
        {
            Validate(et, true);
            return DAL_KhuVuc.Instance.SuaKhuVuc(et);
        }
        #endregion

        #region Validate dữ liệu
        /// <summary>
        /// Kiểm tra mã / tên đã tồn tại chưa.
        /// </summary>
        public bool KiemTraTonTai(string field, string value)
        {
            return DAL_KhuVuc.Instance.KiemTraTonTai(field, value);
        }
        /// <summary>
        /// Validate dữ liệu trước khi thêm / sửa.
        /// </summary>
        private void Validate(ET_KhuVuc et, bool isEdit)
        {
            // =========================
            // TRIM
            // =========================
            et.MaKhuVuc = et.MaKhuVuc?.Trim();

            et.TenKhuVuc = et.TenKhuVuc?.Trim();

            et.MoTa = et.MoTa?.Trim();

            // =========================
            // RỖNG
            // =========================
            if (string.IsNullOrWhiteSpace(et.MaKhuVuc))
            {
                throw new Exception("Vui lòng nhập mã khu vực");
            }

            if (string.IsNullOrWhiteSpace(et.TenKhuVuc))
            {
                throw new Exception("Vui lòng nhập tên khu vực");
            }

            // =========================
            // ĐỘ DÀI
            // =========================
            if (et.MaKhuVuc.Length > 150)
            {
                throw new Exception("Mã khu vực không được vượt quá 150 ký tự");
            }

            if (et.MaKhuVuc.Length < 2)
            {
                throw new Exception("Mã khu vực quá ngắn");
            }

            if (et.TenKhuVuc.Length > 150)
            {
                throw new Exception("Tên khu vực không được vượt quá 150 ký tự");
            }

            if (et.TenKhuVuc.Length < 3)
            {
                throw new Exception("Tên khu vực phải từ 3 ký tự trở lên");
            }

            if (!string.IsNullOrWhiteSpace(et.MoTa) && et.MoTa.Length > 500)
            {
                throw new Exception("Mô tả không được vượt quá 500 ký tự");
            }

            // =========================
            // KHÔNG CHO 2 KHOẢNG TRẮNG
            // =========================
            if (et.MaKhuVuc.Contains("  "))
            {
                throw new Exception("Mã khu vực không được chứa 2 khoảng trắng liên tiếp");
            }

            if (et.TenKhuVuc.Contains("  "))
            {
                throw new Exception("Tên khu vực không được chứa 2 khoảng trắng liên tiếp");
            }

            // =========================
            // MÃ KHÔNG ĐƯỢC CHỨA SỐ
            // =========================
            if (et.MaKhuVuc.Any(char.IsDigit))
            {
                throw new Exception("Mã khu vực không được chứa số");
            }

            // =========================
            // KÝ TỰ ĐẶC BIỆT
            // =========================
            Regex regexMa = new Regex(@"^[a-zA-Z_]+$");

            if (!regexMa.IsMatch(et.MaKhuVuc))
            {
                throw new Exception("Mã khu vực không được chứa ký tự đặc biệt");
            }

            Regex regexTen = new Regex(@"^[\p{L}\s]+$");

            if (!regexTen.IsMatch(et.TenKhuVuc))
            {
                throw new Exception("Tên khu vực không được chứa ký tự đặc biệt");
            }

            // =========================
            // SỨC CHỨA
            // =========================
            if (et.SucChua <= 0)
            {
                throw new Exception("Sức chứa không hợp lệ");
            }

            if (et.SucChua > 5000)
            {
                throw new Exception("Sức chứa không được vượt quá 5000");
            }

            // =========================
            // LOẠI KHU VỰC
            // =========================
            if (string.IsNullOrWhiteSpace(et.LoaiKhuVuc))
            {
                throw new Exception("Vui lòng chọn loại khu vực");
            }

            // =========================
            // TRÙNG MÃ
            // =========================
            if (!isEdit)
            {
                bool tonTai = DAL_KhuVuc.Instance.KiemTraTonTai("MaKhuVuc", et.MaKhuVuc);

                if (tonTai)
                {
                    throw new Exception("Mã khu vực đã tồn tại");
                }

                bool tenTonTai = DAL_KhuVuc.Instance.KiemTraTonTai("TenKhuVuc", et.TenKhuVuc);

                if (tenTonTai)
                {
                    throw new Exception(
                        "Tên khu vực đã tồn tại");
                }
            }
        }
        #endregion
    }
}


