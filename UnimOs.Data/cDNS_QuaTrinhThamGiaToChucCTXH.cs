using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhThamGiaToChucCTXH : cDBase
    {
        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_QuaTrinhThamGiaToChucCTXH_GetBy_IDNS_GiaoVien", colParam);
        }
    }
}
