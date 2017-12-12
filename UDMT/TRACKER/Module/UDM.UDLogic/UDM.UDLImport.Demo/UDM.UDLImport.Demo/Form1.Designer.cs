namespace UDM.UDLImport.Demo
{
    partial class Form1
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
            this.btnTagGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcTag = new DevExpress.XtraGrid.GridControl();
            this.gvTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatatype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLogic = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMergeCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValidSymbolCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_OpenMit = new System.Windows.Forms.Button();
            this.btn_LS = new System.Windows.Forms.Button();
            this.btn_OpenSiemens = new System.Windows.Forms.Button();
            this.btn_OpenAB = new System.Windows.Forms.Button();
            this.btnOpenAll = new System.Windows.Forms.Button();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLogic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTagGenerate
            // 
            this.btnTagGenerate.Location = new System.Drawing.Point(5, 5);
            this.btnTagGenerate.Name = "btnTagGenerate";
            this.btnTagGenerate.Size = new System.Drawing.Size(149, 77);
            this.btnTagGenerate.TabIndex = 0;
            this.btnTagGenerate.Text = "Tag Generate";
            this.btnTagGenerate.Click += new System.EventHandler(this.btnTagGenerate_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.splitContainerControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 88);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1327, 609);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Information";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 21);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcTag);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcLogic);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1323, 586);
            this.splitContainerControl1.SplitterPosition = 491;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcTag
            // 
            this.gcTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTag.Location = new System.Drawing.Point(0, 0);
            this.gcTag.MainView = this.gvTag;
            this.gcTag.Name = "gcTag";
            this.gcTag.Size = new System.Drawing.Size(491, 586);
            this.gcTag.TabIndex = 0;
            this.gcTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTag});
            // 
            // gvTag
            // 
            this.gvTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colDatatype,
            this.colAddress,
            this.colDescription,
            this.colName});
            this.gvTag.GridControl = this.gcTag;
            this.gvTag.Name = "gvTag";
            this.gvTag.OptionsView.ShowAutoFilterRow = true;
            // 
            // colKey
            // 
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            // 
            // colDatatype
            // 
            this.colDatatype.Caption = "Datatype";
            this.colDatatype.FieldName = "DataType";
            this.colDatatype.Name = "colDatatype";
            this.colDatatype.Visible = true;
            this.colDatatype.VisibleIndex = 2;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 3;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // gcLogic
            // 
            this.gcLogic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLogic.Location = new System.Drawing.Point(0, 0);
            this.gcLogic.MainView = this.gridView1;
            this.gcLogic.Name = "gcLogic";
            this.gcLogic.Size = new System.Drawing.Size(827, 586);
            this.gcLogic.TabIndex = 1;
            this.gcLogic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProgram,
            this.colStepIndex,
            this.colMergeCheck,
            this.gcValidSymbolCheck,
            this.colLogic});
            this.gridView1.GridControl = this.gcLogic;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colProgram
            // 
            this.colProgram.AppearanceHeader.Options.UseTextOptions = true;
            this.colProgram.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProgram.Caption = "Program";
            this.colProgram.FieldName = "Program";
            this.colProgram.Name = "colProgram";
            this.colProgram.Visible = true;
            this.colProgram.VisibleIndex = 0;
            this.colProgram.Width = 93;
            // 
            // colStepIndex
            // 
            this.colStepIndex.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepIndex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepIndex.Caption = "Step Num";
            this.colStepIndex.FieldName = "StepNum";
            this.colStepIndex.Name = "colStepIndex";
            this.colStepIndex.Visible = true;
            this.colStepIndex.VisibleIndex = 1;
            this.colStepIndex.Width = 72;
            // 
            // colMergeCheck
            // 
            this.colMergeCheck.Caption = "MergePairCheck";
            this.colMergeCheck.FieldName = "MergePairCheck";
            this.colMergeCheck.Name = "colMergeCheck";
            this.colMergeCheck.Visible = true;
            this.colMergeCheck.VisibleIndex = 2;
            this.colMergeCheck.Width = 37;
            // 
            // gcValidSymbolCheck
            // 
            this.gcValidSymbolCheck.Caption = "SymbolCountCheck";
            this.gcValidSymbolCheck.FieldName = "ValidSymbolCountCheck";
            this.gcValidSymbolCheck.Name = "gcValidSymbolCheck";
            this.gcValidSymbolCheck.Visible = true;
            this.gcValidSymbolCheck.VisibleIndex = 3;
            this.gcValidSymbolCheck.Width = 39;
            // 
            // colLogic
            // 
            this.colLogic.AppearanceHeader.Options.UseTextOptions = true;
            this.colLogic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogic.Caption = "Logic";
            this.colLogic.FieldName = "UDL";
            this.colLogic.Name = "colLogic";
            this.colLogic.Visible = true;
            this.colLogic.VisibleIndex = 4;
            this.colLogic.Width = 910;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(160, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(157, 77);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Tag & Logic Generate";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(323, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(157, 77);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Instruction List Generate";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.btnTagGenerate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1327, 88);
            this.panelControl1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_OpenMit);
            this.groupBox1.Controls.Add(this.btn_LS);
            this.groupBox1.Controls.Add(this.btn_OpenSiemens);
            this.groupBox1.Controls.Add(this.btn_OpenAB);
            this.groupBox1.Controls.Add(this.btnOpenAll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(714, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 84);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NewCommonConvertor";
            // 
            // btn_OpenMit
            // 
            this.btn_OpenMit.Location = new System.Drawing.Point(502, 31);
            this.btn_OpenMit.Name = "btn_OpenMit";
            this.btn_OpenMit.Size = new System.Drawing.Size(89, 47);
            this.btn_OpenMit.TabIndex = 4;
            this.btn_OpenMit.Text = "OpenMit";
            this.btn_OpenMit.UseVisualStyleBackColor = true;
            // 
            // btn_LS
            // 
            this.btn_LS.Location = new System.Drawing.Point(392, 31);
            this.btn_LS.Name = "btn_LS";
            this.btn_LS.Size = new System.Drawing.Size(89, 47);
            this.btn_LS.TabIndex = 3;
            this.btn_LS.Text = "OpenLS";
            this.btn_LS.UseVisualStyleBackColor = true;
            // 
            // btn_OpenSiemens
            // 
            this.btn_OpenSiemens.Location = new System.Drawing.Point(273, 31);
            this.btn_OpenSiemens.Name = "btn_OpenSiemens";
            this.btn_OpenSiemens.Size = new System.Drawing.Size(89, 47);
            this.btn_OpenSiemens.TabIndex = 2;
            this.btn_OpenSiemens.Text = "OpenSiemens";
            this.btn_OpenSiemens.UseVisualStyleBackColor = true;
            // 
            // btn_OpenAB
            // 
            this.btn_OpenAB.Location = new System.Drawing.Point(148, 31);
            this.btn_OpenAB.Name = "btn_OpenAB";
            this.btn_OpenAB.Size = new System.Drawing.Size(89, 47);
            this.btn_OpenAB.TabIndex = 1;
            this.btn_OpenAB.Text = "OpenAB";
            this.btn_OpenAB.UseVisualStyleBackColor = true;
            // 
            // btnOpenAll
            // 
            this.btnOpenAll.Location = new System.Drawing.Point(25, 31);
            this.btnOpenAll.Name = "btnOpenAll";
            this.btnOpenAll.Size = new System.Drawing.Size(89, 47);
            this.btnOpenAll.TabIndex = 0;
            this.btnOpenAll.Text = "OpenAll";
            this.btnOpenAll.UseVisualStyleBackColor = true;
            this.btnOpenAll.Click += new System.EventHandler(this.btnOpenAll_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(486, 5);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(157, 77);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "View Logic Diagram";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 697);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = ".";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLogic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTagGenerate;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcTag;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTag;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcLogic;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colStepIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colLogic;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMergeCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gcValidSymbolCheck;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraGrid.Columns.GridColumn colDatatype;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_OpenMit;
        private System.Windows.Forms.Button btn_LS;
        private System.Windows.Forms.Button btn_OpenSiemens;
        private System.Windows.Forms.Button btn_OpenAB;
        private System.Windows.Forms.Button btnOpenAll;

        private DevExpress.XtraGrid.Columns.GridColumn colName;

    }
}

