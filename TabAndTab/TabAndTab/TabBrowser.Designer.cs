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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabButton2 = new TabAndTab.TabButton();
            this.tabButton1 = new TabAndTab.TabButton();
            this.browser1 = new TabAndTab.Browser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabButton2);
            this.splitContainer1.Panel1.Controls.Add(this.tabButton1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.browser1);
            this.splitContainer1.Panel2MinSize = 270;
            this.splitContainer1.Size = new System.Drawing.Size(613, 420);
            this.splitContainer1.SplitterDistance = 26;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabButton2
            // 
            this.tabButton2.Location = new System.Drawing.Point(113, 0);
            this.tabButton2.Name = "tabButton2";
            this.tabButton2.Size = new System.Drawing.Size(110, 25);
            this.tabButton2.TabIndex = 0;
            // 
            // tabButton1
            // 
            this.tabButton1.Location = new System.Drawing.Point(3, 0);
            this.tabButton1.Name = "tabButton1";
            this.tabButton1.Size = new System.Drawing.Size(110, 25);
            this.tabButton1.TabIndex = 0;
            // 
            // browser1
            // 
            this.browser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser1.Location = new System.Drawing.Point(0, 0);
            this.browser1.Name = "browser1";
            this.browser1.Size = new System.Drawing.Size(613, 390);
            this.browser1.TabIndex = 0;
            // 
            // TabBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "TabBrowser";
            this.Size = new System.Drawing.Size(613, 420);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private TabButton tabButton2;
        private TabButton tabButton1;
        private Browser browser1;
    }
}
