using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    public delegate void ChangeGroup();
    struct Coordinate
    {
        public float corx1;
        public float corx2;
        public float cory1;
        public float cory2;
    }
    class Group : GraphItem
    {
        GraphItemList graphItems = new GraphItemList();
        Coordinate[] nabor;
       public Group(GraphItemList graphItems) : base(null)
        {
            for (int i = 0; i < graphItems.Count; i++)
            {
                this.graphItems.Add(graphItems[i]);
            }
            frame = graphItems[0].Frame.Clone();
            for (int i = 1; i < graphItems.Count; i++)
            {
                frame.Compose(graphItems[i].Frame);
            }
            nabor = new Coordinate[graphItems.Count];
            for (int i = 0; i < graphItems.Count; i++)
            {
                nabor[i].corx1 = (graphItems[i].frame.x1 - frame.x1) / (frame.x2 - frame.x1);
                nabor[i].corx2 = (graphItems[i].frame.x2 - frame.x1) / (frame.x2 - frame.x1);
                nabor[i].cory1 = (graphItems[i].frame.y1 - frame.y1) / (frame.y2 - frame.y1);
                nabor[i].cory2 = (graphItems[i].frame.y2 - frame.y1) / (frame.y2 - frame.y1);

            }
            frame.changeGroup = Change;
            

        }
        public override void Draw(Painter painter)
        {
            for(int i = 0; i < graphItems.Count; i++)
            {
                graphItems[i].Draw(painter);
            }
        }
        public override Selection CreateSelection()
        {
            isRelease = true;
            return new RectSelection(ref frame);
        }

        public override bool isPointInBody(PointF point)
        {
            for (int i = 0; i < graphItems.Count; i++)
            {
                if (graphItems[i].isPointInBody(point))
                {
                    return true;
                }
            }

            return false;
        }

        public override void DragBody(float dx, float dy)
        {

        }


        public override GraphItemList UnGroup()
        {
            return graphItems;
        }

        public override void Change()
        {
            for (int i = 0; i < graphItems.Count; i++)
            {
                if (graphItems[i].UnGroup() != null)
                {
                    graphItems[i].Change();
                }
                graphItems[i].frame.x1 = nabor[i].corx1 * (frame.x2 - frame.x1) + frame.x1;
                graphItems[i].frame.x2 = nabor[i].corx2 * (frame.x2 - frame.x1) + frame.x1;
                graphItems[i].frame.y1 = nabor[i].cory1 * (frame.y2 - frame.y1) + frame.y1;
                graphItems[i].frame.y2 = nabor[i].cory2 * (frame.y2 - frame.y1) + frame.y1;
            }
        }
    }
}
