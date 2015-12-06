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
        static private int splitterPos = 151;
        public Browser()
        {
            InitializeComponent();
            browserSplitContainer.Paint += BrowserSplitContainer_Paint;
            browserSplitContainer.SplitterMoving += BrowserSplitter_Moving;
        }

        private void BrowserSplitter_Moving(object sender, SplitterCancelEventArgs e)
        {
            splitterPos = e.SplitX;
            MessageBox.Show(splitterPos+"");
        }

        public Browser(string address) : this()
        {
            Address = address;
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                textBoxAddress.Text = value;
            }
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
