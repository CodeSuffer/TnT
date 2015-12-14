/* Code By Codesuffer */
/* Computer Science 20143035 */
/* To OSS Team Project */
/* Class for control a tab button */

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
        static private Image imageXHover;
        static private Image imageXClicked;
        static private Image imageXUnclicked;

        private ImageButton button;
        private ImageButton buttonX;

        public event EventHandler OnClickX;

        //properties
        public string ButtonText
        {
            get
            {
                return button.ButtonText;
            }

            set
            {
                button.ButtonText = value;
            }
        }

        static TabButton()
        {
            imageHover = Properties.Resources.tab_mouseup;
            imageClicked = Properties.Resources.tab_clicked;
            imageUnclicked = Properties.Resources.tab_unclicked;
            imageXHover = Properties.Resources.button_x_hover;
            imageXClicked = Properties.Resources.button_x_click;
            imageXUnclicked = Properties.Resources.button_x;
        }

        public TabButton()
        {
            InitializeComponent();

            this.Height = imageClicked.Height;
            this.Width = imageClicked.Width;

            button = new ImageButton(imageHover, imageClicked, imageUnclicked, "");
            button.Location = new Point(0, 0);
            this.Controls.Add(button);
            buttonX = new ImageButton(imageXHover, imageXClicked, imageXUnclicked, imageXUnclicked, "");
            buttonX.Location = new Point(this.Width - imageXClicked.Width - 5, 5);
            this.Controls.Add(buttonX);
            buttonX.BringToFront();

            button.MouseDown += Button_MouseDown;
            buttonX.Click += ButtonX_Click;
        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            if (OnClickX != null) OnClickX(this, e);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        public TabButton(string text) : this()
        {
            button.ButtonText = text;
            ButtonText = text;
        }

        public void imageChange(ImageButton.ImageStatus status)
        {
            button.imageChange(status);
        }
    }
}
