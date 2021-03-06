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
    public partial class frmDoiTuongTroCap : frmBase
    {
        private cBDM_DoiTuongTroCap oBDM_DoiTuongTroCap;
        private DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo;
        int status = 0;
        private int Index;
        List<DM_DoiTuongTroCapInfo> LstDTTC;
        private string Ma;
        public frmDoiTuongTroCap()
        {
            InitializeComponent();
            oBDM_DoiTuongTroCap = new cBDM_DoiTuongTroCap();
            pDM_DoiTuongTroCapInfo = new DM_DoiTuongTroCapInfo();
            LstDTTC = new List<DM_DoiTuongTroCapInfo>();
            LstDTTC = oBDM_DoiTuongTroCap.GetList(pDM_DoiTuongTroCapInfo);
        }

        private void frmDoiTuongTroCap_Load(object sender, EventArgs e)
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                Ma = pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap;
                if (!Check_Valid()) return;
                if (status == 0)
                {
                    oBDM_DoiTuongTroCap.Add(GetpDoiTuongTroCap());
                    XtraMessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (status == 1 || txtMaDoiTuongTroCap.Text == Ma)
                    {
                        oBDM_DoiTuongTroCap.Update(GetpDoiTuongTroCap());
                        XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID = 0;
                GetData();
                LstDTTC = oBDM_DoiTuongTroCap.GetList(pDM_DoiTuongTroCapInfo);
                ClearText();
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
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
            txtMaDoiTuongTroCap.Focus();
            txtMaDoiTuongTroCap.Text = pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap;
            txtTenDoiTuongTroCap.Text = pDM_DoiTuongTroCapInfo.TenDoiTuongTroCap;
            txtSoTienTroCap.Text = pDM_DoiTuongTroCapInfo.SoTienTroCap.ToString();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID > 0)
                {
                    oBDM_DoiTuongTroCap.Delete(pDM_DoiTuongTroCapInfo);
                    pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID = 0;
                    GetData();
                    LstDTTC = oBDM_DoiTuongTroCap.GetList(pDM_DoiTuongTroCapInfo);
                    XoaThanhCong();
                }
                else
                    ThongBao("Bạn chưa chọn đối tượng trợ cấp nào!");
            }
            catch
            {
                XoaThatBai();
            }
        }

        private void GetData()
        {
            grdDoiTuongTroCap.DataSource = oBDM_DoiTuongTroCap.Get(pDM_DoiTuongTroCapInfo);
            grdDoiTuongTroCap.RefreshDataSource();
            if (grvDoiTuongTroCap.RowCount > 0)
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
            barbtnXoa.Enabled = val;
        }

        private DM_DoiTuongTroCapInfo GetpDoiTuongTroCap()
        {
            pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap = txtMaDoiTuongTroCap.Text;
            pDM_DoiTuongTroCapInfo.TenDoiTuongTroCap = txtTenDoiTuongTroCap.Text;
            pDM_DoiTuongTroCapInfo.SoTienTroCap = float.Parse(txtSoTienTroCap.Text);
            return pDM_DoiTuongTroCapInfo;
        }

        private void ClearText()
        {
            txtMaDoiTuongTroCap.Text = "";
            txtTenDoiTuongTroCap.Text = "";
            txtSoTienTroCap.Text = "";
            txtMaDoiTuongTroCap.Focus();
        }

        private bool Check_Valid()
        {
            bool functionReturnValue = false;
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaDoiTuongTroCap.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMaDoiTuongTroCap, "Mã đối tượng trợ cấp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaDoiTuongTroCap;
            }
            if (txtTenDoiTuongTroCap.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenDoiTuongTroCap, "Tên đối tượng trợ cấp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenDoiTuongTroCap;
            }
            if (txtSoTienTroCap.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtSoTienTroCap, "Số tiền trợ cấp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoTienTroCap;
            }
            if (status == 1 && txtMaDoiTuongTroCap.Text == Ma)
            {
                return status == 1;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (LstDTTC != null)
                {
                    for (int i = 0; i < LstDTTC.Count; i++)
                    {
                        if (txtMaDoiTuongTroCap.Text == LstDTTC[i].MaDoiTuongTroCap)
                        {
                            DxErrorProvider.SetError(txtMaDoiTuongTroCap, "Mã đối tượng trợ cấp bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMaDoiTuongTroCap;
                            txtMaDoiTuongTroCap.Text = "";
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

        private void grvDoiTuongTroCap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvDoiTuongTroCap.DataRowCount > 0)
                {
                    SetControl(true);
                    Index = grvDoiTuongTroCap.FocusedRowHandle;
                    pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID = int.Parse(grvDoiTuongTroCap.GetDataRow(Index)["DM_DoiTuongTroCapID"].ToString());
                    pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap = grvDoiTuongTroCap.GetDataRow(Index)["MaDoiTuongTroCap"].ToString();
                    pDM_DoiTuongTroCapInfo.TenDoiTuongTroCap = grvDoiTuongTroCap.GetDataRow(Index)["TenDoiTuongTroCap"].ToString();
                    pDM_DoiTuongTroCapInfo.SoTienTroCap = float.Parse(grvDoiTuongTroCap.GetDataRow(Index)["SoTienTroCap"].ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}