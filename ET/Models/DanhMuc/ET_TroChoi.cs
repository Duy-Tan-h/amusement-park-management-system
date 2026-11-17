namespace ET.Models.DanhMuc
{
    public class ET_TroChoi
    {
        public int Id { get; set; }
        public string TenTroChoi { get; set; }
        public int? IdKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }
        public int? SucChua { get; set; }
        public int? DoTuoiToiThieu { get; set; }
        public int? ThoiGianLuot { get; set; }
        public string TrangThai { get; set; }
        public bool DaXoa { get; set; }
    }
}
