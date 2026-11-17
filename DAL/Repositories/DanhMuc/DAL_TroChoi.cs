using ET.Models.DanhMuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Constants;

namespace DAL.Repositories.DanhMuc
{
    public class DAL_TroChoi
    {
        public static DAL_TroChoi Instance { get; } = new DAL_TroChoi();
        #region Danh sách

        /// <summary>
        /// Lấy danh sách trò chơi kèm đa ngôn ngữ.
        /// </summary>
        public List<ET_TroChoi> GetDanhSachTroChoi(string langCode = "vi-VN")
        {
            using (var db = new DaiNamDBDataContext())
            {
                var query =
                from tc in db.TroChois
                join kv in db.KhuVucs
                    on tc.IdKhuVuc equals kv.Id into kvJoin
                from kv in kvJoin.DefaultIfEmpty()

                where tc.DaXoa == false

                select new
                {
                    TroChoi = tc,
                    TenKhuVuc = kv.TenKhuVuc
                };

                // Nếu là tiếng Việt => lấy gốc
                if (langCode == "vi-VN")
                {
                    return query.Select(x => new ET_TroChoi
                    {
                        Id = x.TroChoi.Id,
                        TenTroChoi = x.TroChoi.TenTroChoi,
                        IdKhuVuc = x.TroChoi.IdKhuVuc,
                        TenKhuVuc = x.TenKhuVuc,

                        SucChua = x.TroChoi.SucChua,
                        DoTuoiToiThieu = x.TroChoi.DoTuoiToiThieu,
                        ThoiGianLuot = x.TroChoi.ThoiGianLuot,

                        TrangThai = x.TroChoi.TrangThai
                    }).ToList();
                }

                // =========================
                // Dịch tên trò chơi
                // =========================

                var dicTroChoi = db.BanDiches
                    .Where(x =>
                        x.NgonNgu == langCode &&
                        x.LoaiThucThe == AppConstants.ThucTheDich.TroChoi &&
                        x.TruongDich == AppConstants.TruongDich.TenTroChoi)
                    .ToDictionary(x => x.IdThucThe, x => x.NoiDung);

                // =========================
                // Dịch tên khu vực
                // =========================

                var dicKhuVuc = db.BanDiches
                    .Where(x =>
                        x.NgonNgu == langCode &&
                        x.LoaiThucThe == AppConstants.ThucTheDich.KhuVuc &&
                        x.TruongDich == AppConstants.TruongDich.TenKhuVuc)
                    .ToDictionary(x => x.IdThucThe, x => x.NoiDung);

                var result = query.ToList();

                return result.Select(x =>
                {
                    string tenTroChoi = x.TroChoi.TenTroChoi;
                    string tenKhuVuc = x.TenKhuVuc;

                    if (dicTroChoi.TryGetValue(x.TroChoi.Id, out var tenDich))
                        tenTroChoi = tenDich;

                    if (x.TroChoi.IdKhuVuc != null &&
                        dicKhuVuc.TryGetValue(x.TroChoi.IdKhuVuc.Value, out var kvDich))
                        tenKhuVuc = kvDich;

                    return new ET_TroChoi
                    {
                        Id = x.TroChoi.Id,
                        TenTroChoi = tenTroChoi,

                        IdKhuVuc = x.TroChoi.IdKhuVuc,
                        TenKhuVuc = tenKhuVuc,

                        SucChua = x.TroChoi.SucChua,
                        DoTuoiToiThieu = x.TroChoi.DoTuoiToiThieu,
                        ThoiGianLuot = x.TroChoi.ThoiGianLuot,

                        TrangThai = x.TroChoi.TrangThai
                    };
                }).ToList();
            }
        }
        /// <summary>
        /// Lấy danh sách khu vực
        /// </summary>
        public List<KhuVuc> GetKhuVuc()
        {
            using (var db = new DaiNamDBDataContext())
            {
                return db.KhuVucs
                .Where(x => x.DaXoa == false)
                .ToList();
            }
        }
        #endregion

        #region Thống kê

        /// <summary>
        /// Tổng trò chơi.
        /// </summary>
        public int TongTroChoi()
        {
            using (var db = new DaiNamDBDataContext())
            {
                return db.TroChois.Count(x => x.DaXoa == false);
            }
        }

        public int TongHoatDong()
        {
            using (var db = new DaiNamDBDataContext())
            {
                return db.TroChois.Count(x =>
                    x.DaXoa == false &&
                    x.TrangThai == "HoatDong");
            }
        }

        public int TongBaoTri()
        {
            using (var db = new DaiNamDBDataContext())
            {
                return db.TroChois.Count(x =>
                    x.DaXoa == false &&
                    x.TrangThai == "BaoTri");
            }
        }

        public int TongTamNgung()
        {
            using (var db = new DaiNamDBDataContext())
            {
                return db.TroChois.Count(x =>
                    x.DaXoa == false &&
                    x.TrangThai == "TamNgung");
            }
        }
        #endregion

        #region Thêm

        /// <summary>
        /// Thêm trò chơi.
        /// </summary>
        public bool ThemTroChoi(TroChoi tc)
        {
            try
            {
                using (var db = new DaiNamDBDataContext())
                {
                    db.TroChois.InsertOnSubmit(tc);
                    db.SubmitChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Sửa

        /// <summary>
        /// Cập nhật trò chơi.
        /// </summary>
        public bool CapNhatTroChoi(TroChoi model)
        {
            try
            {
                using (var db = new DaiNamDBDataContext())
                {
                    var tc = db.TroChois.FirstOrDefault(x => x.Id == model.Id);

                    if (tc == null)
                        return false;

                    tc.TenTroChoi = model.TenTroChoi;
                    tc.IdKhuVuc = model.IdKhuVuc;
                    tc.SucChua = model.SucChua;
                    tc.DoTuoiToiThieu = model.DoTuoiToiThieu;
                    tc.ThoiGianLuot = model.ThoiGianLuot;
                    tc.TrangThai = model.TrangThai;

                    db.SubmitChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Xóa

        /// <summary>
        /// Xóa mềm trò chơi.
        /// </summary>

        public bool XoaTroChoi(int id)
        {
            try
            {
                using (var db = new DaiNamDBDataContext())
                {
                    var troChoi = db.TroChois
                        .FirstOrDefault(x => x.Id == id);

                    if (troChoi == null)
                        return false;

                    troChoi.DaXoa = true;

                    db.SubmitChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool KiemTraTonTaiTenTroChoi(string tenTroChoi, int id = 0)
        {
            using (var db = new DaiNamDBDataContext())
            {
                tenTroChoi = tenTroChoi.Trim().ToLower();

                return db.TroChois.Any(x =>
                    x.Id != id &&
                    x.DaXoa == false &&
                    x.TenTroChoi.Trim().ToLower() == tenTroChoi);
            }
        }
        #endregion
    }
}
