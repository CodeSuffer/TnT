﻿namespace TabAndTab
{
    partial class ImageButton
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
            this.button = new System.Windows.Forms.PictureBox();
            this.labelButton = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.button)).BeginInit();
            this.button.SuspendLayout();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.Transparent;
            this.button.Controls.Add(this.labelButton);
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(150, 150);
            this.button.TabIndex = 0;
            this.button.TabStop = false;
            // 
            // labelButton
            // 
            this.labelButton.AutoSize = true;
            this.labelButton.BackColor = System.Drawing.Color.Transparent;
            this.labelButton.Location = new System.Drawing.Point(14, 64);
            this.labelButton.Name = "labelButton";
            this.labelButton.Size = new System.Drawing.Size(0, 15);
            this.labelButton.TabIndex = 1;
            this.labelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ImageButton";
            ((System.ComponentModel.ISupportInitialize)(this.button)).EndInit();
            this.button.ResumeLayout(false);
            this.button.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox button;
        private System.Windows.Forms.Label labelButton;
    }
}
