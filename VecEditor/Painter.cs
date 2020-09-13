using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Painter
    {
        Graphics graphics;

        public Graphics DeviceGraphics
        {
            set
            {
                graphics = value;
            }
        }

        Pen selectionPen = new Pen(Color.Black, 1);
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brush = new SolidBrush(Color.White);
        SolidBrush brushFont = new SolidBrush(Color.Black);

        public void SetPenParams(Color color, int width)
        {
            pen.Width = width;
            pen.Color = color;
        }

        public void SetBrushParams(Color color)
        {
            brush.Color = color;
        }

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            if (graphics != null)
            {
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        public void DrawRect(float x1, float y1, float x2, float y2)
        {
            if (graphics != null)
            {
                float minx, miny;

                if (x1 < x2)
                    minx = x1;
                else
                    minx = x2;

                if (y1 < y2)
                    miny = y1;
                else
                    miny = y2;
                graphics.DrawRectangle(pen, minx, miny, Math.Abs(x2 - x1), Math.Abs(y2 - y1));
                graphics.FillRectangle(brush, minx, miny, Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            }
        }
        public void Polygon(List<PointF> point)
        {
            if (graphics != null)
            {
                    graphics.DrawLines(pen, point.ToArray());
            }
        }

        public void DrawEllipse(float x1, float y1, float x2, float y2)
        {
            if (graphics != null)
            {
                graphics.DrawEllipse(pen, x1, y1, x2 - x1, y2 - y1);
                graphics.FillEllipse(brush, x1, y1, x2 - x1, y2 - y1);
            }
        }

        public void DrawLineSelection(float x1, float y1, float x2, float y2)
        {
            if (graphics != null)
            {
                selectionPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawRectangle(selectionPen, x1 - 5, y1 - 5, 10, 10);   //начальный маркер
                graphics.DrawRectangle(selectionPen, x2 - 5, y2 - 5, 10, 10);   //конечный маркер
            }
        }

        public void DrawRectSelection(float x1, float y1, float x2, float y2)
        {
            if (graphics != null)
            {
                float minx, miny;
                if (x1 < x2)
                {
                    minx = x1;
                }
                else
                {
                    minx = x2;
                }

                if (y1 < y2)
                {
                    miny = y1;
                }
                else
                {
                    miny = y2;
                }
                selectionPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawRectangle(selectionPen, minx, miny, Math.Abs(x2 - x1), Math.Abs(y2 - y1));
                graphics.DrawRectangle(selectionPen, x1 - 5, y1 - 5, 10, 10);       //левый верхний
                graphics.DrawRectangle(selectionPen, x2 - 5, y1 - 5, 10, 10);       //правый верхний 
                graphics.DrawRectangle(selectionPen, x1 - 5, y2 - 5, 10, 10);       //левый нижний
                graphics.DrawRectangle(selectionPen, x2 - 5, y2 - 5, 10, 10);       //правый нижний
            }
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
        }
    }
}
