using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public interface MapItem
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        bool isWalkable { get; set; }

        public String MapViewChar { get; set; }
    }
}
