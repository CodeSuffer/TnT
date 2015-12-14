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
    public partial class ImageButton : UserControl
    {        
        //variables
        private Image imageHover;
        private Image imageClicked;
        private Image imageUnclicked;
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
                if (value == ImageStatus.clicked)
                    status = value;
            }
        }

        public enum ImageStatus
        {
            clicked, unclicked, hover
        }

        public ImageButton(Image hover, Image clicked, Image unclicked, string str)
        {
            InitializeComponent();
            
            imageHover = hover;
            imageClicked = clicked;
            imageUnclicked = unclicked;

            this.Height = imageClicked.Height;
            this.Width = imageClicked.Width;

            buttonText = str;
            labelButton.Top = imageClicked.Height / 2 - labelButton.Height / 2;
            labelButton.Left = 5;
            imageChange(ImageStatus.unclicked);

            button.Click += buttonClick;
            button.MouseDown += buttonMouseDown;
            button.MouseEnter += buttonMouseHover;
            button.MouseHover += buttonMouseHover;
            button.MouseLeave += buttonMouseLeave;
            labelButton.Click += buttonClick;
            labelButton.MouseDown += buttonMouseDown;
            labelButton.MouseEnter += buttonMouseHover;
            labelButton.MouseHover += buttonMouseHover;
            button.MouseMove += Button_MouseMove;
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            buttonMouseHover(sender, e);
        }

        public ImageButton(Image hover, Image clicked, Image unclicked, Image mouseout, string str) : this(hover, clicked, unclicked, str)
        {
            button.MouseLeave += Button_MouseLeave;
            button.MouseUp += Button_MouseLeave;
        }

        public void imageChange(ImageStatus status)
        {
            Image tempImage;
            if (status == ImageStatus.clicked) tempImage = imageClicked;
            else if (status == ImageStatus.unclicked) tempImage = imageUnclicked;
            else if (status == ImageStatus.hover) tempImage = imageHover;
            else return;

            button.Image = tempImage;
            button.Height = tempImage.Height;
            button.Width = tempImage.Width;
            button.Top = imageClicked.Height - tempImage.Height;
            this.status = status;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void buttonMouseDown(object sender, MouseEventArgs e)
        {
            if (status == ImageStatus.unclicked || status == ImageStatus.hover)
            {
                imageChange(ImageStatus.clicked);
            }
            OnMouseDown(e);
        }
        private void buttonMouseLeave(object sender, EventArgs e)
        {
            if (status == ImageStatus.hover)
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
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (status == ImageStatus.clicked)
            {
                imageChange(ImageStatus.unclicked);
            }
        }
    }
}