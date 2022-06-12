using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal interface MapItem
    {
        public string Name { get;}

        public int XPos { get;}
        
        public int YPos { get;}
        
        public bool IsWalkable { get;}

        public String MapViewChar { get;}

    }
}
