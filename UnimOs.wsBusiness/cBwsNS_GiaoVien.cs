using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;
using System.Collections;
using System.IO;
using System.Drawing;
using TruongViet.UnimOs.Entity.Model;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsNS_GiaoVien : cBwsBase
    {
        private cDNS_GiaoVien oDNS_GiaoVien;
        private NS_GiaoVienInfo oNS_GiaoVienInfo;
        private ArrayList arrGiaoVien;
        private int currID;

        public cBwsNS_GiaoVien()
        {
            oDNS_GiaoVien = new cDNS_GiaoVien();
            oNS_GiaoVienInfo = new NS_GiaoVienInfo();
        }

        //public DataTable Get(NS_GiaoVienInfo pNS_GiaoVienInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<NS_GiaoVienInfo>(client.cDNS_GiaoVien_Get(GlobalVar.MaXacThuc, pNS_GiaoVienInfo));
        //    }
        //}

        public DataTable GetByIDNS_DonVi(int IDNS_DonVi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_GetByIDNS_DonViResult>(client.cDNS_GiaoVien_GetByIDNS_DonVi(GlobalVar.MaXacThuc, IDNS_DonVi));
            }
        }

        public DataTable GetForLapTaiKhoan(int IDNS_DonVi, bool ChuaLapTaiKhoan)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_GetForLapTaiKhoanResult>(client.cDNS_GiaoVien_GetForLapTaiKhoan(GlobalVar.MaXacThuc, IDNS_DonVi, ChuaLapTaiKhoan));
            }
        }

        public DataTable NangBacChuyenNgach_GetByIDNS_DonVi(int IDNS_DonVi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonViResult>(client.cDNS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonVi(GlobalVar.MaXacThuc, IDNS_DonVi));
            }
        }

        public DataTable GetGiaoVien_DangGiangDay_ByIDNS_DonVi(int IDNS_DonVi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_DangGiangDay_GetByIDNS_DonViResult>(client.cDNS_GiaoVien_GetGiaoVien_DangGiangDay_ByIDNS_DonVi(GlobalVar.MaXacThuc, IDNS_DonVi));
            }
        }

        public DataTable GetByIDNS_DonVi_ChucDanh(int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_GiaoVien_GetBy_DonVi_ChucDanhResult>(client.cDNS_GiaoVien_GetByIDNS_DonVi_ChucDanh(GlobalVar.MaXacThuc, IDNS_DonVi, IDDM_NamHoc, HocKy));
            }
        }

        public DataTable TongHopGioGiang(int IDNS_DonVi, int NamHoc)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<NS_GiaoVienInfo>(client.cDNS_GiaoVien_TongHopGioGiang(GlobalVar.MaXacThuc, IDNS_DonVi, NamHoc));
            }
        }

        public DataTable ChiTietGioGiang(int IDNS_GiaoVien, int NamHoc)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<NS_GiaoVienInfo>(client.cDNS_GiaoVien_ChiTietGioGiang(GlobalVar.MaXacThuc, IDNS_GiaoVien, NamHoc));
            }
        }

        public DataTable GetHoSo(int NS_GiaoVienID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_GetHoSoResult>(client.cDNS_GiaoVien_GetHoSo(GlobalVar.MaXacThuc, NS_GiaoVienID));
            }
        }

        public string CheckExistByMaGiaoViens(string MaGiaoViens)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDNS_GiaoVien_CheckExistByMaGiaoVien(GlobalVar.MaXacThuc, MaGiaoViens);
            }
        }

        public DataTable Get_TKB(int IDNS_DonVi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_Get_TKBResult>(client.cDNS_GiaoVien_Get_TKB(GlobalVar.MaXacThuc, IDNS_DonVi));
            }
        }

        public DataTable GetByUsername(string Username)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_GetByUserNameResult>(client.cDNS_GiaoVien_GetByUsername(GlobalVar.MaXacThuc, Username));
            }
        }

        #region Hiển thị tree giáo viên đơn vị
        private DataTable CreateTableTree()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentIDs", typeof(int));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("Level", typeof(int));
            dt.Columns.Add("NS_DonViID", typeof(int));
            dt.Columns.Add("IDNS_GiaoVien", typeof(int));
            return dt;
        }

        public DataTable Get_Tree(int IDNS_DonVi)
        {
            cBwsNS_DonVi oBDonVi = new cBwsNS_DonVi();
            DataTable dt = oBDonVi.GetByID(IDNS_DonVi);
            DataTable dtTree = CreateTableTree();
            var client = new UnimOsServiceClient();
            DataTable dtGV = ConvertList.ToDataTable<sp_NS_GiaoVien_Get_TKBResult>(client.cDNS_GiaoVien_Get_TKB(GlobalVar.MaXacThuc, IDNS_DonVi));
            client.Close();
            currID = 0;
            AddTree(dt, dtTree, dtGV, "ParentID", int.Parse(dt.Rows[0]["ParentID"].ToString()), int.Parse(dt.Rows[0]["ParentID"].ToString()));
            return dtTree;
        }

        private void AddTree(DataTable dtSource, DataTable dtTree, DataTable dtGV, string ParentField, int ParentValue, int ValueField)
        {
            if (dtSource.Rows.Count > 0)
            {
                string strFilter = "";
                int pValue;
                if (ParentValue > 0)
                {
                    strFilter = ParentField + " = " + ValueField;
                }
                else
                {
                    strFilter = ParentField + " <= 0";
                }
                DataRow[] arrDr = dtSource.Select(strFilter);
                if (arrDr.Length > 0)
                {
                    foreach (DataRow dr in arrDr)
                    {
                        DataRow drNew = dtTree.NewRow();
                        currID++;
                        drNew["ID"] = currID;
                        drNew["ParentIDs"] = ParentValue;
                        drNew["Ten"] = dr["TenDonVi"];
                        drNew["ParentID"] = dr["ParentID"];
                        drNew["Level"] = dr["Level"];
                        drNew["NS_DonViID"] = dr["NS_DonViID"];
                        drNew["IDNS_GiaoVien"] = -1;
                        dtTree.Rows.Add(drNew);
                        // Add giáo viên vào tree đơn vị
                        pValue = currID;
                        DataRow[] drGV = dtGV.Select("IDNS_DonVi = " + dr["NS_DonViID"].ToString());
                        foreach (DataRow dr1 in drGV)
                        {
                            currID++;
                            drNew = dtTree.NewRow();
                            drNew["ID"] = currID;
                            drNew["ParentIDs"] = pValue;
                            drNew["Ten"] = dr1["HoTen"].ToString();
                            drNew["ParentID"] = dr["ParentID"];
                            drNew["Level"] = int.Parse(dr["Level"].ToString()) + 1;
                            drNew["NS_DonViID"] = dr["NS_DonViID"];
                            drNew["IDNS_GiaoVien"] = dr1["NS_GiaoVienID"];
                            dtTree.Rows.Add(drNew);
                        }
                        AddTree(dtSource, dtTree, dtGV, ParentField, pValue, int.Parse(dr["NS_DonViID"].ToString()));
                    }
                }
            }
        }
        #endregion

        public DataTable Get_QuaTrinhBoiDuong(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoiDuongResult>(client.cDNS_GiaoVien_Get_QuaTrinhBoiDuong(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhBoNhiemChucVu(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoNhiemChucVuResult>(client.cDNS_GiaoVien_Get_QuaTrinhBoNhiemChucVu(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhCongTac(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhCongTacResult>(client.cDNS_GiaoVien_Get_QuaTrinhCongTac(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhKhenThuong(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKhenThuongResult>(client.cDNS_GiaoVien_Get_QuaTrinhKhenThuong(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhKyLuat(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKyLuatResult>(client.cDNS_GiaoVien_Get_QuaTrinhKyLuat(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhLuanChuyen(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhLuanChuyenResult>(client.cDNS_GiaoVien_Get_QuaTrinhLuanChuyen(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhMienNhiemTuChuc(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhMienNhiemTuChucResult>(client.cDNS_GiaoVien_Get_QuaTrinhMienNhiemTuChuc(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhThamGiaLLVT(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaLLVTResult>(client.cDNS_GiaoVien_Get_QuaTrinhThamGiaLLVT(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable Get_QuaTrinhThamGiaTCCTXH(int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaTCCTXHResult>(client.cDNS_GiaoVien_Get_QuaTrinhThamGiaTCCTXH(GlobalVar.MaXacThuc, IDNS_GiaoVien));
            }
        }

        public DataTable TimKiem(NS_GiaoVienInfo pNS_GiaoVienInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<NS_GiaoVienInfo>(client.cDNS_GiaoVien_TimKiem(GlobalVar.MaXacThuc, pNS_GiaoVienInfo));
            }
        }

        public DataTable GetBaoCaoChatLuongCanBo(DateTime DenNgay)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_GetBaoCaoChatLuongCanBoResult>(client.cDNS_GiaoVien_GetBaoCaoChatLuongCanBo(GlobalVar.MaXacThuc, DenNgay));
            }
        }

        public DataSet GetBaoCaoChatLuongDoiNguGiaoVien(DateTime DenNgay)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDNS_GiaoVien_GetBaoCaoChatLuongDoiNguGiaoVien(GlobalVar.MaXacThuc, DenNgay);
            }
        }

        public DataTable UpdateDanhSach(int IDNS_DonVi, string ChuoiNS_GiaoVienID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<NS_GiaoVienInfo>(client.cDNS_GiaoVien_UpdateDanhSach(GlobalVar.MaXacThuc, IDNS_DonVi, ChuoiNS_GiaoVienID));
            }
        }

        public DataTable UpdatePassword(int IDNS_GiaoVien, string Password)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<NS_GiaoVienInfo>(client.cDNS_GiaoVien_UpdatePassword(GlobalVar.MaXacThuc, IDNS_GiaoVien, Password));
            }
        }

        public DataTable LocGiaoVien(int IDNS_GiaoVien, string HoTen)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<NS_GiaoVienInfo>(client.cDNS_GiaoVien_LocGiaoVien(GlobalVar.MaXacThuc, IDNS_GiaoVien, HoTen));
            }
        }

        public string GetMaLonNhat(int DoDaiMa, string PhanDauMa, string PhanCuoiMa)
        {
            var client = new UnimOsServiceClient();
            DataTable dt = ConvertList.ToDataTable<sp_NS_GiaoVien_GetMaLonNhatResult>(client.cDNS_GiaoVien_GetMaLonNhat(GlobalVar.MaXacThuc, DoDaiMa, PhanDauMa, PhanCuoiMa));
            client.Close();
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["MaGiaoVien"].ToString();
            else
                return "";
        }

        public DataTable Get_SoYeuLyLich(int NS_GiaoVienID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_Get_SoYeuLyLichResult>(client.cDNS_GiaoVien_Get_SoYeuLyLich(GlobalVar.MaXacThuc, NS_GiaoVienID));
            }
        }

        public DataTable Get_CanhBaoHanNghiHuu(int HanCanhBao, DateTime TinhDenNgay)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_Get_CanhBaoHanNghiHuuResult>(client.cDNS_GiaoVien_Get_CanhBaoHanNghiHuu(GlobalVar.MaXacThuc, HanCanhBao, TinhDenNgay));
            }
        }

        public DataTable Get_CanhBaoHetNhiemKy(int HanCanhBao, DateTime TinhDenNgay)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_GiaoVien_Get_CanhBaoHetNhiemKyResult>(client.cDNS_GiaoVien_Get_CanhBaoHetNhiemKy(GlobalVar.MaXacThuc, HanCanhBao, TinhDenNgay));
            }
        }

        //public int Add(NS_GiaoVienInfo pNS_GiaoVienInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDNS_GiaoVien_Add(GlobalVar.MaXacThuc, pNS_GiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDNS_GiaoVien.ErrorMessages;
        //    mErrorNumber = oDNS_GiaoVien.ErrorNumber;
        //    return ID;
        //}

        //public void Update(NS_GiaoVienInfo pNS_GiaoVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDNS_GiaoVien_Update(GlobalVar.MaXacThuc, pNS_GiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDNS_GiaoVien.ErrorMessages;
        //    mErrorNumber = oDNS_GiaoVien.ErrorNumber;
        //}

        public int UpdateMaGiaoVien(string MaGiaoVien, int NS_GiaoVienID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDNS_GiaoVien_UpdateMaGiaoVien(GlobalVar.MaXacThuc, MaGiaoVien, NS_GiaoVienID);
            }
        }

        public void UpdateMaGiaoVien(ref DataTable dtGiaoVien)
        {
            if (!dtGiaoVien.Columns.Contains("GhiChu"))
                dtGiaoVien.Columns.Add("GhiChu", typeof(string));
            foreach (DataRow dr in dtGiaoVien.Rows)
            {
                if (UpdateMaGiaoVien(dr["MaGiaoVien"].ToString(), int.Parse(dr["NS_GiaoVienID"].ToString())) > 0)
                    dr["GhiChu"] = "Mã này đã được sử dụng cho cán bộ khác";
            }
        }

        public string UpdateTaiKhoan(string Username, string Password, int NS_GiaoVienID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDNS_GiaoVien_UpdateTaiKhoan(GlobalVar.MaXacThuc, Username, Password, NS_GiaoVienID);
            }
        }

        public void UpdateTaiKhoan(ref DataTable dtGiaoVien)
        {
            if (!dtGiaoVien.Columns.Contains("GhiChu"))
                dtGiaoVien.Columns.Add("GhiChu", typeof(string));
            string UsernameNew = "";
            foreach (DataRow dr in dtGiaoVien.Rows)
            {
                if (string.IsNullOrEmpty(dr["Username"].ToString())) continue;

                UsernameNew = UpdateTaiKhoan(dr["Username"].ToString(), dr["Password"].ToString(), int.Parse(dr["NS_GiaoVienID"].ToString()));
                if (UsernameNew != dr["Username"].ToString())
                {
                    dr["Username"] = UsernameNew;
                    dr["GhiChu"] = "Tên truy nhập đã được thay thế.";
                }
            }
        }

        public void UpdateIDDM_Khoa_GiaoVu(int IDDM_Khoa_GiaoVu, int NS_GiaoVienID)
        {
            var client = new UnimOsServiceClient();
            client.cDNS_GiaoVien_UpdateIDDM_Khoa_GiaoVu(GlobalVar.MaXacThuc, IDDM_Khoa_GiaoVu, NS_GiaoVienID);
            client.Close();
        }

        public void UpdateAnhGiaoVien(DataTable dtSinhVien, string ThuMucAnh)
        {
            Image img;
            byte[] Anh;
            foreach (DataRow dr in dtSinhVien.Rows)
            {
                if ("" + dr["FileAnh"] != "")
                {
                    MemoryStream ms = new MemoryStream();
                    img = Image.FromFile(ThuMucAnh + dr["FileAnh"].ToString());
                    img.Save(ms, img.RawFormat);
                    Anh = ms.GetBuffer();
                    var client = new UnimOsServiceClient();
                    client.cDNS_GiaoVien_UpdateAnhGiaoVien(GlobalVar.MaXacThuc, Anh, int.Parse(dr["NS_GiaoVienID"].ToString()));
                    client.Close();
                }
            }
        }

        public void UpdateDonVi(int NS_GiaoVienID, int IDNS_DonVi)
        {
            var client = new UnimOsServiceClient();
            client.cDNS_GiaoVien_UpdateDonVi(GlobalVar.MaXacThuc, NS_GiaoVienID, IDNS_DonVi);
            client.Close();
        }

        //public void Delete(NS_GiaoVienInfo pNS_GiaoVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDNS_GiaoVien_Delete(GlobalVar.MaXacThuc, pNS_GiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDNS_GiaoVien.ErrorMessages;
        //    mErrorNumber = oDNS_GiaoVien.ErrorNumber;
        //}

        //public List<NS_GiaoVienInfo> GetList(NS_GiaoVienInfo pNS_GiaoVienInfo)
        //{
        //    List<NS_GiaoVienInfo> oNS_GiaoVienInfoList = new List<NS_GiaoVienInfo>();
        //    DataTable dtb = Get(pNS_GiaoVienInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oNS_GiaoVienInfo = new NS_GiaoVienInfo();

        //            oNS_GiaoVienInfo.NS_GiaoVienID = int.Parse(dtb.Rows[i]["NS_GiaoVienID"].ToString());
        //            oNS_GiaoVienInfo.MaGiaoVien = dtb.Rows[i]["MaGiaoVien"].ToString();
        //            oNS_GiaoVienInfo.HoTen = dtb.Rows[i]["HoTen"].ToString();
        //            oNS_GiaoVienInfo.Ten = dtb.Rows[i]["Ten"].ToString();
        //            oNS_GiaoVienInfo.TenVietTat = dtb.Rows[i]["TenVietTat"].ToString();
        //            oNS_GiaoVienInfo.NgaySinh = DateTime.Parse(dtb.Rows[i]["NgaySinh"].ToString());
        //            oNS_GiaoVienInfo.IDNS_DonVi = int.Parse(dtb.Rows[i]["IDNS_DonVi"].ToString());
        //            oNS_GiaoVienInfo.Anh = (byte[])(dtb.Rows[i]["Anh"]);
        //            oNS_GiaoVienInfo.DienThoai = dtb.Rows[i]["DienThoai"].ToString();
        //            oNS_GiaoVienInfo.IDDM_TinhHuyenXaQueQuan = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaQueQuan"].ToString());
        //            oNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiSinh = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaNoiSinh"].ToString());
        //            oNS_GiaoVienInfo.DiaChiThuongTru = dtb.Rows[i]["DiaChiThuongTru"].ToString();
        //            oNS_GiaoVienInfo.IDDM_TinhHuyenXaThuongTru = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaThuongTru"].ToString());
        //            oNS_GiaoVienInfo.DiaChiNoiO = dtb.Rows[i]["DiaChiNoiO"].ToString();
        //            oNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiO = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaNoiO"].ToString());
        //            oNS_GiaoVienInfo.IDDM_DanToc = int.Parse(dtb.Rows[i]["IDDM_DanToc"].ToString());
        //            oNS_GiaoVienInfo.IDDM_TonGiao = int.Parse(dtb.Rows[i]["IDDM_TonGiao"].ToString());
        //            oNS_GiaoVienInfo.GioiTinh = bool.Parse(dtb.Rows[i]["GioiTinh"].ToString());
        //            oNS_GiaoVienInfo.SoCMND = "" + dtb.Rows[i]["SoCMND"].ToString();
        //            oNS_GiaoVienInfo.NgayCap = DateTime.Parse(dtb.Rows[i]["NgayCap"].ToString());
        //            oNS_GiaoVienInfo.Email = dtb.Rows[i]["Email"].ToString();
        //            oNS_GiaoVienInfo.GiangDay = bool.Parse(dtb.Rows[i]["GiangDay"].ToString());
        //            oNS_GiaoVienInfo.TrangThaiGiaoVien = int.Parse(dtb.Rows[i]["TrangThaiGiaoVien"].ToString());

        //            oNS_GiaoVienInfoList.Add(oNS_GiaoVienInfo);
        //        }
        //    }
        //    return oNS_GiaoVienInfoList;
        //}

        public void ToDataRow(NS_GiaoVienInfo pNS_GiaoVienInfo, ref DataRow dr)
        {
            dr[pNS_GiaoVienInfo.strNS_GiaoVienID] = pNS_GiaoVienInfo.NS_GiaoVienID;
            dr[pNS_GiaoVienInfo.strMaGiaoVien] = pNS_GiaoVienInfo.MaGiaoVien;
            dr[pNS_GiaoVienInfo.strHoTen] = pNS_GiaoVienInfo.HoTen;
            dr[pNS_GiaoVienInfo.strTen] = pNS_GiaoVienInfo.Ten;
            dr[pNS_GiaoVienInfo.strTenVietTat] = pNS_GiaoVienInfo.TenVietTat;
            dr[pNS_GiaoVienInfo.strNgaySinh] = pNS_GiaoVienInfo.NgaySinh;
            dr[pNS_GiaoVienInfo.strIDNS_DonVi] = pNS_GiaoVienInfo.IDNS_DonVi;
            dr[pNS_GiaoVienInfo.strAnh] = pNS_GiaoVienInfo.Anh;
            dr[pNS_GiaoVienInfo.strDienThoai] = pNS_GiaoVienInfo.DienThoai;
            dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaQueQuan] = pNS_GiaoVienInfo.IDDM_TinhHuyenXaQueQuan;
            dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaNoiSinh] = pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiSinh;
            dr[pNS_GiaoVienInfo.strDiaChiThuongTru] = pNS_GiaoVienInfo.DiaChiThuongTru;
            dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaThuongTru] = pNS_GiaoVienInfo.IDDM_TinhHuyenXaThuongTru;
            dr[pNS_GiaoVienInfo.strDiaChiNoiO] = pNS_GiaoVienInfo.DiaChiNoiO;
            dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaNoiO] = pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiO;
            dr[pNS_GiaoVienInfo.strIDDM_DanToc] = pNS_GiaoVienInfo.IDDM_DanToc;
            dr[pNS_GiaoVienInfo.strIDDM_TonGiao] = pNS_GiaoVienInfo.IDDM_TonGiao;
            dr[pNS_GiaoVienInfo.strGioiTinh] = pNS_GiaoVienInfo.GioiTinh;
            dr[pNS_GiaoVienInfo.strSoCMND] = pNS_GiaoVienInfo.SoCMND;
            dr[pNS_GiaoVienInfo.strNgayCap] = pNS_GiaoVienInfo.NgayCap;
            dr[pNS_GiaoVienInfo.strEmail] = pNS_GiaoVienInfo.Email;
            dr[pNS_GiaoVienInfo.strGiangDay] = pNS_GiaoVienInfo.GiangDay;
            dr[pNS_GiaoVienInfo.strTrangThaiGiaoVien] = pNS_GiaoVienInfo.TrangThaiGiaoVien;
            dr[pNS_GiaoVienInfo.strUsername] = pNS_GiaoVienInfo.Username;
            dr[pNS_GiaoVienInfo.strPassword] = pNS_GiaoVienInfo.Password;
            dr[pNS_GiaoVienInfo.strIsDuocTruyCap] = pNS_GiaoVienInfo.IsDuocTruyCap;
            dr[pNS_GiaoVienInfo.strIDDM_Khoa_GiaoVu] = pNS_GiaoVienInfo.IDDM_Khoa_GiaoVu;
        }

        public void ToInfo(ref NS_GiaoVienInfo pNS_GiaoVienInfo, DataRow dr)
        {
            pNS_GiaoVienInfo.NS_GiaoVienID = int.Parse(dr[pNS_GiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_GiaoVienInfo.MaGiaoVien = dr[pNS_GiaoVienInfo.strMaGiaoVien].ToString();
            pNS_GiaoVienInfo.HoTen = dr[pNS_GiaoVienInfo.strHoTen].ToString();
            pNS_GiaoVienInfo.Ten = dr[pNS_GiaoVienInfo.strTen].ToString();
            pNS_GiaoVienInfo.TenVietTat = dr[pNS_GiaoVienInfo.strTenVietTat].ToString();
            if (dr[pNS_GiaoVienInfo.strNgaySinh].ToString() != "")
                pNS_GiaoVienInfo.NgaySinh = DateTime.Parse(dr[pNS_GiaoVienInfo.strNgaySinh].ToString());
            pNS_GiaoVienInfo.IDNS_DonVi = int.Parse("0" + dr[pNS_GiaoVienInfo.strIDNS_DonVi]);
            //if (dr[pNS_GiaoVienInfo.strAnh] != null)
            //    pNS_GiaoVienInfo.Anh = (byte[])(dr[pNS_GiaoVienInfo.strAnh]);
            pNS_GiaoVienInfo.DienThoai = dr[pNS_GiaoVienInfo.strDienThoai].ToString();
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaQueQuan = int.Parse("0" + dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaQueQuan]);
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiSinh = int.Parse("0" + dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaNoiSinh]);
            pNS_GiaoVienInfo.DiaChiThuongTru = "" + dr[pNS_GiaoVienInfo.strDiaChiThuongTru].ToString();
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaThuongTru = int.Parse("0" + dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaThuongTru]);
            pNS_GiaoVienInfo.DiaChiNoiO = dr[pNS_GiaoVienInfo.strDiaChiNoiO].ToString();
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiO = int.Parse("0" + dr[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaNoiO]);
            pNS_GiaoVienInfo.IDDM_DanToc = int.Parse("0" + dr[pNS_GiaoVienInfo.strIDDM_DanToc]);
            pNS_GiaoVienInfo.IDDM_TonGiao = int.Parse("0" + dr[pNS_GiaoVienInfo.strIDDM_TonGiao]);
            pNS_GiaoVienInfo.GioiTinh = bool.Parse(dr[pNS_GiaoVienInfo.strGioiTinh].ToString());
            pNS_GiaoVienInfo.SoCMND = dr[pNS_GiaoVienInfo.strSoCMND].ToString();
            if (dr[pNS_GiaoVienInfo.strNgayCap].ToString() != "")
                pNS_GiaoVienInfo.NgayCap = DateTime.Parse(dr[pNS_GiaoVienInfo.strNgayCap].ToString());
            pNS_GiaoVienInfo.Email = dr[pNS_GiaoVienInfo.strEmail].ToString();
            pNS_GiaoVienInfo.GiangDay = bool.Parse(dr[pNS_GiaoVienInfo.strGiangDay].ToString());
            pNS_GiaoVienInfo.TrangThaiGiaoVien = int.Parse("0" + dr[pNS_GiaoVienInfo.strTrangThaiGiaoVien]);
            pNS_GiaoVienInfo.Username = "" + dr[pNS_GiaoVienInfo.strUsername];
            pNS_GiaoVienInfo.Password = "" + dr[pNS_GiaoVienInfo.strPassword];
            if (pNS_GiaoVienInfo.Username != "")
            {
                pNS_GiaoVienInfo.IsDuocTruyCap = bool.Parse(dr[pNS_GiaoVienInfo.strIsDuocTruyCap].ToString());
                if ("" + dr[pNS_GiaoVienInfo.strIDDM_Khoa_GiaoVu] != "")
                    pNS_GiaoVienInfo.IDDM_Khoa_GiaoVu = int.Parse(dr[pNS_GiaoVienInfo.strIDDM_Khoa_GiaoVu].ToString());
            }
        }

        public void ToInfo(ref NS_GiaoVienInfo pNS_GiaoVienInfo, DataRow dr, DataTable dt)
        {
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strMaGiaoVien))
                pNS_GiaoVienInfo.MaGiaoVien = dr[pNS_GiaoVienInfo.strMaGiaoVien].ToString();
            if (dt.Columns.Contains("HoVaTen"))
            {
                pNS_GiaoVienInfo.HoTen = dr["HoVaTen"].ToString();
                pNS_GiaoVienInfo.Ten = GetTen(pNS_GiaoVienInfo.HoTen);
            }
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strNgaySinh))
            {
                if (dr[pNS_GiaoVienInfo.strNgaySinh].ToString() != "")
                    pNS_GiaoVienInfo.NgaySinh = DateTime.Parse(dr[pNS_GiaoVienInfo.strNgaySinh].ToString());
                else
                    pNS_GiaoVienInfo.NgaySinh = DateTime.Parse("01/01/1900");
            }
            else
                pNS_GiaoVienInfo.NgaySinh = DateTime.Parse("01/01/1900");

            if (dt.Columns.Contains(pNS_GiaoVienInfo.strDiaChiThuongTru))
                pNS_GiaoVienInfo.DiaChiThuongTru = "" + dr[pNS_GiaoVienInfo.strDiaChiThuongTru].ToString();
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strDiaChiNoiO))
                pNS_GiaoVienInfo.DiaChiNoiO = "" + dr[pNS_GiaoVienInfo.strDiaChiNoiO];
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strGioiTinh))
                pNS_GiaoVienInfo.GioiTinh = bool.Parse(dr[pNS_GiaoVienInfo.strGioiTinh].ToString() == "Nam" ? "0" : "1");

            pNS_GiaoVienInfo.NgayCap = DateTime.Parse("01/01/1900");
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strDienThoai))
                pNS_GiaoVienInfo.DienThoai = "" + dr[pNS_GiaoVienInfo.strDienThoai];
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strEmail))
                pNS_GiaoVienInfo.Email = "" + dr[pNS_GiaoVienInfo.strEmail];
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strGiangDay))
                pNS_GiaoVienInfo.GiangDay = true;
            if (dt.Columns.Contains(pNS_GiaoVienInfo.strTrangThaiGiaoVien))
                pNS_GiaoVienInfo.TrangThaiGiaoVien = 1;
        }

        #region Dành cho việc xếp TKB
        public cBwsNS_GiaoVien(HT_ThamSoXepLichInfo pThamSoTKB)
        {
            oDNS_GiaoVien = new cDNS_GiaoVien();
            //oNS_GiaoVienInfo = new NS_GiaoVienInfo();
            arrGiaoVien = new ArrayList();
            int intNS_GiaoVienID;
            string strHoTen, strTenVietTat, strMaGiaoVien;
            //oNS_GiaoVienInfo.NS_GiaoVienID = 0;
            DataTable dtGV = Get_TKB(0);
            GiaoVien objGV;
            foreach (DataRow dr in dtGV.Rows)
            {
                intNS_GiaoVienID = (int)dr["NS_GiaoVienID"];
                strHoTen = dr["HoTen"].ToString();
                strTenVietTat = dr["TenVietTat"].ToString();
                strMaGiaoVien = dr["MaGiaoVien"].ToString();
                objGV = new GiaoVien(intNS_GiaoVienID, strMaGiaoVien, strHoTen, strTenVietTat, pThamSoTKB);
                arrGiaoVien.Add(objGV);
            }
        }

        public string SearchTenGV(int IDNS_GiaoVien)
        {
            GiaoVien objGV;
            for (int i = 0; i < arrGiaoVien.Count; i++)
            {
                objGV = (GiaoVien)arrGiaoVien[i];
                if (objGV.NS_GiaoVienID == IDNS_GiaoVien)
                    return objGV.HoTen;
            }
            return "";
        }

        public int SearchIndexGV(int IDNS_GiaoVien)
        {
            GiaoVien objGV;
            for (int i = 0; i < arrGiaoVien.Count; i++)
            {
                objGV = (GiaoVien)arrGiaoVien[i];
                if (objGV.NS_GiaoVienID == IDNS_GiaoVien)
                    return i;
            }
            return -1;
        }

        public int Count
        {
            get { return arrGiaoVien.Count; }
        }

        public GiaoVien this[int idx]
        {
            set { arrGiaoVien[idx] = value; }
            get { return (GiaoVien)arrGiaoVien[idx]; }
        }
        #endregion
    }
}
