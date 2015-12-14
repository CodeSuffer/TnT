/* Code By Codesuffer */
/* Computer Science 20143035 */
/* To OSS Team Project */
/* Class for control a browser */

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
        private class CustomWebBrowser : WebBrowser
        {
            Control parentControl;

            public Control ParentControl
            {
                get
                {
                    return parentControl;
                }
            }

            public CustomWebBrowser(Control parent)
            {
                parentControl = parent;
            }
        }
        private ImageButton buttonBack = new ImageButton(Properties.Resources.browser_go_back, Properties.Resources.browser_go_back, Properties.Resources.browser_go_back, "");
        private ImageButton buttonForward = new ImageButton(Properties.Resources.browser_go_forward, Properties.Resources.browser_go_forward, Properties.Resources.browser_go_forward, "");
        private List<Control> menuContainer = new List<Control>();
        
        public event EventHandler<string> onTitleChanging;
        static private int splitterPos = 151;
        private WebBrowser explorer;

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

        private string title;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        
        public Browser()
        {
            InitializeComponent();
            this.explorer = new CustomWebBrowser(this);
            this.explorer.Dock = DockStyle.Fill;
            browserSplitContainer.Paint += BrowserSplitContainer_Paint;
            browserSplitContainer.SplitterMoving += BrowserSplitter_Moving;
            browserSplitContainer.Panel2.Controls.Add(this.explorer);
            this.textBoxAddress.KeyDown += TextBoxAddress_KeyDown;
            this.explorer.DocumentTitleChanged += Explorer_DocumentTitleChanged;

            buttonBack.Click += ButtonBack_Click;
            this.buttonContainer.Panel1.Controls.Add(buttonBack);
            this.menuContainer.Add(buttonBack);
            buttonForward.Click += ButtonForward_Click;
            this.buttonContainer.Panel1.Controls.Add(buttonForward);
            this.menuContainer.Add(buttonForward);
            RefreshMenu();

            treeView.Tree.NodeMouseDoubleClick += Tree_NodeMouseDoubleClick;
        }

        private void Tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try {
                explorer.Url = new Uri((e.Node.Tag as ShellItem).Path);
            }
            catch
            {

            }
        }

        private void ButtonForward_Click(object sender, EventArgs e)
        {
            explorer.GoForward();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            explorer.GoBack();
        }

        private void Explorer_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Title = ((WebBrowser)sender).DocumentTitle;
            this.Address = ((WebBrowser)sender).Url.AbsolutePath;
            if (onTitleChanging != null) onTitleChanging(((CustomWebBrowser)sender).ParentControl, ((WebBrowser)sender).DocumentTitle);
        }

        private void TextBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Address = textBoxAddress.Text;
                this.AddressChanging(address);
            }
        }

        private void BrowserSplitter_Moving(object sender, SplitterCancelEventArgs e)
        {
            splitterPos = e.SplitX;
        }

        public Browser(string address) : this()
        {
            Address = address;
            this.AddressChanging(address);
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

        public bool AddressChanging(string address)
        {
            try
            {
                Uri uri = new Uri(address);
                if (!uri.IsFile) throw new System.UriFormatException();
                this.explorer.Url = uri;
                return true;
            }
            catch (System.UriFormatException)
            {
                this.explorer.DocumentText = "잘못된 페이지 입니다.";
                return false;
            }
        }

        public void GoBack()
        {
            if (!this.explorer.CanGoBack) return;

            this.explorer.GoBack();
        }

        public void GoForward()
        {
            if (!this.explorer.CanGoForward) return;

            this.explorer.GoForward();
        }

        private void RefreshMenu()
        {
            int widthSum = 0;
            foreach (Control it in menuContainer)
            {
                it.Left = widthSum;
                widthSum += it.Width;
            }
        }
    }
}
