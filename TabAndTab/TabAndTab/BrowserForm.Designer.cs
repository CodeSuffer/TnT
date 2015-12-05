namespace TabAndTab
{
    partial class BrowserForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tabBrowser = new TabAndTab.TabBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.menuSplitContainer)).BeginInit();
            this.menuSplitContainer.Panel2.SuspendLayout();
            this.menuSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuSplitContainer
            // 
            this.menuSplitContainer.CausesValidation = false;
            this.menuSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.menuSplitContainer.IsSplitterFixed = true;
            this.menuSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.menuSplitContainer.Name = "menuSplitContainer";
            this.menuSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // menuSplitContainer.Panel1
            // 
            this.menuSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.menuSplitContainer.Panel1MinSize = 50;
            // 
            // menuSplitContainer.Panel2
            // 
            this.menuSplitContainer.Panel2.Controls.Add(this.tabBrowser);
            this.menuSplitContainer.Panel2MinSize = 325;
            this.menuSplitContainer.Size = new System.Drawing.Size(590, 401);
            this.menuSplitContainer.SplitterDistance = 51;
            this.menuSplitContainer.SplitterWidth = 1;
            this.menuSplitContainer.TabIndex = 0;
            this.menuSplitContainer.TabStop = false;
            // 
            // tabBrowser
            // 
            this.tabBrowser.BackColor = System.Drawing.SystemColors.Window;
            this.tabBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBrowser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabBrowser.Location = new System.Drawing.Point(0, 0);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Size = new System.Drawing.Size(590, 349);
            this.tabBrowser.TabIndex = 0;
            // 
            // BrowserForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 401);
            this.Controls.Add(this.menuSplitContainer);
            this.Name = "BrowserForm";
            this.Text = "TabBrowser";
            this.menuSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuSplitContainer)).EndInit();
            this.menuSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer menuSplitContainer;
        private TabBrowser tabBrowser;
    }
}

