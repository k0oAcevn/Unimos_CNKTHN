﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using C1.Win.C1FlexGrid;
using System.Data.OleDb;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraExport;
using DevExpress.XtraTreeList;
using System.Globalization;
using System.Linq;
using System.Diagnostics;
using System.IO;
using Aspose.Cells;

namespace UnimOs.UI
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        #region Khai báo các biến
        private DevExpress.Utils.WaitDialogForm dlg = null;
        protected DataTable mdtColor = new DataTable();
        private cBHT_Log oBHT_Log = new cBHT_Log();
        private HT_LogInfo oHT_LogInfo = new HT_LogInfo();
        protected CultureInfo enUS = new CultureInfo("en-US");
        protected DateTimeStyles dateStyle = DateTimeStyles.None;
        private Cells _range;
        private Worksheet _exSheet;
        #endregion

        public frmBase()
        {
            InitializeComponent();
        }

        protected string GetTen(string pHoVaTen)
        {
            string[] arrTemp = pHoVaTen.Trim().Split(new char[] { ' ' });
            if (arrTemp.Length == 0)
                return "";
            else
                return arrTemp[arrTemp.Length - 1];
        }

        protected string GetTen(string pHoVaTen, ref string Ho_Dem)
        {
            pHoVaTen = pHoVaTen.Trim();
            if (pHoVaTen == "")
            {
                Ho_Dem = "";
                return "";
            }
            string[] arrTemp = pHoVaTen.Split(new char[] { ' ' });
            if (arrTemp.Length == 0)
            {
                Ho_Dem = "";
                return "";
            }
            else if (arrTemp.Length == 1)
            {
                Ho_Dem = "";
                return arrTemp[0];
            }
            else
            {
                Ho_Dem = pHoVaTen.Substring(0, pHoVaTen.ToString().Length - arrTemp[arrTemp.Length - 1].Length - 1);
                return arrTemp[arrTemp.Length - 1];
            }
        }

        protected void SetSelectedRow(GridView grv, int index)
        {
            int AmountRows = grv.DataRowCount;
            //Tổng row
            if ((AmountRows > 0))
            {
                //Khi có dữ liệu
                if ((index >= 0) & (index < AmountRows))
                {
                    //when index in datagrid
                    grv.FocusedRowHandle = index;
                }
                else
                {
                    if ((index >= AmountRows))
                    {
                        //Khi chỉ số lớn hơn
                        grv.FocusedRowHandle = AmountRows - 1;
                    }
                }
            }
        }

        protected List<int> ListTuan()
        {
            List<int> lstTuan = new List<int>();
            for (int i = 1; i <= 52; i++)
            {
                lstTuan.Add(i);
            }
            return lstTuan;
        }

        //Khai báo một danh sách các buổi học
        public enum BUOIHOC { ChuaXacDinh = -1, SANG = 0, CHIEU = 1, TOI = 2 };

        #region Xuất file
        protected void ExportTo(IExportProvider provider, GridView grv)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = grv.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            //link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            link.ExportTo(true);
            provider.Dispose();
            //link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            Cursor.Current = currentCursor;
        }

        protected void ExportToXls(GridView grv)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                CreateWaitDialog("Đang xuất dữ liệu ra Excel", "Xin vui lòng chờ.");
                Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                ExportTo(new DevExpress.XtraExport.ExportXlsProvider(sv.FileName), grv);
                CloseWaitDialog();
                if (ThongBaoChon("Xuất dữ liệu thành công!\n Bạn có muốn mở file này không?") == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = sv.FileName;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                    catch
                    {
                        ThongBaoLoi("Bạn chưa cài đặt ứng dụng Office để chạy file excel");
                    }
                }
            }
        }

        protected void ExportToXls(GridView grv, string FileName)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.FileName = FileName + ".xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                CreateWaitDialog("Đang xuất dữ liệu ra Excel", "Xin vui lòng chờ.");
                Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                ExportTo(new DevExpress.XtraExport.ExportXlsProvider(sv.FileName), grv);
                CloseWaitDialog();
                if (ThongBaoChon("Xuất dữ liệu thành công!\n Bạn có muốn mở file này không?") == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = sv.FileName;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                    catch
                    {
                        ThongBaoLoi("Bạn chưa cài đặt ứng dụng Office để chạy file excel");
                    }
                }
            }
        }

        protected void ExportFlexGridToXls(C1.Win.C1FlexGrid.C1FlexGrid fg)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.FileName = "KH-TienDo-" + Program.NamHoc + ".xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                CreateWaitDialog("Đang xuất dữ liệu ra file Excel\nXin vui lòng chờ!", "Xuất dữ liệu");
                try
                {
                    fg.SaveExcel(sv.FileName, FileFlags.IncludeFixedCells);
                    Lib.clsExportToExcel clsExcel = new Lib.clsExportToExcel();

                    clsExcel.MergeExcel(sv.FileName, fg);

                    CloseWaitDialog();
                }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Lỗi: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Dòng: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);
                    CloseWaitDialog();
                    ThongBaoLoi(errorMessage);
                }
            }
        }

        protected void XuatExcelXtraGrid(string TemplateFile, string OutputName, int _SheetsNumber, GridView grv, int DongFieldName, int DongBatDau,
            Dictionary<string, string> DuLieuThayThe)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");

            #region Chuẩn bị tệp excel để ghi dữ liệu
            Workbook exBook = new Workbook();
            exBook.Open(Application.StartupPath + "\\Template\\" + TemplateFile, FileFormatType.Excel2003);
            _exSheet = exBook.Worksheets[_SheetsNumber];
            _range = _exSheet.Cells;
            #endregion

            #region Đổ dữ liệu vào báo cáo
            // Thay thế dữ liệu trên file
            if (DuLieuThayThe != null)
                foreach (KeyValuePair<string, string> pair in DuLieuThayThe)
                {
                    _exSheet.Replace(pair.Key, pair.Value);
                }

            // Thêm các dòng và đưa style vào các dòng được thêm
            Range rngCopy = _exSheet.Cells.CreateRange(DongBatDau + 1, 0, 1, 100);
            Range rngPaste;
            int _count = grv.RowCount;

            if (_count > 3)
                _range.InsertRows(DongBatDau + 1, _count - 3);
            else
                _range.DeleteRows(DongBatDau + 1, 3 - _count);

            for (int i = 1; i < _count - 1; i++)
            {
                rngPaste = _exSheet.Cells.CreateRange(DongBatDau + i, 0, 1, 100);
                rngPaste.Copy(rngCopy);
                rngPaste.CopyStyle(rngCopy);
                _exSheet.Cells.SetRowHeight(DongBatDau + i, rngCopy.RowHeight);
            }

            // Gán giá trị cho các dòng dữ liệu
            int k = 0, DongHienTai = DongBatDau;
            string _FieldName = "";
            GridColumn grc;

            for (int i = 0; i < _count; i++)
            {
                k = 0;
                _FieldName = ("" + _exSheet.Cells[DongFieldName, 0].Value).Trim();

                while (_FieldName != "")
                {
                    grc = grv.Columns.ColumnByFieldName(_FieldName);
                    if (grc != null || _FieldName.ToUpper() == "STT")
                    {
                        if (_FieldName.ToUpper() == "STT")
                            _range[DongHienTai, k].PutValue(i + 1);
                        else if (_FieldName.IndexOf("=") >= 0)
                            _range[DongHienTai, k].Formula = _FieldName.Replace("[i]", (DongBatDau + i + 1).ToString()).Replace("'", "");
                        else
                            _range[DongHienTai, k].PutValue(grv.GetRowCellValue(i, grc));
                    }
                    k++;
                    _FieldName = ("" + _exSheet.Cells[DongFieldName, k].Value).Trim();
                }

                _exSheet.AutoFitRow(DongHienTai);

                DongHienTai++;
            }

            // Xóa dòng field name
            _exSheet.Cells.DeleteRow(DongFieldName);
            #endregion

            #region Lưu và mở file excel
            if (!Directory.Exists(Program.DuongDanThuMucBaoCao))
                Directory.CreateDirectory(Program.DuongDanThuMucBaoCao);
            string strTenFileExcelMoi = Program.DuongDanThuMucBaoCao + "\\" + OutputName;
            exBook.Save(strTenFileExcelMoi, FileFormatType.Excel2003);
            CloseWaitDialog();

            try
            {
                Process.Start(strTenFileExcelMoi);
            }
            catch (Exception ex)
            {
                ThongBaoLoi("Đã có lỗi: " + ex.Message);
            }
            #endregion
        }

        protected Dictionary<string, string> GetDuLieuThayTheBaoCao()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("TenBo", Program.TenBo);
            dic.Add("TenTruong", Program.TenTruong);
            dic.Add("DiaChi", Program.DiaChi);

            return dic;
        }
        #endregion

        #region Các hàm dùng chung
        protected string NgayNghiToString(string NgayNghi)
        {
            if (NgayNghi == "CaTuan")
                return "Cả tuần";

            string[] arrStr = NgayNghi.Split(',');
            string strNgayNghi = "";
            foreach (string str in arrStr)
            {
                if (str == "0")
                    strNgayNghi += (strNgayNghi == "" ? "" : ", ") + "Chủ nhật";
                else
                    strNgayNghi += (strNgayNghi == "" ? "" : ", ") + "Thứ " + (int.Parse(str) + 1).ToString();
            }
            return strNgayNghi;
        }

        protected void ShowIndicator(DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle + 1 > 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.ImageIndex = -1;
            }
        }

        protected void Base_DeleteInCombo(ComboBoxEdit cmb)
        {
            cmb.EditValue = null;
        }

        protected void GhiLog(string mNoiDung, string mSuKien, string mTag)
        {
            //  oHT_LogInfo.IPMayTram = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[2].ToString();
            oHT_LogInfo.IPMayTram = Lib.clsAuthentication.FindIPAddress();
            oHT_LogInfo.MacMayTram = Lib.clsAuthentication.FindMACAddress();
            oHT_LogInfo.NoiDung = mNoiDung;
            oHT_LogInfo.SuKien = mSuKien;
            oHT_LogInfo.Tag = mTag;
            oHT_LogInfo.ThoiDiem = DateTime.Now;
            oHT_LogInfo.UserName = Program.objUserCurrent.UserName;
            oBHT_Log.Add(oHT_LogInfo);
        }

        protected void FillKy(ComboBoxEdit cmb, int SoHocKy)
        {
            cmb.Properties.Items.Clear();
            for (int i = 1; i <= SoHocKy; i++)
                cmb.Properties.Items.Add(i);
        }

        protected int GetKyThuFromHocKy(string NienKhoa)
        {
            return (int.Parse(Program.NamHoc.Substring(0, 4)) - int.Parse(NienKhoa.Substring(0, 4))) * 2 + Program.HocKy;
        }

        protected void SetBandCaption(GridBand grbTemp, string caption, int width)
        {
            grbTemp.AppearanceHeader.Options.UseTextOptions = true;
            grbTemp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grbTemp.Caption = caption;
            grbTemp.OptionsBand.FixedWidth = true;
            grbTemp.Width = width;
        }

        protected void SetColumnBandCaption(BandedGridColumn bgc, string caption, string fieldName, int width, DevExpress.Utils.HorzAlignment alignment, bool sum)
        {
            bgc.AppearanceHeader.Options.UseTextOptions = true;
            bgc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bgc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            bgc.AppearanceCell.TextOptions.HAlignment = alignment;
            bgc.Caption = caption;
            bgc.FieldName = fieldName;
            bgc.OptionsColumn.FixedWidth = true;
            if (sum)
                bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            bgc.Visible = true;
            bgc.Width = width;
        }

        protected void SetColumnCaption(GridColumn grc, string caption, string fieldName, int width, DevExpress.Utils.HorzAlignment alignment, bool sum, int idx)
        {
            grc.AppearanceHeader.Options.UseTextOptions = true;
            grc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grc.AppearanceCell.TextOptions.HAlignment = alignment;
            grc.Caption = caption;
            grc.FieldName = fieldName;
            grc.OptionsColumn.FixedWidth = true;
            if (sum)
                grc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grc.Visible = true;
            grc.VisibleIndex = idx;
            grc.Width = width;
        }

        public string DateToInt(DateTime value)
        {
            return value.Year.ToString() + IntToString(value.Month) + IntToString(value.Day);
        }

        private string IntToString(int value)
        {
            if (value <= 9)
                return "0" + value.ToString();
            else
                return value.ToString();
        }

        public DateTime StringToDate(string value, string Thang)
        {
            string oDate = value.Substring(0, 4);
            oDate += "-" + value.Substring(4, Thang.Substring(Thang.Length - 2).Trim().Length);
            oDate += "-" + value.Substring(4 + Thang.Substring(Thang.Length - 2).Trim().Length);
            return DateTime.ParseExact(oDate, "yyyy-M-d", null);
        }

        public DateTime StringToDate(string value)
        {
            return DateTime.ParseExact(value, "yyyyMMdd", null);
        }

        public object Encode(string value, int r)
        {
            if (r % 2 == 1)
                return double.Parse(value);
            else
                return value;
        }

        public object EncodeString(string value, int r)
        {
            if (r % 2 == 1)
                return value + " ";
            else
                return value;
        }

        public object EncodeCaHoc(string value, int col)
        {
            if (col % 2 == 1)
                return value + " ";
            else
                return value;
        }

        public string GetThu(int Thu)
        {
            string strThu = "";
            switch (Thu)
            {
                case 0:
                    strThu = "Chủ nhật";
                    break;
                case 1:
                    strThu = "Thứ 2";
                    break;
                case 2:
                    strThu = "Thứ 3";
                    break;
                case 3:
                    strThu = "Thứ 4";
                    break;
                case 4:
                    strThu = "Thứ 5";
                    break;
                case 5:
                    strThu = "Thứ 6";
                    break;
                case 6:
                    strThu = "Thứ 7";
                    break;
            }
            return strThu;
        }

        public string GetCa(int CaHoc)
        {
            string strCa = "";
            switch (CaHoc)
            {
                case 0:
                    strCa = "Sáng";
                    break;
                case 1:
                    strCa = "Chiều";
                    break;
                case 2:
                    strCa = "Tối";
                    break;
                default:
                    strCa = "Không xác định";
                    break;
            }
            return strCa;
        }

        public void TaoKetNoiOleDB(OleDbConnection cnn, string LoaiNguon, string FileName)
        {
            string strKetNoi = "";
            string strFileType = "";
            strFileType = FileName.Substring(FileName.LastIndexOf("."));
            if (LoaiNguon != "Foxpro")
            {
                if (strFileType == ".mdb" | strFileType == ".xls")
                {
                    strKetNoi = "Provider=Microsoft.Jet.OLEDB.4.0;";
                }
                else
                {
                    strKetNoi = "Provider=Microsoft.ACE.OLEDB.12.0;";
                }
                strKetNoi += "Data source=" + FileName + ";";
                if (strFileType == ".xls" | strFileType == ".xlsx")
                {
                    strKetNoi += "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
            }
            else
            {
                strKetNoi = "Provider=VFPOLEDB;Data Source=" + FileName + ";Collating Sequence=machine;";
            }
            if (cnn.State == ConnectionState.Open) cnn.Close();
            cnn.ConnectionString = strKetNoi;
            cnn.Open();
        }

        public void HienThiDanhSachCacSheet(OleDbConnection cnn, ListBoxControl lst)
        {
            DataTable dt = default(DataTable);
            dt = cnn.GetSchema("tables");
            lst.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (dt.Rows[i]["TABLE_TYPE"].ToString() == "TABLE")
                {
                    lst.Items.Add(dt.Rows[i]["TABLE_NAME"]);
                }
            }
        }

        public DataTable GetDuLieuOleDb(OleDbConnection cnn, string SheetName)
        {
            // Lấy dữ liệu
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cd = new OleDbCommand();
            cd.CommandText = "select * from [" + SheetName + "]";
            cd.Connection = cnn;
            da.SelectCommand = cd;
            DataSet ds = new DataSet();
            da.Fill(ds, "DuLieuNguon");

            return ds.Tables["DuLieuNguon"];
        }

        public DataTable TaoBangCotChuyenDoi(DataTable dt)
        {
            DataTable dtCot = new DataTable();
            dtCot.Columns.Add("TenTruong", typeof(string));
            dtCot.Columns.Add("KieuDuLieu", typeof(string));
            dtCot.Columns.Add("KieuDuLieuMoi");
            dtCot.Columns.Add("MaKieuMoi");
            dtCot.Columns.Add("DinhDangDuLieuNguon");
            dtCot.Columns.Add("MaDinhDang");
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                object[] arr = { dt.Columns[i].ColumnName, dt.Columns[i].DataType.Name, "", "", "", "" };
                dtCot.Rows.Add(arr);
            }

            return dtCot;
        }

        public string GetSoPhieu(int HocKy, int IDDM_NamHoc, int SV_SinhVienID, int IDDM_DiaDiem)
        {
            DataTable dtTemp = (new cBTC_BienLaiThuTien()).GetSoPhieu(HocKy, IDDM_NamHoc, SV_SinhVienID, IDDM_DiaDiem);
            if (dtTemp != null && dtTemp.Rows.Count > 0)
                return GetSoPhieu(dtTemp.Rows[0]["SoPhieu"].ToString());
            else
                return "1";
        }

        private string GetSoPhieu(string SoPhieu)
        {
            if (SoPhieu.IndexOf("@") < 0)
            {
                SoPhieu = SoPhieu.Replace("@", "");
                string ChuoiTuTang = GetNumber(SoPhieu);
                string ChuoiMa = SoPhieu.Replace(ChuoiTuTang, "");
                if (ChuoiTuTang != "" && ChuoiTuTang.Substring(0, 1) == "0")
                {
                    ChuoiTuTang = "1" + ChuoiTuTang.ToString();
                    return ChuoiMa + (int.Parse("0" + ChuoiTuTang) + 1).ToString().Substring(1, ChuoiTuTang.Length - 1);
                }
                else
                    return ChuoiMa + (int.Parse("0" + ChuoiTuTang) + 1).ToString();
            }
            else
                return SoPhieu.Replace("@", "");

        }

        private string GetNumber(string strChuoi)
        {
            string strNumber = "";
            if (strChuoi != "")
            {
                while (strChuoi != "" && char.IsNumber(char.Parse(strChuoi.Substring(strChuoi.Length - 1, 1))) && strChuoi.Length > 0)
                {
                    strNumber = strChuoi.Substring(strChuoi.Length - 1, 1) + strNumber;
                    strChuoi = strChuoi.Substring(0, strChuoi.Length - 1);
                }
            }
            return strNumber;
        }

        public double SumColumnValue(DataTable dt, string FieldName)
        {
            double sum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sum += double.Parse("0" + dr[FieldName]);
            }
            return sum;
        }
        #endregion

        #region UserControl Hệ Trình độ
        //public void XuLyControl(ucHeTrinhDo pucHeTrinhDo)
        //{
        //    pucHeTrinhDo.cmbHe.EditValueChanged += new EventHandler(cmbHe_EditValueChanged);
        //    pucHeTrinhDo.cmbTrinhDo.EditValueChanged += new EventHandler(cmbTrinhDo_EditValueChanged);
        //    TruongViet.TVSchool.Business.cBHe oBHe = new TruongViet.TVSchool.Business.cBHe();
        //    TruongViet.TVSchool.Entity.HeInfo pHeInfo = new TruongViet.TVSchool.Entity.HeInfo();
        //    pHeInfo.HeID = 0;
        //    pucHeTrinhDo.cmbHe.Properties.DataSource = oBHe.Get(pHeInfo);
        //}


        //void cmbHe_EditValueChanged(object sender, EventArgs e)
        //{
        //    int IDHe = int.Parse(((ucHeTrinhDo)(((Control)sender).Parent.Parent)).cmbHe.EditValue.ToString());
        //    TruongViet.TVSchool.Business.cBTrinhDo oBTrinhDo = new TruongViet.TVSchool.Business.cBTrinhDo();
        //    TruongViet.TVSchool.Entity.TrinhDoInfo pTrinhDoInfo = new TruongViet.TVSchool.Entity.TrinhDoInfo();
        //    pTrinhDoInfo.IDHe = IDHe;
        //    ((ucHeTrinhDo)(((Control)sender).Parent.Parent)).cmbTrinhDo.Properties.DataSource = oBTrinhDo.GetByIDHe(pTrinhDoInfo);
        //}

        //void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        //{
        //    int IDHe = int.Parse(((ucHeTrinhDo)(((Control)sender).Parent.Parent)).cmbTrinhDo.EditValue.ToString());
        //    TruongViet.TVSchool.Business.cBKhoi_Lop oBKhoi_Lop = new TruongViet.TVSchool.Business.cBKhoi_Lop();
        //    ((ucHeTrinhDo)(((Control)sender).Parent.Parent)).cmbLop.Properties.DataSource = oBKhoi_Lop.GetByIDTrinhDo((int)((ucHeTrinhDo)(((Control)sender).Parent.Parent)).cmbTrinhDo.EditValue, Program.IDNamHoc);
        //}
        #endregion

        #region Wait Form
        public void CreateWaitDialog()
        {
            dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu, xin vui lòng chờ!", "Tải dữ liệu");
        }
        public void CreateWaitDialog(string str1, string str2)
        {
            dlg = new DevExpress.Utils.WaitDialogForm(str1, str2);
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if ((dlg != null)) dlg.Caption = fCaption;
        }
        public void CloseWaitDialog()
        {
            if ((dlg != null)) dlg.Close();
        }
        #endregion

        #region From
        protected void SetQuyen(Form frm, string Tag)
        {
            if (Program.htTable == null || Program.htTable.Count == 0)
                return;

            if (Program.htTable.ContainsKey(Tag))
            {
                string[] arrBit = (string[])Program.htTable[Tag];

                Control button;
                if (arrBit != null && arrBit.Length > 0)
                {
                    if ("" + arrBit[1] != "")
                    {
                        button = frm.Controls.Find(arrBit[1], true).SingleOrDefault();

                        if (button != null)
                            button.Enabled = false;
                    }

                    if ("" + arrBit[2] != "")
                    {
                        button = frm.Controls.Find(arrBit[2], true).SingleOrDefault();

                        if (button != null)
                            button.Enabled = false;
                    }

                    if ("" + arrBit[3] != "")
                    {
                        button = frm.Controls.Find(arrBit[3], true).SingleOrDefault();

                        if (button != null)
                            button.Enabled = false;
                    }
                }
            }
        }
        #endregion

        #region FlexColor
        // Khai báo cho phần format color
        //protected DataTable mdtColor = new DataTable();
        protected Hashtable htbCellStyle = new Hashtable();
        protected void FlexColor(C1FlexGrid fg)
        {
            cBXL_KeHoachKhac oBKeHoachKhac = new cBXL_KeHoachKhac();
            XL_KeHoachKhacInfo pKeHoachKhacInfo = new XL_KeHoachKhacInfo();
            pKeHoachKhacInfo.XL_KeHoachKhacID = 0;
            mdtColor = oBKeHoachKhac.GetCombo(pKeHoachKhacInfo);
            CellStyle objCellStyle;
            // Định nghĩa các Style theo kế hoạch người dùng chọn
            foreach (DataRow dr in mdtColor.Rows)
            {
                objCellStyle = fg.Styles.Add("MyCellStyle" + dr["XL_KeHoachKhacID"].ToString());
                objCellStyle.Font = new System.Drawing.Font("Arial", 8);
                objCellStyle.BackColor = Color.FromArgb(int.Parse(dr["MauNen"].ToString()));
                objCellStyle.ForeColor = Color.FromArgb(int.Parse(dr["MauChu"].ToString()));
                htbCellStyle.Add("MyCellStyle" + dr["XL_KeHoachKhacID"].ToString(), objCellStyle);
            }
            // Định nghĩa các Style chuẩn như sáng, chiều, tối...
            // Style lớp
            objCellStyle = fg.Styles.Add("MyCellStyleLop");
            //objCellStyle.Font = new Font("Arial", 10);
            objCellStyle.BackColor = Color.Tan;
            objCellStyle.ForeColor = Color.Black;
            htbCellStyle.Add("MyCellStyleLop", objCellStyle);
            // Style chuẩn
            objCellStyle = fg.Styles.Add("MyCellStyle");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.White;
            objCellStyle.ForeColor = Color.Black;
            htbCellStyle.Add("MyCellStyle", objCellStyle);
            // Ca học sáng
            objCellStyle = fg.Styles.Add("MyCellStyleSang");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.SkyBlue;
            objCellStyle.ForeColor = Color.Maroon;
            htbCellStyle.Add("MyCellStyleSang", objCellStyle);
            // Ca học chiều
            objCellStyle = fg.Styles.Add("MyCellStyleChieu");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.Gainsboro;
            objCellStyle.ForeColor = Color.DodgerBlue;
            htbCellStyle.Add("MyCellStyleChieu", objCellStyle);
            // Ca học tối
            objCellStyle = fg.Styles.Add("MyCellStyleToi");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.DarkSeaGreen;
            objCellStyle.ForeColor = Color.Gold;
            htbCellStyle.Add("MyCellStyleToi", objCellStyle);

            // Giáo viên
            objCellStyle = fg.Styles.Add("MyCellStyleGiaoVien");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.LemonChiffon;
            objCellStyle.ForeColor = Color.Blue;
            htbCellStyle.Add("MyCellStyleGiaoVien", objCellStyle);

            // Row TongHop
            objCellStyle = fg.Styles.Add("MyCellStyleTongHop");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.Silver;
            objCellStyle.ForeColor = Color.Blue;
            htbCellStyle.Add("MyCellStyleTongHop", objCellStyle);
        }

        protected void FlexColorSetup(C1FlexGrid fg)
        {
            CellStyle objCellStyle;
            // Định nghĩa các Style chuẩn
            // Style chuẩn
            objCellStyle = fg.Styles.Add("MyCellStyle");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.White;
            objCellStyle.ForeColor = Color.Black;
            objCellStyle.TextAlign = TextAlignEnum.CenterCenter;
            // Style báo bận
            objCellStyle = fg.Styles.Add("MyCellStyleBaoBan");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.SkyBlue;
            objCellStyle.ForeColor = Color.Maroon;
            objCellStyle.TextAlign = TextAlignEnum.CenterCenter;
            // Style khóa
            objCellStyle = fg.Styles.Add("MyCellStyleKhoa");
            objCellStyle.Font = new System.Drawing.Font("Arial", 8);
            objCellStyle.BackColor = Color.Gainsboro;
            objCellStyle.ForeColor = Color.DodgerBlue;
            objCellStyle.TextAlign = TextAlignEnum.CenterCenter;
            objCellStyle.ImageAlign = ImageAlignEnum.RightCenter;
        }


        protected void ShowBaoBanChiTiet(C1FlexGrid fgChiTiet, DataTable dt, int ColBegin)
        {
            fgChiTiet.DataSource = dt;
            fgChiTiet.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            // Gán cột fix
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fgChiTiet[fgChiTiet.Rows.Fixed + i, 0] = dt.Rows[i]["CaHoc"].ToString();
                fgChiTiet[fgChiTiet.Rows.Fixed + i, 1] = dt.Rows[i]["Tiet"].ToString();
            }
            // Gán row fix
            fgChiTiet[0, 0] = dt.Rows[0]["CaHoc"].ToString();
            fgChiTiet[0, 1] = dt.Rows[0]["Tiet"].ToString();

            fgChiTiet[1, 0] = dt.Rows[1]["CaHoc"].ToString();
            fgChiTiet[1, 1] = dt.Rows[1]["Tiet"].ToString();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                fgChiTiet[0, fgChiTiet.Cols.Fixed + i] = dt.Rows[0][i].ToString();
                fgChiTiet[1, fgChiTiet.Cols.Fixed + i] = dt.Rows[1][i].ToString();
            }

            fgChiTiet.Cols[0].Width = 55;
            fgChiTiet.Cols[1].Width = 25;

            fgChiTiet.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            fgChiTiet.Cols[1].TextAlign = TextAlignEnum.CenterCenter;

            fgChiTiet.Cols[0].AllowMerging = true;
            fgChiTiet.Cols[1].AllowMerging = true;
            fgChiTiet.Cols["CaHoc"].Visible = false;
            fgChiTiet.Cols["Tiet"].Visible = false;

            fgChiTiet.Rows[0].AllowMerging = true;
            fgChiTiet.Rows[1].AllowMerging = true;
            fgChiTiet.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            fgChiTiet.Rows[1].TextAlign = TextAlignEnum.CenterCenter;
            //fgChiTiet.Rows[1].Visible = false;
            fgChiTiet.Rows[2].Visible = false;
            fgChiTiet.Rows[3].Visible = false;

            SetStyles(fgChiTiet, ColBegin);
        }

        protected void SetStyles(C1FlexGrid fgChiTiet, int ColBegin)
        {
            for (int r = fgChiTiet.Rows.Fixed; r < fgChiTiet.Rows.Count; r++)
            {
                for (int c = ColBegin; c < fgChiTiet.Cols.Count; c++)
                {
                    if (fgChiTiet[r, c] + "" != "")
                    {
                        fgChiTiet.SetCellStyle(r, c, fgChiTiet.Styles["MyCellStyleBaoBan"]);
                    }
                }
            }
        }

        /// <summary>
        /// Hàm khởi tạo bảng cho chức năng báo bận chi tiết
        /// </summary>
        /// <returns></returns>
        protected DataTable CreateTableChiTiet(DateTime NgayBatDauTuan, DateTime NgayCuoiTuan)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CaHoc", typeof(string));
            dt.Columns.Add("Tiet", typeof(string));
            DateTime NgayTemp = NgayBatDauTuan;
            while (NgayTemp <= NgayCuoiTuan && NgayTemp.DayOfWeek != DayOfWeek.Sunday)
            {
                dt.Columns.Add("T" + ((int)NgayTemp.DayOfWeek).ToString(), typeof(string));
                NgayTemp = NgayTemp.AddDays(1);
            }

            Lib.clsStringHelper cls = new Lib.clsStringHelper();
            string[] TenThu = cls.TenThu();

            DataRow dr = dt.NewRow();
            dr["CaHoc"] = "Ngày";
            dr["Tiet"] = "Ngày";

            DataRow dr1 = dt.NewRow();
            dr1["CaHoc"] = "Buổi học";
            dr1["Tiet"] = "Tiết";
            while (NgayBatDauTuan <= NgayCuoiTuan && NgayBatDauTuan.DayOfWeek != DayOfWeek.Sunday)
            {
                dr["T" + ((int)NgayBatDauTuan.DayOfWeek).ToString()] = NgayBatDauTuan.ToString("dd/MM");
                dr["T" + ((int)NgayBatDauTuan.DayOfWeek).ToString()] = TenThu[((int)NgayBatDauTuan.DayOfWeek)];
                NgayBatDauTuan = NgayBatDauTuan.AddDays(1);
            }
            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);

            //dr = dt.NewRow();
            //dr["CaHoc"] = "Buổi học";
            //dr["Tiet"] = "Tiết";
            //clsStringHelper cls = new clsStringHelper();
            //string[] TenThu = cls.TenThu();
            //for (int i = Program.pgrThamSo.THU_BAT_DAU; i <= Program.pgrThamSo.THU_KET_THUC; i++)
            //{
            //    dr["T" + i.ToString()] = TenThu[i];
            //}
            //dt.Rows.Add(dr1);

            for (int i = 0; i < Program.pgrThamSo.SO_TIET_CASANG; i++)
            {
                dr = dt.NewRow();
                dr["CaHoc"] = "Sáng";
                dr["Tiet"] = (i + 1).ToString();
                dt.Rows.Add(dr);
            }
            for (int i = 0; i < Program.pgrThamSo.SO_TIET_CACHIEU; i++)
            {
                dr = dt.NewRow();
                dr["CaHoc"] = "Chiều";
                dr["Tiet"] = (i + 1).ToString();
                dt.Rows.Add(dr);
            }
            for (int i = 0; i < Program.pgrThamSo.SO_TIET_CATOI; i++)
            {
                dr = dt.NewRow();
                dr["CaHoc"] = "Tối";
                dr["Tiet"] = (i + 1).ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region XtraGrid
        public void ClearGridBandColumn(BandedGridView bgrv, GridBand grb)
        {
            for (int i = grb.Columns.Count - 1; i >= 0; i--)
                bgrv.Columns.Remove(grb.Columns[i]);

            grb.Columns.Clear();
            foreach (GridBand grbChild in grb.Children)
            {
                ClearGridBandColumn(bgrv, grbChild);
            }
        }

        public void CheckAll(GridView grv, string Field, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (grv != null)
                {
                    for (int i = 0; i < grv.DataRowCount; i++)
                    {
                        grv.GetDataRow(i)[Field] = 1;
                    }
                }
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (grv != null)
                {
                    for (int i = 0; i < grv.DataRowCount; i++)
                    {
                        grv.GetDataRow(i)[Field] = 0;
                    }
                }
            }
        }
        #endregion

        #region Load DataSource cho Combo
        protected DataTable KieuRibbon()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaKieu", typeof(string));
            dt.Columns.Add("TenKieu", typeof(string));
            dt.Columns.Add("MoTa", typeof(string));
            dt.Rows.Add(new string[] { "RPage", "RibbonPage", "" });
            dt.Rows.Add(new string[] { "RPGroup", "RibbonPageGroup", "" });
            dt.Rows.Add(new string[] { "BarItem", "BarButtonItem", "" });
            return dt;
        }

        protected DataTable LoadGioiTinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GioiTinh", typeof(int));
            dt.Columns.Add("TenGioiTinh", typeof(string));
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Nam";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "Nữ";
            dt.Rows.Add(dr);
            return dt;
        }

        protected DataTable LoadGioiTinhSV()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GioiTinh", typeof(bool));
            dt.Columns.Add("TenGioiTinh", typeof(string));
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = false;
            dr[1] = "Nam";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = true;
            dr[1] = "Nữ";
            dt.Rows.Add(dr);
            return dt;
        }

        public DataTable LoadTHinhThucNghiViec()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("HinhThucNghiViec", typeof(string));
            dt.Columns.Add("TenHinhThucNghiViec", typeof(string));

            dt.Rows.Add(new object[] { "CHUYENCONGTAC", "Chuyển công tác" });
            dt.Rows.Add(new object[] { "NGHIHUU", "Nghỉ hưu" });
            dt.Rows.Add(new object[] { "THOIVIEC", "Thôi việc" });

            return dt;
        }

        public DataTable LoadTrangThaiGiaoVien()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("TrangThai", typeof(int));
            dt.Columns.Add("TenTrangThai", typeof(string));

            dt.Rows.Add(new object[] { 1, "Đang giảng dạy" });
            dt.Rows.Add(new object[] { 2, "Chưa vào trường" });
            dt.Rows.Add(new object[] { 3, "Thôi việc" });
            dt.Rows.Add(new object[] { 4, "Nghỉ hưu" });

            return dt;
        }

        protected DataTable baseLoadLoaiGiangDay()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LoaiGiangDay", typeof(string));
            dt.Columns.Add("TenLoaiGiangDay", typeof(string));
            dt.Rows.Add(new string[] { "LY_THUYET", "Lý thuyết" });
            dt.Rows.Add(new string[] { "THUC_HANH", "Thực hành" });
            return dt;
        }

        public DataTable LoadDanToc()
        {
            cBDM_DanToc oBDanToc = new cBDM_DanToc();
            DM_DanTocInfo pDanTocInfo = new DM_DanTocInfo();
            pDanTocInfo.DM_DanTocID = 0;
            return oBDanToc.Get(pDanTocInfo);
        }

        public DataTable LoadTonGiao()
        {
            return (new cBDM_TonGiao()).Get(new DM_TonGiaoInfo());
        }

        public DataTable LoadNgoaiNgu()
        {
            cBDM_NgoaiNgu oBNgoaiNgu = new cBDM_NgoaiNgu();
            DM_NgoaiNguInfo pNgoaiNguInfo = new DM_NgoaiNguInfo();
            pNgoaiNguInfo.DM_NgoaiNguID = 0;
            return oBNgoaiNgu.Get(pNgoaiNguInfo);
        }

        public DataTable LoadQuocTich()
        {
            cBDM_QuocTich oBQuocTich = new cBDM_QuocTich();
            DM_QuocTichInfo pQuocTichInfo = new DM_QuocTichInfo();
            pQuocTichInfo.DM_QuocTichID = 0;
            return oBQuocTich.Get(pQuocTichInfo);
        }

        public DataTable LoadChucDanh()
        {
            cBDM_ChucDanh oBChucDanh = new cBDM_ChucDanh();
            DM_ChucDanhInfo pChucDanhInfo = new DM_ChucDanhInfo();
            pChucDanhInfo.DM_ChucDanhID = 0;
            return oBChucDanh.Get(pChucDanhInfo);
        }

        public DataTable LoadHocHam()
        {
            cBDM_HocHam oBHocHam = new cBDM_HocHam();
            DM_HocHamInfo pHocHamInfo = new DM_HocHamInfo();
            pHocHamInfo.DM_HocHamID = 0;
            return oBHocHam.Get(pHocHamInfo);
        }

        public DataTable LoadHocVi()
        {
            cBDM_HocVi oBHocVi = new cBDM_HocVi();
            DM_HocViInfo pHocViInfo = new DM_HocViInfo();
            pHocViInfo.DM_HocViID = 0;
            return oBHocVi.Get(pHocViInfo);
        }

        public DataTable LoadQuanHeGiaDinh()
        {
            cBDM_QuanHeGiaDinh oBQuanHeGiaDinh = new cBDM_QuanHeGiaDinh();
            DM_QuanHeGiaDinhInfo pQuanHeGiaDinhInfo = new DM_QuanHeGiaDinhInfo();
            pQuanHeGiaDinhInfo.DM_QuanHeGiaDinhID = 0;
            return oBQuanHeGiaDinh.Get(pQuanHeGiaDinhInfo);
        }


        public DataTable LoadDanhHieuDuocPhongTang()
        {
            cBDM_DanhHieuDuocPhongTang oBDanhHieuDuocPhongTang = new cBDM_DanhHieuDuocPhongTang();
            DM_DanhHieuDuocPhongTangInfo pDanhHieuDuocPhongTangInfo = new DM_DanhHieuDuocPhongTangInfo();
            pDanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID = 0;
            return oBDanhHieuDuocPhongTang.Get(pDanhHieuDuocPhongTangInfo);
        }

        public DataTable LoadTrinhDoQuanLyHanhChinhNhaNuoc()
        {
            cBDM_TrinhDoQuanLyHanhChinhNhaNuoc oBTrinhDoQuanLyHanhChinhNhaNuoc = new cBDM_TrinhDoQuanLyHanhChinhNhaNuoc();
            DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pTrinhDoQuanLyHanhChinhNhaNuocInfo = new DM_TrinhDoQuanLyHanhChinhNhaNuocInfo();
            pTrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID = 0;
            return oBTrinhDoQuanLyHanhChinhNhaNuoc.Get(pTrinhDoQuanLyHanhChinhNhaNuocInfo);
        }

        public DataTable LoadTrinhDoChuyenMon()
        {
            cBDM_TrinhDoChuyenMon oBTrinhDoChuyenMon = new cBDM_TrinhDoChuyenMon();
            DM_TrinhDoChuyenMonInfo pTrinhDoChuyenMonInfo = new DM_TrinhDoChuyenMonInfo();
            pTrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID = 0;
            return oBTrinhDoChuyenMon.Get(pTrinhDoChuyenMonInfo);
        }

        public DataTable LoadTrinhDoLyLuan()
        {
            cBDM_TrinhDoLyLuan oBTrinhDoLyLuan = new cBDM_TrinhDoLyLuan();
            DM_TrinhDoLyLuanInfo pTrinhDoLyLuanInfo = new DM_TrinhDoLyLuanInfo();
            pTrinhDoLyLuanInfo.DM_TrinhDoLyLuanID = 0;
            return oBTrinhDoLyLuan.Get(pTrinhDoLyLuanInfo);
        }

        public DataTable LoadVanBangChungChi()
        {
            cBDM_VanBangChungChi oBVanBangChungChi = new cBDM_VanBangChungChi();
            DM_VanBangChungChiInfo pVanBangChungChiInfo = new DM_VanBangChungChiInfo();
            pVanBangChungChiInfo.DM_VanBangChungChiID = 0;
            return oBVanBangChungChi.Get(pVanBangChungChiInfo);
        }

        public DataTable LoadXepLoaiChungChi()
        {
            cBDM_XepLoaiChungChi oBXepLoaiChungChi = new cBDM_XepLoaiChungChi();
            DM_XepLoaiChungChiInfo pXepLoaiChungChiInfo = new DM_XepLoaiChungChiInfo();
            pXepLoaiChungChiInfo.DM_XepLoaiChungChiID = 0;
            return oBXepLoaiChungChi.Get(pXepLoaiChungChiInfo);
        }

        public DataTable LoadHinhThucDaoTao()
        {
            cBDM_HinhThucDaoTao oBHinhThucDaoTao = new cBDM_HinhThucDaoTao();
            DM_HinhThucDaoTaoInfo pHinhThucDaoTaoInfo = new DM_HinhThucDaoTaoInfo();
            pHinhThucDaoTaoInfo.DM_HinhThucDaoTaoID = 0;
            return oBHinhThucDaoTao.Get(pHinhThucDaoTaoInfo);
        }

        public DataTable LoadQuanHam()
        {
            cBDM_QuanHam oBQuanHam = new cBDM_QuanHam();
            DM_QuanHamInfo pQuanHamInfo = new DM_QuanHamInfo();
            pQuanHamInfo.DM_QuanHamID = 0;
            return oBQuanHam.Get(pQuanHamInfo);
        }

        public DataTable LoadNhomNgach()
        {
            cBNS_NhomNgach oBNhomNgach = new cBNS_NhomNgach();
            NS_NhomNgachInfo pNhomNgachInfo = new NS_NhomNgachInfo();
            pNhomNgachInfo.NS_NhomNgachID = 0;
            return oBNhomNgach.Get(pNhomNgachInfo);
        }

        public DataTable LoadLoaiPhuCap()
        {
            cBNS_LoaiPhuCap oBLoaiPhuCap = new cBNS_LoaiPhuCap();
            NS_LoaiPhuCapInfo pLoaiPhuCapInfo = new NS_LoaiPhuCapInfo();
            pLoaiPhuCapInfo.NS_LoaiPhuCapID = 0;
            return oBLoaiPhuCap.Get(pLoaiPhuCapInfo);
        }

        public DataTable LoadNgachCongChuc()
        {
            cBNS_NgachCongChuc oBNgachCongChuc = new cBNS_NgachCongChuc();
            NS_NgachCongChucInfo pNgachCongChucInfo = new NS_NgachCongChucInfo();
            pNgachCongChucInfo.NS_NgachCongChucID = 0;
            return oBNgachCongChuc.Get(pNgachCongChucInfo);
        }


        protected DataTable LoadTuan()
        {
            cBXL_Tuan oBTuan = new cBXL_Tuan();
            XL_TuanInfo pTuanInfo = new XL_TuanInfo();
            pTuanInfo.IDDM_NamHoc = Program.IDNamHoc;
            return oBTuan.GetByIDNamHoc(pTuanInfo);
        }

        protected DataTable LoadKhoa()
        {
            cBDM_Khoa oBKhoa = new cBDM_Khoa();
            DM_KhoaInfo pKhoaInfo = new DM_KhoaInfo();
            pKhoaInfo.DM_KhoaID = 0;
            return oBKhoa.Get(pKhoaInfo);
        }

        protected DataTable LoadNamHoc()
        {
            cBDM_NamHoc oBNamHoc = new cBDM_NamHoc();
            DM_NamHocInfo pNamHocInfo = new DM_NamHocInfo();
            pNamHocInfo.DM_NamHocID = 0;
            return oBNamHoc.Get(pNamHocInfo);
        }

        // KQHT_QuyChe
        protected DataTable LoadQuyChe()
        {
            cBKQHT_QuyChe oBKHQT_QuyChe = new cBKQHT_QuyChe();
            KQHT_QuyCheInfo pKQHT_QuyCheInfo = new KQHT_QuyCheInfo();
            pKQHT_QuyCheInfo.KQHT_QuyCheID = 0;
            return oBKHQT_QuyChe.Get(pKQHT_QuyCheInfo);
        }

        protected DataTable LoadLoaiPhong()
        {
            cBDM_LoaiPhong oBDM_LoaiPhong = new cBDM_LoaiPhong();
            DM_LoaiPhongInfo pLoaiPhongInfo = new DM_LoaiPhongInfo();
            pLoaiPhongInfo.DM_LoaiPhongID = 0;
            return oBDM_LoaiPhong.Get(pLoaiPhongInfo);
        }

        protected DataTable LoadTang()
        {
            cBDM_Tang oBDM_Tang = new cBDM_Tang();
            DM_TangInfo pDM_TangInfo = new DM_TangInfo();
            pDM_TangInfo.DM_TangID = 0;
            return oBDM_Tang.Get(pDM_TangInfo);
        }

        protected DataTable LoadHe()
        {
            cBDM_He oBDM_He = new cBDM_He();
            DM_HeInfo pDM_HeInfo = new DM_HeInfo();
            pDM_HeInfo.DM_HeID = 0;
            return oBDM_He.Get(pDM_HeInfo);
        }

        protected DataTable LoadTrinhDoByIDHe(int IDDM_He)
        {
            cBDM_TrinhDo oBDM_TrinhDo = new cBDM_TrinhDo();
            return oBDM_TrinhDo.GetByIDHe(IDDM_He);
        }

        protected DataTable LoadTrinhDo()
        {
            cBDM_TrinhDo oBDM_TrinhDo = new cBDM_TrinhDo();
            DM_TrinhDoInfo pDM_TrinhDoInfo = new DM_TrinhDoInfo();
            pDM_TrinhDoInfo.DM_TrinhDoID = 0;
            return oBDM_TrinhDo.Get(pDM_TrinhDoInfo);
        }

        protected DataTable LoadNganhByIDKhoa(int IDDM_Khoa)
        {
            cBDM_Nganh oBDM_Nganh = new cBDM_Nganh();
            return oBDM_Nganh.GetByIDKhoa(IDDM_Khoa);
        }

        protected DataTable LoadNganh()
        {
            cBDM_Nganh oBDM_Nganh = new cBDM_Nganh();
            DM_NganhInfo pDM_NganhInfo = new DM_NganhInfo();
            pDM_NganhInfo.DM_NganhID = 0;
            return oBDM_Nganh.Get(pDM_NganhInfo);
        }

        protected DataTable LoadChuyenNganh(int IDDM_Nganh)
        {
            cBDM_ChuyenNganh oBDM_ChuyenNganh = new cBDM_ChuyenNganh();
            return oBDM_ChuyenNganh.GetByIDNganh(IDDM_Nganh);
        }

        protected DataTable LoadKhoaHoc()
        {
            cBDM_KhoaHoc oBDM_KhoaHoc = new cBDM_KhoaHoc();
            return oBDM_KhoaHoc.GetAll();
        }

        protected DataTable bLoadDiaDiem()
        {
            return (new cBDM_DiaDiem()).Get(new DM_DiaDiemInfo());
        }

        protected DataTable LoadTruongLienKet()
        {
            cBDM_TruongLienKet oBDM_TruongLienKet = new cBDM_TruongLienKet();
            DM_TruongLienKetInfo pDM_TruongLienKetInfo = new DM_TruongLienKetInfo();
            pDM_TruongLienKetInfo.DM_TruongLienKetID = 0;
            return oBDM_TruongLienKet.Get(pDM_TruongLienKetInfo);
        }

        protected DataTable LoadCongThucDiemToanKhoa()
        {
            cBKQHT_CongThucDiemToanKhoa oBKQHT_CongThucDiemToanKhoa = new cBKQHT_CongThucDiemToanKhoa();
            KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo = new KQHT_CongThucDiemToanKhoaInfo();
            pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID = 0;
            return oBKQHT_CongThucDiemToanKhoa.Get(pKQHT_CongThucDiemToanKhoaInfo);
        }

        protected DataTable LoadBoMon()
        {
            cBDM_BoMon oBDM_BoMon = new cBDM_BoMon();
            DM_BoMonInfo pDM_BoMonInfo = new DM_BoMonInfo();
            pDM_BoMonInfo.DM_BoMonID = 0;
            return oBDM_BoMon.Get(pDM_BoMonInfo);
        }

        protected DataTable LoadBoMonTheoKhoa(int IDDM_Khoa)
        {
            cBDM_BoMon oBDM_BoMon = new cBDM_BoMon();
            return oBDM_BoMon.GetByIDKhoa(IDDM_Khoa);
        }

        protected DataTable LoadKhoiKienThuc()
        {
            cBDM_KhoiKienThuc oBDM = new cBDM_KhoiKienThuc();
            DM_KhoiKienThucInfo pDM = new DM_KhoiKienThucInfo();
            pDM.DM_KhoiKienThucID = 0;
            return oBDM.Get(pDM);
        }

        protected DataTable LoadHinhThucThi()
        {
            cBDM_HinhThucThi oBDM = new cBDM_HinhThucThi();
            DM_HinhThucThiInfo pDM = new DM_HinhThucThiInfo();
            pDM.DM_HinhThucThiID = 0;
            return oBDM.Get(pDM);
        }

        // Đơn vị
        public DataTable LoadDonVi()
        {
            cBNS_DonVi oBDonVi = new cBNS_DonVi();
            NS_DonViInfo pDonViInfo = new NS_DonViInfo();
            pDonViInfo.NS_DonViID = 0;
            return oBDonVi.Get_Tree();
        }

        public DataTable LoadLoaiLuanChuyen()
        {
            cBNS_LoaiLuanChuyen oBLoaiLuanChuyen = new cBNS_LoaiLuanChuyen();
            NS_LoaiLuanChuyenInfo pLoaiLuanChuyenInfo = new NS_LoaiLuanChuyenInfo();
            pLoaiLuanChuyenInfo.NS_LoaiLuanChuyenID = 0;
            return oBLoaiLuanChuyen.Get(pLoaiLuanChuyenInfo);
        }

        public DataTable LoadChucVu()
        {
            cBDM_ChucVu oBDM_ChucVu = new cBDM_ChucVu();
            DM_ChucVuInfo pDM_ChucVuInfo = new DM_ChucVuInfo();
            pDM_ChucVuInfo.DM_ChucVuID = 0;
            return oBDM_ChucVu.Get(pDM_ChucVuInfo);
        }

        // Lớp theo khoa
        public DataTable LoadLopTheoKhoa(int IDDM_Khoa)
        {
            cBDM_Lop oBDM_Lop = new cBDM_Lop();
            return oBDM_Lop.GetByKhoa(IDDM_Khoa, Program.NamHoc);
        }

        // Môn học trong kỳ
        public DataTable MonHocTrongKy(int IDDM_Lop)
        {
            cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            return oBXL_MonHocTrongKy.GetByHocKyNamHoc(IDDM_Lop, Program.HocKy, Program.IDNamHoc, 0, 0);

        }
        // Môn học trong kỳ - GET ALL
        public DataTable MonHocTrongKyGetAll(int IDDM_Lop)
        {
            cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            return oBXL_MonHocTrongKy.GetAllByHocKyNamHoc(IDDM_Lop, Program.HocKy, Program.IDNamHoc);
        }

        // Môn học trong kỳ - GET BY LOP GOP
        public DataTable MonHocTrongKyGetByLopGop(string IDDM_Lops, int SoLop)
        {
            cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            return oBXL_MonHocTrongKy.GetByLopGop(IDDM_Lops, Program.HocKy, Program.IDNamHoc, SoLop);
        }

        // Phòng học
        public DataTable LoadPhongHoc()
        {
            cBDM_PhongHoc oBDM_PhongHoc = new cBDM_PhongHoc();
            DM_PhongHocInfo pDM_PhongHocInfo = new DM_PhongHocInfo();
            pDM_PhongHocInfo.DM_PhongHocID = 0;
            return oBDM_PhongHoc.Get(pDM_PhongHocInfo);
        }

        // Nhóm người dùng
        public DataTable LoadNhomNguoiDung()
        {
            cBHT_UserGroup oBHT_UserGroup = new cBHT_UserGroup();
            HT_UserGroupInfo pHT_UserGroupInfo = new HT_UserGroupInfo();
            pHT_UserGroupInfo.HT_UserGroupID = 0;
            return oBHT_UserGroup.Get(pHT_UserGroupInfo);
        }

        // Danh sách môn học
        public DataTable LoadMonHoc()
        {
            cBDM_MonHoc oBDM_MonHoc = new cBDM_MonHoc();
            DM_MonHocInfo pDM_MonHocInfo = new DM_MonHocInfo();
            return oBDM_MonHoc.Get(pDM_MonHocInfo);
        }

        // Danh sách giảng viên
        public DataTable LoadGiaoVien()
        {
            cBNS_GiaoVien oBNS_GiaoVien = new cBNS_GiaoVien();
            NS_GiaoVienInfo pNS_GiaoVienInfo = new NS_GiaoVienInfo();
            DataTable dtGV = oBNS_GiaoVien.Get(pNS_GiaoVienInfo);
            dtGV.DefaultView.Sort = "Ten, HoTen";
            return dtGV;
        }

        // Thành phần điểm
        public DataTable LoadThanhPhanDiem()
        {
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            return oBKQHT_ThanhPhanDiem.Get(pKQHT_ThanhPhanDiemInfo);
        }
        // Thành phần điểm
        public DataTable LoadLoaiThuChi()
        {
            cBTC_LoaiThuChi oBTC_LoaiThuChi = new cBTC_LoaiThuChi();
            TC_LoaiThuChiInfo pTC_LoaiThuChiInfo = new TC_LoaiThuChiInfo();
            return oBTC_LoaiThuChi.Get(pTC_LoaiThuChiInfo);
        }

        public DataTable LoadLoaiThuChi(int IDNamHoc, int HocKy)
        {
            cBTC_LoaiThuChi oBTC_LoaiThuChi = new cBTC_LoaiThuChi();
            return oBTC_LoaiThuChi.GetBy_IDNamHoc_HocKy(IDNamHoc, HocKy, false);
        }

        public DataTable LoadLoaiThuChiTongHop()
        {
            cBTC_LoaiThuChi oBTC_LoaiThuChi = new cBTC_LoaiThuChi();
            return oBTC_LoaiThuChi.GetTongHop();
        }
        // Cấp khen thưởng
        public DataTable LoadCapKhenThuong()
        {
            return new cBDM_CapKhenThuong().Get(new DM_CapKhenThuongInfo());
        }

        // Loại khen thưởng
        public DataTable LoadLoaiKhenThuong()
        {
            return new cBDM_LoaiKhenThuong().Get(new DM_LoaiKhenThuongInfo());
        }

        // Hành vi kỷ luật
        public DataTable LoadHanhVi()
        {
            return new cBDM_HanhVi().Get(new DM_HanhViInfo());
        }

        // Loại học lực
        protected DataTable LoadXLHocLuc()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("XLHocLuc", typeof(string));
            dt.Columns.Add("TenXLHocLuc", typeof(string));
            dt.Rows.Add(new string[] { "G", "Giỏi" });
            dt.Rows.Add(new string[] { "K", "Khá" });
            dt.Rows.Add(new string[] { "TB", "Trung bình" });
            dt.Rows.Add(new string[] { "Y", "Yếu" });
            dt.Rows.Add(new string[] { "Kem", "Kém" });
            return dt;
        }

        // Loại học lực
        protected DataTable LoadXLHanhKiem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("XLHanhKiem", typeof(string));
            dt.Columns.Add("TenXLHanhKiem", typeof(string));
            dt.Rows.Add(new string[] { "T", "Tốt" });
            dt.Rows.Add(new string[] { "K", "Khá" });
            dt.Rows.Add(new string[] { "TB", "Trung bình" });
            dt.Rows.Add(new string[] { "Y", "Yếu" });
            return dt;
        }

        // Xếp loại rèn luyện
        public DataTable LoadXepLoaiRenLuyen()
        {
            return new cBDM_XepLoaiRenLuyen().Get(new DM_XepLoaiRenLuyenInfo());
        }

        public DataTable bLoadTrinhDoNgoaiNgu_TinHoc()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ma", typeof(string));
            dt.Columns.Add("Ten", typeof(string));

            dt.Rows.Add(new string[] { "CN", "Cử nhân" });
            dt.Rows.Add(new string[] { "SC", "Sơ cấp" });

            return dt;
        }

        public DataTable bLoadHinhThucHDLD()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("STT", typeof(string));

            dt.Rows.Add(new string[] { "BCSN", "Biên chế sự nghiệp", "I" });
            dt.Rows.Add(new string[] { "TLKP", "Tự lo kinh phí", "II" });

            return dt;
        }

        public DataTable bLoadSapXep()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(new string[] { "Ten, HoVa", "Họ tên" });
            dt.Rows.Add(new string[] { "MaSinhVien", "Mã sinh viên" });
            dt.Rows.Add(new string[] { "TenLop, Ten, HoVa", "Lớp, họ tên" });
            dt.Rows.Add(new string[] { "TenLop, MaSinhVien", "Lớp, mã sinh viên" });
            dt.Rows.Add(new string[] { "", "Mặc định" });

            return dt;
        }
        #endregion

        #region THÔNG BÁO
        protected void ThemThanhCong()
        {
            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void SuaThanhCong()
        {
            XtraMessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void XoaThanhCong()
        {
            XtraMessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void LuuThanhCong()
        {
            XtraMessageBox.Show("Lưu thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void ThongBao(string message)
        {
            XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void ThongBaoLoi(string message)
        {
            XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void CanhBao(string message)
        {
            XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected void XoaThatBai()
        {
            XtraMessageBox.Show("Dữ liệu đang dùng không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected DialogResult ThongBaoChon(string message)
        {
            return XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #endregion

        #region Xử lý phân quyền thêm, sửa xóa
        public void EnableButton(DevExpress.XtraBars.BarButtonItem barbtnThem, DevExpress.XtraBars.BarButtonItem barbtnSua, DevExpress.XtraBars.BarButtonItem barbtnXoa)
        {

        }
        #endregion

        #region Hàm xử lý trên tree
        public void CheckAllTree(DataTable dt, string Field, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][Field] = 1;
                    }
                }
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][Field] = 0;
                    }
                }
            }
        }

        public void SetCheckedChildNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        public void SetCheckedParentNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
        #endregion

        #region Hàm xử lý cho UserControl địa chỉ
        public void LoadDiaChi(ucDiaChi uc)
        {
            uc.cmbTinh.Properties.DataSource = (new cBDM_TinhHuyenXa()).GetByCap(1, 0);
            uc.cmbTinh.EditValueChanged += new EventHandler(cmbTinh_EditValueChanged);
            uc.cmbHuyen.EditValueChanged += new EventHandler(cmbHuyen_EditValueChanged);
        }

        void cmbTinh_EditValueChanged(object sender, EventArgs e)
        {
            ucDiaChi uc = (ucDiaChi)(sender as LookUpEdit).Parent.Parent;
            if (uc.cmbTinh.EditValue != null)
                uc.cmbHuyen.Properties.DataSource = (new cBDM_TinhHuyenXa()).GetByCap(2, int.Parse(uc.cmbTinh.EditValue.ToString()));
        }

        void cmbHuyen_EditValueChanged(object sender, EventArgs e)
        {
            ucDiaChi uc = (ucDiaChi)(sender as LookUpEdit).Parent.Parent;
            if (uc.cmbHuyen.EditValue != null)
                uc.cmbXa.Properties.DataSource = (new cBDM_TinhHuyenXa()).GetByCap(3, int.Parse(uc.cmbHuyen.EditValue.ToString()));
        }

        public void SetValueDiaChi(ucDiaChi uc, int IDDM_TinhHuyenXa)
        {
            cBDM_TinhHuyenXa cBDM = new cBDM_TinhHuyenXa();
            DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo = new DM_TinhHuyenXaInfo();
            pDM_TinhHuyenXaInfo.DM_TinhHuyenXaID = IDDM_TinhHuyenXa;
            DataTable dtDiaChi = cBDM.Get(pDM_TinhHuyenXaInfo);

            if (dtDiaChi.Rows.Count > 0)
            {
                DataRow dr = dtDiaChi.Rows[0];
                if (int.Parse(dr["Level"].ToString()) == 1)
                    uc.cmbTinh.EditValue = dr["DM_TinhHuyenXaID"];
                else if (int.Parse(dr["Level"].ToString()) == 2)
                {
                    uc.cmbTinh.EditValue = dr["ParentID"];
                    uc.cmbHuyen.EditValue = dr["DM_TinhHuyenXaID"];
                }
                else if (int.Parse(dr["Level"].ToString()) == 3)
                {
                    DataTable dt = cBDM.GetTinh(int.Parse(dr["ParentID"].ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        uc.cmbTinh.EditValue = dt.Rows[0]["DM_TinhHuyenXaID"];
                        uc.cmbHuyen.EditValue = dr["ParentID"];
                        uc.cmbXa.EditValue = dr["DM_TinhHuyenXaID"];
                    }
                }
            }
        }
        #endregion

        #region Hàm xử lý cho UserControl TreeLop
        public void LoadTreeLop(ucTreeLop uc)
        {
            uc.trlLop.DataSource = (new cBDM_Lop()).GetTreeTheoKhoa(Program.NamHoc);
        }
        #endregion
    }

    #region Vẽ các control trên flexgrid
    ///// <summary>
    ///// HostedControl
    ///// Vẽ các control trên flexgrid
    ///// </summary>
    //internal class HostedControl
    //{
    //    internal C1FlexGrid _flex;
    //    internal Control _ctl;
    //    internal Row _row;
    //    internal Column _col;

    //    internal HostedControl(C1FlexGrid flex, Control hosted, int row, int col)
    //    {
    //        // save info
    //        _flex = flex;
    //        _ctl = hosted;
    //        _row = flex.Rows[row];
    //        _col = flex.Cols[col];

    //        // insert hosted control into grid
    //        _flex.Controls.Add(_ctl);
    //    }
    //    internal bool UpdatePosition()
    //    {
    //        // get row/col indices
    //        int r = _row.Index;
    //        int c = _col.Index;
    //        if (r < 0 || c < 0) return false;

    //        // get cell rect
    //        Rectangle rc = _flex.GetCellRect(r, c, false);

    //        // hide control if out of range
    //        if (rc.Width <= 0 || rc.Height <= 0 || !rc.IntersectsWith(_flex.ClientRectangle))
    //        {
    //            _ctl.Visible = false;
    //            return true;
    //        }

    //        // move the control and show it
    //        _ctl.Bounds = rc;
    //        _ctl.Visible = true;

    //        // done
    //        return true;
    //    }
    //}
    #endregion
}
