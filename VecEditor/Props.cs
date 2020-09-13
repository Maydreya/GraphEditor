using System.Drawing;

namespace VecEditor
{
    abstract class Props
    {
        public int width { get; set; }

        public abstract void SetParams(Painter painter);
        public abstract Props Clone();
    }
}
