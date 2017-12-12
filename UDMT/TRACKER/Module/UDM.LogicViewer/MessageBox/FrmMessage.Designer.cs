namespace UDM.LogicViewer
{
    partial class FrmMessage
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessage));
            this.pictureError = new System.Windows.Forms.Label();
            this.pictureInfo = new System.Windows.Forms.Label();
            this.contentLabel = new System.Windows.Forms.Label();
            this.headerImage = new System.Windows.Forms.PictureBox();
            this.pictureSelector = new System.Windows.Forms.Label();
            this.pictureInput = new System.Windows.Forms.Label();
            this.pictureQuestion = new System.Windows.Forms.Label();
            this.pictureWarning = new System.Windows.Forms.Label();
            this.buttonOK = new DevExpress.XtraEditors.CheckButton();
            this.buttonCancel = new DevExpress.XtraEditors.CheckButton();
            this.listBox_Select = new DevExpress.XtraEditors.ListBoxControl();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.headerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureError
            // 
            this.pictureError.Image = ((System.Drawing.Image)(resources.GetObject("pictureError.Image")));
            this.pictureError.Location = new System.Drawing.Point(12, 5);
            this.pictureError.Name = "pictureError";
            this.pictureError.Size = new System.Drawing.Size(65, 115);
            this.pictureError.TabIndex = 22;
            this.pictureError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureError.Visible = false;
            // 
            // pictureInfo
            // 
            this.pictureInfo.Image = ((System.Drawing.Image)(resources.GetObject("pictureInfo.Image")));
            this.pictureInfo.Location = new System.Drawing.Point(12, 5);
            this.pictureInfo.Name = "pictureInfo";
            this.pictureInfo.Size = new System.Drawing.Size(65, 115);
            this.pictureInfo.TabIndex = 19;
            this.pictureInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureInfo.Visible = false;
            // 
            // contentLabel
            // 
            this.contentLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.contentLabel.Location = new System.Drawing.Point(83, 22);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(296, 63);
            this.contentLabel.TabIndex = 12;
            this.contentLabel.Text = "Message";
            this.contentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerImage
            // 
            this.headerImage.Location = new System.Drawing.Point(-91, 3);
            this.headerImage.Name = "headerImage";
            this.headerImage.Size = new System.Drawing.Size(32, 37);
            this.headerImage.TabIndex = 10;
            this.headerImage.TabStop = false;
            // 
            // pictureSelector
            // 
            this.pictureSelector.Image = ((System.Drawing.Image)(resources.GetObject("pictureSelector.Image")));
            this.pictureSelector.Location = new System.Drawing.Point(12, 5);
            this.pictureSelector.Name = "pictureSelector";
            this.pictureSelector.Size = new System.Drawing.Size(65, 115);
            this.pictureSelector.TabIndex = 26;
            this.pictureSelector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureSelector.Visible = false;
            // 
            // pictureInput
            // 
            this.pictureInput.Image = ((System.Drawing.Image)(resources.GetObject("pictureInput.Image")));
            this.pictureInput.Location = new System.Drawing.Point(12, 5);
            this.pictureInput.Name = "pictureInput";
            this.pictureInput.Size = new System.Drawing.Size(65, 115);
            this.pictureInput.TabIndex = 24;
            this.pictureInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureInput.Visible = false;
            // 
            // pictureQuestion
            // 
            this.pictureQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pictureQuestion.Image")));
            this.pictureQuestion.Location = new System.Drawing.Point(12, 5);
            this.pictureQuestion.Name = "pictureQuestion";
            this.pictureQuestion.Size = new System.Drawing.Size(65, 115);
            this.pictureQuestion.TabIndex = 23;
            this.pictureQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureQuestion.Visible = false;
            // 
            // pictureWarning
            // 
            this.pictureWarning.Image = ((System.Drawing.Image)(resources.GetObject("pictureWarning.Image")));
            this.pictureWarning.Location = new System.Drawing.Point(12, 5);
            this.pictureWarning.Name = "pictureWarning";
            this.pictureWarning.Size = new System.Drawing.Size(65, 115);
            this.pictureWarning.TabIndex = 22;
            this.pictureWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureWarning.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(117, 275);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 25);
            this.buttonOK.TabIndex = 30;
            this.buttonOK.Text = "&Ok";
            this.buttonOK.CheckedChanged += new System.EventHandler(this.buttonOK_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(262, 275);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 25);
            this.buttonCancel.TabIndex = 30;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.CheckedChanged += new System.EventHandler(this.buttonCancel_CheckedChanged);
            // 
            // listBox_Select
            // 
            this.listBox_Select.HorizontalScrollbar = true;
            this.listBox_Select.Location = new System.Drawing.Point(83, 12);
            this.listBox_Select.Name = "listBox_Select";
            this.listBox_Select.Size = new System.Drawing.Size(362, 257);
            this.listBox_Select.TabIndex = 31;
            this.listBox_Select.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Select_MouseDoubleClick);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(83, 66);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(296, 20);
            this.txtInput.TabIndex = 32;
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 304);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.pictureWarning);
            this.Controls.Add(this.pictureQuestion);
            this.Controls.Add(this.pictureInput);
            this.Controls.Add(this.pictureError);
            this.Controls.Add(this.pictureInfo);
            this.Controls.Add(this.pictureSelector);
            this.Controls.Add(this.headerImage);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.listBox_Select);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMessageDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMessageDialog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.headerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox headerImage;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Label pictureInfo;
        private System.Windows.Forms.Label pictureError;
        private System.Windows.Forms.Label pictureInput;
        private System.Windows.Forms.Label pictureQuestion;
        private System.Windows.Forms.Label pictureWarning;
        private System.Windows.Forms.Label pictureSelector;
        private DevExpress.XtraEditors.CheckButton buttonOK;
        private DevExpress.XtraEditors.CheckButton buttonCancel;
        private DevExpress.XtraEditors.ListBoxControl listBox_Select;
        private DevExpress.XtraEditors.TextEdit txtInput;

    }
}

