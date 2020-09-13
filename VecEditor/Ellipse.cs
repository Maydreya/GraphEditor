using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Ellipse : AtomGraphItem
    {
        public Ellipse(Frame frame, PropBox propBox) : base(frame, propBox) { }

        public override void DrawBody(Painter painter)
        {
            painter.DrawEllipse(frame.x1, frame.y1, frame.x2, frame.y2);
        }
        public override void Change()
        {
        }

        public override Selection CreateSelection()
        {
            isRelease = true;
            return new RectSelection(ref frame);
        }

        public override bool isPointInBody(PointF point)
        {
            PointF centre = new PointF((frame.x2 + frame.x1) / 2, (frame.y2 + frame.y1) / 2);

            bool ecuationIsNull = Math.Pow(point.X - centre.X, 2) / Math.Pow(((frame.x2 - frame.x1) / 2), 2) + Math.Pow(point.Y - centre.Y, 2) / Math.Pow(((frame.y2 - frame.y1) / 2), 2) <= 1;

            if (ecuationIsNull)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void DragBody(float dx, float dy)
        {

        }

        public override GraphItemList UnGroup()
        {
            return null;
        }
    }
}
