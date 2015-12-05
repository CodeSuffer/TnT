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
    public partial class BrowserControl : UserControl
    {
        private List<Browser> browsers = new List<Browser>();
        public BrowserControl()
        {
            InitializeComponent();
        }
        public void AddBrowser(Browser arg)
        {
            browsers.Add(arg);
            arg.Location = new Point(0, 0);
            arg.Dock = DockStyle.Fill;
            this.Controls.Add(arg);
            arg.Hide();
        }
        public void ShowBrowser(int index)
        {
            foreach (Browser it in browsers)
            {
                it.Hide();
            }
            browsers[index].Show();
        }
        public void OrderChange(int indexOrigin, int indexChanged)
        {
            Browser origin = browsers[indexOrigin];
            browsers.Remove(origin);
            browsers.Insert(indexChanged, origin);
        }
    }
}
