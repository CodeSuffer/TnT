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
        static private int tabMarginLeft = 5; 
        private List<TabButton> tabs = new List<TabButton>();
        private List<Browser> browsers = new List<Browser>();

        public TabBrowser()
        {
            InitializeComponent();
            AddBrowser(new Browser("test1"));
            AddBrowser(new Browser("test2"));
            AddBrowser(new Browser("test3"));
        }

        private void tab_Click(object sender, EventArgs e)
        {
            int index = tabs.IndexOf((TabButton)sender);
            foreach(Browser it in browsers)
            {
                it.Hide();
            }
            browsers[index].Show();


            foreach (TabButton it in tabs)
            {
                it.imageChange(TabButton.ImageStatus.unclicked);
            }
            tabs[index].imageChange(TabButton.ImageStatus.clicked);
        }

        public TabBrowser(Browser arg) : this()
        {
            AddBrowser(arg);
        }

        public void AddBrowser(Browser arg)
        {
            browsers.Add(arg);
            AddNewTab(arg.Address);
            arg.Location = new Point(0, 0);
            this.tabSpliter.Panel2.Controls.Add(arg);
            arg.Hide();
        }

        public void AddNewTab(string directory)
        {
            TabButton tab = new TabButton(directory);

            tab.Location = new Point(tabMarginLeft + tabs.Count * 109, 0);
            tab.Click += tab_Click;
            tabSpliter.Panel1.Controls.Add(tab);
            tabs.Add(tab);
        }
    }
}
