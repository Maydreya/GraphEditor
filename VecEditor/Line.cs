using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Line : AtomGraphItem
    {
        public Line(Frame frame, PropBox propBox) : base(frame, propBox) { }

        public override void DrawBody(Painter painter)
        {
            painter.DrawLine(frame.x1, frame.y1, frame.x2, frame.y2);
        }

        public override Selection CreateSelection()
        {
            isRelease = true;
            return new LineSelection(ref frame);
        }

        public override bool isPointInBody(PointF point)
        {
            // Line equation: y = kx + b 
            int minY, minX, maxY, maxX;
            if (Frame.y1 > Frame.y2) maxY = (int)Frame.y1;
            else maxY = (int)Frame.y2;
            if (Frame.x1 > Frame.x2) maxX = (int)Frame.x1;
            else maxX = (int)Frame.x2;
            if (Frame.x1 < Frame.x2) minX = (int)Frame.x1;
            else minX = (int)Frame.x2;
            if (Frame.y1 < Frame.y2) minY = (int)Frame.y1;
            else minY = (int)Frame.y2;


            // Calculate k 
            float k = 0;
            // If we got vertical line 
            if (Frame.x2 == Frame.x1)
            {
                k = 1;
            }
            // If we got horizontal line 
            else if (Frame.y2 == Frame.y1) k = 1;
            else k = (float)(Frame.y2 - Frame.y1) / (Frame.x2 - Frame.x1);


            // Calculate b 
            float b = 0;
            if (k == 1.0f) b = minY;
            else b = Frame.y2 - Frame.x2 * k;


            // Hit error = Hit +- eps 
            int eps = 30;


            int CalculatedY = (int)(k * point.X + b);


            // Check if we are in object range 
            if ((point.X >= (minX - eps)) && (point.X <= (maxX + eps)) && (point.Y >= (minY - eps)) && (point.Y <= (maxY + eps)))
            {
                if ((point.Y >= (CalculatedY - eps)) && (point.Y <= (CalculatedY + eps)))
                {
                    return true;
                }
            }
            return false;
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
