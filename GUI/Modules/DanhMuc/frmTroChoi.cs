using BUS.Services.DanhMuc;
using DAL;
using DevExpress.XtraEditors;
using ET.Models.DanhMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Infrastructure;

namespace GUI.Modules.DanhMuc
{
    public partial class frmTroChoi : DevExpress.XtraEditors.XtraForm
    {
        #region Biến toàn cục

        // TRUE  = đang thêm
        // FALSE = đang sửa
        private bool _isAdding = false;
        private int _idTroChoi = 0;

        #endregion

        #region Khởi tạo
        public frmTroChoi()
        {
            InitializeComponent();
        }

        private void panelControl8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Load dữ liệu

        /// <summary>
        /// Load danh sách trò chơi.
        /// </summary>
        private void LoadDanhSachTroChoi()
        {
            gcTroChoi.DataSource = BUS_TroChoi.Instance.GetDanhSachTroChoi(SessionManager.CurrentLanguage);
        }
        /// <summary>
        /// Load danh sách khu vực.
        /// </summary>
        private void LoadKhuVuc()
        {
            lkKhuVuc.Properties.DataSource = BUS_TroChoi.Instance.GetKhuVuc();

            lkKhuVuc.Properties.DisplayMember = "TenKhuVuc";
            lkKhuVuc.Properties.ValueMember = "Id";

            lkKhuVuc.Properties.NullText = "";
            lkKhuVuc.Properties.PopulateColumns();

            lkKhuVuc.Properties.Columns["Id"].Visible = false;
            lkKhuVuc.Properties.Columns["MaKhuVuc"].Visible = false;
            lkKhuVuc.Properties.Columns["SucChua"].Visible = false;
            lkKhuVuc.Properties.Columns["TrangThai"].Visible = false;
            lkKhuVuc.Properties.Columns["HinhAnh"].Visible = false;
            lkKhuVuc.Properties.Columns["MoTa"].Visible = false;
            lkKhuVuc.Properties.Columns["LoaiKhuVuc"].Visible = false;
            lkKhuVuc.Properties.Columns["DaXoa"].Visible = false;
            lkKhuVuc.Properties.Columns["KhuVucBien"].Visible = false;
            lkKhuVuc.Properties.Columns["KhuVucThu"].Visible = false;


        }
        /// <summary>
        /// Load trạng thái trò chơi.
        /// </summary>
        private void LoadTrangThai()
        {
            cboTrangThai.Properties.Items.Clear();

            cboTrangThai.Properties.Items.Add("HoatDong");
            cboTrangThai.Properties.Items.Add("BaoTri");
            cboTrangThai.Properties.Items.Add("TamNgung");
        }
        /// <summary>
        /// Load thống kê.
        /// </summary>
        private void LoadThongKe()
        {
            lblTongTroChoi.Text = BUS_TroChoi.Instance.TongTroChoi().ToString();
            lblTongHoatDong.Text = BUS_TroChoi.Instance.TongHoatDong().ToString();
            lblTongBaoTri.Text = BUS_TroChoi.Instance.TongBaoTri().ToString();
            lblTongTamNgung.Text = BUS_TroChoi.Instance.TongTamNgung().ToString();
        }
        /// <summary>
        /// Load form.
        /// </summary>
        private void frmTroChoi_Load(object sender, EventArgs e)
        {
            LoadDanhSachTroChoi();
            LoadKhuVuc();
            LoadTrangThai();
            LoadThongKe();
        }
        #endregion

        #region GridView

        /// <summary>
        /// Click dòng trên grid để load dữ liệu.
        /// </summary>
        private void gvTroChoi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var troChoi = gvTroChoi.GetFocusedRow() as ET_TroChoi;

                if (troChoi == null) return;

                _idTroChoi = troChoi.Id;
                // Tên trò chơi
                txtTenTC.Text = troChoi.TenTroChoi;

                // Khu vực
                lkKhuVuc.EditValue = troChoi.IdKhuVuc;

                // Sức chứa
                spSucChua.EditValue = troChoi.SucChua ?? 0;

                // Độ tuổi tối thiểu
                spTuoiToiThieu.EditValue = troChoi.DoTuoiToiThieu ?? 0;

                // Thời gian lượt
                spThoiGian.EditValue = troChoi.ThoiGianLuot ?? 0;

                // Trạng thái
                cboTrangThai.EditValue = troChoi.TrangThai;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Làm mới

        /// <summary>
        /// Reset form.
        /// </summary>
        private void ClearForm()
        {
            _idTroChoi = 0;

            txtTenTC.Text = "";
            lkKhuVuc.EditValue = null;

            spSucChua.EditValue = 0;
            spTuoiToiThieu.EditValue = 0;
            spThoiGian.EditValue = 0;

            cboTrangThai.EditValue = "HoatDong";

            txtTenTC.Focus();
        }
        #endregion

        #region Thêm

        /// <summary>
        /// Chuyển sang chế độ thêm.
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;

            ClearForm();
        }
        #endregion

        #region Sửa

        /// <summary>
        /// Sửa cập nhật trò chơi
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idTroChoi == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn trò chơi");
                    return;
                }

                var tc = new TroChoi()
                {
                    Id = _idTroChoi,

                    TenTroChoi = txtTenTC.Text.Trim(),

                    IdKhuVuc = lkKhuVuc.EditValue != null
                        ? Convert.ToInt32(lkKhuVuc.EditValue)
                        : (int?)null,

                    SucChua = Convert.ToInt32(spSucChua.EditValue),

                    DoTuoiToiThieu = Convert.ToInt32(spTuoiToiThieu.EditValue),

                    ThoiGianLuot = Convert.ToInt32(spThoiGian.EditValue),

                    TrangThai = cboTrangThai.EditValue?.ToString()
                };

                bool result = BUS_TroChoi.Instance.CapNhatTroChoi(tc);

                if (result)
                {
                    XtraMessageBox.Show("Cập nhật thành công");

                    LoadDanhSachTroChoi();
                    LoadThongKe();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật thất bại");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Lưu

        /// <summary>
        /// Thêm trò chơi.
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenTC.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập tên trò chơi");
                    return;
                }

                var tc = new TroChoi()
                {
                    TenTroChoi = txtTenTC.Text.Trim(),

                    IdKhuVuc = lkKhuVuc.EditValue != null
                        ? Convert.ToInt32(lkKhuVuc.EditValue)
                        : (int?)null,

                    SucChua = Convert.ToInt32(spSucChua.EditValue),

                    DoTuoiToiThieu = Convert.ToInt32(spTuoiToiThieu.EditValue),

                    ThoiGianLuot = Convert.ToInt32(spThoiGian.EditValue),

                    TrangThai = cboTrangThai.EditValue?.ToString(),

                    DaXoa = false
                };

                bool result = BUS_TroChoi.Instance.ThemTroChoi(tc);

                if (result)
                {
                    XtraMessageBox.Show("Thêm trò chơi thành công");

                    LoadDanhSachTroChoi();
                    LoadThongKe();
                    ClearForm();

                    _isAdding = false;
                }
                else
                {
                    XtraMessageBox.Show("Thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Xóa

        /// <summary>
        /// Xóa mềm trò chơi.
        /// Chỉ cho phép xóa khi đã tạm ngưng.
        /// </summary>
        private void btnXoaa_Click(object sender, EventArgs e)
        {
            try
            {
                var troChoi = gvTroChoi.GetFocusedRow() as ET_TroChoi;

                if (troChoi == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn trò chơi!");
                    return;
                }

                // Chỉ cho xóa khi đã tạm ngưng
                if (troChoi.TrangThai != "TamNgung")
                {
                    XtraMessageBox.Show(
                        "Chỉ được xóa trò chơi đã tạm ngưng!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var rs = XtraMessageBox.Show(
                    $"Xóa trò chơi [{troChoi.TenTroChoi}] ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (rs != DialogResult.Yes)
                    return;

                bool result = BUS_TroChoi.Instance.XoaTroChoi(troChoi.Id);

                if (result)
                {
                    XtraMessageBox.Show("Xóa thành công!");

                    LoadDanhSachTroChoi();
                    LoadThongKe();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show("Xóa thất bại!");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}