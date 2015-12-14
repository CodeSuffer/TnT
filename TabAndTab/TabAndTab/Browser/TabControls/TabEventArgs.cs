/* Code By Codesuffer */
/* Computer Science 20143035 */
/* To OSS Team Project */
/* Class for Tab event argument */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabAndTab
{
    public class TabEventArgs : EventArgs
    {
        private int tabIndex;
        private int tabOrigin, tabChanged;
        
        public TabEventArgs(int index) : base()
        {
            TabIndex = index;
        }
        public TabEventArgs(int index1, int index2) : base()
        {
            TabOrigin = index1;
            TabChanged = index2;
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

        public int TabOrigin
        {
            get
            {
                return tabOrigin;
            }

            set
            {
                tabOrigin = value;
            }
        }

        public int TabChanged
        {
            get
            {
                return tabChanged;
            }

            set
            {
                tabChanged = value;
            }
        }
    }
}
