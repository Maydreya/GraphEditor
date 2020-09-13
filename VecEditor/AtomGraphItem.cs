using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    abstract class AtomGraphItem : GraphItem
    {
        public AtomGraphItem(Frame frame, PropBox propBox) : base(frame)
        {
            this.propBox = propBox;
        }

        protected PropBox propBox;

        public abstract void DrawBody(Painter painter);

        public override void Draw(Painter painter)
        {
            propBox.SetParams(painter);
            DrawBody(painter);
        }
    }
}
