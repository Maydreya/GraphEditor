using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VecEditor
{
    interface IEvents
    {
        void MouseDown(PointF point);
        void MouseMove(PointF point);
        void MouseUp();
    }
}