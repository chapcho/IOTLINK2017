namespace IOTLManager.UserControls
{
    partial class UCExcelChartSample
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExcelPic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExcelPic
            // 
            this.btnExcelPic.Location = new System.Drawing.Point(362, 232);
            this.btnExcelPic.Name = "btnExcelPic";
            this.btnExcelPic.Size = new System.Drawing.Size(169, 56);
            this.btnExcelPic.TabIndex = 0;
            this.btnExcelPic.Text = "Excel Pic";
            this.btnExcelPic.UseVisualStyleBackColor = true;
            this.btnExcelPic.Click += new System.EventHandler(this.btnExcelPic_Click);
            // 
            // UCExcelChartSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExcelPic);
            this.Name = "UCExcelChartSample";
            this.Size = new System.Drawing.Size(685, 404);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcelPic;
    }
}
