/* Code By Codesuffer */
/* Computer Science 20143035 */
/* To OSS Team Project */
/* Class for TabIndex. (just replace int) */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabAndTab
{
    public class TabIndex
    {
        int index;

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public TabIndex(int index)
        {
            this.index = index;
        }

        public static implicit operator int(TabIndex i)
        {
            if (i == null) return -1;
            else return i.Index;
        }
    }
}
