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
    public partial class frmTonGiao : frmBase
    {
        private cBDM_TonGiao oBTonGiao;
        private DM_TonGiaoInfo pDM_TonGiaoInfo;
        int status = 0;
        private int Index;
        List<DM_TonGiaoInfo> LstTonGiao;
        private string Ma;
        public frmTonGiao()
        {
            InitializeComponent();
            oBTonGiao = new cBDM_TonGiao();
            pDM_TonGiaoInfo = new DM_TonGiaoInfo();
            LstTonGiao = new List<DM_TonGiaoInfo>();
            LstTonGiao = oBTonGiao.GetList(pDM_TonGiaoInfo);
        }

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private void GetData()
        {
            grdTonGiao.DataSource = oBTonGiao.Get(pDM_TonGiaoInfo);
            grdTonGiao.RefreshDataSource();
            if (grvTonGiao.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }

        private void ClearText()
        {
            txtMaTonGiao.Text = "";
            txtTenTonGiao.Text = "";
        }

        private void frmTonGiao_Load(object sender, EventArgs e)
        {
            bar2.Visible = true;
            try
            {
                SetControl(false);
                GetData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private DM_TonGiaoInfo GetpTonGiao()
        {
            pDM_TonGiaoInfo.MaTonGiao = txtMaTonGiao.Text;
            pDM_TonGiaoInfo.TenTonGiao = txtTenTonGiao.Text;
            return pDM_TonGiaoInfo;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            status = 0;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            status = 1;
            txtMaTonGiao.Text = pDM_TonGiaoInfo.MaTonGiao;
            txtTenTonGiao.Text = pDM_TonGiaoInfo.TenTonGiao;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    if (pDM_TonGiaoInfo.DM_TonGiaoID > 0)
                    {
                        oBTonGiao.Delete(pDM_TonGiaoInfo);
                        pDM_TonGiaoInfo.DM_TonGiaoID = 0;
                        GetData();
                        LstTonGiao = oBTonGiao.GetList(pDM_TonGiaoInfo);
                        // ghi log
                        GhiLog("Xóa tôn giáo '" + pDM_TonGiaoInfo.TenTonGiao + "'", "Xóa", this.Tag.ToString());
                        XoaThanhCong();
                    }
                    else
                        CanhBao("Bạn chưa chọn tôn giáo nào!");
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
            Ma = pDM_TonGiaoInfo.MaTonGiao;
            if (!Check_Valid()) return;
            try
            {
                
                if (status == 0)
                {
                    oBTonGiao.Add(GetpTonGiao());
                    // ghi log
                    GhiLog("Thêm tôn giáo '" + pDM_TonGiaoInfo.TenTonGiao + "'", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                }
                else
                {
                    if (status == 1 || txtMaTonGiao.Text == Ma)
                    {
                        oBTonGiao.Update(GetpTonGiao());
                        // ghi log
                        GhiLog("Sửa tôn giáo '" + pDM_TonGiaoInfo.TenTonGiao + "'", "Sửa", this.Tag.ToString());
                        SuaThanhCong();
                    }
                }
                pDM_TonGiaoInfo.DM_TonGiaoID = 0;
                GetData();
                LstTonGiao = oBTonGiao.GetList(pDM_TonGiaoInfo);
                ClearText();
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
            if (txtMaTonGiao.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMaTonGiao, "Mã Tôn giáo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaTonGiao;
            }
            if (txtTenTonGiao.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenTonGiao, "Tên Tôn giáo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenTonGiao;
            }
            if (status == 1 && txtMaTonGiao.Text.Trim() == Ma)
            {
                return status == 1;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (LstTonGiao != null)
                {
                    for (int i = 0; i < LstTonGiao.Count; i++)
                    {
                        if (txtMaTonGiao.Text == LstTonGiao[i].MaTonGiao)
                        {
                            DxErrorProvider.SetError(txtMaTonGiao, "Mã tôn giáo bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMaTonGiao;                          
                            break;
                        }
                    }
                }
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
                if (grvTonGiao.DataRowCount > 0)
                {
                    SetControl(true);
                    Index = grvTonGiao.FocusedRowHandle;
                    pDM_TonGiaoInfo.DM_TonGiaoID = int.Parse(grvTonGiao.GetDataRow(Index)["DM_TonGiaoID"].ToString());
                    pDM_TonGiaoInfo.MaTonGiao = grvTonGiao.GetDataRow(Index)["MaTonGiao"].ToString();
                    pDM_TonGiaoInfo.TenTonGiao = grvTonGiao.GetDataRow(Index)["TenTonGiao"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

    }
}