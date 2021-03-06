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
    public partial class frmDanToc : frmBase
    {
        private  cBDM_DanToc oBDanToc;
        private DM_DanTocInfo pDM_DanTocInfo;
        int status = 0;
        private int Index;
        private string Ma;
        List<DM_DanTocInfo> LstDanToc;
        public frmDanToc()
        {
            InitializeComponent();
            oBDanToc = new cBDM_DanToc();
            pDM_DanTocInfo = new DM_DanTocInfo();
            LstDanToc = new List<DM_DanTocInfo>();
            LstDanToc = oBDanToc.GetList(pDM_DanTocInfo);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pDM_DanTocInfo.MaDanToc;
            if (!Check_Valid()) return;
            try
            {
               
                if (status == 0)
                {
                    oBDanToc.Add(GetpDanToc());
                    // ghi log
                    GhiLog("Thêm dân tộc '" + pDM_DanTocInfo.TenDanToc + "'", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                }
                else
                {
                    if (status == 1 || txtMaDanToc.Text == Ma)
                    {
                        oBDanToc.Update(GetpDanToc());
                        // ghi log
                        GhiLog("Sửa dân tộc '" + pDM_DanTocInfo.TenDanToc + "'", "Sửa", this.Tag.ToString());
                        SuaThanhCong();                        
                    }
                }
                pDM_DanTocInfo.DM_DanTocID = 0;
                GetData();
                LstDanToc = oBDanToc.GetList(pDM_DanTocInfo);
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void GetData()
        {
            grdDanToc.DataSource = oBDanToc.Get(pDM_DanTocInfo);
            grdDanToc.RefreshDataSource();
            if (grvDanToc.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnSua.Enabled = val;
        }

        private DM_DanTocInfo GetpDanToc()
        {
            pDM_DanTocInfo.MaDanToc = txtMaDanToc.Text;
            pDM_DanTocInfo.TenDanToc = txtTenDanToc.Text;
            return pDM_DanTocInfo;
        }

        private void ClearText()
        {
            txtMaDanToc.Text = "";
            txtTenDanToc.Text = "";
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            ClearText();
            status = 0;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvDanToc_FocusedRowChanged(null, null);
            status = 1;
            panelTop.Visible = true;
            txtMaDanToc.Text = pDM_DanTocInfo.MaDanToc;
            txtTenDanToc.Text = pDM_DanTocInfo.TenDanToc;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    if (pDM_DanTocInfo.DM_DanTocID > 0)
                    {
                        oBDanToc.Delete(pDM_DanTocInfo);
                        // ghi log
                        GhiLog("Xóa dân tộc '" + pDM_DanTocInfo.TenDanToc + "'", "Xóa", this.Tag.ToString());
                        pDM_DanTocInfo.DM_DanTocID = 0;
                        GetData();
                        LstDanToc = oBDanToc.GetList(pDM_DanTocInfo);                        
                        XoaThanhCong();
                    }
                    else
                        ThongBao("Bạn chưa chọn dân tộc nào!");
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaDanToc.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMaDanToc, "Mã dân tộc không thể rỗng.");
                if (CtrlErr == null)   CtrlErr = txtMaDanToc;
                  
            }
            if (txtTenDanToc.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenDanToc, "Tên dân tộc không thể rỗng.");
                if (CtrlErr == null)                CtrlErr = txtTenDanToc;
                 
            }
            if (status == 1 && txtMaDanToc.Text.Trim() == Ma)
            {
                return status == 1;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (LstDanToc != null)
                {
                    for (int i = 0; i < LstDanToc.Count; i++)
                    {
                        if (txtMaDanToc.Text == LstDanToc[i].MaDanToc)
                        {
                            DxErrorProvider.SetError(txtMaDanToc, "Mã dân tộc bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMaDanToc;
                            txtMaDanToc.Text = "";
                            ThongBao("Mã bạn nhập đã bị trùng!");
                            break;
                        }
                    }
                }
            }
            //Kiểm tra thông tin thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void frmDanToc_Load(object sender, EventArgs e)
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

        private void grvDanToc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvDanToc.DataRowCount > 0)
                {
                    SetControl(true);
                    Index = grvDanToc.FocusedRowHandle;
                    pDM_DanTocInfo.DM_DanTocID = int.Parse(grvDanToc.GetDataRow(Index)["DM_DanTocID"].ToString());
                    pDM_DanTocInfo.MaDanToc = grvDanToc.GetDataRow(Index)["MaDanToc"].ToString();
                    pDM_DanTocInfo.TenDanToc = grvDanToc.GetDataRow(Index)["TenDanToc"].ToString();
                }
             }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}