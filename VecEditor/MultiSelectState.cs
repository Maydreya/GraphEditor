using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class MultiSelectState : State
    {
        public MultiSelectState(EditorFacade editorFacade, Changer changer) : base(editorFacade, changer) { }

        public override void MouseDown(PointF point)
        {
            if (editorFacade.isCtrl && editorFacade.isPointInBody(point))
            {
                editorFacade.TrySelect(point);
                editorFacade.ReDraw();
            }
            else if (editorFacade.isPointInBody(point))
            {
                //MessageBox.Show("SingleSelect");
                editorFacade.ClearSelectionStore();
                editorFacade.TrySelect(point);
                changer(3);
            }
            else
            {
                //MessageBox.Show("empty");
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
