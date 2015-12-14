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

        private void BrowserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }

            MouseHookManager.UnSetHook();
        }

        public BrowserForm(Browser arg = null)
        {
            this.FormClosed += BrowserForm_FormClosed;
            InitializeComponent();
            if(arg != null) tabBrowser = new TabBrowser(arg);
            tabBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(tabBrowser);
        }

        public BrowserForm(string arg) : this(new Browser(arg))
        {
        }

        public void FormFollowMouse()
        {
            MouseHookManager.UnSetHook();
            MouseHookManager.OnMouseProc += MouseHookManager_OnMouseProc;
            MouseHookManager.OnMouseLeftUp += MouseHookManager_OnMouseLeftUp;
            MouseHookManager.SetHook();
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
            this.FormMoveToMouse();
        }

        private void MouseHookManager_OnMouseLeftUp(Point mouse)
        {
            MouseHookManager.UnSetHook();
            MouseHookManager.OnMouseProc -= MouseHookManager_OnMouseProc;
            MouseHookManager.OnMouseLeftUp -= MouseHookManager_OnMouseLeftUp;
        }

        public void FormMoveToMouse()
        {
            Point mousePoint = new Point(Control.MousePosition.X, Control.MousePosition.Y);
            this.FindForm().Location = new Point(mousePoint.X - 80, mousePoint.Y - 50);
        }
    }
}
