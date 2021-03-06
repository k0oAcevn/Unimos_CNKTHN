using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_HinhThucThi : cBBase
    {
        private cDDM_HinhThucThi oDDM_HinhThucThi;
        private DM_HinhThucThiInfo oDM_HinhThucThiInfo;

        public cBDM_HinhThucThi()        
        {
            oDDM_HinhThucThi = new cDDM_HinhThucThi();
        }

        public DataTable Get(DM_HinhThucThiInfo pDM_HinhThucThiInfo)        
        {
            return oDDM_HinhThucThi.Get(pDM_HinhThucThiInfo);
        }

        public int Add(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
			int ID = 0;
            ID = oDDM_HinhThucThi.Add(pDM_HinhThucThiInfo);
            mErrorMessage = oDDM_HinhThucThi.ErrorMessages;
            mErrorNumber = oDDM_HinhThucThi.ErrorNumber;
            return ID;
        }

        public void Update(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            oDDM_HinhThucThi.Update(pDM_HinhThucThiInfo);
            mErrorMessage = oDDM_HinhThucThi.ErrorMessages;
            mErrorNumber = oDDM_HinhThucThi.ErrorNumber;
        }
        
        public void Delete(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            oDDM_HinhThucThi.Delete(pDM_HinhThucThiInfo);
            mErrorMessage = oDDM_HinhThucThi.ErrorMessages;
            mErrorNumber = oDDM_HinhThucThi.ErrorNumber;
        }

        public List<DM_HinhThucThiInfo> GetList(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            List<DM_HinhThucThiInfo> oDM_HinhThucThiInfoList = new List<DM_HinhThucThiInfo>();
            DataTable dtb = Get(pDM_HinhThucThiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_HinhThucThiInfo = new DM_HinhThucThiInfo();
                    

                    oDM_HinhThucThiInfo.DM_HinhThucThiID = int.Parse(dtb.Rows[i]["DM_HinhThucThiID"].ToString());
                    oDM_HinhThucThiInfo.MaHinhThucThi = dtb.Rows[i]["MaHinhThucThi"].ToString();
                    oDM_HinhThucThiInfo.TenHinhThucThi = dtb.Rows[i]["TenHinhThucThi"].ToString();
                    oDM_HinhThucThiInfo.XepLichThi = bool.Parse(dtb.Rows[i]["XepLichThi"].ToString());
                    
                    oDM_HinhThucThiInfoList.Add(oDM_HinhThucThiInfo);
                }
            }
            return oDM_HinhThucThiInfoList;
        }
    }
}
