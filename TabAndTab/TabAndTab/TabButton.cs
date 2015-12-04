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
    public partial class TabButton : UserControl
    {
        static private Image imageHover;
        static private Image imageClicked;
        static private Image imageUnclicked;
        ImageStatus imageStatus;

        public enum ImageStatus
        {
            clicked, unclicked, hover
        }

        static TabButton()
        {
            imageHover = Properties.Resources.tab_mouseup;
            imageClicked = Properties.Resources.tab_clicked;
            imageUnclicked = Properties.Resources.tab_unclicked;
        }

        public TabButton()
        {
            InitializeComponent();
            
            imageChange(ImageStatus.unclicked);
            
            button.Click += new EventHandler(buttonMouseClick);
            button.MouseEnter += new EventHandler(buttonMouseHover);
            button.MouseLeave += new EventHandler(buttonMouseLeave);
        }

        public void imageChange(ImageStatus status)
        {
            if (status == ImageStatus.clicked)
            {
                imageStatus = ImageStatus.clicked;

                button.Image = imageClicked;
                button.Height = imageClicked.Height;
                button.Width = imageClicked.Width;
                button.Location = new Point(0, 0);
            }
            else if(status == ImageStatus.unclicked)
            {
                imageStatus = ImageStatus.unclicked;

                button.Image = imageUnclicked;
                button.Height = imageUnclicked.Height;
                button.Width = imageUnclicked.Width;
                button.Location = new Point(0, 2);
            }
            else if(status == ImageStatus.hover)
            {
                imageStatus = ImageStatus.hover;

                button.Image = imageHover;
                button.Height = imageHover.Height;
                button.Width = imageHover.Width;
                button.Location = new Point(0, 2);
            }
        }

        private void buttonMouseClick(object sender, EventArgs e)
        {
            if (imageStatus == ImageStatus.unclicked || imageStatus == ImageStatus.hover)
            {
                imageChange(ImageStatus.clicked);
            }
        }
        private void buttonMouseLeave(object sender, EventArgs e)
        {
            if(imageStatus == ImageStatus.hover)
            {
                imageChange(ImageStatus.unclicked);
            }
        }
        private void buttonMouseHover(object sender, EventArgs e)
        {
            if (imageStatus == ImageStatus.unclicked)
            {
                imageChange(ImageStatus.hover);
            }
        }
    }
}
