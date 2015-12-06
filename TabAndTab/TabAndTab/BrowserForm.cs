using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabAndTab
{
    public partial class BrowserForm : Form
    {
        TabBrowser tabBrowser;
        public BrowserForm()
        {
            InitializeComponent();
            tabBrowser = new TabBrowser();
            tabBrowser.Dock = DockStyle.Fill;
            tabBrowser.AddBrowser("111111");
            tabBrowser.AddBrowser("222222");
            tabBrowser.AddBrowser("333333");
            this.menuSplitContainer.Panel2.Controls.Add(tabBrowser);
        }
    }
}
