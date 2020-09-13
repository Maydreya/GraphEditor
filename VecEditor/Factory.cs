using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Factory
    {
        Store store;
        SelectionStore selections;
        Frame frame;
        PropBox propBox;

        int signal;
        bool isEnter;
        int i = 0;
        List<PointF> points = new List<PointF>();
        PointF point, pointbegin;
        float minX, minY, maxX, maxY;

        public Factory(Store store, SelectionStore selections)
        {
            this.store = store;
            this.selections = selections;
        }

        public void Create(PointF point)
        {
            frame = new Frame(point.X, point.Y, point.X, point.Y);

            switch (signal)
            {
                case 0:
                    propBox = new PropBox { penProps.Clone() };

                    Line line = new Line(frame, propBox);
                    store.Add(line);
                    selections.Add(store[store.Count - 1].CreateSelection());
                    break;
                case 1:
                    propBox = new PropBox { penProps.Clone(), brushProps.Clone() };

                    Rect rect = new Rect(frame, propBox);
                    //rect.Frame.Reverse(); 
                    store.Add(rect);
                    selections.Add(store[store.Count - 1].CreateSelection());
                    break;
                case 2:
                    propBox = new PropBox { penProps.Clone(), brushProps.Clone() };

                    Ellipse ellipse = new Ellipse(frame, propBox);
                    //ellipse.Frame.Reverse(); 
                    store.Add(ellipse);
                    selections.Add(store[store.Count - 1].CreateSelection());
                    break;
                case 3:
                    propBox = new PropBox { penProps.Clone(), brushProps.Clone() };
                    points.Add(point);
                    if (points.Count < 2)
                    {
                        pointbegin = points[0];
                        minX = pointbegin.X;
                        maxX = pointbegin.X;
                        minY = pointbegin.Y;
                        maxY = pointbegin.Y;
                    }

                    if (points.Count == 1)
                    {
                        points.Add(point);
                    }
                    point = points[points.Count - 1];
                    if (minX > point.X) minX = point.X;
                    if (minY > point.Y) minY = point.Y;
                    if (maxY < point.Y) maxY = point.Y;
                    if (maxX < point.X) maxX = point.X;
                    frame = new Frame(minX, minY, maxX, maxY);
                    Polygon polygon = new Polygon(frame, points);
                    i++;
                    store.Add(polygon);
                    selections.Clear();
                    selections.Add(store[store.Count - 1].CreateSelection());
                    if (isEnter)
                    {
                        int l = store.Count;
                        i--;
                        for (int k = store.Count - 1; k > l - i; k -- )
                        {
                            store.Delete(k);
                        }
                        selections.Clear();
                        polygon = new Polygon(frame, points);
                        store.Add(polygon);
                        selections.Add(store[store.Count - 1].CreateSelection());
                    }
                    break;
            }
        }

        public void CreateGroup(GraphItemList graphItems)
        {
            Group group = new Group(graphItems);
            store.Add(group);
            selections.Clear();
            selections.Add(store[store.Count - 1].CreateSelection());
        }

        PenProps penProps;
        BrushProps brushProps;
        public void SetBrushParams(Color color2)
        {
            brushProps = new BrushProps(color2);
        }
        public void SetPenParams(Color color1, int width)
        {
            penProps = new PenProps(color1, width);
        }
        public void SetSignal(int signal)
        {
            this.signal = signal;
        }
        public void SetisEnter(bool isEnter)
        {
            this.isEnter = isEnter;
            if (isEnter)
            {
                Create(points[0]);
            }

        }
        public void ClearPoints()
        {
            points.Clear();
        }

    }
}


