using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class ObjectCreationState : State
    {
        public ObjectCreationState(EditorFacade editorFacade, Changer changer) : base(editorFacade, changer) { }

        public override void MouseDown(PointF point)
        {
            editorFacade.Create(point);
            if (editorFacade.TryGrab(point))
            {
                changer(2);
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
