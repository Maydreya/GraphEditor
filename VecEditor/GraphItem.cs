using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    abstract class GraphItem
    {
        public GraphItem(Frame frame)
        {
            this.frame = frame;
        }
        public bool isRelease { get; set; } = false;

        public Frame frame;

        public Frame Frame { get { return frame; } }

        public List<PointF> point { get; set; }

        public abstract void Draw(Painter painter);
        public abstract Selection CreateSelection();

        public abstract void Change();
        public abstract void DragBody(float dx, float dy);

        public abstract bool isPointInBody(PointF point);



        public abstract GraphItemList UnGroup();

        public GraphItem(Frame frame, List<PointF> point)
        {
            this.frame = frame;
            this.point = point;
        }
    }
}
