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
    public partial class TabControl : UserControl
    {
        public delegate void TabSelectHandler(object sender, TabIndex e);
        public event EventHandler<TabEventArgs> OnTabOrderChange;
        public event EventHandler<TabEventArgs> OnTabMouseDown;
        public event TabSelectHandler OnTabCloseButtonClick;
        public event EventHandler<TabDragEventArgs> OnTabDraggedOut;
        public event DragEventHandler OnBrowserDragEnter;
        public event MouseEventHandler OnOneTabDragged;
        public delegate void NothingHandler(object sender);
        public event NothingHandler NoTabExist;

        static private int tabMarginLeft = 1;
        private List<TabButton> tabs = new List<TabButton>();
        private ImageButton addTabButton = new ImageButton(Properties.Resources.button_add_mouseup, Properties.Resources.button_add_clicked, Properties.Resources.button_add, Properties.Resources.button_add, "");

        public int Count
        {
            get
            {
                return tabs.Count;
            }
        }

        public TabControl()
        {
            InitializeComponent();
            this.DragEnter += TabControl_DragEnter;
            this.DragOver += TabControl_DragOver;
            this.AllowDrop = true;
            this.Controls.Add(addTabButton);
            this.addTabButton.Click += AddTabButton_Click;
        }

        private void AddTabButton_Click(object sender, EventArgs e)
        {
            ((sender as Control).FindForm() as BrowserForm).TabBrowser.AddBrowser(@"C:\");
        }

        public TabButton GetTab(int index)
        {
            return tabs.ElementAt(index);
        }

        public void ShowTab(int index)
        {
            foreach (TabButton it in tabs)
            {
                it.imageChange(ImageButton.ImageStatus.unclicked);
            }
            tabs[index].imageChange(ImageButton.ImageStatus.clicked);
        }

        public void SetTabText(int index, string text)
        {
            TabButton tab = tabs.ElementAt(index);
            tab.ButtonText = text;
        }
        
        public void AddNewTab(string directory)
        {
            TabButton tab = new TabButton(directory);
            tab.MouseDown += Tab_MouseDown;
            tab.DragEnter += Tab_DragEnter;
            tab.DragOver += TabControl_DragOver;
            tab.OnClickX += Tab_OnClickX;
            tabs.Add(tab);
            this.Controls.Add(tab);
            TabRefresh();
            tab.QueryContinueDrag += Tab_QueryContinueDrag;
        }

        private void Tab_OnClickX(object sender, EventArgs e)
        {
            if (this.OnTabCloseButtonClick != null) this.OnTabCloseButtonClick(sender, new TabIndex(tabs.IndexOf(sender as TabButton)));
            this.RemoveTab(sender as TabButton);
        }

        private void Tab_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(TabIndex))) return;
            int originIndex = (TabIndex)e.Data.GetData(typeof(TabIndex));
            TabButton data = tabs.ElementAt(originIndex);

            if (data == (TabButton)sender) return;
            TabButton target = (TabButton)sender;
            int targetIndex = tabs.IndexOf(target);

            tabs.Remove(data);
            tabs.Insert(targetIndex, data);

            e.Data.SetData(typeof(TabIndex), new TabIndex(targetIndex));
            this.TabRefresh();
            OnTabOrderChange(sender, new TabEventArgs(originIndex, targetIndex));
        }

        private void TabControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabIndex))) e.Effect = DragDropEffects.Move;
        }


        private void TabControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabIndex)))
            {
                int originIndex = (TabIndex)e.Data.GetData(typeof(TabIndex));
                int targetIndex = -1;
                TabButton temp = tabs.ElementAt(originIndex);
                if (tabs.First() != temp && e.X < this.PointToScreen(tabs.First().Location).X)  //left of tabs
                    targetIndex = 0;
                else if (tabs.Last() != temp && e.X > this.PointToScreen(tabs.Last().Location).X + tabs.Last().Size.Width) //right of tabs
                    targetIndex = tabs.Count - 1;

                if (targetIndex != -1)
                {
                    tabs.Remove(temp);
                    tabs.Insert(targetIndex, temp);

                    this.TabRefresh();

                    OnTabOrderChange(sender, new TabEventArgs(originIndex, targetIndex));
                }
            }
            else if(e.Data.GetDataPresent(typeof(Browser))){
                if(OnBrowserDragEnter != null) OnBrowserDragEnter(sender, e);
            }
            else if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void Tab_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (tabs.Count == 1) return;
            int left = this.PointToScreen(this.Location).X;
            int right = left + this.Size.Width;
            int top = this.PointToScreen(this.Location).Y;
            int bottom = top + this.Size.Height;
            Point mousePoint = Control.MousePosition;

            if (left > mousePoint.X //dragged out
                || mousePoint.X > right
                || top > mousePoint.Y
                || mousePoint.Y > bottom)
            {
                TabButton tab = (TabButton)sender;
                int index = tabs.IndexOf(tab);
                TabDragEventArgs dragEvent = new TabDragEventArgs(mousePoint.X, mousePoint.Y, index); // drag info

                RemoveTab(tab);

                TabRefresh();
                
                tab.QueryContinueDrag -= Tab_QueryContinueDrag;
                e.Action = DragAction.Cancel;
                OnTabDraggedOut(sender, dragEvent);
            }
        }

        private void Tab_MouseDown(object sender, MouseEventArgs e)
        {
            if (tabs.Count > 1)
            {
                int index = tabs.IndexOf((TabButton)sender);
                TabEventArgs tabEvent = new TabEventArgs(index);

                this.OnTabMouseDown(sender, tabEvent);

                TabButton tabButton = (TabButton)sender;
                var effect = tabButton.DoDragDrop(
                    new TabIndex(tabs.IndexOf(tabButton)), DragDropEffects.All);
            }
            else
            {
                this.OnOneTabDragged(sender, e);
            }
        }

        private void TabRefresh()
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                tabs[i].Location = new Point(tabMarginLeft + i * (tabs[i].Size.Width - 1), this.Height - this.tabs[i].Size.Height);
            }

            int width = 0;
            if(tabs.Count != 0)
            {
                width = tabMarginLeft + tabs.Count * (tabs[0].Size.Width - 1);
            }
            else
            {
                width = 0;
            }
            addTabButton.Location = new Point(width + 5, 3);
        }

        public void RemoveTab(TabButton tab)
        {
            int index = tabs.IndexOf(tab);
            tabs.Remove(tab);
            this.Controls.Remove(tab);

            TabButton temp = tabs.ElementAtOrDefault(index);
            if (temp == null)
            {
                temp = tabs.ElementAtOrDefault(--index);
            }
            if (temp == null)
            {
                if(this.NoTabExist != null) this.NoTabExist(tab);

                TabRefresh();
                return;
            }

            this.ShowTab(index);
            this.
            TabRefresh();
        }
    }
}
