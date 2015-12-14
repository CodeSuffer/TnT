namespace TabAndTab
{
    partial class Browser
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
            this.addressSplitContainer = new System.Windows.Forms.SplitContainer();
            this.buttonContainer = new System.Windows.Forms.SplitContainer();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.browserSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftFavoritesBar1 = new TabAndTab.LeftFavoritesBar();
            ((System.ComponentModel.ISupportInitialize)(this.addressSplitContainer)).BeginInit();
            this.addressSplitContainer.Panel1.SuspendLayout();
            this.addressSplitContainer.Panel2.SuspendLayout();
            this.addressSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonContainer)).BeginInit();
            this.buttonContainer.Panel2.SuspendLayout();
            this.buttonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserSplitContainer)).BeginInit();
            this.browserSplitContainer.Panel1.SuspendLayout();
            this.browserSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // addressSplitContainer
            // 
            this.addressSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.addressSplitContainer.IsSplitterFixed = true;
            this.addressSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.addressSplitContainer.Name = "addressSplitContainer";
            this.addressSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // addressSplitContainer.Panel1
            // 
            this.addressSplitContainer.Panel1.Controls.Add(this.buttonContainer);
            // 
            // addressSplitContainer.Panel2
            // 
            this.addressSplitContainer.Panel2.Controls.Add(this.browserSplitContainer);
            this.addressSplitContainer.Panel2MinSize = 300;
            this.addressSplitContainer.Size = new System.Drawing.Size(631, 428);
            this.addressSplitContainer.SplitterDistance = 26;
            this.addressSplitContainer.SplitterWidth = 1;
            this.addressSplitContainer.TabIndex = 2;
            // 
            // buttonContainer
            // 
            this.buttonContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonContainer.IsSplitterFixed = true;
            this.buttonContainer.Location = new System.Drawing.Point(0, 0);
            this.buttonContainer.Name = "buttonContainer";
            this.buttonContainer.Panel1MinSize = 50;
            // 
            // buttonContainer.Panel2
            // 
            this.buttonContainer.Panel2.Controls.Add(this.textBoxAddress);
            this.buttonContainer.Size = new System.Drawing.Size(631, 26);
            this.buttonContainer.SplitterDistance = 51;
            this.buttonContainer.SplitterWidth = 1;
            this.buttonContainer.TabIndex = 1;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAddress.Location = new System.Drawing.Point(0, 0);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(579, 25);
            this.textBoxAddress.TabIndex = 0;
            // 
            // browserSplitContainer
            // 
            this.browserSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.browserSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.browserSplitContainer.MinimumSize = new System.Drawing.Size(450, 300);
            this.browserSplitContainer.Name = "browserSplitContainer";
            // 
            // browserSplitContainer.Panel1
            // 
            this.browserSplitContainer.Panel1.Controls.Add(this.leftFavoritesBar1);
            this.browserSplitContainer.Panel1MinSize = 150;
            this.browserSplitContainer.Panel2MinSize = 300;
            this.browserSplitContainer.Size = new System.Drawing.Size(631, 401);
            this.browserSplitContainer.SplitterDistance = 151;
            this.browserSplitContainer.SplitterWidth = 1;
            this.browserSplitContainer.TabIndex = 1;
            this.browserSplitContainer.TabStop = false;
            // 
            // leftFavoritesBar1
            // 
            this.leftFavoritesBar1.AllowDrop = true;
            this.leftFavoritesBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftFavoritesBar1.Location = new System.Drawing.Point(0, 0);
            this.leftFavoritesBar1.Name = "leftFavoritesBar1";
            this.leftFavoritesBar1.Size = new System.Drawing.Size(151, 401);
            this.leftFavoritesBar1.TabIndex = 0;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addressSplitContainer);
            this.Name = "Browser";
            this.Size = new System.Drawing.Size(631, 428);
            this.addressSplitContainer.Panel1.ResumeLayout(false);
            this.addressSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addressSplitContainer)).EndInit();
            this.addressSplitContainer.ResumeLayout(false);
            this.buttonContainer.Panel2.ResumeLayout(false);
            this.buttonContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonContainer)).EndInit();
            this.buttonContainer.ResumeLayout(false);
            this.browserSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browserSplitContainer)).EndInit();
            this.browserSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer addressSplitContainer;
        private System.Windows.Forms.SplitContainer browserSplitContainer;
        private LeftFavoritesBar leftFavoritesBar1;
        private System.Windows.Forms.SplitContainer buttonContainer;
        private System.Windows.Forms.TextBox textBoxAddress;
    }
}
