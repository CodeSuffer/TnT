using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabAndTab
{
    public partial class Browser : UserControl
    {
        public Browser()
        {
            InitializeComponent();
            browserSplitContainer.Paint += BrowserSplitContainer_Paint;
        }

        private void BrowserSplitContainer_Paint(object sender, PaintEventArgs e)
        {
            SplitContainer s = sender as SplitContainer;
            if (s != null)
            {
                int top = 1;
                int bottom = s.Height - 1;
                float left = s.SplitterDistance + s.SplitterWidth / 2.0f;
                e.Graphics.DrawLine(Pens.Silver, left, top, left, bottom);
            }
        }
    }
}
