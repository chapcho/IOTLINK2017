namespace UDM.Ladder
{
    partial class FrmLadderValidationMultiple
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelResult = new System.Windows.Forms.Label();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnStep = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnContact = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnContactName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnContactX = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnContactY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnCell = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnCellRow = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnCellColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnCellStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBoxShowProblemOnly = new System.Windows.Forms.CheckBox();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonIncreasePage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonDecreasePage = new System.Windows.Forms.Button();
            this.buttonBeginPage = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeList);
            this.splitContainer1.Size = new System.Drawing.Size(843, 496);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(22, 19);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(64, 12);
            this.labelResult.TabIndex = 0;
            this.labelResult.Text = "Result : --";
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnStep,
            this.treeListColumnContact,
            this.treeListColumnContactName,
            this.treeListColumnContactX,
            this.treeListColumnContactY,
            this.treeListColumnCell,
            this.treeListColumnCellRow,
            this.treeListColumnCellColumn,
            this.treeListColumnCellStatus});
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.Size = new System.Drawing.Size(843, 443);
            this.treeList.TabIndex = 0;
            // 
            // treeListColumnStep
            // 
            this.treeListColumnStep.Caption = "Step";
            this.treeListColumnStep.FieldName = "Step";
            this.treeListColumnStep.Name = "treeListColumnStep";
            this.treeListColumnStep.Visible = true;
            this.treeListColumnStep.VisibleIndex = 0;
            // 
            // treeListColumnContact
            // 
            this.treeListColumnContact.Caption = "Contact";
            this.treeListColumnContact.FieldName = "Contact";
            this.treeListColumnContact.Name = "treeListColumnContact";
            this.treeListColumnContact.Visible = true;
            this.treeListColumnContact.VisibleIndex = 1;
            // 
            // treeListColumnContactName
            // 
            this.treeListColumnContactName.Caption = "Name";
            this.treeListColumnContactName.FieldName = "ContactName";
            this.treeListColumnContactName.Name = "treeListColumnContactName";
            this.treeListColumnContactName.Visible = true;
            this.treeListColumnContactName.VisibleIndex = 2;
            // 
            // treeListColumnContactX
            // 
            this.treeListColumnContactX.Caption = "X";
            this.treeListColumnContactX.FieldName = "ContactX";
            this.treeListColumnContactX.Name = "treeListColumnContactX";
            this.treeListColumnContactX.Visible = true;
            this.treeListColumnContactX.VisibleIndex = 3;
            // 
            // treeListColumnContactY
            // 
            this.treeListColumnContactY.Caption = "Y";
            this.treeListColumnContactY.FieldName = "ContactY";
            this.treeListColumnContactY.Name = "treeListColumnContactY";
            this.treeListColumnContactY.Visible = true;
            this.treeListColumnContactY.VisibleIndex = 4;
            // 
            // treeListColumnCell
            // 
            this.treeListColumnCell.Caption = "Cell";
            this.treeListColumnCell.FieldName = "Cell";
            this.treeListColumnCell.Name = "treeListColumnCell";
            this.treeListColumnCell.Visible = true;
            this.treeListColumnCell.VisibleIndex = 5;
            // 
            // treeListColumnCellRow
            // 
            this.treeListColumnCellRow.Caption = "Row";
            this.treeListColumnCellRow.FieldName = "CellRow";
            this.treeListColumnCellRow.Name = "treeListColumnCellRow";
            this.treeListColumnCellRow.Visible = true;
            this.treeListColumnCellRow.VisibleIndex = 6;
            // 
            // treeListColumnCellColumn
            // 
            this.treeListColumnCellColumn.Caption = "Column";
            this.treeListColumnCellColumn.FieldName = "CellColumn";
            this.treeListColumnCellColumn.Name = "treeListColumnCellColumn";
            this.treeListColumnCellColumn.Visible = true;
            this.treeListColumnCellColumn.VisibleIndex = 7;
            // 
            // treeListColumnCellStatus
            // 
            this.treeListColumnCellStatus.Caption = "Status";
            this.treeListColumnCellStatus.FieldName = "Status";
            this.treeListColumnCellStatus.Name = "treeListColumnCellStatus";
            this.treeListColumnCellStatus.Visible = true;
            this.treeListColumnCellStatus.VisibleIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.checkBoxShowProblemOnly);
            this.splitContainer2.Panel2.Controls.Add(this.buttonLastPage);
            this.splitContainer2.Panel2.Controls.Add(this.buttonIncreasePage);
            this.splitContainer2.Panel2.Controls.Add(this.labelPage);
            this.splitContainer2.Panel2.Controls.Add(this.buttonDecreasePage);
            this.splitContainer2.Panel2.Controls.Add(this.buttonBeginPage);
            this.splitContainer2.Size = new System.Drawing.Size(843, 530);
            this.splitContainer2.SplitterDistance = 496;
            this.splitContainer2.TabIndex = 1;
            // 
            // checkBoxShowProblemOnly
            // 
            this.checkBoxShowProblemOnly.AutoSize = true;
            this.checkBoxShowProblemOnly.Location = new System.Drawing.Point(74, 7);
            this.checkBoxShowProblemOnly.Name = "checkBoxShowProblemOnly";
            this.checkBoxShowProblemOnly.Size = new System.Drawing.Size(137, 16);
            this.checkBoxShowProblemOnly.TabIndex = 5;
            this.checkBoxShowProblemOnly.Text = "Show Problem Only";
            this.checkBoxShowProblemOnly.UseVisualStyleBackColor = true;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(482, 4);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(29, 23);
            this.buttonLastPage.TabIndex = 4;
            this.buttonLastPage.Text = ">>";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.ButtonLastPageClick);
            // 
            // buttonIncreasePage
            // 
            this.buttonIncreasePage.Location = new System.Drawing.Point(441, 4);
            this.buttonIncreasePage.Name = "buttonIncreasePage";
            this.buttonIncreasePage.Size = new System.Drawing.Size(29, 23);
            this.buttonIncreasePage.TabIndex = 3;
            this.buttonIncreasePage.Text = ">";
            this.buttonIncreasePage.UseVisualStyleBackColor = true;
            this.buttonIncreasePage.Click += new System.EventHandler(this.ButtonIncreasePageClick);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(401, 11);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(17, 12);
            this.labelPage.TabIndex = 2;
            this.labelPage.Text = "--";
            // 
            // buttonDecreasePage
            // 
            this.buttonDecreasePage.Location = new System.Drawing.Point(347, 4);
            this.buttonDecreasePage.Name = "buttonDecreasePage";
            this.buttonDecreasePage.Size = new System.Drawing.Size(29, 23);
            this.buttonDecreasePage.TabIndex = 1;
            this.buttonDecreasePage.Text = "<";
            this.buttonDecreasePage.UseVisualStyleBackColor = true;
            this.buttonDecreasePage.Click += new System.EventHandler(this.ButtonDecreasePageClick);
            // 
            // buttonBeginPage
            // 
            this.buttonBeginPage.Location = new System.Drawing.Point(306, 4);
            this.buttonBeginPage.Name = "buttonBeginPage";
            this.buttonBeginPage.Size = new System.Drawing.Size(29, 23);
            this.buttonBeginPage.TabIndex = 0;
            this.buttonBeginPage.Text = "<<";
            this.buttonBeginPage.UseVisualStyleBackColor = true;
            this.buttonBeginPage.Click += new System.EventHandler(this.ButtonBeginPageClick);
            // 
            // FrmLadderValidationMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 530);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FrmLadderValidationMultiple";
            this.Text = "FrmLadderValidationMultiple";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelResult;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnStep;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnContact;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnContactName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnContactX;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnContactY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnCell;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnCellRow;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnCellColumn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnCellStatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonIncreasePage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonDecreasePage;
        private System.Windows.Forms.Button buttonBeginPage;
        private System.Windows.Forms.CheckBox checkBoxShowProblemOnly;
    }
}