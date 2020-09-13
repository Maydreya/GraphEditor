using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Rect : AtomGraphItem
    {
        public Rect(Frame frame, PropBox propBox) : base(frame, propBox) { }

        public override void DrawBody(Painter painter)
        {
            painter.DrawRect(frame.x1, frame.y1, frame.x2, frame.y2);
        }

        public override Selection CreateSelection()
        {
            isRelease = true;
            return new RectSelection(ref frame);
        }

        public override bool isPointInBody(PointF point)
        {
            bool firstEcuation = point.X <= frame.x2 && point.X >= frame.x1 && point.Y <= frame.y2 && point.Y >= frame.y1;
            bool secondEcuation = point.X >= frame.x2 && point.X <= frame.x1 && point.Y >= frame.y2 && point.Y <= frame.y1;
            bool thirdEcuation = point.X <= frame.x2 && point.X >= frame.x1 && point.Y >= frame.y2 && point.Y <= frame.y1;
            bool fourthEcuation = point.X >= frame.x2 && point.X <= frame.x1 && point.Y <= frame.y2 && point.Y >= frame.y1;

            bool equationIsNull = firstEcuation || secondEcuation || thirdEcuation || fourthEcuation;

            if (equationIsNull)
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
        public override void Change()
        {
            
        }

        public override GraphItemList UnGroup()
        {
            return null;
        }
    }
}
