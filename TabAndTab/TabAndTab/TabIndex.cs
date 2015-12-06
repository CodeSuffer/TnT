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

        TabIndex(int index)
        {
            this.index = index;
        }

        public static implicit operator int(TabIndex i)
        {
            return i.Index;
        }
    }
}
