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
        public delegate void TabOrderChangeHandler(object sender, EventArgs e);
        public event TabOrderChangeHandler OnTabOrderChange;

        static private int tabMarginLeft = 5;
        private List<TabButton> tabs = new List<TabButton>();

        public TabControl()
        {
            InitializeComponent();
            this.DragEnter += TabControl_DragEnter;
        }
        
        private void Tab_Click(object sender, EventArgs e)
        {
            int index = tabs.IndexOf((TabButton)sender);

            TabEventArgs tabEvent = new TabEventArgs(index);

            this.OnClick(tabEvent);

            foreach (TabButton it in tabs)
            {
                it.imageChange(TabButton.ImageStatus.unclicked);
            }
            tabs[index].imageChange(TabButton.ImageStatus.clicked);
        }

        public void AddNewTab(string directory)
        {
            TabButton tab = new TabButton(directory);
            tab.Location = new Point(tabMarginLeft + tabs.Count * 109, 0);
            tab.MouseDown += Tab_MouseDown;
            tab.DragEnter += Tab_DragEnter;
            this.Controls.Add(tab);
            tabs.Add(tab);
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

        private void TabControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabButton)))
            {
                if (e.X < this.PointToScreen(tabs.First().Location).X)  //left of tabs
                {
                    TabButton temp = (TabButton)e.Data.GetData(typeof(TabButton));
                    int originIndex = tabs.IndexOf(temp);
                    int targetIndex = 0;

                    tabs.Remove(temp);
                    tabs.Insert(targetIndex, temp);

                    this.TabRefresh();

                    OnTabOrderChange(sender, new TabEventArgs(originIndex, targetIndex));
                }
                else if(e.X > this.PointToScreen(tabs.Last().Location).X + tabs.Last().Size.Width) //right of tabs
                {
                    TabButton temp = (TabButton)e.Data.GetData(typeof(TabButton));
                    int originIndex = tabs.IndexOf(temp);
                    int targetIndex = tabs.Count-1;
                    tabs.Remove(temp);
                    tabs.Insert(targetIndex, temp);

                    this.TabRefresh();

                    OnTabOrderChange(sender, new TabEventArgs(originIndex, targetIndex));

                }
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

        private void TabRefresh()
        {
            for(int i=0; i<tabs.Count; i++)
            {
                tabs[i].Location = new Point(tabMarginLeft + i * 109, 0);
            }
        }
    }
}
