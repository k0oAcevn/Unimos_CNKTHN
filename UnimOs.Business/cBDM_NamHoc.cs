﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using Microsoft.VisualBasic;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_NamHoc : cBBase
    {
        private cDDM_NamHoc oDDM_NamHoc;
        private DM_NamHocInfo oDM_NamHocInfo;

        public cBDM_NamHoc()        
        {
            oDDM_NamHoc = new cDDM_NamHoc();
        }

        public DataTable Get(DM_NamHocInfo pDM_NamHocInfo)        
        {
            return oDDM_NamHoc.Get(pDM_NamHocInfo);
        }

        public int GetKy2(DM_NamHocInfo pNamHocInfo)
        {
            return oDDM_NamHoc.GetKy2(pNamHocInfo);
        }

        public int Add(DM_NamHocInfo pDM_NamHocInfo)
        {
			int ID = 0;
            ID = oDDM_NamHoc.Add(pDM_NamHocInfo);
            mErrorMessage = oDDM_NamHoc.ErrorMessages;
            mErrorNumber = oDDM_NamHoc.ErrorNumber;
            return ID;
        }

        public void Update(DM_NamHocInfo pDM_NamHocInfo)
        {
            oDDM_NamHoc.Update(pDM_NamHocInfo);
            mErrorMessage = oDDM_NamHoc.ErrorMessages;
            mErrorNumber = oDDM_NamHoc.ErrorNumber;
        }
        
        public void Delete(DM_NamHocInfo pDM_NamHocInfo)
        {
            oDDM_NamHoc.Delete(pDM_NamHocInfo);
            mErrorMessage = oDDM_NamHoc.ErrorMessages;
            mErrorNumber = oDDM_NamHoc.ErrorNumber;
        }

        public List<DM_NamHocInfo> GetList(DM_NamHocInfo pDM_NamHocInfo)
        {
            List<DM_NamHocInfo> oDM_NamHocInfoList = new List<DM_NamHocInfo>();
            pDM_NamHocInfo.DM_NamHocID = 0;
            DataTable dtb = Get(pDM_NamHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_NamHocInfo = new DM_NamHocInfo();
                    

                    oDM_NamHocInfo.DM_NamHocID = int.Parse(dtb.Rows[i]["DM_NamHocID"].ToString());
                    oDM_NamHocInfo.TenNamHoc = dtb.Rows[i]["TenNamHoc"].ToString();
                    oDM_NamHocInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oDM_NamHocInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    
                    oDM_NamHocInfoList.Add(oDM_NamHocInfo);
                }
            }
            return oDM_NamHocInfoList;
        }

        public void TaoKeHoachTuan(int IDNamHoc, DateTime TuNgay, DateTime DenNgay, int Ky2TuTuan)
        {
            XL_TuanInfo pXL_TuanInfo = new XL_TuanInfo();
            cBXL_Tuan oBXL_Tuan = new cBXL_Tuan();
            pXL_TuanInfo.IDDM_NamHoc = IDNamHoc;
            DataView dv = oBXL_Tuan.GetByIDNamHoc(pXL_TuanInfo).DefaultView;
            DateTime NgayDau, NgayCuoi;
            int TuanThu, Tuan, Ky, idx;
            // Lấy tuần thứ mấy trong năm. Dùng hàm DatePart của VB.NET
            TuanThu = DateAndTime.DatePart(DateInterval.WeekOfYear, TuNgay, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            NgayDau = TuNgay;
            NgayCuoi = NgayDau.AddDays(1);
            Tuan = 1;
            Ky = 1;
            do
            {
                if ((TuanThu != DateAndTime.DatePart(DateInterval.WeekOfYear, NgayCuoi, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) && (NgayCuoi.DayOfWeek == DayOfWeek.Sunday))
                {
                    dv.Sort = "TuanThu";
                    idx = dv.Find(Tuan);
                    if (idx < 0)
                    {
                        pXL_TuanInfo.TuanThu = Tuan;
                        pXL_TuanInfo.IDDM_NamHoc = IDNamHoc;
                        pXL_TuanInfo.TuNgay = NgayDau;
                        pXL_TuanInfo.DenNgay = NgayCuoi;
                        pXL_TuanInfo.ChoPhepXemLich = false;
                        pXL_TuanInfo.HocKy = Ky;
                        oBXL_Tuan.Add(pXL_TuanInfo);
                    }
                    else
                    {
                        pXL_TuanInfo.XL_TuanID = long.Parse(dv[idx]["XL_TuanID"].ToString());
                        pXL_TuanInfo.TuanThu = Tuan;
                        pXL_TuanInfo.IDDM_NamHoc = IDNamHoc;
                        pXL_TuanInfo.TuNgay = NgayDau;
                        pXL_TuanInfo.DenNgay = NgayCuoi;
                        pXL_TuanInfo.ChoPhepXemLich = false;
                        pXL_TuanInfo.HocKy = Ky;
                        oBXL_Tuan.Update(pXL_TuanInfo);
                    }
                    NgayCuoi = NgayCuoi.AddDays(1);
                    NgayDau = NgayCuoi;
                    TuanThu = DateAndTime.DatePart(DateInterval.WeekOfYear, NgayCuoi, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                    Tuan += 1;
                    if (Tuan < Ky2TuTuan)
                        Ky = 1;
                    else
                        Ky = 2;
                }
                NgayCuoi = NgayCuoi.AddDays(1);
            }
            while (NgayCuoi <= DenNgay);
            pXL_TuanInfo.TuanThu = Tuan;
            oBXL_Tuan.DeleteTuanThua(pXL_TuanInfo);
        }
    }
}
