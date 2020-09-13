using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VecEditor
{
    class Scene
    {
        Painter painter;
        Store store;
        SelectionStore selections;
        public Scene(Painter painter, Store store, SelectionStore selections)
        {
            this.painter = painter;
            this.store = store;
            this.selections = selections;
        }

        public void ReDraw()
        {
            painter.Clear();
            for (int i = 0; i < store.Count; i++)
            {
                store[i].Draw(painter);         
            }

            for (int i = 0; i < selections.Count; i++)
            {
                selections[i].Draw(painter);
            }
        }

    }
}
