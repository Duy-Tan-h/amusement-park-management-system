using DAL;
using DAL.Repositories.DanhMuc;
using ET.Models.DanhMuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BUS.Services.DanhMuc
{
    public class BUS_TroChoi
    {
        public static BUS_TroChoi Instance { get; } = new BUS_TroChoi();
        #region Danh sách

        /// <summary>
        /// Lấy danh sách trò chơi.
        /// </summary>
        public List<ET_TroChoi> GetDanhSachTroChoi(string langCode = "vi-VN")
        {
            return DAL_TroChoi.Instance.GetDanhSachTroChoi(langCode);
        }
        /// <summary>
        /// Lấy danh sách khu vực.
        /// </summary>
        public List<KhuVuc> GetKhuVuc()
        {
            return DAL_TroChoi.Instance.GetKhuVuc();
        }
        #endregion

        #region Thống kê

        /// <summary>
        /// Tổng trò chơi.
        /// </summary>
        public int TongTroChoi()
        {
            return DAL_TroChoi.Instance.TongTroChoi();
        }
        /// <summary>
        /// Tổng hoạt động.
        /// </summary>
        public int TongHoatDong()
        {
            return DAL_TroChoi.Instance.TongHoatDong();
        }
        /// <summary>
        /// Tổng bảo trì.
        /// </summary>
        public int TongBaoTri()
        {
            return DAL_TroChoi.Instance.TongBaoTri();
        }
        /// <summary>
        /// Tổng tạm ngưng.
        /// </summary>
        public int TongTamNgung()
        {
            return DAL_TroChoi.Instance.TongTamNgung();
        }
        #endregion

        #region Thêm

        /// <summary>
        /// Thêm trò chơi.
        /// </summary>
        public bool ThemTroChoi(TroChoi tc)
        {
            Validate(tc, false);
            return DAL_TroChoi.Instance.ThemTroChoi(tc);
        }
        #endregion

        #region Sửa

        /// <summary>
        /// Cập nhật trò chơi.
        /// </summary>
        public bool CapNhatTroChoi(TroChoi tc)
        {
            Validate(tc, true);
            return DAL_TroChoi.Instance.CapNhatTroChoi(tc);
        }
        #endregion

        #region Xóa

        /// <summary>
        /// Xóa mềm trò chơi.
        /// </summary>
        public bool XoaTroChoi(int id)
        {
            return DAL_TroChoi.Instance.XoaTroChoi(id);
        }
        #endregion

        #region Validate

        /// <summary>
        /// Kiểm tra dữ liệu đầu vào.
        /// </summary>
        private void Validate(TroChoi et, bool isEdit)
        {
            et.TenTroChoi = et.TenTroChoi?.Trim();

            // =========================
            // TÊN TRÒ CHƠI
            // =========================
            if (string.IsNullOrWhiteSpace(et.TenTroChoi))
                throw new Exception("Vui lòng nhập tên trò chơi");

            if (et.TenTroChoi.Length < 2)
                throw new Exception("Tên trò chơi quá ngắn");

            if (et.TenTroChoi.Length > 100)
                throw new Exception("Tên trò chơi không được vượt quá 100 ký tự");

            if (et.TenTroChoi.Contains("  "))
                throw new Exception("Tên trò chơi không được chứa 2 khoảng trắng liên tiếp");

            Regex regexTen = new Regex(@"^[\p{L}\p{N}\s\-_()]+$");

            if (!regexTen.IsMatch(et.TenTroChoi))
                throw new Exception("Tên trò chơi không được chứa ký tự đặc biệt");

            // =========================
            // KHU VỰC
            // =========================
            if (et.IdKhuVuc == null || et.IdKhuVuc <= 0)
                throw new Exception("Vui lòng chọn khu vực");

            // =========================
            // SỨC CHỨA
            // =========================
            if (et.SucChua <= 0)
                throw new Exception("Sức chứa không hợp lệ");

            if (et.SucChua > 5000)
                throw new Exception("Sức chứa không được vượt quá 5000");

            // =========================
            // ĐỘ TUỔI
            // =========================
            if (et.DoTuoiToiThieu < 0)
                throw new Exception("Độ tuổi tối thiểu không hợp lệ");

            if (et.DoTuoiToiThieu > 100)
                throw new Exception("Độ tuổi tối thiểu không được vượt quá 100");

            // =========================
            // THỜI GIAN LƯỢT
            // =========================
            if (et.ThoiGianLuot <= 0)
                throw new Exception("Thời gian lượt không hợp lệ");

            if (et.ThoiGianLuot > 300)
                throw new Exception("Thời gian lượt không được vượt quá 5000 phút");

            // =========================
            // TRẠNG THÁI
            // =========================
            List<string> dsTrangThai = new List<string>
            {
                "HoatDong",
                "BaoTri",
                "TamNgung"
            };

            if (string.IsNullOrWhiteSpace(et.TrangThai))
                throw new Exception("Vui lòng chọn trạng thái");

            if (!dsTrangThai.Contains(et.TrangThai))
                throw new Exception("Trạng thái không hợp lệ");

            // =========================
            // TRÙNG TÊN
            // =========================
            bool tonTai = DAL_TroChoi.Instance.KiemTraTonTaiTenTroChoi(et.TenTroChoi, et.Id);

            if (tonTai)
            {
                throw new Exception("Tên trò chơi đã tồn tại");
            }
        }
        #endregion
    }
}
