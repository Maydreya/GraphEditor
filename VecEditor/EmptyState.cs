using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class EmptyState : State
    {
        public EmptyState(EditorFacade editorFacade, Changer changer) : base(editorFacade, changer) { }

        public override void MouseDown(PointF point)
        {
            if (editorFacade.TrySelect(point))
            {
                editorFacade.TrySelect(point);
                changer(3);
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
