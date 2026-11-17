using ET.Models.DanhMuc;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.DanhMuc
{
    public class DAL_KhuVuc
    {
        #region Khởi tạo (Singleton)

        // khởi tạo singleton dùng chung toàn hệ thống
        public static DAL_KhuVuc Instance { get; } = new DAL_KhuVuc();
        #endregion

        #region Truy vấn dữ liệu

        /// <summary>
        /// Lấy danh sách khu vực chưa bị xóa mềm.
        /// Có hỗ trợ đa ngôn ngữ qua bảng BanDich.
        /// </summary>
        public List<KhuVuc> LayDanhSach(string langCode = "vi-VN")
        {

            using (var db = new DaiNamDBDataContext())
            {
                var query = db.KhuVucs.Where(k => k.DaXoa == false);
                if (langCode == "vi-VN" || string.IsNullOrEmpty(langCode))
                    return query.ToList();

                var listRaw = (from k in query
                               join bd in db.BanDiches
                               on new { Id = k.Id, Loai = "KhuVuc", Cot = "TenKhuVuc", NgonNgu = langCode }
                               equals new { Id = bd.IdThucThe, Loai = bd.LoaiThucThe, Cot = bd.TruongDich, NgonNgu = bd.NgonNgu } into dich
                               from d in dich.DefaultIfEmpty()
                               select new
                               {
                                   Id = k.Id,
                                   MaKhuVuc = k.MaKhuVuc,
                                   TenKhuVuc = d != null ? d.NoiDung : k.TenKhuVuc,
                                   LoaiKhuVuc = k.LoaiKhuVuc,
                                   SucChua = k.SucChua,
                                   TrangThai = k.TrangThai,
                                   MoTa = k.MoTa,
                                   DaXoa = k.DaXoa
                               }).ToList();

                var list = listRaw.Select(k => new KhuVuc
                {
                    Id = k.Id,
                    MaKhuVuc = k.MaKhuVuc,
                    TenKhuVuc = k.TenKhuVuc,
                    LoaiKhuVuc = k.LoaiKhuVuc,
                    SucChua = k.SucChua,
                    TrangThai = k.TrangThai,
                    MoTa = k.MoTa,
                    DaXoa = k.DaXoa
                }).ToList();

                return list;

            }

        }
        #endregion

        #region Thêm / Sửa / Xóa

        /// <summary>
        /// Thêm mới khu vực.
        /// </summary>
        public bool ThemKhuVuc(ET_KhuVuc et)
        {
            using (var db = new DaiNamDBDataContext())
            {
                KhuVuc kv = new KhuVuc();

                kv.MaKhuVuc = et.MaKhuVuc;

                kv.TenKhuVuc = et.TenKhuVuc;

                kv.LoaiKhuVuc = et.LoaiKhuVuc;

                kv.SucChua = et.SucChua;

                kv.TrangThai = et.TrangThai;

                kv.MoTa = et.MoTa;

                kv.DaXoa = false;

                db.KhuVucs.InsertOnSubmit(kv);

                db.SubmitChanges();

                return true;
            }
        }
        /// <summary>
        /// Cập nhật thông tin khu vực.
        /// </summary>
        public bool SuaKhuVuc(ET_KhuVuc et)
        {
            using (var db = new DaiNamDBDataContext())
            {
                var kv =
                    db.KhuVucs
                    .FirstOrDefault(x => x.Id == et.Id);

                if (kv == null)
                    return false;

                kv.MaKhuVuc = et.MaKhuVuc;

                kv.TenKhuVuc = et.TenKhuVuc;

                kv.LoaiKhuVuc = et.LoaiKhuVuc;

                kv.SucChua = et.SucChua;

                kv.TrangThai = et.TrangThai;

                kv.MoTa = et.MoTa;

                db.SubmitChanges();

                return true;
            }
        }
        #endregion

        #region Kiểm tra dữ liệu

        /// <summary>
        /// Kiểm tra mã hoặc tên đã tồn tại chưa.
        /// excludeId dùng cho trường hợp sửa.
        /// </summary>
        public bool KiemTraTonTai(string field, string value)
        {
            using (var db = new DaiNamDBDataContext())
            {
                value = value.Trim().ToLower();
                switch (field)
                {
                    case "MaKhuVuc":
                        return db.KhuVucs.Any(x => x.MaKhuVuc.Trim().ToLower() == value);
                    case "TenKhuVuc":
                        return db.KhuVucs.Any(x => x.TenKhuVuc.Trim().ToLower() == value);
                    default:
                        return false;
                }
            }
        }
        #endregion
    }
}


