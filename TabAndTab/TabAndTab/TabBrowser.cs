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
            tabControl.Dock = DockStyle.Fill;
            tabControl.OnTabClick += TabControl_Click;
            tabControl.OnTabOrderChange += TabControl_OrderChange;
            tabControl.OnTabDraggedOut += TabControl_DraggedOut;
            tabControl.OnBrowserDragEnter += TabControl_BrowserDragEnter;
        }

        public TabBrowser(Browser arg) : this()
        {
            AddBrowser(arg);
        }

        private void TabControl_BrowserDragEnter(object sender, DragEventArgs e)
        {
            Browser temp = (Browser)e.Data.GetData(typeof(Browser));
            
            this.AddBrowser(temp);

            int index = browserControl.getIndex(temp);
            browserControl.ShowBrowser(index);
            tabControl.ShowTab(index);
            DoDragDrop(tabControl.GetTab(index), DragDropEffects.Move);
        }

        private void TabControl_DraggedOut(object sender, TabDragEventArgs e)
        {
            Browser temp = browserControl.PopBrowser(e.TabIndex);

            DoDragDrop(temp, DragDropEffects.Copy);
        }

        private void TabControl_OrderChange(object sender, TabEventArgs e)
        {
            browserControl.OrderChange(e.TabOrigin, e.TabChanged);
        }

        private void TabControl_Click(object sender, TabEventArgs e)
        {
            int index = e.TabIndex;
            tabControl.ShowTab(index);
            browserControl.ShowBrowser(index);
        }

        public void AddBrowser(Browser arg)
        {
            browserControl.AddBrowser(arg);
            tabControl.AddNewTab(arg.Address);
        }
        public void AddBrowser(string address)
        {
            browserControl.AddBrowser(address);
            tabControl.AddNewTab(address);
        }
    }
}
