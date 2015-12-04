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
            this.addressSplitContainer = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.browsersplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftFavoritesBar1 = new TabAndTab.LeftFavoritesBar();
            this.splitableTabControl1 = new TabAndTab.SplitableTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.menuSplitContainer)).BeginInit();
            this.menuSplitContainer.Panel2.SuspendLayout();
            this.menuSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressSplitContainer)).BeginInit();
            this.addressSplitContainer.Panel1.SuspendLayout();
            this.addressSplitContainer.Panel2.SuspendLayout();
            this.addressSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browsersplitContainer)).BeginInit();
            this.browsersplitContainer.Panel1.SuspendLayout();
            this.browsersplitContainer.Panel2.SuspendLayout();
            this.browsersplitContainer.SuspendLayout();
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
            // menuSplitContainer.Panel2
            // 
            this.menuSplitContainer.Panel2.Controls.Add(this.addressSplitContainer);
            this.menuSplitContainer.Size = new System.Drawing.Size(606, 396);
            this.menuSplitContainer.TabIndex = 0;
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
            this.addressSplitContainer.Panel1.Controls.Add(this.textBox1);
            // 
            // addressSplitContainer.Panel2
            // 
            this.addressSplitContainer.Panel2.Controls.Add(this.browsersplitContainer);
            this.addressSplitContainer.Size = new System.Drawing.Size(606, 342);
            this.addressSplitContainer.SplitterDistance = 25;
            this.addressSplitContainer.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(606, 25);
            this.textBox1.TabIndex = 0;
            // 
            // browsersplitContainer
            // 
            this.browsersplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browsersplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.browsersplitContainer.Location = new System.Drawing.Point(0, 0);
            this.browsersplitContainer.Name = "browsersplitContainer";
            // 
            // browsersplitContainer.Panel1
            // 
            this.browsersplitContainer.Panel1.Controls.Add(this.leftFavoritesBar1);
            this.browsersplitContainer.Panel1MinSize = 150;
            // 
            // browsersplitContainer.Panel2
            // 
            this.browsersplitContainer.Panel2.Controls.Add(this.splitableTabControl1);
            this.browsersplitContainer.Size = new System.Drawing.Size(606, 313);
            this.browsersplitContainer.SplitterDistance = 150;
            this.browsersplitContainer.TabIndex = 0;
            // 
            // leftFavoritesBar1
            // 
            this.leftFavoritesBar1.AllowDrop = true;
            this.leftFavoritesBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftFavoritesBar1.Location = new System.Drawing.Point(0, 0);
            this.leftFavoritesBar1.Name = "leftFavoritesBar1";
            this.leftFavoritesBar1.Size = new System.Drawing.Size(150, 313);
            this.leftFavoritesBar1.TabIndex = 0;
            // 
            // splitableTabControl1
            // 
            this.splitableTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitableTabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitableTabControl1.Location = new System.Drawing.Point(0, 0);
            this.splitableTabControl1.Name = "splitableTabControl1";
            this.splitableTabControl1.Size = new System.Drawing.Size(452, 313);
            this.splitableTabControl1.TabIndex = 0;
            // 
            // BrowserForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 396);
            this.Controls.Add(this.menuSplitContainer);
            this.Name = "BrowserForm";
            this.Text = "TabBrowser";
            this.menuSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuSplitContainer)).EndInit();
            this.menuSplitContainer.ResumeLayout(false);
            this.addressSplitContainer.Panel1.ResumeLayout(false);
            this.addressSplitContainer.Panel1.PerformLayout();
            this.addressSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addressSplitContainer)).EndInit();
            this.addressSplitContainer.ResumeLayout(false);
            this.browsersplitContainer.Panel1.ResumeLayout(false);
            this.browsersplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browsersplitContainer)).EndInit();
            this.browsersplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer menuSplitContainer;
        private System.Windows.Forms.SplitContainer addressSplitContainer;
        private System.Windows.Forms.SplitContainer browsersplitContainer;
        private System.Windows.Forms.TextBox textBox1;
        private SplitableTabControl splitableTabControl1;
        private LeftFavoritesBar leftFavoritesBar1;
    }
}

