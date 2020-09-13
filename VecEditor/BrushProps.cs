using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class BrushProps : Props
    {
        public BrushProps(Color color)
        {
            this.color = color;
        }
        public override Props Clone()
        {
            return new BrushProps(color);
        }

        public override void SetParams(Painter painter)
        {
            painter.SetBrushParams(color);
        }

        public Color color { get; set; }
    }
}
