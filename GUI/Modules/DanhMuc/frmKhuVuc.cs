using BUS.Services.DanhMuc;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using ET.Models.DanhMuc;
using GUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Modules.DanhMuc
{
    public partial class frmKhuVuc : DevExpress.XtraEditors.XtraForm
    {
        #region Biến toàn cục

        // lưu khu vực đang được chọn trên grid
        ET_KhuVuc kvDangChon = null;
        #endregion

        #region Khởi tạo
        public frmKhuVuc()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Load dữ liệu
        /// <summary>
        /// Load danh sách khu vực lên grid.
        /// </summary>
        private void loadDS()
        {
            gcKhuVuc.DataSource = BUS_KhuVuc.Instance.LayDanhSach(SessionManager.CurrentLanguage);
        }
        /// <summary>
        /// Load form.
        /// </summary>
        private void frmKhuVuc_Load(object sender, EventArgs e)
        {
            loadDS();
            LoadLoaiKhuVuc();
            tgTrangThai.IsOn = true;
        }
        /// <summary>
        /// Load danh sách loại khu vực cố định.
        /// </summary>
        private void LoadLoaiKhuVuc()
        {
            cboLoaiKV.Properties.Items.Clear();

            cboLoaiKV.Properties.Items.Add("CongVao");

            cboLoaiKV.Properties.Items.Add("VuiChoi");

            cboLoaiKV.Properties.Items.Add("ThamQuan");

            cboLoaiKV.Properties.Items.Add("LuuTru");

            cboLoaiKV.Properties.Items.Add("AnUong");

            cboLoaiKV.Properties.Items.Add("HaTang");

            cboLoaiKV.Properties.Items.Add("GiaiTri");
        }
        private void gcKhuVuc_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region GridView

        /// <summary>
        /// Click dòng trên grid để load dữ liệu.
        /// </summary>
        private void gvKhuVuc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            var row = gvKhuVuc.GetRow(e.RowHandle) as ET_KhuVuc;

            if (row == null)
                return;

            kvDangChon = row;

            txtMaKV.Text = row.MaKhuVuc;

            txtTenKV.Text = row.TenKhuVuc;

            cboLoaiKV.EditValue = row.LoaiKhuVuc;

            spSucChua.Value = row.SucChua ?? 0;

            mMoTa.Text = row.MoTa;

            tgTrangThai.IsOn = row.TrangThai == "HoatDong";
            // khóa mã
            txtMaKV.Enabled = false;
        }
        #endregion

        #region Thêm

        /// <summary>
        /// Thêm khu vực mới.
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                ET_KhuVuc et = new ET_KhuVuc();

                et.MaKhuVuc = txtMaKV.Text.Trim();

                et.TenKhuVuc = txtTenKV.Text.Trim();

                et.LoaiKhuVuc = cboLoaiKV.EditValue?.ToString();

                et.SucChua = Convert.ToInt32(spSucChua.Value);

                et.TrangThai = tgTrangThai.IsOn ? "HoatDong" : "NgungHoatDong";

                et.MoTa = mMoTa.Text;

                bool kq = BUS_KhuVuc.Instance.ThemKhuVuc(et);

                if (kq)
                {
                    XtraMessageBox.Show("Thêm thành công");

                    loadDS();

                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Sửa
        /// <summary>
        /// Cập nhật khu vực.
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (kvDangChon == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn khu vực");
                    return;
                }

                kvDangChon.MaKhuVuc = txtMaKV.Text.Trim();

                kvDangChon.TenKhuVuc = txtTenKV.Text.Trim();

                kvDangChon.LoaiKhuVuc = cboLoaiKV.EditValue?.ToString();

                kvDangChon.SucChua = Convert.ToInt32(spSucChua.Value);

                kvDangChon.TrangThai = tgTrangThai.IsOn ? "HoatDong" : "NgungHoatDong";

                kvDangChon.MoTa = mMoTa.Text;

                bool kq = BUS_KhuVuc.Instance.SuaKhuVuc(kvDangChon);

                if (kq)
                {
                    XtraMessageBox.Show("Cập nhật thành công");

                    loadDS();

                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Làm mới
        /// <summary>
        /// Reset dữ liệu form.
        /// </summary>
        private void LamMoi()
        {
            kvDangChon = null;

            txtMaKV.Clear();

            txtTenKV.Clear();

            cboLoaiKV.EditValue = null;

            spSucChua.Value = 0;

            mMoTa.Clear();

            tgTrangThai.IsOn = true;
            // mở lại mã
            txtMaKV.Enabled = true;
            txtMaKV.Focus();
            gvKhuVuc.ClearSelection();
        }
        /// <summary>
        /// Click làm mới.
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();

            loadDS();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Thoát

        /// <summary>
        /// Đóng form.
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = XtraMessageBox.Show(
            "Bạn có muốn thoát không ?",
            "Thông báo",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion
    }
}