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
    public partial class dlgCapNhatTinhHuyenXa : frmBase
    {
        public int status; // 0 = Thêm ; 1= Sửa        
        private int ID;
        private int Level;
        private cBDM_TinhHuyenXa oBTinhHuyenXa;
        private DM_TinhHuyenXaInfo pTinhHuyenXaInfo;
        private frmTinhHuyenXa frm;
        List<DM_TinhHuyenXaInfo> LstTHX;
        private string Ma;
        public dlgCapNhatTinhHuyenXa()
        {
            InitializeComponent();
        }
        public dlgCapNhatTinhHuyenXa(frmTinhHuyenXa _frm, int _ID,int _Level)
        {
            InitializeComponent();
            oBTinhHuyenXa = new cBDM_TinhHuyenXa();
            pTinhHuyenXaInfo = new DM_TinhHuyenXaInfo();
            LstTHX = new List<DM_TinhHuyenXaInfo>();
            pTinhHuyenXaInfo.DM_TinhHuyenXaID = 0;
            LstTHX = oBTinhHuyenXa.GetList(pTinhHuyenXaInfo);
            ID = _ID;
            Level = _Level;
            frm = _frm;
        }

        public dlgCapNhatTinhHuyenXa(frmTinhHuyenXa _frm, DM_TinhHuyenXaInfo _pTinhHuyenXaInfo)
        {
            InitializeComponent();
            oBTinhHuyenXa = new cBDM_TinhHuyenXa();
            pTinhHuyenXaInfo = new DM_TinhHuyenXaInfo();
            LstTHX = new List<DM_TinhHuyenXaInfo>();
            pTinhHuyenXaInfo.DM_TinhHuyenXaID = 0;
            LstTHX = oBTinhHuyenXa.GetList(pTinhHuyenXaInfo);
            pTinhHuyenXaInfo = _pTinhHuyenXaInfo;
            frm = _frm;            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DM_TinhHuyenXaInfo GetDataInfo()
        {
            if (status == 0)
            {
                pTinhHuyenXaInfo.Level = Level + 1;
                pTinhHuyenXaInfo.Ma = txtMa.Text;
                pTinhHuyenXaInfo.ParentID = ID;
                pTinhHuyenXaInfo.Ten = txtTen.Text;
            }
            else
            {  
                pTinhHuyenXaInfo.Ma = txtMa.Text;               
                pTinhHuyenXaInfo.Ten = txtTen.Text;
            }
            return pTinhHuyenXaInfo;
        
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pTinhHuyenXaInfo.Ma;
            if (!Check_Valid()) return;
            try
            {
                oBTinhHuyenXa = new cBDM_TinhHuyenXa();
                if (status == 0)
                {
                    oBTinhHuyenXa.Add(GetDataInfo());
                    ClearText();
                    ThemThanhCong();
                    // ghi log
                    GhiLog("Thêm tỉnh huyện xã '" + pTinhHuyenXaInfo.Ten + "'", "Thêm", frm.Tag.ToString());
                }
                else
                {
                    if (status == 1 || txtMa.Text == Ma)
                    {
                        oBTinhHuyenXa.Update(GetDataInfo());
                        SuaThanhCong();
                        // ghi log
                        GhiLog("Sửa tỉnh huyện xã '" + pTinhHuyenXaInfo.Ten + "'", "Sửa", frm.Tag.ToString());
                    }
                }
                this.Close();
                frm.GetData();
                LstTHX = oBTinhHuyenXa.GetList(pTinhHuyenXaInfo);
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void ClearText()
        {
            txtTen.Text = "";
            txtMa.Text = "";
        }

        private void dlgCapNhatTinhHuyenXa_Load(object sender, EventArgs e)
        {
            try
            {
                txtTen.Text = pTinhHuyenXaInfo.Ten;
                txtMa.Text = pTinhHuyenXaInfo.Ma;
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
            if (txtMa.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMa, "Mã không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMa;
            }
            if (txtTen.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTen, "Tên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTen;
            }
            if (status == 1 && txtMa.Text == Ma)
            {
                return status == 1;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (LstTHX != null)
                {
                    for (int i = 0; i < LstTHX.Count; i++)
                    {
                        if (txtMa.Text == LstTHX[i].Ma)
                        {
                            DxErrorProvider.SetError(txtMa, "Mã tỉnh huyện xã bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMa;
                            txtMa.Text = "";
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
    }
}