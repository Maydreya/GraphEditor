using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class LineSelection : Selection
    {
        PointF memberPoint;

        public PointF StartPoint;
        public PointF EndPoint;

        public LineSelection(ref Frame frame) : base(ref frame)
        {
            StartPoint.X = frame.x1;
            StartPoint.Y = frame.y1;

            EndPoint.X = frame.x2;
            EndPoint.Y = frame.y2;
        }

        public override void Draw(Painter painter)
        {
            painter.DrawLineSelection(StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
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
            if (point.X >= EndPoint.X - 5 && point.X <= EndPoint.X + 5 && point.Y >= EndPoint.Y - 5 && point.Y <= EndPoint.Y + 5)
            {
                marker = frame.Marker4;
                isBody = false;
                return true;
            }

            if (point.X >= StartPoint.X - 5 && point.X <= StartPoint.X + 5 && point.Y >= StartPoint.Y - 5 && point.Y <= StartPoint.Y + 5)
            {
                marker = frame.Marker1;
                isBody = false;
                return true;
            }


            // Line equation: y = kx + b 
            int minY, minX, maxY, maxX;
            if (frame.y1 > frame.y2) maxY = (int)frame.y1;
            else maxY = (int)frame.y2;
            if (frame.x1 > frame.x2) maxX = (int)frame.x1;
            else maxX = (int)frame.x2;
            if (frame.x1 < frame.x2) minX = (int)frame.x1;
            else minX = (int)frame.x2;
            if (frame.y1 < frame.y2) minY = (int)frame.y1;
            else minY = (int)frame.y2;


            // Calculate k 
            float k = 0;
            // If we got vertical line 
            if (frame.x2 == frame.x1)
            {
                k = 1;
            }
            // If we got horizontal line 
            else if (frame.y2 == frame.y1) k = 1;
            else k = (float)(frame.y2 - frame.y1) / (frame.x2 - frame.x1);


            // Calculate b 
            float b = 0;
            if (k == 1.0f) b = minY;
            else b = frame.y2 - frame.x2 * k;


            // Hit error = Hit +- eps 
            int eps = 30;


            int CalculatedY = (int)(k * point.X + b);


            // Check if we are in object range 
            if ((point.X >= (minX - eps)) && (point.X <= (maxX + eps)) && (point.Y >= (minY - eps)) && (point.Y <= (maxY + eps)))
            {
                if ((point.Y >= (CalculatedY - eps)) && (point.Y <= (CalculatedY + eps)))
                {
                    isBody = true;
                    memberPoint = point;
                    marker = frame.Body;
                    return true;
                }
            }

            return false;
        }

        public override void DragTo(PointF point)
        {
            if (isBody)
            {
                point.X -= memberPoint.X;
                point.Y -= memberPoint.Y;
            }
                marker(point);

            StartPoint.X = frame.x1;  
            StartPoint.Y = frame.y1;

            EndPoint.X = frame.x2;
            EndPoint.Y = frame.y2;

            if (isBody)
            {
                point.X += memberPoint.X;
                point.Y += memberPoint.Y;
                memberPoint = point;
            }
        }
    }
}
