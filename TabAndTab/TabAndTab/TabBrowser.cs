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
            tabControl.OnBrowserDragEnter += TabControl_BrowserDragEnter;
            tabControl.OnOneTabDragged += TabControl_OneTabDragged;
        }


        public TabBrowser(Browser arg) : this()
        {
            AddBrowser(arg);
        }

        private void TabControl_BrowserDragEnter(object sender, DragEventArgs e)
        {
            Browser temp = (Browser)e.Data.GetData(typeof(Browser));
            
            this.AddBrowser(temp);
            
            int index = browserControl.GetIndex(temp);
            browserControl.ShowBrowser(index);
            tabControl.ShowTab(index);
            
            tabControl.GetTab(index).DoDragDrop(new TabIndex(index), DragDropEffects.Move);
        }
        
        private void TabControl_DraggedOut(object sender, TabDragEventArgs e)
        {
            Browser temp = browserControl.PopBrowser(e.TabIndex);
            BrowserForm browserForm = new BrowserForm(temp);
            browserForm.Show();
            ((BrowserForm)temp.FindForm()).TabBrowser.FormFollowMouse();
            //temp.DoDragDrop(temp, DragDropEffects.Copy);

        }

        private void MouseHookManager_OnMouseProc(Point mouse)
        {
            Form temp = this.FindForm();
            if (temp == null)
            {
                MouseHookManager.OnMouseProc -= MouseHookManager_OnMouseProc;
                MouseHookManager.OnMouseLeftUp -= MouseHookManager_OnMouseLeftUp;
                return;
            }
            Point mousePoint = new Point(mouse.X, mouse.Y);
            temp.Location = new Point(mousePoint.X - 60, mousePoint.Y - 105);
        }

        private void TabControl_OneTabDragged(object sender, MouseEventArgs e)
        {
            Browser temp = browserControl.GetBrowser(0);
            ((BrowserForm)temp.FindForm()).TabBrowser.FormFollowMouse();
            temp.DoDragDrop(temp, DragDropEffects.Copy);
        }

        private void TabControl_OrderChange(object sender, TabEventArgs e)
        {
            browserControl.OrderChange(e.TabOrigin, e.TabChanged);
        }

        private void TabControl_MouseDown(object sender, TabEventArgs e)
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

        private void FormFollowMouse()
        {
            MouseHookManager.UnSetHook();
            MouseHookManager.OnMouseProc += MouseHookManager_OnMouseProc;
            MouseHookManager.OnMouseLeftUp += MouseHookManager_OnMouseLeftUp;
            MouseHookManager.SetHook();
        }

        private void MouseHookManager_OnMouseLeftUp(Point mouse)
        {
            MouseHookManager.OnMouseProc -= MouseHookManager_OnMouseProc;
            MouseHookManager.OnMouseLeftUp -= MouseHookManager_OnMouseLeftUp;
            MouseHookManager.UnSetHook();
        }
    }
}
