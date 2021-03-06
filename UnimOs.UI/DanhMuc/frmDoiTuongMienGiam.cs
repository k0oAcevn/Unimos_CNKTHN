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
    public partial class frmDoiTuongMienGiam : frmBase
    {
        private cBDM_DoiTuongMienGiam oBDM_DoiTuongMienGiam;
        private DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo;
        int status = 0;
        private int Index;
        List<DM_DoiTuongMienGiamInfo> LstDTMG;
        private string Ma;
        public frmDoiTuongMienGiam()
        {
            InitializeComponent();
            oBDM_DoiTuongMienGiam = new cBDM_DoiTuongMienGiam();
            pDM_DoiTuongMienGiamInfo = new DM_DoiTuongMienGiamInfo();
            LstDTMG = new List<DM_DoiTuongMienGiamInfo>();
            LstDTMG = oBDM_DoiTuongMienGiam.GetList(pDM_DoiTuongMienGiamInfo);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                Ma = pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam;
                if (!Check_Valid()) return;
                if (status == 0)
                {
                    oBDM_DoiTuongMienGiam.Add(GetpDoiTuongMienGiam());
                    XtraMessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (status == 1 || txtMaDoiTuongMienGiam.Text == Ma)
                    {
                        oBDM_DoiTuongMienGiam.Update(GetpDoiTuongMienGiam());
                        XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID = 0;
                GetData();
                LstDTMG = oBDM_DoiTuongMienGiam.GetList(pDM_DoiTuongMienGiamInfo);
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 0;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            txtMaDoiTuongMienGiam.Focus();
            txtMaDoiTuongMienGiam.Text = pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam;
            txtTenDoiTuongMienGiam.Text = pDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam;
            txtMienGiam.Text = pDM_DoiTuongMienGiamInfo.MienGiam;
            txtSoTienMienGiam.Text = pDM_DoiTuongMienGiamInfo.SoTienMienGiam.ToString();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID > 0)
                {
                    oBDM_DoiTuongMienGiam.Delete(pDM_DoiTuongMienGiamInfo);
                    pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID = 0;
                    GetData();
                    LstDTMG = oBDM_DoiTuongMienGiam.GetList(pDM_DoiTuongMienGiamInfo);
                    XoaThanhCong();
                }
                else
                    ThongBao("Bạn chưa chọn đối tượng miễn giảm nào!");
            }
            catch
            {
                ThongBaoLoi("Đối tượng miễn giảm này đang được sử dụng, không thễ xóa!");
            }
        }

        private void ClearText()
        {
            txtMaDoiTuongMienGiam.Text = "";
            txtTenDoiTuongMienGiam.Text = "";
            txtMienGiam.Text = "";
            txtSoTienMienGiam.Text = "";
            txtMaDoiTuongMienGiam.Focus();
        }

        private void GetData()
        {
            grdDoiTuongMienGiam.DataSource = oBDM_DoiTuongMienGiam.Get(pDM_DoiTuongMienGiamInfo);
            grdDoiTuongMienGiam.RefreshDataSource();
            if (grvDoiTuongMienGiam.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }

        private void frmDoiTuongMienGiam_Load(object sender, EventArgs e)
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

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private DM_DoiTuongMienGiamInfo GetpDoiTuongMienGiam()
        {
            pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam = txtMaDoiTuongMienGiam.Text;
            pDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam = txtTenDoiTuongMienGiam.Text;
            pDM_DoiTuongMienGiamInfo.MienGiam = txtMienGiam.Text;
            pDM_DoiTuongMienGiamInfo.SoTienMienGiam = float.Parse("0" + txtSoTienMienGiam.Text.Trim());
            return pDM_DoiTuongMienGiamInfo;
        }

        private bool Check_Valid()
        {
            bool functionReturnValue = false;
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaDoiTuongMienGiam.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMaDoiTuongMienGiam, "Mã đối tượng miễn giảm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaDoiTuongMienGiam;
            }
            if (txtTenDoiTuongMienGiam.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenDoiTuongMienGiam, "Tên đối tượng miễn giảm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenDoiTuongMienGiam;
            }
            if (txtMienGiam.Text == string.Empty && txtSoTienMienGiam.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMienGiam, "Miễn giảm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMienGiam;
            }
           
            if (status == 1 && txtMaDoiTuongMienGiam.Text == Ma)
            {
                return status == 1;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (LstDTMG != null)
                {
                    for (int i = 0; i < LstDTMG.Count; i++)
                    {
                        if (txtMaDoiTuongMienGiam.Text == LstDTMG[i].MaDoiTuongMienGiam)
                        {
                            DxErrorProvider.SetError(txtMaDoiTuongMienGiam, "Mã đối tượng miễn giảm bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMaDoiTuongMienGiam;
                            txtMaDoiTuongMienGiam.Text = "";
                            XtraMessageBox.Show("Mã bạn nhập đã bị trùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }
            }
            //Kiểm tra thông tin thành công
            if ((CtrlErr != null)) goto QUIT;
            functionReturnValue = true;
            return functionReturnValue;
        QUIT:
            functionReturnValue = false;
            CtrlErr.Focus();
            return functionReturnValue;
        }

        private void grvDoiTuongMienGiam_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvDoiTuongMienGiam.DataRowCount > 0)
                {
                    SetControl(true);
                    Index = grvDoiTuongMienGiam.FocusedRowHandle;
                    pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID = int.Parse(grvDoiTuongMienGiam.GetDataRow(Index)["DM_DoiTuongMienGiamID"].ToString());
                    pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam = grvDoiTuongMienGiam.GetDataRow(Index)["MaDoiTuongMienGiam"].ToString();
                    pDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam = grvDoiTuongMienGiam.GetDataRow(Index)["TenDoiTuongMienGiam"].ToString();
                    pDM_DoiTuongMienGiamInfo.MienGiam = grvDoiTuongMienGiam.GetDataRow(Index)["PhanTramMienGiam"].ToString();
                    pDM_DoiTuongMienGiamInfo.SoTienMienGiam = float.Parse(grvDoiTuongMienGiam.GetDataRow(Index)["SoTienMienGiam"].ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}