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
using DevExpress.XtraTreeList;

namespace UnimOs.UI
{
    public partial class frmTinhHuyenXa : frmBase
    {
        private cBDM_TinhHuyenXa oBTinhHuyenXa;
        private DM_TinhHuyenXaInfo pTinhHuyenXaInfo;
        //private int Index;
        public frmTinhHuyenXa()
        {
            InitializeComponent();
            oBTinhHuyenXa = new cBDM_TinhHuyenXa();
            pTinhHuyenXaInfo = new DM_TinhHuyenXaInfo();
        }

        public void GetData()
        {
            treeTinhHuyenXa.DataSource = null;
            pTinhHuyenXaInfo.DM_TinhHuyenXaID = 0;
            treeTinhHuyenXa.DataSource = oBTinhHuyenXa.GetTree();
            //treeTinhHuyenXa.ExpandAll();
            
        }

        private void frmTinhHuyenXa_Load(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void treeTinhHuyenXa_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TreeList tree = sender as TreeList;
                if (e.Button == System.Windows.Forms.MouseButtons.Right && ModifierKeys == Keys.None && tree.State == TreeListState.Regular)
                {
                    Point pt = tree.PointToClient(MousePosition);
                    TreeListHitInfo info = tree.CalcHitInfo(pt);
                    int SavedTopIndex = tree.TopVisibleNodeIndex;
                    tree.FocusedNode = info.Node;
                    if (treeTinhHuyenXa.FocusedNode != null)
                    {
                        if (treeTinhHuyenXa.FocusedNode.HasChildren == true)
                        {
                            barbtnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                        {
                            barbtnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                        if (pTinhHuyenXaInfo.Level == 1)
                        {
                            barbtnThemTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barbtnSuaTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barbtnThemHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barbtnSuaHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnThemXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnSuaXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        if (pTinhHuyenXaInfo.Level == 2)
                        {
                            barbtnThemTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnSuaTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnThemHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnSuaHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barbtnThemXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barbtnSuaXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        if (pTinhHuyenXaInfo.Level == 3)
                        {
                            barbtnThemXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnSuaXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barbtnThemTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnSuaTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnThemHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barbtnSuaHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                    }
                    else
                    {
                        barbtnThemTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barbtnSuaTinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        barbtnThemHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        barbtnSuaHuyen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        barbtnThemXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        barbtnSuaXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        barbtnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    popupMenu.ShowPopup(MousePosition);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void treeTinhHuyenXa_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (treeTinhHuyenXa.FocusedNode == null) return;
                pTinhHuyenXaInfo.Ma = treeTinhHuyenXa.FocusedNode.GetValue("Ma").ToString();
                pTinhHuyenXaInfo.Ten = treeTinhHuyenXa.FocusedNode.GetValue("Ten").ToString();
                pTinhHuyenXaInfo.ParentID =  int.Parse(treeTinhHuyenXa.FocusedNode.GetValue("ParentID").ToString());
                pTinhHuyenXaInfo.DM_TinhHuyenXaID = int.Parse(treeTinhHuyenXa.FocusedNode.GetValue("TinhHuyenXaID").ToString());
                pTinhHuyenXaInfo.Level = int.Parse(treeTinhHuyenXa.FocusedNode.GetValue("Level").ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barbtnThemTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgCapNhatTinhHuyenXa frm = new dlgCapNhatTinhHuyenXa(this, 0, 0);
            frm.status = 0;
            frm.ShowDialog();
        }

        private void barbtnThemHuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgCapNhatTinhHuyenXa frm = new dlgCapNhatTinhHuyenXa(this, pTinhHuyenXaInfo.DM_TinhHuyenXaID, 1);
            frm.status = 0;
            frm.ShowDialog();
        }

        private void barbtnThemXa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgCapNhatTinhHuyenXa frm = new dlgCapNhatTinhHuyenXa(this, pTinhHuyenXaInfo.DM_TinhHuyenXaID, 2);
            frm.status = 0;
            frm.ShowDialog();        
        }

        private void barbtnSuaTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgCapNhatTinhHuyenXa frm = new dlgCapNhatTinhHuyenXa(this, pTinhHuyenXaInfo);
            frm.status = 1;          
            frm.ShowDialog();
        }

        private void barbtnSuaHuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgCapNhatTinhHuyenXa frm = new dlgCapNhatTinhHuyenXa(this, pTinhHuyenXaInfo);
            frm.status = 1;
            frm.ShowDialog();
        }

        private void barbtnSuaXa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgCapNhatTinhHuyenXa frm = new dlgCapNhatTinhHuyenXa(this, pTinhHuyenXaInfo);
            frm.status = 1;
            frm.ShowDialog();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    if (pTinhHuyenXaInfo.DM_TinhHuyenXaID > 0)
                    {
                        oBTinhHuyenXa.Delete(pTinhHuyenXaInfo);
                        // ghi log
                        GhiLog("Xóa tỉnh huyện xã '" + pTinhHuyenXaInfo.Ten + "'", "Xóa", this.Tag.ToString());
                        GetData();
                        XoaThanhCong();
                    }
                    else
                        ThongBao("Bạn chưa chọn tỉnh huyện xã nào!");
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpandAll.Checked)
                treeTinhHuyenXa.ExpandAll();
            else
                treeTinhHuyenXa.CollapseAll();
        }

        private void frmTinhHuyenXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}