namespace TabAndTab
{
    partial class TabBrowser
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
            this.tabSpliter = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.tabSpliter)).BeginInit();
            this.tabSpliter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSpliter
            // 
            this.tabSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.tabSpliter.IsSplitterFixed = true;
            this.tabSpliter.Location = new System.Drawing.Point(0, 0);
            this.tabSpliter.Name = "tabSpliter";
            this.tabSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tabSpliter.Panel2MinSize = 270;
            this.tabSpliter.Size = new System.Drawing.Size(613, 420);
            this.tabSpliter.SplitterDistance = 26;
            this.tabSpliter.SplitterWidth = 1;
            this.tabSpliter.TabIndex = 2;
            this.tabSpliter.TabStop = false;
            // 
            // TabBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSpliter);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "TabBrowser";
            this.Size = new System.Drawing.Size(613, 420);
            ((System.ComponentModel.ISupportInitialize)(this.tabSpliter)).EndInit();
            this.tabSpliter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer tabSpliter;
    }
}
