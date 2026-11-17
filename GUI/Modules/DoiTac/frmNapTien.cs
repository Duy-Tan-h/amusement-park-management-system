using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GUI.Infrastructure;
using ET.Constants;

namespace GUI.Modules.DoiTac
{
    public partial class frmNapTien : XtraForm
    {
        public decimal SoTien { get; private set; }
        public string PhuongThuc { get; private set; }

        private readonly string[] _dsPhuongThuc = new[]
        {
            AppConstants.PhuongThucTT.TienMat,
            AppConstants.PhuongThucTT.ChuyenKhoan,
            AppConstants.PhuongThucTT.QR,
            AppConstants.PhuongThucTT.MoMo,
            AppConstants.PhuongThucTT.TheNganHang
        };
        private string T(string key, string fallback)
        {
            string s = LanguageManager.GetString(key);

            if (string.IsNullOrWhiteSpace(s) || s == key)
                return fallback;

            return s;
        }
        public frmNapTien()
        {
            InitializeComponent();
            btnXacNhan.DialogResult = DialogResult.None;
            btnHuy.DialogResult = DialogResult.None;

            btnXacNhan.Click -= BtnXacNhan_Click;
            btnXacNhan.Click += BtnXacNhan_Click;

            btnHuy.Click -= BtnHuy_Click;
            btnHuy.Click += BtnHuy_Click;
            ApplyStyle();
            DichNgonNgu();
            NapComboBox();
            AppStyle.FixEditorForeColor(this);
        }


        private void ApplyStyle()
        {
            lblTitle.ForeColor = AppStyle.Teal;
            AppStyle.StyleBtnPrimary(btnXacNhan);
            AppStyle.StyleBtnOutline(btnHuy, AppStyle.Navy);
        }

        private void DichNgonNgu()
        {
            Text = T("FRM_NAP_TIEN_TITLE", "Nạp tiền ví");

            lblTitle.Text = T("FRM_NAP_TIEN_HEADER", "NẠP TIỀN VÍ ĐIỆN TỬ");

            lblSoTien.Text = T("LBL_NAP_SOTIEN", "Số tiền nạp (*)");

            lblPhuongThuc.Text = T("LBL_NAP_PHUONGTHUC", "Hình thức thanh toán (*)");

            btnXacNhan.Text = "  " + T("BTN_NAP_XACNHAN", "Xác nhận nạp tiền");

            btnHuy.Text = T("BTN_HUY_CHUNG", "Hủy");
        }

        private void NapComboBox()
        {
            cboPhuongThuc.Properties.Items.Clear();

            foreach (var pt in _dsPhuongThuc)
            {
                cboPhuongThuc.Properties.Items.Add(
                    T("PTTT_" + pt, DichPhuongThuc(pt)));
            }

            cboPhuongThuc.SelectedIndex = 0;
        }

        private string DichPhuongThuc(string ma)
        {
            switch (ma)
            {
                case AppConstants.PhuongThucTT.TienMat: return "Tiền mặt";
                case AppConstants.PhuongThucTT.ChuyenKhoan: return "Chuyển khoản";
                case AppConstants.PhuongThucTT.QR: return "QR Code";
                case AppConstants.PhuongThucTT.MoMo: return "Ví MoMo";
                case AppConstants.PhuongThucTT.TheNganHang: return "Thẻ ngân hàng";
                default: return ma;
            }
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (numSoTien.Value <= 0)
                {
                    UIHelper.Loi(
                        T(AppConstants.ErrorMessages.ERR_VI_SO_TIEN_AM,
                        "Số tiền phải lớn hơn 0!"));

                    numSoTien.Focus();
                    return;
                }

                if (cboPhuongThuc.SelectedIndex < 0)
                {
                    UIHelper.Loi("Vui lòng chọn phương thức thanh toán!");
                    cboPhuongThuc.Focus();
                    return;
                }

                SoTien = numSoTien.Value;

                PhuongThuc = _dsPhuongThuc[cboPhuongThuc.SelectedIndex];

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Lỗi form nạp tiền: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
