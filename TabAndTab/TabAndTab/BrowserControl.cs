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
        }
        public void AddBrowser(string arg)
        {
            Browser temp = new Browser(arg);
            browsers.Add(temp);
            temp.Location = new Point(0, 0);
            temp.Dock = DockStyle.Fill;
            this.Controls.Add(temp);
        }
        public Browser PopBrowser(int index)
        {
            Browser origin = browsers.ElementAt(index);
            this.Controls.Remove(origin);
            browsers.RemoveAt(index);

            Browser newSource = browsers.ElementAtOrDefault(index);
            if (newSource == null)
            {
                newSource = browsers.ElementAtOrDefault(index - 1);
                if (newSource != null) 
                {
                    this.ShowBrowser(index - 1);
                }
            }
            else
            {
                this.ShowBrowser(index);
            }

            return origin;
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
        public int GetIndex(Browser arg)
        {
            return browsers.IndexOf(arg);
        }
        public Browser GetBrowser(int index)
        {
            return browsers.ElementAt(index);
        }
    }
}
