using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachTroCap : cDBase
    {
        public DataTable GetInSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_TC_DanhSachTroCap_GetInSinhVien", colParam);
        }
        public DataTable GetNotInSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy, string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar,20, NamHoc));

            return RunProcedureGet("sp_TC_DanhSachTroCap_GetNotInSinhVien", colParam);
        }
    }
}
