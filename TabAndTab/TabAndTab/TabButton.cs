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

        //variables
        static private Image imageHover;
        static private Image imageClicked;
        static private Image imageUnclicked;
        private ImageStatus status;
        private string buttonText;

        //properties
        public string ButtonText
        {
            get
            {
                return buttonText;
            }

            set
            {
                buttonText = value;
                labelButton.Text = value;
            }
        }

        public ImageStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                if(value == ImageStatus.clicked)
                status = value;
            }
        }

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
            
            button.MouseDown += new MouseEventHandler(buttonMouseDown);
            button.MouseEnter += new EventHandler(buttonMouseHover);
            button.MouseHover += new EventHandler(buttonMouseHover);
            button.MouseLeave += new EventHandler(buttonMouseLeave);
            labelButton.MouseDown += new MouseEventHandler(buttonMouseDown);
            labelButton.MouseEnter += new EventHandler(buttonMouseHover);
            labelButton.MouseHover += new EventHandler(buttonMouseHover);
        }

        public TabButton(string text) : this()
        {
            ButtonText = text;
        }

        public void imageChange(ImageStatus status)
        {
            if (status == ImageStatus.clicked)
            {
                this.status = ImageStatus.clicked;

                button.Image = imageClicked;
                button.Height = imageClicked.Height;
                button.Width = imageClicked.Width;
                button.Location = new Point(0, 0);

                this.BringToFront();
            }
            else if(status == ImageStatus.unclicked)
            {
                this.status = ImageStatus.unclicked;

                button.Image = imageUnclicked;
                button.Height = imageUnclicked.Height;
                button.Width = imageUnclicked.Width;
                button.Location = new Point(0, 2);
            }
            else if(status == ImageStatus.hover)
            {
                this.status = ImageStatus.hover;

                button.Image = imageHover;
                button.Height = imageHover.Height;
                button.Width = imageHover.Width;
                button.Location = new Point(0, 2);
            }
        }

        private void buttonMouseDown(object sender, MouseEventArgs e)
        {
            if (status == ImageStatus.unclicked || status == ImageStatus.hover)
            {
                imageChange(ImageStatus.clicked);
            }
            this.OnMouseDown(e);
        }
        private void buttonMouseLeave(object sender, EventArgs e)
        {
            if(status == ImageStatus.hover)
            {
                imageChange(ImageStatus.unclicked);
            }
        }
        private void buttonMouseHover(object sender, EventArgs e)
        {
            if (status == ImageStatus.unclicked)
            {
                imageChange(ImageStatus.hover);
            }
        }
    }
}
