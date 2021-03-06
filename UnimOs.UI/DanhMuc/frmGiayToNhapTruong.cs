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
    public partial class frmGiayToNhapTruong : frmBase
    {
        private cBDM_GiayToNhapTruong oBDM_GiayToNhapTruong;
        private DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo;
        private DataTable dtGiayTo;
        private DataRow drGiayTo;
        private EDIT_MODE edit;

        public frmGiayToNhapTruong()
        {
            InitializeComponent();
            oBDM_GiayToNhapTruong = new cBDM_GiayToNhapTruong();
            pDM_GiayToNhapTruongInfo = new DM_GiayToNhapTruongInfo();
        }

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private void ClearText()
        {
            txtTenGiayTo.Text = "";
            txtTenGiayTo.Focus();
        }

        private void frmTonGiao_Load(object sender, EventArgs e)
        {
            bar2.Visible = true;
            try
            {
                dtGiayTo = oBDM_GiayToNhapTruong.Get(pDM_GiayToNhapTruongInfo);
                grdGiayTo.DataSource = dtGiayTo;
                if (grvGiayTo.RowCount > 0)
                {
                    SetControl(true);
                }
                else
                {
                    SetControl(false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void GetpGiayTo()
        {
            pDM_GiayToNhapTruongInfo.TenGiayTo = txtTenGiayTo.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            edit = EDIT_MODE.SUA;
            txtTenGiayTo.Text = pDM_GiayToNhapTruongInfo.TenGiayTo;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    if (pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID > 0)
                    {
                        oBDM_GiayToNhapTruong.Delete(pDM_GiayToNhapTruongInfo);
                        dtGiayTo.Rows.Remove(drGiayTo);
                        // ghi log
                        GhiLog("Xóa giấy tờ nhập trường '" + pDM_GiayToNhapTruongInfo.TenGiayTo + "'", "Xóa", this.Tag.ToString());
                        XoaThanhCong();
                    }
                    else
                        CanhBao("Bạn chưa chọn giấy tờ nhập trường nào!");
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                GetpGiayTo();
                if (edit == EDIT_MODE.THEM)
                {
                    pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID = oBDM_GiayToNhapTruong.Add(pDM_GiayToNhapTruongInfo);
                    DataRow drNew = dtGiayTo.NewRow();
                    oBDM_GiayToNhapTruong.ToDataRow(pDM_GiayToNhapTruongInfo, ref drNew);
                    dtGiayTo.Rows.Add(drNew);
                    // ghi log
                    GhiLog("Thêm giấy tờ nhập trường '" + pDM_GiayToNhapTruongInfo.TenGiayTo + "'", "Thêm", this.Tag.ToString());
                    ClearText();
                }
                else
                {
                    oBDM_GiayToNhapTruong.Update(pDM_GiayToNhapTruongInfo);
                    oBDM_GiayToNhapTruong.ToDataRow(pDM_GiayToNhapTruongInfo, ref drGiayTo);
                    // ghi log
                    GhiLog("Sửa giấy tờ nhập trường '" + pDM_GiayToNhapTruongInfo.TenGiayTo + "'", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                    panelTop.Visible = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenGiayTo.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenGiayTo, "Tên giấy tờ nhập trường không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenGiayTo;
            }
            //Kiểm tra thông tin thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void grvTonGiao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvGiayTo.DataRowCount > 0)
                {
                    SetControl(true);
                    pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID = int.Parse(grvGiayTo.GetDataRow(grvGiayTo.FocusedRowHandle)["DM_GiayToNhapTruongID"].ToString());
                    pDM_GiayToNhapTruongInfo.TenGiayTo = grvGiayTo.GetDataRow(grvGiayTo.FocusedRowHandle)["TenGiayTo"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void grvGiayTo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

    }
}