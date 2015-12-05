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
    public partial class TabBrowser : UserControl
    {
        private BrowserControl browserControl = new BrowserControl();
        private TabControl tabControl = new TabControl();

        public TabBrowser()
        {
            InitializeComponent();
            this.tabSpliter.Panel1.Controls.Add(tabControl);
            browserControl.Dock = DockStyle.Fill;
            this.tabSpliter.Panel2.Controls.Add(browserControl);
            tabControl.Click += tabControl_Click;

            tabControl.OnTabOrderChange += TabOrder_Change;

            AddBrowser(new Browser("test1"));
            AddBrowser(new Browser("test2"));
            AddBrowser(new Browser("test3"));
        }

        public void TabOrder_Change(object sender, EventArgs e)
        {
            TabEventArgs tabEvent = (TabEventArgs)e;
            browserControl.OrderChange(tabEvent.TabOrigin, tabEvent.TabChanged);
        }

        public TabBrowser(Browser arg) : this()
        {
            AddBrowser(arg);
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            int index = ((TabEventArgs)e).TabIndex;
            browserControl.ShowBrowser(index);
        }

        public void AddBrowser(Browser arg)
        {
            browserControl.AddBrowser(arg);
            tabControl.AddNewTab(arg.Address);
        }
    }
}
