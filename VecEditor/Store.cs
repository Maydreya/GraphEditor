using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Store : List<GraphItem>
    {
        SelectionStore selections;

        public Store(SelectionStore selections)
        {
            this.selections = selections;
        }

        public GraphItemList GetGraphItemList()
        {
            GraphItemList graphItems = new GraphItemList();

            for (int i = Count; i > 0; i--)
            {
                if (this[i - 1].isRelease)
                {
                    graphItems.Add(this[i - 1]);
                    RemoveAt(i - 1);
                }
            }

            return graphItems;
        }

        public void UnGroup()
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].UnGroup() != null && this[i].isRelease)
                {
                    int buf = this[i].UnGroup().Count;
                    for (int j = 0; j < this[i].UnGroup().Count; j++)
                    {
                        Insert(i + 1, this[i].UnGroup()[j]);
                    }
                    RemoveAt(i);
                    selections.Clear();
                    int k = i; int z = 0;
                    while (z != buf)
                    {
                        selections.Add(this[k].CreateSelection());
                        k++;
                        z++;
                    }
                    break;
                }

                //selections.Add(this[i].CreateSelection());
            }
        }



        public bool isPointInBody(PointF point)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].isPointInBody(point))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TrySelect(PointF point)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].isPointInBody(point) && this[i].isRelease == false)
                {
                    selections.Add(this[i].CreateSelection());
                    return true;
                }
            }

            return false;
        }

        public void DeleteObject()
        {
            for (int i = Count; i > 0; i--)
            {
                if (this[i - 1].isRelease)
                {
                    RemoveAt(i - 1);
                }
            }
        }
        public void Delete(int pos)
        {
            RemoveAt(pos);
        }
    }
}
