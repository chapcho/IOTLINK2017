using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public interface ICanvasItemEntity
    {
        CVertexS ToVertexS();
    }

    public class CCanvasItemEntityS : HashSet<ICanvasItemEntity>
    {
        public CCanvasItemEntityS()
        {

        }

        public ICanvasItemEntity GetEntity(int index)
        {
            int i = -1;
            foreach (ICanvasItemEntity entity in this)
            {
                i++;
                if (i == index) { return entity; }
            }
            return null;
        }
    }
}
