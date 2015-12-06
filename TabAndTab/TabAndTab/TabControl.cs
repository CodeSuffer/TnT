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
        public event EventHandler<TabEventArgs> OnTabOrderChange;
        public event EventHandler<TabEventArgs> OnTabClick;
        public event EventHandler<TabDragEventArgs> OnTabDraggedOut;
        public event DragEventHandler OnBrowserDragEnter;

        static private int tabMarginLeft = 5;
        private List<TabButton> tabs = new List<TabButton>();

        public TabControl()
        {
            InitializeComponent();
            this.DragEnter += TabControl_DragEnter;
            this.DragOver += TabControl_DragOver;
        }

        public TabButton GetTab(int index)
        {
            return tabs.ElementAt(index);
        }

        public void ShowTab(int index)
        {
            foreach (TabButton it in tabs)
            {
                it.imageChange(TabButton.ImageStatus.unclicked);
            }
            tabs[index].imageChange(TabButton.ImageStatus.clicked);
        }
        
        public void AddNewTab(string directory)
        {
            TabButton tab = new TabButton(directory);
            tab.MouseDown += Tab_MouseDown;
            tab.DragEnter += Tab_DragEnter;
            tab.DragOver += TabControl_DragOver;
            tab.QueryContinueDrag += Tab_QueryContinueDrag;
            tabs.Add(tab);
            this.Controls.Add(tab);
            TabRefresh();
        }

        private void Tab_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(TabButton))) return;
            TabButton data = (TabButton)e.Data.GetData(typeof(TabButton));
            if (data == (TabButton)sender) return;
            TabButton target = (TabButton)sender;

            int originIndex = tabs.IndexOf(data);
            int targetIndex = tabs.IndexOf(target);
            tabs.Remove(data);
            tabs.Insert(targetIndex, data);

            this.TabRefresh();
            OnTabOrderChange(sender, new TabEventArgs(originIndex, targetIndex));
        }

        private void TabControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabButton))) e.Effect = DragDropEffects.Move;
        }


        private void TabControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabButton)))
            {
                TabButton temp = (TabButton)e.Data.GetData(typeof(TabButton));
                if (tabs.First() != temp && e.X < this.PointToScreen(tabs.First().Location).X)  //left of tabs
                {
                    int originIndex = tabs.IndexOf(temp);
                    int targetIndex = 0;

                    tabs.Remove(temp);
                    tabs.Insert(targetIndex, temp);

                    this.TabRefresh();

                    OnTabOrderChange(sender, new TabEventArgs(originIndex, targetIndex));
                }
                else if (tabs.Last() != temp && e.X > this.PointToScreen(tabs.Last().Location).X + tabs.Last().Size.Width) //right of tabs
                {
                    int originIndex = tabs.IndexOf(temp);
                    int targetIndex = tabs.Count - 1;
                    tabs.Remove(temp);
                    tabs.Insert(targetIndex, temp);

                    this.TabRefresh();

                    OnTabOrderChange(sender, new TabEventArgs(originIndex, targetIndex));

                }
            }
            else if(e.Data.GetDataPresent(typeof(Browser))){
                this.OnBrowserDragEnter(sender, e);
            }
        }
        private void Tab_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
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
                tabs.Remove(tab);
                this.Controls.Remove(tab);
                TabRefresh();
                TabDragEventArgs dragEvent = new TabDragEventArgs(tab, mousePoint.X, mousePoint.Y, index);
                
                tab.QueryContinueDrag -= Tab_QueryContinueDrag;
                e.Action = DragAction.Cancel;
                OnTabDraggedOut(sender, dragEvent);
            }
        }

        private void Tab_MouseDown(object sender, MouseEventArgs e)
        {
            if(sender is TabButton)
            {
                Tab_Click(sender, e);

                TabButton tabButton = (TabButton)sender;
                var effect = tabButton.DoDragDrop(
                    tabButton, DragDropEffects.All);
            }
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            int index = tabs.IndexOf((TabButton)sender);

            TabEventArgs tabEvent = new TabEventArgs(index);

            this.OnTabClick(sender, tabEvent);
        }

        private void TabRefresh()
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                tabs[i].Location = new Point(tabMarginLeft + i * 109, 0);
            }
        }
    }
}
