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

        public TabBrowser TabBrowser
        {
            get
            {
                return tabBrowser;
            }

            set
            {
                tabBrowser = value;
            }
        }

        public BrowserForm()
        {
            this.FormClosed += BrowserForm_FormClosed;
            InitializeComponent();
            tabBrowser = new TabBrowser();
            tabBrowser.Dock = DockStyle.Fill;
            tabBrowser.AddBrowser("111111");
            tabBrowser.AddBrowser("222222");
            tabBrowser.AddBrowser("333333");
            this.menuSplitContainer.Panel2.Controls.Add(tabBrowser);
        }

        private void BrowserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }

            MouseHookManager.UnSetHook();
        }

        public BrowserForm(Browser arg)
        {
            this.FormClosed += BrowserForm_FormClosed;
            InitializeComponent();
            tabBrowser = new TabBrowser();
            tabBrowser.Dock = DockStyle.Fill;
            tabBrowser.AddBrowser(arg);
            this.menuSplitContainer.Panel2.Controls.Add(tabBrowser);
        }
    }
}
