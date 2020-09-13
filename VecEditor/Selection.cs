using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    abstract class Selection
    {
        public delegate void Marker(PointF point);
        protected Frame frame;
        public Marker marker;
        protected bool isBody;
        public Selection(ref Frame frame)
        {
            this.frame = frame;
        }

        public abstract void Draw(Painter painter);

        public abstract bool isPointInMarker(PointF point);

        public abstract bool TryGrab(PointF point);

        public abstract void DragTo(PointF point);
    }
}
