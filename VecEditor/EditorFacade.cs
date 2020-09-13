using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class EditorFacade
    {
        Painter painter;
        Store store;
        Factory factory;
        Scene scene;
        SelectionStore selections;

        public EditorFacade()
        {
            painter = new Painter();
            selections = new SelectionStore();
            store = new Store(selections);
            factory = new Factory(store, selections);
            scene = new Scene(painter, store, selections);
        }
        public void Group()
        {
            factory.CreateGroup(store.GetGraphItemList());
        }
        public void UnGroup()
        {
            store.UnGroup();
        }
        public void Setsignal(int signal)
        {
            factory.SetSignal(signal);
        }
        public void SetGraphicsParams(Graphics graphics)
        {
            painter.DeviceGraphics = graphics;
        }
        public void SetBrushParams(Color color2)
        {
            factory.SetBrushParams(color2);
        }
        public void SetPenParams(Color color1, int width)
        {
            factory.SetPenParams(color1, width);
        }
        public bool isPointInBody(PointF point)
        {
            if (store.isPointInBody(point))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isPointInMarker(PointF point)
        {
            if (selections.isPointInMarker(point))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DragTo(PointF point)
        {
            selections.DragTo(point);
        }
        public bool TryGrab(PointF point)
        {
            if (selections.TryGrab(point))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create(PointF point)
        {
            factory.Create(point);
        }

        public bool TrySelect(PointF point)
        {
            if (store.TrySelect(point))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isCtrl { get; set; }
        public void SetisEnter(bool isEnter)
        {
            factory.SetisEnter(isEnter);
        }
        public bool isEnter { get; set; }
        public void SetIsCtrl(bool isCtrl)
        {
            this.isCtrl = isCtrl;
        }

        public bool CheckSelectionStore()
        {
            if (selections.Count > 1)
            {
                return true;
            }

            return false;
        }

        public void DeleteObject()
        {
            store.DeleteObject();
            selections.Clear();
        }

        public void SetSignal(int signal)
        {
            factory.SetSignal(signal);
        }

        public void ReDraw()
        {
            scene.ReDraw();
        }

        public void ClearSelectionStore()
        {
            selections.Clear();
            for (int i = 0; i < store.Count; i++)
            {
                store[i].isRelease = false;
            }
        }

        public void Clear()
        {
            store.Clear();
            factory.ClearPoints();
        }
    }
}
