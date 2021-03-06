using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsDM_KhoiKienThuc : cBwsBase
    {
        private cDDM_KhoiKienThuc oDDM_KhoiKienThuc;
        private DM_KhoiKienThucInfo oDM_KhoiKienThucInfo;

        public cBwsDM_KhoiKienThuc()
        {
            oDDM_KhoiKienThuc = new cDDM_KhoiKienThuc();
        }

        public DataTable Get(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_KhoiKienThuc_GetResult>(client.cDDM_KhoiKienThuc_Get(GlobalVar.MaXacThuc, pDM_KhoiKienThucInfo));
            }
        }

        public int Add(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDDM_KhoiKienThuc_Add(GlobalVar.MaXacThuc, pDM_KhoiKienThucInfo);
            client.Close();
            mErrorMessage = oDDM_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDDM_KhoiKienThuc.ErrorNumber;
            return ID;
        }

        public void Update(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDDM_KhoiKienThuc_Update(GlobalVar.MaXacThuc, pDM_KhoiKienThucInfo);
            client.Close();
            mErrorMessage = oDDM_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDDM_KhoiKienThuc.ErrorNumber;
        }

        public void Delete(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDDM_KhoiKienThuc_Delete(GlobalVar.MaXacThuc, pDM_KhoiKienThucInfo);
            client.Close();
            mErrorMessage = oDDM_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDDM_KhoiKienThuc.ErrorNumber;
        }

        public List<DM_KhoiKienThucInfo> GetList(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            List<DM_KhoiKienThucInfo> oDM_KhoiKienThucInfoList = new List<DM_KhoiKienThucInfo>();
            DataTable dtb = Get(pDM_KhoiKienThucInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oDM_KhoiKienThucInfo = new DM_KhoiKienThucInfo();


                    oDM_KhoiKienThucInfo.DM_KhoiKienThucID = int.Parse(dtb.Rows[i]["DM_KhoiKienThucID"].ToString());
                    oDM_KhoiKienThucInfo.MaKhoiKienThuc = dtb.Rows[i]["MaKhoiKienThuc"].ToString();
                    oDM_KhoiKienThucInfo.TenKhoiKienThuc = dtb.Rows[i]["TenKhoiKienThuc"].ToString();
                    oDM_KhoiKienThucInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
                    oDM_KhoiKienThucInfo.SoHocPhanPhaiChon = int.Parse(dtb.Rows[i]["SoHocPhanPhaiChon"].ToString());
                    oDM_KhoiKienThucInfo.KhoaLuanTotNghiep = bool.Parse(dtb.Rows[i]["KhoaLuanTotNghiep"].ToString());
                    oDM_KhoiKienThucInfo.SapXep = int.Parse(dtb.Rows[i]["SapXep"].ToString());

                    oDM_KhoiKienThucInfoList.Add(oDM_KhoiKienThucInfo);
                }
            }
            return oDM_KhoiKienThucInfoList;
        }
    }
}
