using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TabAndTab
{
    public partial class TabBrowser : UserControl
    {
        private BrowserControl browserControl = new BrowserControl();
        private TabControl tabControl = new TabControl();
        public TabControl TabControl
        {
            get
            {
                return tabControl;
            }

            set
            {
                tabControl = value;
            }
        }

        public BrowserControl BrowserControl
        {
            get
            {
                return browserControl;
            }

            set
            {
                browserControl = value;
            }
        }

        public TabBrowser()
        {
            InitializeComponent();
            this.tabSpliter.Panel1.Controls.Add(tabControl);
            browserControl.Dock = DockStyle.Fill;
            this.tabSpliter.Panel2.Controls.Add(browserControl);
            tabControl.Dock = DockStyle.Fill;
            tabControl.OnTabMouseDown += TabControl_MouseDown;
            tabControl.OnTabOrderChange += TabControl_OrderChange;
            tabControl.OnTabDraggedOut += TabControl_DraggedOut;
            tabControl.OnOneTabDragged += TabControl_OneTabDragged;
            tabControl.DragDrop += TabControl_DragDrop;
            tabControl.NoTabExist += TabControl_NoTabExist;
            tabControl.OnTabCloseButtonClick += TabControl_OnTabCloseButtonClick;
            browserControl.onTitleChanging += BrowserControl_onTitleChanging;
        }

        private void TabControl_OnTabCloseButtonClick(object sender, TabIndex e)
        {
            if((sender as Control).FindForm() != null) browserControl.PopBrowser(e);
        }

        private void TabControl_NoTabExist(object sender)
        {
            this.FindForm().Close();
        }

        public TabBrowser(Browser arg) : this()
        {
            this.AddBrowser(arg);
        }

        public TabBrowser(string arg) : this()
        {
            this.AddBrowser(arg);
        }

        private void BrowserControl_onTitleChanging(object sender, int index, string title)
        {
            BrowserForm tempForm = (sender as Control).FindForm() as BrowserForm;
            tempForm.TabBrowser.tabControl.SetTabText(index, title);
        }

        public void BrowserIn(Browser arg)
        {
            Form tempForm = arg.FindForm();
            arg.QueryContinueDrag -= Browser_QueryContinueDrag;
            this.AddBrowser(arg);
            
            int index = this.browserControl.GetIndex(arg);
            this.browserControl.ShowBrowser(index);
            tabControl.ShowTab(index);
            tempForm.Close();
            tabControl.GetTab(index).DoDragDrop(new TabIndex(index), DragDropEffects.Move);
        }

        private void TabControl_DraggedOut(object sender, TabDragEventArgs e)
        {
            Browser temp = browserControl.PopBrowser(e.TabIndex);
            BrowserForm browserForm = new BrowserForm(temp);
            browserForm.Show();
            ((BrowserForm)temp.FindForm()).FormFollowMouse();
            temp.QueryContinueDrag += Browser_QueryContinueDrag;
            temp.DoDragDrop(temp, DragDropEffects.Copy);
        }

        private void Browser_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            try
            {
                BrowserForm tempForm = (sender as Control).FindForm() as BrowserForm;
                foreach (BrowserForm it in Application.OpenForms)
                {
                    if (it == tempForm) continue;
                    TabControl target = it.TabBrowser.TabControl;

                    int left = target.PointToScreen(new Point(0, 0)).X;
                    int right = left + target.Size.Width;
                    int top = target.PointToScreen(new Point(0, 0)).Y;
                    int bottom = top + target.Size.Height;
                    Point mousePoint = Control.MousePosition;

                    if (left < mousePoint.X //dragged out
                        && mousePoint.X < right
                        && top < mousePoint.Y
                        && mousePoint.Y < bottom)
                    {
                        it.TabBrowser.BrowserIn((Browser)sender);
                        tempForm.TabBrowser.browserControl.PopBrowser(tempForm.TabBrowser.browserControl.GetIndex((Browser)sender));
                        ((Browser)sender).QueryContinueDrag -= Browser_QueryContinueDrag;
                    }
                }
            }
            catch (System.InvalidOperationException)
            {
                Browser_QueryContinueDrag(sender, e);
            }
        }

        private void TabControl_OneTabDragged(object sender, MouseEventArgs e)
        {
            Browser temp = browserControl.GetBrowser(0);
            ((BrowserForm)temp.FindForm()).FormFollowMouse();
            temp.QueryContinueDrag += Browser_QueryContinueDrag;
            temp.DoDragDrop(temp, DragDropEffects.Copy);
        }

        private void TabControl_OrderChange(object sender, TabEventArgs e)
        {
            browserControl.OrderChange(e.TabOrigin, e.TabChanged);
        }

        private void TabControl_MouseDown(object sender, TabEventArgs e)
        {
            int index = e.TabIndex;
            this.ShowPage(index);
        }

        private void TabControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] temp = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filename in temp)
                {
                    this.AddBrowser(filename);
                }
            }
        }

        public void AddBrowser(Browser arg)
        {
            browserControl.AddBrowser(arg);
            tabControl.AddNewTab(arg.Title);
            ShowPage(browserControl.GetIndex(arg));
        }
        public void AddBrowser(string address)
        {
            this.AddBrowser(new Browser(address));
        }

        public void ShowPage(int index)
        {
            tabControl.ShowTab(index);
            browserControl.ShowBrowser(index);
        }

    }
}
