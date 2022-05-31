using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class MovingMapItem : MapItem
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public bool isWalkable { get; set; }
    }
}
