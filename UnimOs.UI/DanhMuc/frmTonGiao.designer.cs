namespace UnimOs.UI
{
    partial class frmTonGiao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTonGiao));
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
            this.txtTenTonGiao = new DevExpress.XtraEditors.TextEdit();
            this.txtMaTonGiao = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdTonGiao = new DevExpress.XtraGrid.GridControl();
            this.grvTonGiao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTonGiao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTonGiao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTonGiao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTonGiao)).BeginInit();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnXoa)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barbtnThem
            // 
            this.barbtnThem.Caption = "Thêm Tôn giáo";
            this.barbtnThem.Id = 0;
            this.barbtnThem.Name = "barbtnThem";
            this.barbtnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThem_ItemClick);
            // 
            // barbtnSua
            // 
            this.barbtnSua.Caption = "Sửa Tôn giáo";
            this.barbtnSua.Id = 1;
            this.barbtnSua.Name = "barbtnSua";
            this.barbtnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSua_ItemClick);
            // 
            // barbtnXoa
            // 
            this.barbtnXoa.Caption = "Xóa Tôn giáo";
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
            this.panelTop.Size = new System.Drawing.Size(405, 82);
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
            this.layoutControl1.Controls.Add(this.txtTenTonGiao);
            this.layoutControl1.Controls.Add(this.txtMaTonGiao);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(401, 78);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(243, 38);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(78, 24);
            this.btnCapNhat.StyleController = this.layoutControl1;
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(332, 38);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(63, 24);
            this.btnHuy.StyleController = this.layoutControl1;
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtTenTonGiao
            // 
            this.txtTenTonGiao.Location = new System.Drawing.Point(264, 7);
            this.txtTenTonGiao.Name = "txtTenTonGiao";
            this.txtTenTonGiao.Size = new System.Drawing.Size(131, 20);
            this.txtTenTonGiao.StyleController = this.layoutControl1;
            this.txtTenTonGiao.TabIndex = 1;
            // 
            // txtMaTonGiao
            // 
            this.txtMaTonGiao.Location = new System.Drawing.Point(78, 7);
            this.txtMaTonGiao.Name = "txtMaTonGiao";
            this.txtMaTonGiao.Size = new System.Drawing.Size(104, 20);
            this.txtMaTonGiao.StyleController = this.layoutControl1;
            this.txtMaTonGiao.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(401, 78);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMaTonGiao;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(186, 31);
            this.layoutControlItem1.Text = "Mã Tôn giáo:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 20);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 31);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(236, 45);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTenTonGiao;
            this.layoutControlItem2.CustomizationFormText = "Tên Tôn giáo:";
            this.layoutControlItem2.Location = new System.Drawing.Point(186, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(213, 31);
            this.layoutControlItem2.Text = "Tên Tôn giáo:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnHuy;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(325, 31);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(74, 45);
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
            this.layoutControlItem4.Location = new System.Drawing.Point(236, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(89, 45);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // grdTonGiao
            // 
            this.grdTonGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTonGiao.Location = new System.Drawing.Point(0, 106);
            this.grdTonGiao.MainView = this.grvTonGiao;
            this.grdTonGiao.Name = "grdTonGiao";
            this.grdTonGiao.Size = new System.Drawing.Size(405, 331);
            this.grdTonGiao.TabIndex = 5;
            this.grdTonGiao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTonGiao,
            this.gridView2});
            // 
            // grvTonGiao
            // 
            this.grvTonGiao.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvTonGiao.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvTonGiao.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(190)))), ((int)(((byte)(243)))));
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.Empty.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvTonGiao.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvTonGiao.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.grvTonGiao.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.grvTonGiao.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.grvTonGiao.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvTonGiao.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvTonGiao.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvTonGiao.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvTonGiao.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.GroupButton.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvTonGiao.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvTonGiao.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.grvTonGiao.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvTonGiao.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.grvTonGiao.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grvTonGiao.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.GroupRow.Options.UseFont = true;
            this.grvTonGiao.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.grvTonGiao.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.grvTonGiao.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvTonGiao.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvTonGiao.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.grvTonGiao.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.grvTonGiao.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.grvTonGiao.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.OddRow.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.OddRow.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.grvTonGiao.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.grvTonGiao.Appearance.Preview.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.Preview.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvTonGiao.Appearance.Row.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.Row.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.grvTonGiao.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvTonGiao.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvTonGiao.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvTonGiao.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.grvTonGiao.Appearance.VertLine.Options.UseBackColor = true;
            this.grvTonGiao.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grvTonGiao.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvTonGiao.GridControl = this.grdTonGiao;
            this.grvTonGiao.Name = "grvTonGiao";
            this.grvTonGiao.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvTonGiao.OptionsView.EnableAppearanceEvenRow = true;
            this.grvTonGiao.OptionsView.EnableAppearanceOddRow = true;
            this.grvTonGiao.OptionsView.ShowGroupPanel = false;
            this.grvTonGiao.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvTonGiao_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã Tôn giáo";
            this.gridColumn1.FieldName = "MaTonGiao";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Tôn giáo";
            this.gridColumn2.FieldName = "TenTonGiao";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdTonGiao;
            this.gridView2.Name = "gridView2";
            // 
            // DxErrorProvider
            // 
            this.DxErrorProvider.ContainerControl = this;
            // 
            // frmTonGiao
            // 
            this.AcceptButton = this.btnCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 437);
            this.Controls.Add(this.grdTonGiao);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTonGiao";
            this.Text = "TON GIAO";
            this.Load += new System.EventHandler(this.frmTonGiao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTonGiao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTonGiao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTonGiao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTonGiao)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grdTonGiao;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTonGiao;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.TextEdit txtTenTonGiao;
        private DevExpress.XtraEditors.TextEdit txtMaTonGiao;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider DxErrorProvider;
    }
}