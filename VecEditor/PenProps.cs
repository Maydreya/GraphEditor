using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class PenProps : Props
    {
        public PenProps(Color color, int width)
        {
            this.color = color;
            this.width = width;
        }

        public override void SetParams(Painter painter)
        {
            painter.SetPenParams(color, width);
        }

        public override Props Clone()
        {
            return new PenProps(color, width);
        }

        public Color color { get; set; }
    }
}
