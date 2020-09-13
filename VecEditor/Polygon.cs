using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Polygon : GraphItem
    {
        public Polygon(Frame frame, List<PointF> point) : base(frame, point)
        {
            this.point = point;
        }
        

        public override void Change()
        {
            
        }

        public override Selection CreateSelection()
        {
            isRelease = true;
            return new RectSelection(ref frame);
        }

        public override void Draw(Painter painter)
        {
            painter.Polygon(point);
        }

        public override bool isPointInBody(PointF point)
        {
            return true;
        }

        public override GraphItemList UnGroup()
        {
            return null;
        }
        public override void DragBody(float dx, float dy)
        {
            
        }
    }
}
