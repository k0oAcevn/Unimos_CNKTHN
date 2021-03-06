namespace UnimOs.UI
{
    partial class frmGiayToNhapTruong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiayToNhapTruong));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barbtnThem = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSua = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.txtTenGiayTo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdGiayTo = new DevExpress.XtraGrid.GridControl();
            this.grvGiayTo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenGiayTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiayTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGiayTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnThem,
            this.barbtnSua,
            this.barbtnXoa});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSua, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnXoa, true)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barbtnThem
            // 
            this.barbtnThem.Caption = "Thêm giấy tờ";
            this.barbtnThem.Id = 0;
            this.barbtnThem.Name = "barbtnThem";
            this.barbtnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThem_ItemClick);
            // 
            // barbtnSua
            // 
            this.barbtnSua.Caption = "Sửa giấy tờ";
            this.barbtnSua.Id = 1;
            this.barbtnSua.Name = "barbtnSua";
            this.barbtnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSua_ItemClick);
            // 
            // barbtnXoa
            // 
            this.barbtnXoa.Caption = "Xóa giấy tờ";
            this.barbtnXoa.Id = 2;
            this.barbtnXoa.Name = "barbtnXoa";
            this.barbtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXoa_ItemClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.layoutControl1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 24);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(511, 82);
            this.panelTop.TabIndex = 4;
            this.panelTop.Visible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.btnCapNhat);
            this.layoutControl1.Controls.Add(this.btnHuy);
            this.layoutControl1.Controls.Add(this.txtTenGiayTo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(505, 76);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(305, 39);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(101, 24);
            this.btnCapNhat.StyleController = this.layoutControl1;
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(417, 39);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(81, 24);
            this.btnHuy.StyleController = this.layoutControl1;
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtTenGiayTo
            // 
            this.txtTenGiayTo.Location = new System.Drawing.Point(71, 8);
            this.txtTenGiayTo.Name = "txtTenGiayTo";
            this.txtTenGiayTo.Size = new System.Drawing.Size(427, 20);
            this.txtTenGiayTo.StyleController = this.layoutControl1;
            this.txtTenGiayTo.TabIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(505, 76);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 31);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(297, 41);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTenGiayTo;
            this.layoutControlItem2.CustomizationFormText = "Tên Tôn giáo:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(501, 31);
            this.layoutControlItem2.Text = "Tên giấy tờ:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(58, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnHuy;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(409, 31);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(92, 41);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnCapNhat;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(297, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(112, 41);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // grdGiayTo
            // 
            this.grdGiayTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGiayTo.Location = new System.Drawing.Point(0, 106);
            this.grdGiayTo.MainView = this.grvGiayTo;
            this.grdGiayTo.Name = "grdGiayTo";
            this.grdGiayTo.Size = new System.Drawing.Size(511, 339);
            this.grdGiayTo.TabIndex = 5;
            this.grdGiayTo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGiayTo,
            this.gridView2});
            // 
            // grvGiayTo
            // 
            this.grvGiayTo.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvGiayTo.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvGiayTo.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(190)))), ((int)(((byte)(243)))));
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.Empty.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvGiayTo.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvGiayTo.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.grvGiayTo.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.grvGiayTo.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.grvGiayTo.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvGiayTo.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvGiayTo.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvGiayTo.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvGiayTo.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.GroupButton.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvGiayTo.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvGiayTo.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.grvGiayTo.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvGiayTo.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvGiayTo.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grvGiayTo.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.GroupRow.Options.UseFont = true;
            this.grvGiayTo.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvGiayTo.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvGiayTo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvGiayTo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGiayTo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.grvGiayTo.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.grvGiayTo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.grvGiayTo.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.OddRow.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.OddRow.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.grvGiayTo.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.grvGiayTo.Appearance.Preview.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.Preview.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvGiayTo.Appearance.Row.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.Row.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.grvGiayTo.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvGiayTo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvGiayTo.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvGiayTo.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.grvGiayTo.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGiayTo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.grvGiayTo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvGiayTo.GridControl = this.grdGiayTo;
            this.grvGiayTo.IndicatorWidth = 28;
            this.grvGiayTo.Name = "grvGiayTo";
            this.grvGiayTo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvGiayTo.OptionsView.EnableAppearanceEvenRow = true;
            this.grvGiayTo.OptionsView.EnableAppearanceOddRow = true;
            this.grvGiayTo.OptionsView.ShowGroupPanel = false;
            this.grvGiayTo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvTonGiao_FocusedRowChanged);
            this.grvGiayTo.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvGiayTo_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Tên giấy tờ";
            this.gridColumn1.FieldName = "TenGiayTo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdGiayTo;
            this.gridView2.Name = "gridView2";
            // 
            // DxErrorProvider
            // 
            this.DxErrorProvider.ContainerControl = this;
            // 
            // frmGiayToNhapTruong
            // 
            this.AcceptButton = this.btnCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 445);
            this.Controls.Add(this.grdGiayTo);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGiayToNhapTruong";
            this.Tag = "frmGiayToNhapTruong";
            this.Text = "GIAY TO NHAP TRUONG";
            this.Load += new System.EventHandler(this.frmTonGiao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenGiayTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiayTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGiayTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barbtnThem;
        private DevExpress.XtraBars.BarButtonItem barbtnSua;
        private DevExpress.XtraBars.BarButtonItem barbtnXoa;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl grdGiayTo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGiayTo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.TextEdit txtTenGiayTo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider DxErrorProvider;
    }
}