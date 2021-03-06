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
    public partial class frmHeSoGioGiang :frmBase
    {        
        private cBGG_HeSoTheoTrinhDo oBGG_HeSoTrinhDo;
        private GG_HeSoTheoTrinhDoInfo pGG_HeSoTrinhDoInfo;
        private DataTable dtHeSo, dtLoaiGiangDay;
        private DataRow drHeSo;
        private EDIT_MODE edit;
     
        public frmHeSoGioGiang()
        {
            InitializeComponent();
            oBGG_HeSoTrinhDo = new cBGG_HeSoTheoTrinhDo();
            pGG_HeSoTrinhDoInfo = new GG_HeSoTheoTrinhDoInfo();
            groupTop.Visible = false;
            SetControl(false);
        }

        private void frmHeSoGioGiang_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            dtHeSo = oBGG_HeSoTrinhDo.GetAll();
            grdHeSo.DataSource = dtHeSo;
            dtLoaiGiangDay = baseLoadLoaiGiangDay();
            cmbLoaiGiangDay.Properties.DataSource = dtLoaiGiangDay;
            repositoryItemcmbLoaiGiangDay.DataSource = dtLoaiGiangDay;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.EditValue = dtTrinhDo.Rows[0]["DM_TrinhDoID"];
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
            cmbLoaiGiangDay.EditValue = drHeSo[pGG_HeSoTrinhDoInfo.strLoaiGiangDay];
            cmbTrinhDo.EditValue = drHeSo[pGG_HeSoTrinhDoInfo.strIDDM_TrinhDo];
            txtTuSo.Text = "" + drHeSo[pGG_HeSoTrinhDoInfo.strTuSo];
            txtDenSo.Text = "" + drHeSo[pGG_HeSoTrinhDoInfo.strDenSo];
            txtHeSo.Text = "" + drHeSo[pGG_HeSoTrinhDoInfo.strHeSo];
            txtTuSo.Focus();
        }

        private void ClearText()
        {
            txtTuSo.Text = "";
            txtDenSo.Text = "";
            txtHeSo.Text = "";
            txtTuSo.Focus();
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
            if (txtTuSo.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTuSo, "Số sinh viên trong ô này không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTuSo;
            }
            if (txtDenSo.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtDenSo, "Số sinh viên trong ô này không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtDenSo;
            }
            if (txtHeSo.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtHeSo, "Hệ số không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtHeSo;
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
            pGG_HeSoTrinhDoInfo.IDDM_TrinhDo = (int)cmbTrinhDo.EditValue;
            pGG_HeSoTrinhDoInfo.LoaiGiangDay = cmbLoaiGiangDay.EditValue.ToString();
            pGG_HeSoTrinhDoInfo.TuSo = int.Parse(txtTuSo.Text);
            pGG_HeSoTrinhDoInfo.DenSo = int.Parse(txtDenSo.Text);
            pGG_HeSoTrinhDoInfo.HeSo = double.Parse(txtHeSo.Text);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupTop.Visible = true;
            edit = EDIT_MODE.THEM;
            grdHeSo.Enabled = false;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupTop.Visible = true;
            edit = EDIT_MODE.SUA;
            grdHeSo.Enabled = false;
            SetText();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pGG_HeSoTrinhDoInfo.GG_HeSoTheoTrinhDoID = int.Parse(drHeSo[pGG_HeSoTrinhDoInfo.strGG_HeSoTheoTrinhDoID].ToString());
                    oBGG_HeSoTrinhDo.Delete(pGG_HeSoTrinhDoInfo);
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
                    pGG_HeSoTrinhDoInfo.GG_HeSoTheoTrinhDoID = oBGG_HeSoTrinhDo.Add(pGG_HeSoTrinhDoInfo);
                    drHeSo = dtHeSo.NewRow();
                    oBGG_HeSoTrinhDo.ToDataRow(pGG_HeSoTrinhDoInfo, ref drHeSo);
                    drHeSo["TenTrinhDo"] = cmbTrinhDo.Text;
                    dtHeSo.Rows.Add(drHeSo);
                    ClearText();
                }
                else
                {
                    pGG_HeSoTrinhDoInfo.GG_HeSoTheoTrinhDoID = int.Parse(drHeSo[pGG_HeSoTrinhDoInfo.strGG_HeSoTheoTrinhDoID].ToString());
                    oBGG_HeSoTrinhDo.Update(pGG_HeSoTrinhDoInfo);
                    oBGG_HeSoTrinhDo.ToDataRow(pGG_HeSoTrinhDoInfo, ref drHeSo);
                    drHeSo["TenTrinhDo"] = cmbTrinhDo.Text;
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi("Có lỗi khi lưu./n" + ex.Message);
            }
        }
    }
}