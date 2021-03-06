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
using System.IO;

namespace UnimOs.UI
{
    public partial class frmHoSoSinhVien : frmBase
    {
        private cBSV_SinhVien oBSV_SinhVien;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private cBSV_SinhVienNhapTruong oBSV_SinhVienNhapTruong;
        private SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo;
        private cBSV_SinhVien_ThongTinKhac oBSV_SinhVien_ThongTinKhac;
        private SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo;
        private cBSV_SinhVien_QuanHeGiaDinh oBSV_SinhVien_QuanHeGiaDinh;
        private SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo;
        private DataTable dtSinhVien, dtQuanHeGiaDinh;
        private DataRow drSinhVien, drHoSo, drQuanHeGiaDinh;
        private EDIT_MODE edit;

        public frmHoSoSinhVien(DataTable _dtSinhVien, ref DataRow _drSinhVien)
        {
            InitializeComponent();
            oBSV_SinhVien = new cBSV_SinhVien();
            pSV_SinhVienInfo = new SV_SinhVienInfo();
            oBSV_SinhVienNhapTruong = new cBSV_SinhVienNhapTruong();
            pSV_SinhVienNhapTruongInfo = new SV_SinhVienNhapTruongInfo();
            oBSV_SinhVien_ThongTinKhac = new cBSV_SinhVien_ThongTinKhac();
            pSV_SinhVien_ThongTinKhacInfo = new SV_SinhVien_ThongTinKhacInfo();
            oBSV_SinhVien_QuanHeGiaDinh = new cBSV_SinhVien_QuanHeGiaDinh();
            pSV_SinhVien_QuanHeGiaDinhInfo = new SV_SinhVien_QuanHeGiaDinhInfo();
            drSinhVien = _drSinhVien;
            dtSinhVien = _dtSinhVien;
            LoadDiaChi(ucNoiSinh);
            LoadDiaChi(ucThuongTru);
            SetControl(false);
            SetControlReadOnly(true);
            btnLuu.Enabled = false;
        }

        private void frmHoSoSinhVien_Load(object sender, EventArgs e)
        {
            LoadCombo();
            drHoSo = oBSV_SinhVien.GetHoSo(int.Parse(drSinhVien["SV_SinhVienID"].ToString())).Rows[0];
            dataSinhVien.DataSource = dtSinhVien;
            SetText();
        }

        private void LoadCombo()
        {
            cmbDanToc.Properties.DataSource = LoadDanToc();
            cmbTonGiao.Properties.DataSource = LoadTonGiao();
            cmbQuocTich.Properties.DataSource = LoadQuocTich();
            cmbNoiCap.Properties.DataSource = (new cBDM_TinhHuyenXa()).GetByCap(1, 0);
            cmbXLHocLuc.Properties.DataSource = LoadXLHocLuc();
            cmbXLTotNghiep.Properties.DataSource = LoadXLHocLuc();
            cmbXLHanhKiem.Properties.DataSource = LoadXLHanhKiem();
            cmbQuanHeGiaDinh.Properties.DataSource = LoadQuanHeGiaDinh();
            reposiQuanHeGiaDinh.DataSource = LoadQuanHeGiaDinh();
        }

        private void SetText()
        {
            // Thông tin sinh viên
            if ("" + drHoSo["Anh"] != "")
            {
                MemoryStream stream = new MemoryStream((byte[])drHoSo[pSV_SinhVienInfo.strAnh]);
                picAnh.Image = Image.FromStream(stream);
            }
            txtMaSinhVien.Text = "" + drHoSo[pSV_SinhVienInfo.strMaSinhVien];
            txtHoVaTen.Text = drHoSo[pSV_SinhVienInfo.strHoVaTen].ToString();
            if ("" + drHoSo[pSV_SinhVienInfo.strNgaySinh] != "")
                dtpNgaySinh.EditValue = drHoSo[pSV_SinhVienInfo.strNgaySinh];
            if ("" + drHoSo[pSV_SinhVienInfo.strGioiTinh] != "")
                radioGioiTinh.EditValue = drHoSo[pSV_SinhVienInfo.strGioiTinh];
            if (int.Parse("0" + drHoSo[pSV_SinhVienInfo.strIDDM_TinhHuyenXaNoiSinh]) > 0)
                SetValueDiaChi(ucNoiSinh, int.Parse(drHoSo[pSV_SinhVienInfo.strIDDM_TinhHuyenXaNoiSinh].ToString()));
            ucNoiSinh.txtSoNha.Text = "" + drHoSo[pSV_SinhVienInfo.strNoiSinh];
            if (int.Parse("0" + drHoSo[pSV_SinhVienInfo.strIDDM_TinhHuyenXaThuongTru]) > 0)
                SetValueDiaChi(ucThuongTru, int.Parse(drHoSo[pSV_SinhVienInfo.strIDDM_TinhHuyenXaThuongTru].ToString()));
            ucThuongTru.txtSoNha.Text = "" + drHoSo[pSV_SinhVienInfo.strThuongTru];

            cmbThanhPhanXuatThan.EditValue = drHoSo[pSV_SinhVienInfo.strThanhPhanXuatThan];
            cmbDanToc.EditValue = drHoSo[pSV_SinhVienInfo.strIDDM_DanToc];
            cmbTonGiao.EditValue = drHoSo[pSV_SinhVienInfo.strIDDM_TonGiao];
            cmbQuocTich.EditValue = drHoSo[pSV_SinhVienInfo.strIDDM_QuocTich];
            txtDienThoaiDD.Text = "" + drHoSo[pSV_SinhVienInfo.strDienThoaiDiDong];
            txtDienThoaiCD.Text = "" + drHoSo[pSV_SinhVienInfo.strDienThoaiNhaRieng];
            txtEmail.Text = "" + drHoSo[pSV_SinhVienInfo.strEmail];
            txtCMND.Text = "" + drHoSo[pSV_SinhVienInfo.strSoCMND];
            if ("" + drHoSo[pSV_SinhVienInfo.strNgayCapCMND] != "")
                dtpNgayCap.EditValue = drHoSo[pSV_SinhVienInfo.strNgayCapCMND];
            cmbNoiCap.EditValue = drHoSo[pSV_SinhVienInfo.strIDTinhNoiCapCMND];
            if ("" + drHoSo[pSV_SinhVienInfo.strNgayVaoDoan] != "")
            {
                dtpNgayVaoDoan.Value = DateTime.Parse(drHoSo[pSV_SinhVienInfo.strNgayVaoDoan].ToString());
                dtpNgayVaoDoan.Checked = true;
            }
            else
                dtpNgayVaoDoan.Checked = false;
            if ("" + drHoSo[pSV_SinhVienInfo.strNgayVaoDang] != "")
            {
                dtpNgayVaoDang.Value = DateTime.Parse(drHoSo[pSV_SinhVienInfo.strNgayVaoDang].ToString());
                dtpNgayVaoDang.Checked = true;
            }
            else
                dtpNgayVaoDang.Checked = false;
            txtBaoTinCho.Text = "" + drHoSo[pSV_SinhVienInfo.strBaoTinCho];
            txtDiaChiBaoTin.Text = "" + drHoSo[pSV_SinhVienInfo.strDiaChiBaoTin];
            // Thông tin tuyển sinh
            txtKhuVucTS.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strKhuVucTuyenSinh];
            txtDoiTuongTS.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strDoiTuongTuyenSinh];
            txtNganhHoc.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strNganhThi];
            txtKyHieuTruong.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strKyHieuTruong];
            txtSoBaoDanh.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strSoBaoDanhTS];
            txtTongDiem.EditValue = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strTongDiemLamTron] == "" ? 0 : drHoSo[pSV_SinhVienNhapTruongInfo.strTongDiemLamTron];
            txtMon1.EditValue = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strDiemMon1] == "" ? 0 : drHoSo[pSV_SinhVienNhapTruongInfo.strDiemMon1];
            txtMon2.EditValue = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strDiemMon2] == "" ? 0 : drHoSo[pSV_SinhVienNhapTruongInfo.strDiemMon2];
            txtMon3.EditValue = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strDiemMon3] == "" ? 0 : drHoSo[pSV_SinhVienNhapTruongInfo.strDiemMon3];
            txtDiemThuong.EditValue = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strDiemThuong] == "" ? 0 : drHoSo[pSV_SinhVienNhapTruongInfo.strDiemThuong];
            txtKhoiThi.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strKhoiThi];
            chkTuyenThang.Checked = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strTuyenThang] == "" ? false : 
                bool.Parse(drHoSo[pSV_SinhVienNhapTruongInfo.strTuyenThang].ToString());
            txtLyDoTuyenThang.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strLyDo];
            cmbXLHocLuc.EditValue = drHoSo[pSV_SinhVienNhapTruongInfo.strXLHocLuc];
            cmbXLTotNghiep.EditValue = drHoSo[pSV_SinhVienNhapTruongInfo.strXLTotNghiep];
            cmbXLHanhKiem.EditValue = drHoSo[pSV_SinhVienNhapTruongInfo.strXLHanhKiem];
            txtNamTotNghiep.Text = "" + drHoSo[pSV_SinhVienNhapTruongInfo.strNamTotNghiep];
            // Thông tin khác
            txtKhenThuong.Text = "" + drHoSo[pSV_SinhVien_ThongTinKhacInfo.strKhenThuongKyLuat];
            txtQuaTrinhHocTap.Text = "" + drHoSo[pSV_SinhVien_ThongTinKhacInfo.strQuaTrinhHocTapCongTac];
            // Quan hệ gia đình
            dtQuanHeGiaDinh = oBSV_SinhVien_QuanHeGiaDinh.GetBySinhVien(int.Parse(drSinhVien["SV_SinhVienID"].ToString()));
            grdSinhVien_QuanHeGiaDinh.DataSource = dtQuanHeGiaDinh;
        }

        private void GetpSinhVienInfo()
        {
            pSV_SinhVienInfo.SV_SinhVienID = int.Parse(drHoSo[pSV_SinhVienInfo.strSV_SinhVienID].ToString());
            pSV_SinhVienInfo.MaSinhVien = txtMaSinhVien.Text;
            pSV_SinhVienInfo.HoVaTen = txtHoVaTen.Text;
            pSV_SinhVienInfo.Ten = GetTen(pSV_SinhVienInfo.HoVaTen);
            pSV_SinhVienInfo.GioiTinh = bool.Parse(radioGioiTinh.EditValue.ToString());
            pSV_SinhVienInfo.NgaySinh = DateTime.Parse("" + dtpNgaySinh.EditValue != "" ? dtpNgaySinh.EditValue.ToString() : "1/1/1900");
            pSV_SinhVienInfo.NoiSinh = ucNoiSinh.txtSoNha.Text;
            pSV_SinhVienInfo.IDDM_TinhHuyenXaNoiSinh = ucNoiSinh.returnID();
            pSV_SinhVienInfo.ThuongTru = ucThuongTru.txtSoNha.Text;
            pSV_SinhVienInfo.IDDM_TinhHuyenXaThuongTru = ucThuongTru.returnID();
            pSV_SinhVienInfo.ThanhPhanXuatThan = int.Parse("0"+cmbThanhPhanXuatThan.EditValue.ToString());
            pSV_SinhVienInfo.IDDM_DanToc = int.Parse("0" + cmbDanToc.EditValue);
            pSV_SinhVienInfo.IDDM_TonGiao = int.Parse("0" + cmbTonGiao.EditValue);
            pSV_SinhVienInfo.IDDM_QuocTich = int.Parse("0" + cmbQuocTich.EditValue);
            pSV_SinhVienInfo.DienThoaiDiDong = txtDienThoaiDD.Text;
            pSV_SinhVienInfo.DienThoaiNhaRieng = txtDienThoaiCD.Text;
            pSV_SinhVienInfo.Email = txtEmail.Text;
            pSV_SinhVienInfo.SoCMND = txtCMND.Text;
            pSV_SinhVienInfo.NgayCapCMND = DateTime.Parse("" + dtpNgayCap.EditValue != "" ? dtpNgayCap.EditValue.ToString() : "1/1/1900");
            pSV_SinhVienInfo.IDTinhNoiCapCMND = int.Parse("0" + cmbNoiCap.EditValue);
            pSV_SinhVienInfo.NgayVaoDoan = dtpNgayVaoDoan.Checked == false ? DateTime.Parse("1/1/1900") : dtpNgayVaoDoan.Value;
            pSV_SinhVienInfo.NgayVaoDang = dtpNgayVaoDang.Checked == false ? DateTime.Parse("1/1/1900") : dtpNgayVaoDang.Value;
            pSV_SinhVienInfo.BaoTinCho = txtBaoTinCho.Text;
            pSV_SinhVienInfo.DiaChiBaoTin = txtDiaChiBaoTin.Text;
            if (picAnh.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                picAnh.Image.Save(stream, picAnh.Image.RawFormat);
                byte[] img = stream.ToArray();
                pSV_SinhVienInfo.Anh = img;
            }
            pSV_SinhVienInfo.Active = int.Parse(drHoSo[pSV_SinhVienInfo.strActive].ToString());
            pSV_SinhVienInfo.Xoa = bool.Parse(drHoSo[pSV_SinhVienInfo.strXoa].ToString());
        }

        private void GetpNhapTruongInfo()
        {
            pSV_SinhVienNhapTruongInfo.HoVaTenTS = txtHoVaTen.Text.Trim();
            pSV_SinhVienNhapTruongInfo.TenTS = GetTen(pSV_SinhVienNhapTruongInfo.HoVaTenTS);
            pSV_SinhVienNhapTruongInfo.KhuVucTuyenSinh = txtKhuVucTS.Text.Trim();
            pSV_SinhVienNhapTruongInfo.DoiTuongTuyenSinh = txtDoiTuongTS.Text.Trim();
            pSV_SinhVienNhapTruongInfo.NganhThi = txtNganhHoc.Text.Trim();
            pSV_SinhVienNhapTruongInfo.KyHieuTruong = txtKyHieuTruong.Text.Trim();
            pSV_SinhVienNhapTruongInfo.SoBaoDanhTS = txtSoBaoDanh.Text.Trim();
            pSV_SinhVienNhapTruongInfo.TongDiemLamTron = float.Parse(txtTongDiem.EditValue.ToString());
            pSV_SinhVienNhapTruongInfo.DiemMon1 = float.Parse(txtMon1.EditValue.ToString());
            pSV_SinhVienNhapTruongInfo.DiemMon2 = float.Parse(txtMon2.EditValue.ToString());
            pSV_SinhVienNhapTruongInfo.DiemMon3 = float.Parse(txtMon3.EditValue.ToString());
            pSV_SinhVienNhapTruongInfo.DiemThuong = float.Parse(txtDiemThuong.EditValue.ToString());
            pSV_SinhVienNhapTruongInfo.KhoiThi = txtKhoiThi.Text.Trim();
            pSV_SinhVienNhapTruongInfo.TuyenThang = chkTuyenThang.Checked;
            pSV_SinhVienNhapTruongInfo.LyDo = txtLyDoTuyenThang.Text.Trim();
            pSV_SinhVienNhapTruongInfo.XLHocLuc = "" + cmbXLHocLuc.EditValue;
            pSV_SinhVienNhapTruongInfo.XLTotNghiep = "" + cmbXLTotNghiep.EditValue;
            pSV_SinhVienNhapTruongInfo.XLHanhKiem = "" + cmbXLHanhKiem.EditValue;
            pSV_SinhVienNhapTruongInfo.NamTotNghiep = txtNamTotNghiep.Text.Trim();
        }

        private void GetpThongTinKhacInfo()
        {
            pSV_SinhVien_ThongTinKhacInfo.KhenThuongKyLuat = txtKhenThuong.Text.Trim();
            pSV_SinhVien_ThongTinKhacInfo.QuaTrinhHocTapCongTac = txtQuaTrinhHocTap.Text.Trim();
        }

        private bool CheckValid()
        {
            return true;
        }

        private void picAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Pictures|*.bmp;*.gif;*.jpg;*.png|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNG|*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = new Bitmap(dlg.FileName);
            }
        }

        private void btnInHoSo_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            try
            {
                GetpSinhVienInfo();
                oBSV_SinhVien.Update(pSV_SinhVienInfo);
                GetpNhapTruongInfo();
                pSV_SinhVienNhapTruongInfo.IDSV_SinhVien = pSV_SinhVienInfo.SV_SinhVienID;
                oBSV_SinhVienNhapTruong.UpdateHoSo(pSV_SinhVienNhapTruongInfo);
                GetpThongTinKhacInfo();
                pSV_SinhVien_ThongTinKhacInfo.IDSV_SinhVien = pSV_SinhVienInfo.SV_SinhVienID;
                oBSV_SinhVien_ThongTinKhac.UpdateHoSo(pSV_SinhVien_ThongTinKhacInfo);
                drSinhVien["MaSinhVien"] = txtMaSinhVien.Text.Trim();
                string HoVa = "";
                drSinhVien["Ten"] = GetTen(txtHoVaTen.Text.Trim(), ref HoVa);
                drSinhVien["HoVa"] = HoVa;
                drSinhVien["NgaySinh"] = dtpNgaySinh.EditValue;
                drSinhVien["GioiTinh"] = radioGioiTinh.EditValue;
                drSinhVien["NoiSinh"] = ucNoiSinh.returnDiaChi();
                drSinhVien["ThuongTru"] = ucThuongTru.returnDiaChi();
                SuaThanhCong();
            }
            catch(Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Quan hệ gia đình
        private void SetTextQuanHeGiaDinh()
        {
            cmbQuanHeGiaDinh.EditValue = drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strIDDM_QuanHeGiaDinh];
            txtHoTenQuanHe.Text = "" + drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strHoVaTen];
            txtNamSinh.Text = "" + drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strNamSinh];
            txtNgheNghiep.Text = "" + drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strNgheNghiep];
            txtNoiO.Text = "" + drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strDiaChi];
            txtThongTinKhac.Text = "" + drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strThongTinKhac];
            txtHoVaTen.Focus();
        }

        private void SetControlReadOnly(bool status)
        {
            txtHoTenQuanHe.Properties.ReadOnly = status;
            txtNamSinh.Properties.ReadOnly = status;
            txtNoiO.Properties.ReadOnly = status;
            txtNgheNghiep.Properties.ReadOnly = status;
            cmbQuanHeGiaDinh.Properties.ReadOnly = status;
            txtThongTinKhac.Properties.ReadOnly = status;
        }

        private void GetpQuanHeGiaDinhInfo()
        {
            pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen = txtHoTenQuanHe.Text;
            pSV_SinhVien_QuanHeGiaDinhInfo.NamSinh = txtNamSinh.Text;
            pSV_SinhVien_QuanHeGiaDinhInfo.IDSV_SinhVien = int.Parse(drSinhVien[pSV_SinhVienInfo.strSV_SinhVienID].ToString());
            pSV_SinhVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh = int.Parse("0" + cmbQuanHeGiaDinh.EditValue);
            pSV_SinhVien_QuanHeGiaDinhInfo.DiaChi = txtNoiO.Text.Trim();
            pSV_SinhVien_QuanHeGiaDinhInfo.NgheNghiep = txtNgheNghiep.Text.Trim();
            pSV_SinhVien_QuanHeGiaDinhInfo.ThongTinKhac = txtThongTinKhac.Text;
        }

        private void SetControl(bool status)
        {
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtHoTenQuanHe.Text = "";
            txtNamSinh.Text = "";
            txtNoiO.Text = "";
            txtNgheNghiep.Text = "";
            txtThongTinKhac.Text = "";
            txtHoVaTen.Focus();
        }

        private bool CheckValidQuanHeGiaDinh()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtHoTenQuanHe.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtHoTenQuanHe, "Họ và tên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtHoTenQuanHe;
            }
            if (cmbQuanHeGiaDinh.EditValue == null)
            {
                dxErrorProvider.SetError(cmbQuanHeGiaDinh, "Mỗi quan hệ gia đình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbQuanHeGiaDinh;
            }
            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            grdSinhVien_QuanHeGiaDinh.Enabled = false;
            SetControlReadOnly(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            grdSinhVien_QuanHeGiaDinh.Enabled = false;
            SetControlReadOnly(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.SUA;
            SetTextQuanHeGiaDinh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID = int.Parse(drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strSV_SinhVien_QuanHeGiaDinhID].ToString());
                    oBSV_SinhVien_QuanHeGiaDinh.Delete(pSV_SinhVien_QuanHeGiaDinhInfo);
                    // ghi log
                    GhiLog("Xóa quan hệ gia đình sinh viên '" + pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuanHeGiaDinh.Rows.Remove(drQuanHeGiaDinh);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckValidQuanHeGiaDinh()) return;
            try
            {
                GetpQuanHeGiaDinhInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID = oBSV_SinhVien_QuanHeGiaDinh.Add(pSV_SinhVien_QuanHeGiaDinhInfo);
                    GhiLog("Thêm quan hệ gia đình sinh viên '" + pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuanHeGiaDinh.NewRow();
                    oBSV_SinhVien_QuanHeGiaDinh.ToDataRow(pSV_SinhVien_QuanHeGiaDinhInfo, ref drNew);
                    dtQuanHeGiaDinh.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID = int.Parse(drQuanHeGiaDinh[pSV_SinhVien_QuanHeGiaDinhInfo.strSV_SinhVien_QuanHeGiaDinhID].ToString());
                    oBSV_SinhVien_QuanHeGiaDinh.Update(pSV_SinhVien_QuanHeGiaDinhInfo);
                    GhiLog("Sửa quan hệ gia đình sinh viên '" + pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBSV_SinhVien_QuanHeGiaDinh.ToDataRow(pSV_SinhVien_QuanHeGiaDinhInfo, ref drQuanHeGiaDinh);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void grvSinhVien_QuanHeGiaDinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvSinhVien_QuanHeGiaDinh.FocusedRowHandle >= 0)
            {
                drQuanHeGiaDinh = grvSinhVien_QuanHeGiaDinh.GetDataRow(grvSinhVien_QuanHeGiaDinh.FocusedRowHandle);
                oBSV_SinhVien_QuanHeGiaDinh.ToInfo(ref pSV_SinhVien_QuanHeGiaDinhInfo, drQuanHeGiaDinh);
                SetTextQuanHeGiaDinh();
            }
            if (grvSinhVien_QuanHeGiaDinh != null)
                if (grvSinhVien_QuanHeGiaDinh.DataRowCount > 0 && grvSinhVien_QuanHeGiaDinh.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drQuanHeGiaDinh = grvSinhVien_QuanHeGiaDinh.GetDataRow(grvSinhVien_QuanHeGiaDinh.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drQuanHeGiaDinh = null;
        }

        private void grvSinhVien_QuanHeGiaDinh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grdSinhVien_QuanHeGiaDinh.Enabled = true;
            dxErrorProvider.ClearErrors();
            SetControlReadOnly(true);
            btnLuu.Enabled = false;
            grvSinhVien_QuanHeGiaDinh_FocusedRowChanged(null, null);
        }
        #endregion
    }
}