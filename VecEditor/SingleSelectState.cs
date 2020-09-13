using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class SingleSelectState : State
    {
        public SingleSelectState(EditorFacade editorFacade, Changer changer) : base(editorFacade, changer) { }

        public override void MouseDown(PointF point)
        {
            if (editorFacade.isCtrl && editorFacade.isPointInBody(point))
            {
                editorFacade.TrySelect(point);
                changer(4);
            }
            else if (editorFacade.TryGrab(point))
            {
                changer(2);
            }
            else if (editorFacade.isPointInBody(point))
            {
                editorFacade.ClearSelectionStore();
                editorFacade.TrySelect(point);
            }
            else
            {
                editorFacade.ClearSelectionStore();
                changer(0);
            }
        }

        public override void MouseMove(PointF point)
        {

        }

        public override void MouseUp()
        {

        }
    }
}
