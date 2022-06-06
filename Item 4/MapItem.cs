using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public interface MapItem
    {
        public int XPos { get;}
        public int YPos { get;}
        bool IsWalkable { get;}

        public String MapViewChar { get;}
    }
}
