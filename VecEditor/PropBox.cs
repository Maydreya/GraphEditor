using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VecEditor
{
    class PropBox : List<Props>
    {
        public void SetParams(Painter painter)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].SetParams(painter);
            }
        }
    }
}
