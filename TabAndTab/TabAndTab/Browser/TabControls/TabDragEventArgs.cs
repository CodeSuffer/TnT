/* Code By Codesuffer */
/* Computer Science 20143035 */
/* To OSS Team Project */
/* Class for TabButton Drag Event arguments */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabAndTab
{
    public class TabDragEventArgs : EventArgs
    {
        private Point location;
        private int tabIndex;

        public Point Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public int X
        {
            get
            {
                return location.X;
            }

            set
            {
                location.X = value;
            }
        }

        public int Y
        {
            get
            {
                return location.Y;
            }

            set
            {
                location.Y = value;
            }
        }

        public int TabIndex
        {
            get
            {
                return tabIndex;
            }

            set
            {
                tabIndex = value;
            }
        }

        public TabDragEventArgs(int X, int Y, int tabIndex) : base()
        {
            this.X = X;
            this.Y = Y;
            this.tabIndex = tabIndex;
        }
    }
}
