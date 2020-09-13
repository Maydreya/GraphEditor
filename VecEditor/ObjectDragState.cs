using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class ObjectDragState : State
    {
        public ObjectDragState(EditorFacade editorFacade, Changer changer) : base(editorFacade, changer) { }

        public override void MouseDown(PointF point)
        {

        }

        public override void MouseMove(PointF point)
        {
            editorFacade.DragTo(point);
        }

        public override void MouseUp()
        {
            //MessageBox.Show("Объект выделен");
            changer(3);
        }
    }
}
