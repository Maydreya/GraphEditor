using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    abstract class State : IEvents
    {
        protected EditorFacade editorFacade;
        public delegate void Changer(int state);
        protected Changer changer;

        public State(EditorFacade editorFacade, Changer changer)
        {
            this.editorFacade = editorFacade;
            this.changer = changer;
        }

        public abstract void MouseDown(PointF point);

        public abstract void MouseMove(PointF point);

        public abstract void MouseUp();
    }
}
