using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmHeSoLopDongTheoKhoa :frmBase
    {
        private cBGG_HeSoLopDongTheoKhoa oBGG_HeSoLopDongTheoKhoa;
        private GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo;
        private DataTable dtHeSo, dtLoaiGiangDay;
        private DataRow drHeSo;
        private EDIT_MODE edit;

        public frmHeSoLopDongTheoKhoa()
        {
            InitializeComponent();
            oBGG_HeSoLopDongTheoKhoa = new cBGG_HeSoLopDongTheoKhoa();
            pGG_HeSoLopDongTheoKhoaInfo = new GG_HeSoLopDongTheoKhoaInfo();
            groupTop.Visible = false;
            SetControl(false);
        }

        private void frmHeSoLopDongTheoKhoa_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            DataTable dtKhoa = LoadKhoa();
            cmbKhoa.Properties.DataSource = dtKhoa;
            dtHeSo = oBGG_HeSoLopDongTheoKhoa.GetAll(0);
            grdHeSo.DataSource = dtHeSo;
            dtLoaiGiangDay = baseLoadLoaiGiangDay();
            cmbLoaiGiangDay.Properties.DataSource = dtLoaiGiangDay;
            repositoryItemcmbLoaiGiangDay.DataSource = dtLoaiGiangDay;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.EditValue = dtTrinhDo.Rows[0]["DM_TrinhDoID"];
            //if (dtKhoa.Rows.Count > 0)
            //    cmbKhoa.EditValue = dtKhoa.Rows[0]["DM_KhoaID"].ToString();
            if (dtLoaiGiangDay.Rows.Count > 0)
                cmbLoaiGiangDay.EditValue = dtLoaiGiangDay.Rows[0]["LoaiGiangDay"];
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void SetText()
        {
            cmbLoaiGiangDay.EditValue = drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strLoaiGiangDay];
            cmbTrinhDo.EditValue = drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strIDDM_TrinhDo];
            cmbKhoa.EditValue = drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strIDDM_Khoa];
            txtSoSVToiDa.Text = "" + drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strSoSVToiDa];
            txtHeSoQuyChuan.Text = "" + drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strHeSoQuyChuan];
            txtSoCongThem1Tiet.Text = "" + drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strSoCongThem1Tiet];
            txtSoTietDinhMuc1Tuan.Text = "" + drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strSoTietDinhMuc1Tuan];
            txtSoSVToiDa.Focus();
        }

        private void ClearText()
        {
            txtSoSVToiDa.Text = "";
            txtHeSoQuyChuan.Text = "";
            txtSoCongThem1Tiet.Text = "";
            txtSoTietDinhMuc1Tuan.Text = "";
            txtSoSVToiDa.Focus();
        }

        private bool CheckValid()
        { 
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (cmbLoaiGiangDay.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLoaiGiangDay, "Loại giảng dạy phải được chọn.");
                if (CtrlErr == null) CtrlErr = cmbLoaiGiangDay;
            }
            if (cmbTrinhDo.EditValue == null)
            {
                dxErrorProvider.SetError(cmbTrinhDo, "Trình độ phải được chọn.");
                if (CtrlErr == null) CtrlErr = cmbTrinhDo;
            }
            if (cmbKhoa.EditValue == null)
            {
                dxErrorProvider.SetError(cmbKhoa, "Khoa phải được chọn.");
                if (CtrlErr == null) CtrlErr = cmbKhoa;
            }
            if (txtSoSVToiDa.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtSoSVToiDa, "Số sinh viên trong ô này không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoSVToiDa;
            }
            if (txtHeSoQuyChuan.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtHeSoQuyChuan, "Hệ số không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtHeSoQuyChuan;
            }
            if (txtSoCongThem1Tiet.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtSoCongThem1Tiet, "Số sinh viên vượt định mức được cộng thêm 1 tiết không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoCongThem1Tiet;
            }
            if (txtSoTietDinhMuc1Tuan.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtSoTietDinhMuc1Tuan, "Số tiết định mức trong 1 tuần không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoTietDinhMuc1Tuan;
            }
            

            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void GetpHeSoTheoTrinhDoInfo()
        {
            pGG_HeSoLopDongTheoKhoaInfo.IDDM_TrinhDo = (int)cmbTrinhDo.EditValue;
            pGG_HeSoLopDongTheoKhoaInfo.LoaiGiangDay = cmbLoaiGiangDay.EditValue.ToString();
            pGG_HeSoLopDongTheoKhoaInfo.SoSVToiDa = int.Parse(txtSoSVToiDa.Text);
            pGG_HeSoLopDongTheoKhoaInfo.HeSoQuyChuan = double.Parse(txtHeSoQuyChuan.Text);
            pGG_HeSoLopDongTheoKhoaInfo.SoCongThem1Tiet = int.Parse(txtSoCongThem1Tiet.Text);
            pGG_HeSoLopDongTheoKhoaInfo.SoTietDinhMuc1Tuan = double.Parse(txtSoTietDinhMuc1Tuan.Text);
            
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupTop.Visible = true;
            cmbKhoa.EditValue = null;
            cmbKhoa.Properties.ReadOnly = false;
            edit = EDIT_MODE.THEM;
            grdHeSo.Enabled = false;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupTop.Visible = true;
            cmbKhoa.Properties.ReadOnly = true;
            edit = EDIT_MODE.SUA;
            grdHeSo.Enabled = false;
            SetText();
            cmbKhoa.RefreshEditValue();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID = int.Parse(drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strGG_HeSoLopDongTheoKhoaID].ToString());
                    oBGG_HeSoLopDongTheoKhoa.Delete(pGG_HeSoLopDongTheoKhoaInfo);
                    dtHeSo.Rows.Remove(drHeSo);
                    grvTrinhDo_FocusedRowChanged(null, null);
                }
                catch //(Exception ex)
                {
                    XoaThatBai();
                }
            }
        }

        private void grvTrinhDo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvHeSo.FocusedRowHandle >= 0)
            {
                drHeSo = grvHeSo.GetDataRow(grvHeSo.FocusedRowHandle);
                SetControl(true);
            }
            else
                SetControl(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            groupTop.Visible = false;
            grdHeSo.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            try
            {
                GetpHeSoTheoTrinhDoInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    string[] arrID = cmbKhoa.EditValue.ToString().Split(',');
                    foreach (string str in arrID)
                    {
                        pGG_HeSoLopDongTheoKhoaInfo.IDDM_Khoa = int.Parse(str);
                        pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID = oBGG_HeSoLopDongTheoKhoa.Add(pGG_HeSoLopDongTheoKhoaInfo);
                        drHeSo = dtHeSo.NewRow();
                        oBGG_HeSoLopDongTheoKhoa.ToDataRow(pGG_HeSoLopDongTheoKhoaInfo, ref drHeSo);
                        drHeSo["TenTrinhDo"] = cmbTrinhDo.Text;
                        drHeSo["TenKhoa"] = cmbKhoa.Text;
                        dtHeSo.Rows.Add(drHeSo);
                    }
                    ClearText();
                }
                else
                {
                    pGG_HeSoLopDongTheoKhoaInfo.IDDM_Khoa = int.Parse(cmbKhoa.EditValue.ToString());
                    pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID = int.Parse(drHeSo[pGG_HeSoLopDongTheoKhoaInfo.strGG_HeSoLopDongTheoKhoaID].ToString());
                    oBGG_HeSoLopDongTheoKhoa.Update(pGG_HeSoLopDongTheoKhoaInfo);
                    oBGG_HeSoLopDongTheoKhoa.ToDataRow(pGG_HeSoLopDongTheoKhoaInfo, ref drHeSo);
                    drHeSo["TenTrinhDo"] = cmbTrinhDo.Text;
                    drHeSo["TenKhoa"] = cmbKhoa.Text;
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi("Có lỗi khi lưu./n" + ex.Message);
            }
        }

        private void grvHeSo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}