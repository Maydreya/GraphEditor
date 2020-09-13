using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace VecEditor
{
    class SelectionStore : List<Selection>
    {
        public void DrawSelection(Painter painter)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].Draw(painter);
            }
        }

        public bool isPointInMarker(PointF point)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].isPointInMarker(point))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryGrab(PointF point)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].TryGrab(point))
                {
                    return true;
                }
            }

            return false;
        }

        public void DragTo(PointF point)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].DragTo(point);
            }
        }
    }
}
