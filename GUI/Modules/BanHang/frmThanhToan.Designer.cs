using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI.Modules.BanHang
{
    partial class frmThanhToan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new DevExpress.XtraEditors.LabelControl();
            this.lblTongPhaiThu = new DevExpress.XtraEditors.LabelControl();
            this.lblTongPhaiThuValue = new DevExpress.XtraEditors.LabelControl();
            this.gridThanhToan = new DevExpress.XtraGrid.GridControl();
            this.viewThanhToan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPhuongThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCboPhuongThuc = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnThemDong = new DevExpress.XtraEditors.SimpleButton();
            this.pnlTienNhanh = new DevExpress.XtraEditors.PanelControl();
            this.btn1tr = new DevExpress.XtraEditors.SimpleButton();
            this.btn500k = new DevExpress.XtraEditors.SimpleButton();
            this.btnVuaDu = new DevExpress.XtraEditors.SimpleButton();
            this.pnlDoiSoat = new DevExpress.XtraEditors.PanelControl();
            this.lblTienThuaValue = new DevExpress.XtraEditors.LabelControl();
            this.lblTienThua = new DevExpress.XtraEditors.LabelControl();
            this.lblConThieuValue = new DevExpress.XtraEditors.LabelControl();
            this.lblConThieu = new DevExpress.XtraEditors.LabelControl();
            this.lblDaTraValue = new DevExpress.XtraEditors.LabelControl();
            this.lblDaTra = new DevExpress.XtraEditors.LabelControl();
            this.pnlRFID = new DevExpress.XtraEditors.PanelControl();
            this.lblSoDuVi = new DevExpress.XtraEditors.LabelControl();
            this.lblChuThe = new DevExpress.XtraEditors.LabelControl();
            this.txtMaThe = new DevExpress.XtraEditors.TextEdit();
            this.lblMaThe = new DevExpress.XtraEditors.LabelControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.pnlDiem = new DevExpress.XtraEditors.PanelControl();
            this.lblQuyDoiDiem = new DevExpress.XtraEditors.LabelControl();
            this.spinDiemDung = new DevExpress.XtraEditors.SpinEdit();
            this.lblDiemCoSan = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridThanhToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewThanhToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCboPhuongThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTienNhanh)).BeginInit();
            this.pnlTienNhanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoiSoat)).BeginInit();
            this.pnlDoiSoat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRFID)).BeginInit();
            this.pnlRFID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaThe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDiem)).BeginInit();
            this.pnlDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiemDung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Appearance.Options.UseFont = true;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(153, 31);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THANH TOÁN";
            // 
            // lblTongPhaiThu
            // 
            this.lblTongPhaiThu.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongPhaiThu.Appearance.Options.UseFont = true;
            this.lblTongPhaiThu.Location = new System.Drawing.Point(20, 55);
            this.lblTongPhaiThu.Name = "lblTongPhaiThu";
            this.lblTongPhaiThu.Size = new System.Drawing.Size(122, 25);
            this.lblTongPhaiThu.TabIndex = 1;
            this.lblTongPhaiThu.Text = "Tổng phải thu:";
            // 
            // lblTongPhaiThuValue
            // 
            this.lblTongPhaiThuValue.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongPhaiThuValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTongPhaiThuValue.Appearance.Options.UseFont = true;
            this.lblTongPhaiThuValue.Appearance.Options.UseForeColor = true;
            this.lblTongPhaiThuValue.Appearance.Options.UseTextOptions = true;
            this.lblTongPhaiThuValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTongPhaiThuValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTongPhaiThuValue.Location = new System.Drawing.Point(350, 50);
            this.lblTongPhaiThuValue.Name = "lblTongPhaiThuValue";
            this.lblTongPhaiThuValue.Size = new System.Drawing.Size(200, 30);
            this.lblTongPhaiThuValue.TabIndex = 2;
            this.lblTongPhaiThuValue.Text = "0 ₫";
            // 
            // gridThanhToan
            // 
            this.gridThanhToan.Location = new System.Drawing.Point(20, 90);
            this.gridThanhToan.MainView = this.viewThanhToan;
            this.gridThanhToan.Name = "gridThanhToan";
            this.gridThanhToan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCboPhuongThuc});
            this.gridThanhToan.Size = new System.Drawing.Size(310, 150);
            this.gridThanhToan.TabIndex = 3;
            this.gridThanhToan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewThanhToan});
            // 
            // viewThanhToan
            // 
            this.viewThanhToan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhuongThuc,
            this.colSoTien,
            this.colGhiChu});
            this.viewThanhToan.GridControl = this.gridThanhToan;
            this.viewThanhToan.Name = "viewThanhToan";
            this.viewThanhToan.OptionsView.ShowGroupPanel = false;
            this.viewThanhToan.OptionsView.ShowIndicator = false;
            this.viewThanhToan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.ViewThanhToan_CellValueChanged);
            // 
            // colPhuongThuc
            // 
            this.colPhuongThuc.Caption = "Phương thức";
            this.colPhuongThuc.ColumnEdit = this.repCboPhuongThuc;
            this.colPhuongThuc.FieldName = "PhuongThuc";
            this.colPhuongThuc.Name = "colPhuongThuc";
            this.colPhuongThuc.Visible = true;
            this.colPhuongThuc.VisibleIndex = 0;
            this.colPhuongThuc.Width = 150;
            // 
            // repCboPhuongThuc
            // 
            this.repCboPhuongThuc.Items.AddRange(new object[] {
            "TienMat",
            "ChuyenKhoan",
            "ViRFID",
            "QR"});
            this.repCboPhuongThuc.Name = "repCboPhuongThuc";
            this.repCboPhuongThuc.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colSoTien
            // 
            this.colSoTien.Caption = "Số tiền";
            this.colSoTien.DisplayFormat.FormatString = "#,##0";
            this.colSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTien.FieldName = "SoTien";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.Visible = true;
            this.colSoTien.VisibleIndex = 1;
            this.colSoTien.Width = 130;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 2;
            this.colGhiChu.Width = 100;
            // 
            // btnThemDong
            // 
            this.btnThemDong.Location = new System.Drawing.Point(20, 245);
            this.btnThemDong.Name = "btnThemDong";
            this.btnThemDong.Size = new System.Drawing.Size(200, 26);
            this.btnThemDong.TabIndex = 4;
            this.btnThemDong.Text = "+ Thêm dòng thanh toán";
            this.btnThemDong.Click += new System.EventHandler(this.BtnThemDong_Click);
            // 
            // pnlTienNhanh
            // 
            this.pnlTienNhanh.Controls.Add(this.btn1tr);
            this.pnlTienNhanh.Controls.Add(this.btn500k);
            this.pnlTienNhanh.Controls.Add(this.btnVuaDu);
            this.pnlTienNhanh.Location = new System.Drawing.Point(350, 90);
            this.pnlTienNhanh.Name = "pnlTienNhanh";
            this.pnlTienNhanh.Size = new System.Drawing.Size(200, 150);
            this.pnlTienNhanh.TabIndex = 5;
            // 
            // btn1tr
            // 
            this.btn1tr.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn1tr.Appearance.Options.UseFont = true;
            this.btn1tr.Location = new System.Drawing.Point(10, 94);
            this.btn1tr.Name = "btn1tr";
            this.btn1tr.Size = new System.Drawing.Size(180, 35);
            this.btn1tr.TabIndex = 2;
            this.btn1tr.Text = "1,000,000";
            this.btn1tr.Click += new System.EventHandler(this.Btn1tr_Click);
            // 
            // btn500k
            // 
            this.btn500k.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn500k.Appearance.Options.UseFont = true;
            this.btn500k.Location = new System.Drawing.Point(10, 52);
            this.btn500k.Name = "btn500k";
            this.btn500k.Size = new System.Drawing.Size(180, 35);
            this.btn500k.TabIndex = 1;
            this.btn500k.Text = "500,000";
            this.btn500k.Click += new System.EventHandler(this.Btn500k_Click);
            // 
            // btnVuaDu
            // 
            this.btnVuaDu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVuaDu.Appearance.Options.UseFont = true;
            this.btnVuaDu.Location = new System.Drawing.Point(10, 10);
            this.btnVuaDu.Name = "btnVuaDu";
            this.btnVuaDu.Size = new System.Drawing.Size(180, 35);
            this.btnVuaDu.TabIndex = 0;
            this.btnVuaDu.Text = "Vừa đủ";
            this.btnVuaDu.Click += new System.EventHandler(this.BtnVuaDu_Click);
            // 
            // pnlDoiSoat
            // 
            this.pnlDoiSoat.Controls.Add(this.lblTienThuaValue);
            this.pnlDoiSoat.Controls.Add(this.lblTienThua);
            this.pnlDoiSoat.Controls.Add(this.lblConThieuValue);
            this.pnlDoiSoat.Controls.Add(this.lblConThieu);
            this.pnlDoiSoat.Controls.Add(this.lblDaTraValue);
            this.pnlDoiSoat.Controls.Add(this.lblDaTra);
            this.pnlDoiSoat.Location = new System.Drawing.Point(20, 280);
            this.pnlDoiSoat.Name = "pnlDoiSoat";
            this.pnlDoiSoat.Size = new System.Drawing.Size(530, 50);
            this.pnlDoiSoat.TabIndex = 6;
            // 
            // lblTienThuaValue
            // 
            this.lblTienThuaValue.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienThuaValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(60)))));
            this.lblTienThuaValue.Appearance.Options.UseFont = true;
            this.lblTienThuaValue.Appearance.Options.UseForeColor = true;
            this.lblTienThuaValue.Location = new System.Drawing.Point(460, 15);
            this.lblTienThuaValue.Name = "lblTienThuaValue";
            this.lblTienThuaValue.Size = new System.Drawing.Size(10, 23);
            this.lblTienThuaValue.TabIndex = 0;
            this.lblTienThuaValue.Text = "0";
            // 
            // lblTienThua
            // 
            this.lblTienThua.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTienThua.Appearance.Options.UseFont = true;
            this.lblTienThua.Location = new System.Drawing.Point(380, 15);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(76, 23);
            this.lblTienThua.TabIndex = 1;
            this.lblTienThua.Text = "Tiền thừa:";
            // 
            // lblConThieuValue
            // 
            this.lblConThieuValue.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConThieuValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblConThieuValue.Appearance.Options.UseFont = true;
            this.lblConThieuValue.Appearance.Options.UseForeColor = true;
            this.lblConThieuValue.Location = new System.Drawing.Point(280, 15);
            this.lblConThieuValue.Name = "lblConThieuValue";
            this.lblConThieuValue.Size = new System.Drawing.Size(10, 23);
            this.lblConThieuValue.TabIndex = 2;
            this.lblConThieuValue.Text = "0";
            // 
            // lblConThieu
            // 
            this.lblConThieu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConThieu.Appearance.Options.UseFont = true;
            this.lblConThieu.Location = new System.Drawing.Point(200, 15);
            this.lblConThieu.Name = "lblConThieu";
            this.lblConThieu.Size = new System.Drawing.Size(79, 23);
            this.lblConThieu.TabIndex = 3;
            this.lblConThieu.Text = "Còn thiếu:";
            // 
            // lblDaTraValue
            // 
            this.lblDaTraValue.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDaTraValue.Appearance.Options.UseFont = true;
            this.lblDaTraValue.Location = new System.Drawing.Point(70, 15);
            this.lblDaTraValue.Name = "lblDaTraValue";
            this.lblDaTraValue.Size = new System.Drawing.Size(10, 23);
            this.lblDaTraValue.TabIndex = 4;
            this.lblDaTraValue.Text = "0";
            // 
            // lblDaTra
            // 
            this.lblDaTra.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDaTra.Appearance.Options.UseFont = true;
            this.lblDaTra.Location = new System.Drawing.Point(10, 15);
            this.lblDaTra.Name = "lblDaTra";
            this.lblDaTra.Size = new System.Drawing.Size(51, 23);
            this.lblDaTra.TabIndex = 5;
            this.lblDaTra.Text = "Đã trả:";
            // 
            // pnlRFID
            // 
            this.pnlRFID.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.pnlRFID.Appearance.Options.UseBackColor = true;
            this.pnlRFID.Controls.Add(this.lblSoDuVi);
            this.pnlRFID.Controls.Add(this.lblChuThe);
            this.pnlRFID.Controls.Add(this.txtMaThe);
            this.pnlRFID.Controls.Add(this.lblMaThe);
            this.pnlRFID.Location = new System.Drawing.Point(20, 340);
            this.pnlRFID.Name = "pnlRFID";
            this.pnlRFID.Size = new System.Drawing.Size(530, 45);
            this.pnlRFID.TabIndex = 7;
            this.pnlRFID.Visible = false;
            // 
            // lblSoDuVi
            // 
            this.lblSoDuVi.Location = new System.Drawing.Point(370, 14);
            this.lblSoDuVi.Name = "lblSoDuVi";
            this.lblSoDuVi.Size = new System.Drawing.Size(58, 16);
            this.lblSoDuVi.TabIndex = 0;
            this.lblSoDuVi.Text = "Số dư: ---";
            // 
            // lblChuThe
            // 
            this.lblChuThe.Location = new System.Drawing.Point(200, 14);
            this.lblChuThe.Name = "lblChuThe";
            this.lblChuThe.Size = new System.Drawing.Size(68, 16);
            this.lblChuThe.TabIndex = 1;
            this.lblChuThe.Text = "Chủ thẻ: ---";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(65, 11);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(120, 22);
            this.txtMaThe.TabIndex = 2;
            // 
            // lblMaThe
            // 
            this.lblMaThe.Location = new System.Drawing.Point(10, 14);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(44, 16);
            this.lblMaThe.TabIndex = 3;
            this.lblMaThe.Text = "Mã thẻ:";
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(300, 400);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 35);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "HỦY (Esc)";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.btnXacNhan.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Appearance.Options.UseBackColor = true;
            this.btnXacNhan.Appearance.Options.UseFont = true;
            this.btnXacNhan.Appearance.Options.UseForeColor = true;
            this.btnXacNhan.Location = new System.Drawing.Point(420, 400);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(130, 35);
            this.btnXacNhan.TabIndex = 9;
            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.Click += new System.EventHandler(this.BtnXacNhan_Click);
            // 
            // pnlDiem
            // 
            this.pnlDiem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlDiem.Appearance.Options.UseBackColor = true;
            this.pnlDiem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDiem.Controls.Add(this.lblQuyDoiDiem);
            this.pnlDiem.Controls.Add(this.spinDiemDung);
            this.pnlDiem.Controls.Add(this.lblDiemCoSan);
            this.pnlDiem.Location = new System.Drawing.Point(20, 245);
            this.pnlDiem.Name = "pnlDiem";
            this.pnlDiem.Size = new System.Drawing.Size(530, 30);
            this.pnlDiem.TabIndex = 10;
            this.pnlDiem.Visible = false;
            // 
            // lblQuyDoiDiem
            // 
            this.lblQuyDoiDiem.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuyDoiDiem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(60)))));
            this.lblQuyDoiDiem.Appearance.Options.UseFont = true;
            this.lblQuyDoiDiem.Appearance.Options.UseForeColor = true;
            this.lblQuyDoiDiem.Location = new System.Drawing.Point(336, 6);
            this.lblQuyDoiDiem.Name = "lblQuyDoiDiem";
            this.lblQuyDoiDiem.Size = new System.Drawing.Size(34, 20);
            this.lblQuyDoiDiem.TabIndex = 0;
            this.lblQuyDoiDiem.Text = "= 0₫";
            // 
            // spinDiemDung
            // 
            this.spinDiemDung.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinDiemDung.Location = new System.Drawing.Point(226, 4);
            this.spinDiemDung.Name = "spinDiemDung";
            this.spinDiemDung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinDiemDung.Properties.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinDiemDung.Properties.IsFloatValue = false;
            this.spinDiemDung.Size = new System.Drawing.Size(100, 24);
            this.spinDiemDung.TabIndex = 1;
            this.spinDiemDung.EditValueChanged += new System.EventHandler(this.SpinDiemDung_EditValueChanged);
            // 
            // lblDiemCoSan
            // 
            this.lblDiemCoSan.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemCoSan.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblDiemCoSan.Appearance.Options.UseFont = true;
            this.lblDiemCoSan.Appearance.Options.UseForeColor = true;
            this.lblDiemCoSan.Location = new System.Drawing.Point(8, 6);
            this.lblDiemCoSan.Name = "lblDiemCoSan";
            this.lblDiemCoSan.Size = new System.Drawing.Size(131, 20);
            this.lblDiemCoSan.TabIndex = 2;
            this.lblDiemCoSan.Text = "⭐ Có 0 điểm. Dùng:";
            // 
            // frmThanhToan
            // 
            this.AcceptButton = this.btnXacNhan;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(570, 450);
            this.Controls.Add(this.pnlDiem);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.pnlRFID);
            this.Controls.Add(this.pnlDoiSoat);
            this.Controls.Add(this.pnlTienNhanh);
            this.Controls.Add(this.btnThemDong);
            this.Controls.Add(this.gridThanhToan);
            this.Controls.Add(this.lblTongPhaiThuValue);
            this.Controls.Add(this.lblTongPhaiThu);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán";
            ((System.ComponentModel.ISupportInitialize)(this.gridThanhToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewThanhToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCboPhuongThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTienNhanh)).EndInit();
            this.pnlTienNhanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoiSoat)).EndInit();
            this.pnlDoiSoat.ResumeLayout(false);
            this.pnlDoiSoat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRFID)).EndInit();
            this.pnlRFID.ResumeLayout(false);
            this.pnlRFID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaThe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDiem)).EndInit();
            this.pnlDiem.ResumeLayout(false);
            this.pnlDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiemDung.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblTieuDe;
        private DevExpress.XtraEditors.LabelControl lblTongPhaiThu;
        private DevExpress.XtraEditors.LabelControl lblTongPhaiThuValue;
        private DevExpress.XtraGrid.GridControl gridThanhToan;
        private DevExpress.XtraGrid.Views.Grid.GridView viewThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colPhuongThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.SimpleButton btnThemDong;
        private DevExpress.XtraEditors.PanelControl pnlTienNhanh;
        private DevExpress.XtraEditors.SimpleButton btnVuaDu;
        private DevExpress.XtraEditors.SimpleButton btn500k;
        private DevExpress.XtraEditors.SimpleButton btn1tr;
        private DevExpress.XtraEditors.PanelControl pnlDoiSoat;
        private DevExpress.XtraEditors.LabelControl lblDaTra;
        private DevExpress.XtraEditors.LabelControl lblDaTraValue;
        private DevExpress.XtraEditors.LabelControl lblConThieu;
        private DevExpress.XtraEditors.LabelControl lblConThieuValue;
        private DevExpress.XtraEditors.LabelControl lblTienThua;
        private DevExpress.XtraEditors.LabelControl lblTienThuaValue;
        private DevExpress.XtraEditors.PanelControl pnlRFID;
        private DevExpress.XtraEditors.LabelControl lblMaThe;
        private DevExpress.XtraEditors.TextEdit txtMaThe;
        private DevExpress.XtraEditors.LabelControl lblChuThe;
        private DevExpress.XtraEditors.LabelControl lblSoDuVi;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repCboPhuongThuc;
        private DevExpress.XtraEditors.PanelControl pnlDiem;
        private DevExpress.XtraEditors.LabelControl lblDiemCoSan;
        private DevExpress.XtraEditors.SpinEdit spinDiemDung;
        private DevExpress.XtraEditors.LabelControl lblQuyDoiDiem;
        private System.ComponentModel.IContainer components = null;




    }}