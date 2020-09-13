using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{

    class Frame
    {
        public ChangeGroup changeGroup;
        public float x1 { get; set; }
        public float y1 { get; set; }
        public float x2 { get; set; }
        public float y2 { get; set; }

        public Frame(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public Frame(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public void Compose(Frame frame)
        {
            if (x2 > x1)
            {
                //расширяем влево x1 
                if (x1 > frame.x1)
                {
                    if (frame.x1 > frame.x2)
                        x1 = frame.x2;
                    else
                        x1 = frame.x1;
                }
                else
                    if (x1 > frame.x2)
                        x1 = frame.x2;

                //расширяем вправо x2 
                if (x2 < frame.x2)
                {
                    if (frame.x2 > frame.x1)
                        x2 = frame.x2;
                    else
                        x2 = frame.x1;
                }
                else
                    if (x2 < frame.x1)
                        x2 = frame.x1;
            }
            else
            {
                //расширяем вправо x1 
                if (x1 < frame.x1)
                {
                    if (frame.x2 > frame.x1)
                        x1 = frame.x2;
                    else
                        x1 = frame.x1;
                }
                else
                    if (x1 < frame.x2)
                        x1 = frame.x2;

                //расширяем влево x2 
                if (x2 > frame.x2)
                {
                    if (frame.x1 < frame.x2)
                        x2 = frame.x1;
                    else
                        x2 = frame.x2;
                }
                else
                    if (x2 > frame.x1)
                        x2 = frame.x1;
            }

            if (y2 > y1)
            {
                //расширяем вверх y1 
                if (y1 > frame.y1)
                {
                    if (frame.y1 > frame.y2)
                        y1 = frame.y2;
                    else
                        y1 = frame.y1;
                }
                else
                    if (y1 > frame.y2)
                        y1 = frame.y2;

                //расширяем вниз y2 
                if (y2 < frame.y2)
                {
                    if (frame.y2 > frame.y1)
                        y2 = frame.y2;
                    else
                        y2 = frame.y1;
                }
                else
                    if (y2 < frame.y1)
                        y2 = frame.y1;
            }
            else
            {
                //расширяем вниз y1 
                if (y1 < frame.y1)
                {
                    if (frame.y2 > frame.y1)
                        y1 = frame.y2;
                    else
                        y1 = frame.y1;
                }
                else
                    if (y1 < frame.y2)
                        y1 = frame.y2;

                //расширяем вверх y2 
                if (y2 > frame.y2)
                {
                    if (frame.y1 < frame.y2)
                        y2 = frame.y1;
                    else
                        y2 = frame.y2;
                }
                else
                    if (y2 > frame.y1)
                        y2 = frame.y1;
            }
        }
        public Frame Clone()
        {
            return new Frame(x1, y1, x2, y2);
        }
        public void Marker1(PointF point)
        {
            x1 = point.X;
            y1 = point.Y;

            if(changeGroup != null)
            {
                changeGroup();              
            }
        }

        public void Marker2(PointF point)
        {
            x2 = point.X;
            y1 = point.Y;

            if (changeGroup != null)
            {
                changeGroup();
            }
        }

        public void Marker3(PointF point)
        {
            x1 = point.X;
            y2 = point.Y;

            if (changeGroup != null)
            {
                changeGroup();
            }
        }

        public void Marker4(PointF point)
        {
            x2 = point.X;
            y2 = point.Y;

            if (changeGroup != null)
            {
                changeGroup();
            }
        }

        public void Body(PointF point)
        {
            x1 += point.X;
            y1 += point.Y;
            x2 += point.X;
            y2 += point.Y;

            if (changeGroup != null)
            {
                changeGroup();
            }
        }
        public void Reverse()
        {
            if (x1 > x2)
            {
                x1 = x2;
            }

            if (y1 > y2)
            {
                y1 = y2;
            }
        }
    }
}
