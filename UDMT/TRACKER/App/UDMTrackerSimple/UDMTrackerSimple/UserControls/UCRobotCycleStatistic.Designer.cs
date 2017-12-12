namespace UDMTrackerSimple
{
    partial class UCRobotCycleStatistic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.exChart = new DevExpress.XtraCharts.ChartControl();
            this.grdRobot = new DevExpress.XtraGrid.GridControl();
            this.grvRobot = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.exCycleChart = new DevExpress.XtraCharts.ChartControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlInformation = new DevExpress.XtraEditors.PanelControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpkTo = new DevExpress.XtraEditors.TimeEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkFrom = new DevExpress.XtraEditors.TimeEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAbnormalFilter = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.txtAverage = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exCycleChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInformation)).BeginInit();
            this.pnlInformation.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbnormalFilter.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.exChart);
            this.panelControl1.Controls.Add(this.grdRobot);
            this.panelControl1.Controls.Add(this.lblTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(251, 227);
            this.panelControl1.TabIndex = 0;
            // 
            // exChart
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.exChart.Diagram = xyDiagram1;
            this.exChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.exChart.Location = new System.Drawing.Point(0, 22);
            this.exChart.Name = "exChart";
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Max";
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Min";
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "Avr";
            this.exChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.exChart.Size = new System.Drawing.Size(251, 158);
            this.exChart.TabIndex = 5;
            // 
            // grdRobot
            // 
            this.grdRobot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdRobot.Location = new System.Drawing.Point(0, 180);
            this.grdRobot.LookAndFeel.SkinName = "Office 2013";
            this.grdRobot.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdRobot.MainView = this.grvRobot;
            this.grdRobot.Name = "grdRobot";
            this.grdRobot.Size = new System.Drawing.Size(251, 47);
            this.grdRobot.TabIndex = 6;
            this.grdRobot.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRobot});
            // 
            // grvRobot
            // 
            this.grvRobot.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvRobot.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMin,
            this.colMax,
            this.colAverage});
            this.grvRobot.GridControl = this.grdRobot;
            this.grvRobot.Name = "grvRobot";
            this.grvRobot.OptionsBehavior.Editable = false;
            this.grvRobot.OptionsBehavior.ReadOnly = true;
            this.grvRobot.OptionsCustomization.AllowColumnMoving = false;
            this.grvRobot.OptionsDetail.AllowZoomDetail = false;
            this.grvRobot.OptionsDetail.EnableMasterViewMode = false;
            this.grvRobot.OptionsDetail.SmartDetailExpand = false;
            this.grvRobot.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvRobot.OptionsView.ShowGroupPanel = false;
            this.grvRobot.OptionsView.ShowIndicator = false;
            this.grvRobot.RowHeight = 30;
            // 
            // colMin
            // 
            this.colMin.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMin.AppearanceCell.Options.UseFont = true;
            this.colMin.AppearanceCell.Options.UseTextOptions = true;
            this.colMin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMin.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colMin.AppearanceHeader.Options.UseFont = true;
            this.colMin.AppearanceHeader.Options.UseForeColor = true;
            this.colMin.AppearanceHeader.Options.UseTextOptions = true;
            this.colMin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMin.Caption = "Min";
            this.colMin.FieldName = "Min";
            this.colMin.Name = "colMin";
            this.colMin.Visible = true;
            this.colMin.VisibleIndex = 1;
            // 
            // colMax
            // 
            this.colMax.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMax.AppearanceCell.Options.UseFont = true;
            this.colMax.AppearanceCell.Options.UseTextOptions = true;
            this.colMax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMax.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMax.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colMax.AppearanceHeader.Options.UseFont = true;
            this.colMax.AppearanceHeader.Options.UseForeColor = true;
            this.colMax.AppearanceHeader.Options.UseTextOptions = true;
            this.colMax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMax.Caption = "Max";
            this.colMax.FieldName = "Max";
            this.colMax.Name = "colMax";
            this.colMax.Visible = true;
            this.colMax.VisibleIndex = 2;
            // 
            // colAverage
            // 
            this.colAverage.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAverage.AppearanceCell.Options.UseFont = true;
            this.colAverage.AppearanceCell.Options.UseTextOptions = true;
            this.colAverage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAverage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAverage.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colAverage.AppearanceHeader.Options.UseFont = true;
            this.colAverage.AppearanceHeader.Options.UseForeColor = true;
            this.colAverage.AppearanceHeader.Options.UseTextOptions = true;
            this.colAverage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAverage.Caption = "Avr";
            this.colAverage.FieldName = "Average";
            this.colAverage.Name = "colAverage";
            this.colAverage.Visible = true;
            this.colAverage.VisibleIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(251, 22);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Statistic";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(251, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 227);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.exCycleChart);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.pnlInformation);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(256, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(575, 227);
            this.panelControl2.TabIndex = 2;
            // 
            // exCycleChart
            // 
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisX.VisualRange.Auto = false;
            xyDiagram2.AxisX.VisualRange.AutoSideMargins = false;
            xyDiagram2.AxisX.VisualRange.MaxValueSerializable = "30";
            xyDiagram2.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram2.AxisX.VisualRange.SideMarginsValue = 1.3333333333333333D;
            xyDiagram2.AxisX.WholeRange.AlwaysShowZeroLevel = false;
            xyDiagram2.AxisX.WholeRange.Auto = false;
            xyDiagram2.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram2.AxisX.WholeRange.MaxValueSerializable = "5000";
            xyDiagram2.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram2.AxisX.WholeRange.SideMarginsValue = 3.3333333333333335D;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.EnableAxisXScrolling = true;
            this.exCycleChart.Diagram = xyDiagram2;
            this.exCycleChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exCycleChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.exCycleChart.Location = new System.Drawing.Point(0, 22);
            this.exCycleChart.Name = "exCycleChart";
            this.exCycleChart.RuntimeHitTesting = true;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "Cycle";
            series5.Name = "Average";
            series5.View = lineSeriesView1;
            this.exCycleChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4,
        series5};
            this.exCycleChart.Size = new System.Drawing.Size(397, 205);
            this.exCycleChart.TabIndex = 6;
            this.exCycleChart.CustomDrawCrosshair += new DevExpress.XtraCharts.CustomDrawCrosshairEventHandler(this.exCycleChart_CustomDrawCrosshair);
            this.exCycleChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exCycleChart_MouseDoubleClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(397, 22);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "All Cycle";
            // 
            // pnlInformation
            // 
            this.pnlInformation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlInformation.Controls.Add(this.groupBox3);
            this.pnlInformation.Controls.Add(this.groupBox2);
            this.pnlInformation.Controls.Add(this.groupBox1);
            this.pnlInformation.Controls.Add(this.labelControl2);
            this.pnlInformation.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInformation.Location = new System.Drawing.Point(397, 0);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(178, 227);
            this.pnlInformation.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpkTo);
            this.groupBox3.Controls.Add(this.panelControl4);
            this.groupBox3.Controls.Add(this.labelControl4);
            this.groupBox3.Controls.Add(this.dtpkFrom);
            this.groupBox3.Controls.Add(this.panelControl3);
            this.groupBox3.Controls.Add(this.labelControl3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 110);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Whole Range";
            // 
            // dtpkTo
            // 
            this.dtpkTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpkTo.EditValue = new System.DateTime(2016, 3, 14, 0, 0, 0, 0);
            this.dtpkTo.Location = new System.Drawing.Point(3, 78);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkTo.Properties.Appearance.Options.UseFont = true;
            this.dtpkTo.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpkTo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpkTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkTo.Properties.DisplayFormat.FormatString = "yyyy.MM.dd";
            this.dtpkTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkTo.Properties.EditFormat.FormatString = "yyyy.MM.dd";
            this.dtpkTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkTo.Properties.Mask.EditMask = "yyyy.MM.dd";
            this.dtpkTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkTo.Properties.ReadOnly = true;
            this.dtpkTo.Size = new System.Drawing.Size(172, 22);
            this.dtpkTo.TabIndex = 6;
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(3, 73);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(172, 5);
            this.panelControl4.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl4.Location = new System.Drawing.Point(3, 59);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(172, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "To";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpkFrom.EditValue = new System.DateTime(2016, 3, 14, 0, 0, 0, 0);
            this.dtpkFrom.Location = new System.Drawing.Point(3, 37);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFrom.Properties.Appearance.Options.UseFont = true;
            this.dtpkFrom.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpkFrom.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpkFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkFrom.Properties.DisplayFormat.FormatString = "yyyy.MM.dd";
            this.dtpkFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkFrom.Properties.EditFormat.FormatString = "yyyy.MM.dd";
            this.dtpkFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkFrom.Properties.Mask.EditMask = "yyyy.MM.dd";
            this.dtpkFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkFrom.Properties.ReadOnly = true;
            this.dtpkFrom.Size = new System.Drawing.Size(172, 22);
            this.dtpkFrom.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(3, 32);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(172, 5);
            this.panelControl3.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl3.Location = new System.Drawing.Point(3, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(172, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAbnormalFilter);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // chkAbnormalFilter
            // 
            this.chkAbnormalFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAbnormalFilter.Location = new System.Drawing.Point(3, 18);
            this.chkAbnormalFilter.Name = "chkAbnormalFilter";
            this.chkAbnormalFilter.Properties.Caption = "Abnormal";
            this.chkAbnormalFilter.Size = new System.Drawing.Size(75, 19);
            this.chkAbnormalFilter.TabIndex = 0;
            this.chkAbnormalFilter.CheckedChanged += new System.EventHandler(this.chkAbnormalFilter_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.txtAverage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 46);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Average";
            // 
            // btnApply
            // 
            this.btnApply.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApply.Appearance.Options.UseBackColor = true;
            this.btnApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApply.Location = new System.Drawing.Point(111, 18);
            this.btnApply.LookAndFeel.SkinName = "Office 2013";
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(64, 25);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtAverage
            // 
            this.txtAverage.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtAverage.Location = new System.Drawing.Point(3, 18);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtAverage.Size = new System.Drawing.Size(102, 20);
            this.txtAverage.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(0, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl2.Size = new System.Drawing.Size(178, 22);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Control";
            // 
            // UCRobotCycleStatistic
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCRobotCycleStatistic";
            this.Size = new System.Drawing.Size(831, 227);
            this.Load += new System.EventHandler(this.UCRobotCycleStatistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exCycleChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInformation)).EndInit();
            this.pnlInformation.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAbnormalFilter.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraCharts.ChartControl exChart;
        private DevExpress.XtraGrid.GridControl grdRobot;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRobot;
        private DevExpress.XtraGrid.Columns.GridColumn colMin;
        private DevExpress.XtraGrid.Columns.GridColumn colMax;
        private DevExpress.XtraGrid.Columns.GridColumn colAverage;
        private DevExpress.XtraCharts.ChartControl exCycleChart;
        private DevExpress.XtraEditors.PanelControl pnlInformation;
        private DevExpress.XtraEditors.TextEdit txtAverage;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TimeEdit dtpkTo;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TimeEdit dtpkFrom;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.CheckEdit chkAbnormalFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnApply;
    }
}
