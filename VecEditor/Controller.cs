using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Controller : IPainterParams
    {
        EditorFacade editorFacade;
        State activeState;
        public Controller(EditorFacade editorFacade)
        {
            this.editorFacade = editorFacade;
            activeState = new EmptyState(editorFacade, ChangeState);
        }
        public void ChangeState(int state)
        {
            switch (state)
            {
                case 0:
                    activeState = new EmptyState(editorFacade, ChangeState);
                    break;
                case 1:
                    activeState = new ObjectCreationState(editorFacade, ChangeState);
                    break;
                case 2:
                    activeState = new ObjectDragState(editorFacade, ChangeState);
                    break;
                case 3:
                    activeState = new SingleSelectState(editorFacade, ChangeState);
                    break;
                case 4:
                    activeState = new MultiSelectState(editorFacade, ChangeState);
                    break;
            }
        }

        public void Group()
        {
            editorFacade.Group();
        }

        public void UnGroup()
        {
            editorFacade.UnGroup();
            ChangeState(4);
        }

        public void SetGraphicsParams(Graphics graphics)
        {
            editorFacade.SetGraphicsParams(graphics);
        }

        public void SetPenParams(Color color, int width)
        {
            editorFacade.SetPenParams(color, width);
        }

        public void SetBrushParams(Color color)
        {
            editorFacade.SetBrushParams(color);
        }

        public bool TrySelect(PointF point)
        {
            if (editorFacade.TrySelect(point))
            {
                return true;
            }

            return false;
        }

        public void DeleteObject()
        {
            editorFacade.DeleteObject();
            ChangeState(0);
        }
        public bool CheckSelectionStore()
        {
            if (editorFacade.CheckSelectionStore())
            {
                return true;
            }

            return false;
        }

        public void SetSignal(int signal)
        {
            editorFacade.SetSignal(signal);
        }

        public void SetIsCtrl(bool isCtrl)
        {
            editorFacade.SetIsCtrl(isCtrl);
        }

        public void SetisEnter(bool isEnter)
        {
            editorFacade.SetisEnter(isEnter);
        }
        public void ReDraw()
        {
            editorFacade.ReDraw();
        }

        public void ClearSelectionStore()
        {
            editorFacade.ClearSelectionStore();
        }

        public void Clear()
        {
            editorFacade.Clear();
            editorFacade.ClearSelectionStore();
        }

        public void MouseDown(PointF point)
        {
            activeState.MouseDown(point);
        }

        public void MouseMove(PointF point)
        {
            activeState.MouseMove(point);
        }

        public void MouseUp()
        {
            activeState.MouseUp();
        }
    }
}
