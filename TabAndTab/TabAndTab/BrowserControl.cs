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
        public delegate void TitleChangeEventHandler(object sender, int index, string title);
        public event TitleChangeEventHandler onTitleChanging;
        int activeBrowserIndex;

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
            arg.onTitleChanging += Browser_onTitleChanging;
            this.Controls.Add(arg);
        }

        private void Browser_onTitleChanging(object sender, string e)
        {
            BrowserForm tempForm = ((BrowserForm)(sender as Control).FindForm());
            onTitleChanging(sender, tempForm.TabBrowser.BrowserControl.GetIndex((Browser)sender), e);
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
            activeBrowserIndex = index;
        }
        public void OrderChange(int indexOrigin, int indexChanged)
        {
            Browser origin = browsers[indexOrigin];
            browsers.Remove(origin);
            browsers.Insert(indexChanged, origin);
            activeBrowserIndex = indexChanged;
        }
        public int GetIndex(Browser arg)
        {
            return browsers.IndexOf(arg);
        }
        public Browser GetBrowser(int index)
        {
            return browsers.ElementAt(index);
        }
        public Browser GetNowBrowser()
        {
            return browsers.ElementAt(activeBrowserIndex);
        }
    }
}
