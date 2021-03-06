namespace UnimOs.UI
{
    partial class frmTinhHuyenXa
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barbtnThemTinh = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnThemHuyen = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnThemXa = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSuaTinh = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSuaHuyen = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSuaXa = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.DxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.treeTinhHuyenXa = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkExpandAll = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeTinhHuyenXa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpandAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnThemTinh,
            this.barbtnThemHuyen,
            this.barbtnThemXa,
            this.barbtnSuaTinh,
            this.barbtnSuaHuyen,
            this.barbtnSuaXa,
            this.barbtnXoa});
            this.barManager1.MaxItemId = 21;
            // 
            // barbtnThemTinh
            // 
            this.barbtnThemTinh.Caption = "Thêm tỉnh";
            this.barbtnThemTinh.Id = 9;
            this.barbtnThemTinh.Name = "barbtnThemTinh";
            this.barbtnThemTinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThemTinh_ItemClick);
            // 
            // barbtnThemHuyen
            // 
            this.barbtnThemHuyen.Caption = "Thêm huyện";
            this.barbtnThemHuyen.Id = 10;
            this.barbtnThemHuyen.Name = "barbtnThemHuyen";
            this.barbtnThemHuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThemHuyen_ItemClick);
            // 
            // barbtnThemXa
            // 
            this.barbtnThemXa.Caption = "Thêm xã";
            this.barbtnThemXa.Id = 11;
            this.barbtnThemXa.Name = "barbtnThemXa";
            this.barbtnThemXa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThemXa_ItemClick);
            // 
            // barbtnSuaTinh
            // 
            this.barbtnSuaTinh.Caption = "Sửa tỉnh";
            this.barbtnSuaTinh.Id = 16;
            this.barbtnSuaTinh.Name = "barbtnSuaTinh";
            this.barbtnSuaTinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSuaTinh_ItemClick);
            // 
            // barbtnSuaHuyen
            // 
            this.barbtnSuaHuyen.Caption = "Sửa huyện";
            this.barbtnSuaHuyen.Id = 18;
            this.barbtnSuaHuyen.Name = "barbtnSuaHuyen";
            this.barbtnSuaHuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSuaHuyen_ItemClick);
            // 
            // barbtnSuaXa
            // 
            this.barbtnSuaXa.Caption = "Sửa xã";
            this.barbtnSuaXa.Id = 19;
            this.barbtnSuaXa.Name = "barbtnSuaXa";
            this.barbtnSuaXa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSuaXa_ItemClick);
            // 
            // barbtnXoa
            // 
            this.barbtnXoa.Caption = "Xóa";
            this.barbtnXoa.Id = 20;
            this.barbtnXoa.Name = "barbtnXoa";
            this.barbtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXoa_ItemClick);
            // 
            // DxErrorProvider
            // 
            this.DxErrorProvider.ContainerControl = this;
            // 
            // treeTinhHuyenXa
            // 
            this.treeTinhHuyenXa.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.treeTinhHuyenXa.Appearance.Empty.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.treeTinhHuyenXa.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.treeTinhHuyenXa.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.treeTinhHuyenXa.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treeTinhHuyenXa.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.treeTinhHuyenXa.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.treeTinhHuyenXa.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.treeTinhHuyenXa.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.treeTinhHuyenXa.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeTinhHuyenXa.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.treeTinhHuyenXa.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.treeTinhHuyenXa.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeTinhHuyenXa.Appearance.GroupButton.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.treeTinhHuyenXa.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.treeTinhHuyenXa.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeTinhHuyenXa.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.treeTinhHuyenXa.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.treeTinhHuyenXa.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.treeTinhHuyenXa.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.treeTinhHuyenXa.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeTinhHuyenXa.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.treeTinhHuyenXa.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.treeTinhHuyenXa.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.treeTinhHuyenXa.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.treeTinhHuyenXa.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.OddRow.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.OddRow.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.treeTinhHuyenXa.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.treeTinhHuyenXa.Appearance.Preview.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.Preview.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.treeTinhHuyenXa.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treeTinhHuyenXa.Appearance.Row.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.Row.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.treeTinhHuyenXa.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treeTinhHuyenXa.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeTinhHuyenXa.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.treeTinhHuyenXa.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.treeTinhHuyenXa.Appearance.VertLine.Options.UseBackColor = true;
            this.treeTinhHuyenXa.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeTinhHuyenXa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTinhHuyenXa.Location = new System.Drawing.Point(0, 29);
            this.treeTinhHuyenXa.Name = "treeTinhHuyenXa";
            this.treeTinhHuyenXa.OptionsBehavior.Editable = false;
            this.treeTinhHuyenXa.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeTinhHuyenXa.OptionsView.EnableAppearanceEvenRow = true;
            this.treeTinhHuyenXa.OptionsView.EnableAppearanceOddRow = true;
            this.treeTinhHuyenXa.ParentFieldName = "ParentIDS";
            this.treeTinhHuyenXa.Size = new System.Drawing.Size(523, 459);
            this.treeTinhHuyenXa.TabIndex = 5;
            this.treeTinhHuyenXa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeTinhHuyenXa_MouseUp);
            this.treeTinhHuyenXa.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeTinhHuyenXa_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Tên";
            this.treeListColumn1.FieldName = "Ten";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 311;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "Mã";
            this.treeListColumn2.FieldName = "Ma";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 191;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnThemTinh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnThemHuyen),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnThemXa),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSuaTinh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSuaHuyen),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSuaXa),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnXoa)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkExpandAll);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(523, 29);
            this.panelControl1.TabIndex = 6;
            // 
            // chkExpandAll
            // 
            this.chkExpandAll.Location = new System.Drawing.Point(12, 5);
            this.chkExpandAll.Name = "chkExpandAll";
            this.chkExpandAll.Properties.Caption = "Mở rộng tất cả";
            this.chkExpandAll.Size = new System.Drawing.Size(101, 19);
            this.chkExpandAll.TabIndex = 0;
            this.chkExpandAll.CheckedChanged += new System.EventHandler(this.chkExpandAll_CheckedChanged);
            // 
            // frmTinhHuyenXa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 488);
            this.Controls.Add(this.treeTinhHuyenXa);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.Name = "frmTinhHuyenXa";
            this.Tag = "frmTinhHuyenXa";
            this.Text = "TINH HUYEN XA";
            this.Load += new System.EventHandler(this.frmTinhHuyenXa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTinhHuyenXa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeTinhHuyenXa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkExpandAll.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider DxErrorProvider;
        private DevExpress.XtraTreeList.TreeList treeTinhHuyenXa;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem barbtnThemTinh;
        private DevExpress.XtraBars.BarButtonItem barbtnThemHuyen;
        private DevExpress.XtraBars.BarButtonItem barbtnThemXa;
        private DevExpress.XtraBars.BarButtonItem barbtnSuaTinh;
        private DevExpress.XtraBars.BarButtonItem barbtnSuaHuyen;
        private DevExpress.XtraBars.BarButtonItem barbtnSuaXa;
        private DevExpress.XtraBars.BarButtonItem barbtnXoa;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkExpandAll;
    }
}