using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using TruongViet.UnimOs.Business;
using System.IO;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmBaoCaoLanhDaoDoBoNhiem : frmBase
    {
        private cBNS_QuaTrinhBoNhiemChucVu oBNS_QuaTrinhBoNhiemChucVu;
        private DataTable dtBaoCao;
        private int _ColStart;

        public frmBaoCaoLanhDaoDoBoNhiem()
        {
            InitializeComponent();
            oBNS_QuaTrinhBoNhiemChucVu = new cBNS_QuaTrinhBoNhiemChucVu();
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private void frmBaoCaoLanhDaoDoBoNhiem_Load(object sender, EventArgs e)
        {
            CreateTable();
            AddBand();
        }

        private void CreateTable()
        {
            dtBaoCao = new DataTable();
            dtBaoCao.Columns.Add("DM_ChucVuID", typeof(int));
            dtBaoCao.Columns.Add("TenChucVu", typeof(string));
            dtBaoCao.Columns.Add("TongSo", typeof(int));
            dtBaoCao.Columns.Add("BoNhiemTrongKy", typeof(int));
            _ColStart = 4;
        }

        private void AddBand()
        {
            BandedGridColumn bgc;
            string TenCot;
            for (int i = 0; i < 18; i++)
            {
                TenCot = (0.1 + (i * 0.05)).ToString();
                dtBaoCao.Columns.Add("C_" + TenCot, typeof(int));
                // Begin Add column HeSo
                bgc = new BandedGridColumn();
                grbHeSo.Columns.Add(bgc);

                SetColumnBandCaption(bgc, TenCot, "C_" + TenCot, 45, DevExpress.Utils.HorzAlignment.Default, true);

                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                bgrvBaoCao.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                // End Add column HeSo
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpDenNgay.EditValue == null)
            {
                ThongBao("Bạn chưa chọn ngày báo cáo !");
                return;
            }
            if (dtBaoCao != null)
                dtBaoCao.Rows.Clear();

            XuLyTable();
            grdBaoCao.DataSource = dtBaoCao;
        }

        private void XuLyTable()
        {
            DataTable dt = oBNS_QuaTrinhBoNhiemChucVu.GetSoLuongBoNhiem((DateTime)dtpDenNgay.EditValue);
            if (dt.Rows.Count <= 0)
                return;
            
            DateTime TuNgay = DateTime.Parse("01/01/" + ((DateTime)dtpDenNgay.EditValue).Year.ToString());
            int TongSo = 0, BoNhiemTrongKy = 0;
            string IDDM_ChucVu = dt.Rows[0]["DM_ChucVuID"].ToString();

            DataRow drNew = dtBaoCao.NewRow();
            drNew["DM_ChucVuID"] = int.Parse(IDDM_ChucVu);
            drNew["TenChucVu"] = dt.Rows[0]["TenChucVu"].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                if (IDDM_ChucVu != dr["DM_ChucVuID"].ToString())
                {
                    drNew["TongSo"] = TongSo;
                    if (BoNhiemTrongKy > 0)
                        drNew["BoNhiemTrongKy"] = BoNhiemTrongKy;
                    dtBaoCao.Rows.Add(drNew);

                    TongSo = 0;
                    BoNhiemTrongKy = 0;
                    IDDM_ChucVu = dr["DM_ChucVuID"].ToString();
                    drNew = dtBaoCao.NewRow();
                    drNew["DM_ChucVuID"] = int.Parse(IDDM_ChucVu);
                    drNew["TenChucVu"] = dr["TenChucVu"].ToString();
                }

                if ("" + dr["HeSoPhuCap"] != "")
                {
                    if (dtBaoCao.Columns.Contains("C_" + dr["HeSoPhuCap"]))
                    {
                        if ("" + drNew["C_" + dr["HeSoPhuCap"]] != "")
                            drNew["C_" + dr["HeSoPhuCap"]] = int.Parse(drNew["C_" + dr["HeSoPhuCap"]].ToString()) + 1;
                        else
                            drNew["C_" + dr["HeSoPhuCap"]] = 1;
                    }
                }
                if ((DateTime)dr["NgayCoHieuLuc"] > TuNgay)
                    BoNhiemTrongKy++;
                TongSo++;
            }
            drNew["TongSo"] = TongSo;
            if (BoNhiemTrongKy > 0)
                drNew["BoNhiemTrongKy"] = BoNhiemTrongKy;
            dtBaoCao.Rows.Add(drNew);
        }

        private void bgrvBaoCao_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatTheoTemplate();
        }

        #region Xuat theo template
        private void XuatTheoTemplate()
        {
            if (dtBaoCao.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\Temp_BaoCaoSoLuongCongChucGiuCacChucVuLanhDao.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Bao cao so luong lanh dao den ngay " + ((DateTime)dtpDenNgay.EditValue).ToString("yyyyMMdd") + ".xls";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                string strTenFileExcelMoi = sv.FileName;
                try
                {
                    File.Copy(strFileExcel, strTenFileExcelMoi, true);
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("File excel đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                    return;
                }
                finally { }
                XuatDuLieuRaExcel(strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 11, ExcCotBatDau = 5, SoCot = 22;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                excel.Cells[5, 1] = "(Có đến ngày " + dtpDenNgay.Text + ")";

                int count = dtBaoCao.Rows.Count;
                DataRow dr;
                for (int i = 0; i < count; i++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    dr = dtBaoCao.Rows[i];

                    excel.Cells[i + DongBatDau, 1] = i + 1;
                    excel.Cells[i + DongBatDau, 2] = "" + dr["TenChucVu"];
                    excel.Cells[i + DongBatDau, 3] = "" + dr["TongSo"];
                    excel.Cells[i + DongBatDau, 4] = "" + dr["BoNhiemTrongKy"];

                    for (int j = _ColStart; j < dtBaoCao.Columns.Count; j++)
                    {
                        if ("" + dr[dtBaoCao.Columns[j].ColumnName] != "")
                        {
                            excel.Cells[i + DongBatDau, j - _ColStart + ExcCotBatDau] = dr[dtBaoCao.Columns[j].ColumnName].ToString();
                            //cel = (Excel.Range)excel.Cells[i + DongBatDau, j - _ColStart + ExcCotBatDau];
                        }
                    }
                }
                // Them dong tong
                cel = (Excel.Range)(excel.Cells[count + DongBatDau + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                excel.Cells[count + DongBatDau, 2] = "Cộng";
                excel.Cells[count + DongBatDau, 3] = dtBaoCao.Compute("Sum(TongSo)", "").ToString();
                string Tong = "" + dtBaoCao.Compute("Sum(BoNhiemTrongKy)", ""), TenCot;
                if (Tong != "")
                    excel.Cells[count + DongBatDau, 4] = Tong;

                for (int j = _ColStart; j < dtBaoCao.Columns.Count; j++)
                {
                    TenCot = dtBaoCao.Columns[j].ColumnName;
                    Tong = "" + dtBaoCao.Compute("Sum([" + TenCot + "])", "");
                    if (Tong != "")
                        excel.Cells[count + DongBatDau, j - _ColStart + ExcCotBatDau] = Tong;
                }
                cel = excel.get_Range(excel.Cells[count + DongBatDau, 1], excel.Cells[DongBatDau + count, SoCot]);
                cel.Font.Bold = true;

                // Set style
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + count - 1, SoCot]);
                cel.Borders.LineStyle = Excel.XlLineStyle.xlDot;
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + count, 1]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;

                for (int j = 1; j <= SoCot; j++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, j], excel.Cells[DongBatDau + count, j]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                cel = excel.get_Range(excel.Cells[DongBatDau + count, 1], excel.Cells[DongBatDau + count, SoCot]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            catch (Exception e)
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                return;
            }
            finally
            {
                excel.Application.Workbooks[1].Save();
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();
                Process.Start(FileExcel);
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion
    }
}