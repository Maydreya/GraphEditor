using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class RectSelection : LineSelection
    {
        PointF memberPoint;

        public PointF UpperLeft;
        public PointF BottomLeft;
        public PointF UpperRight;
        public PointF BottomRight;

        public RectSelection(ref Frame frame) : base(ref frame)
        {
            UpperLeft.X = frame.x1;
            UpperLeft.Y = frame.y1;

            UpperRight.X = frame.x2;
            UpperRight.Y = frame.y1;

            BottomLeft.X = frame.x1;
            BottomLeft.Y = frame.y2;

            BottomRight.X = frame.x2;
            BottomRight.Y = frame.y2;
        }

        public override void Draw(Painter painter)
        {
            painter.DrawRectSelection(UpperLeft.X, UpperLeft.Y, BottomRight.X, BottomRight.Y);
        }

        public override bool isPointInMarker(PointF point)
        {
            if (TryGrab(point))
            {
                return true;
            }

            return false;
        }

        public override bool TryGrab(PointF point)
        {
            if (point.X >= BottomRight.X - 5 && point.X <= BottomRight.X + 5 && point.Y >= BottomRight.Y - 5 && point.Y <= BottomRight.Y + 5)
            {
                isBody = false;
                marker = frame.Marker4;
                return true;
            }

            if (point.X >= UpperRight.X - 5 && point.X <= UpperRight.X + 5 && point.Y >= UpperRight.Y - 5 && point.Y <= UpperRight.Y + 5)
            {
                isBody = false;
                marker = frame.Marker3;
                return true;
            }

            if (point.X >= BottomLeft.X - 5 && point.X <= BottomLeft.X + 5 && point.Y >= BottomLeft.Y - 5 && point.Y <= BottomLeft.Y + 5)
            {
                isBody = false;
                marker = frame.Marker2;
                return true;
            }

            if (point.X >= UpperLeft.X - 5 && point.X <= UpperLeft.X + 5 && point.Y >= UpperLeft.Y - 5 && point.Y <= UpperLeft.Y + 5)
            {
                isBody = false;
                marker = frame.Marker1;
                return true;
            }

            bool firstEcuation = point.X <= frame.x2 && point.X >= frame.x1 && point.Y <= frame.y2 && point.Y >= frame.y1;
            bool secondEcuation = point.X >= frame.x2 && point.X <= frame.x1 && point.Y >= frame.y2 && point.Y <= frame.y1;
            bool thirdEcuation = point.X <= frame.x2 && point.X >= frame.x1 && point.Y >= frame.y2 && point.Y <= frame.y1;
            bool fourthEcuation = point.X >= frame.x2 && point.X <= frame.x1 && point.Y <= frame.y2 && point.Y >= frame.y1;

            bool equationIsNull = firstEcuation || secondEcuation || thirdEcuation || fourthEcuation;

            if (equationIsNull)
            {
                isBody = true;
                memberPoint = point;
                marker = frame.Body;
                return true;
            }


            return false;
        }

        public override void DragTo(PointF point)
        {
            if (isBody)
            {
                point.X = point.X - memberPoint.X;
                point.Y = point.Y - memberPoint.Y;
            }
            marker(point);

            UpperLeft.X = frame.x1;
            UpperLeft.Y = frame.y1;

            UpperRight.X = frame.x1;
            UpperRight.Y = frame.y2;

            BottomLeft.X = frame.x2;
            BottomLeft.Y = frame.y1;

            BottomRight.X = frame.x2;
            BottomRight.Y = frame.y2;

            if (isBody)
            {
                point.X += memberPoint.X;
                point.Y += memberPoint.Y;
                memberPoint = point;
            }
        }
    }
}
