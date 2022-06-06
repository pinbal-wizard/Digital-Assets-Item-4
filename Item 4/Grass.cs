using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Grass : MapItem
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public bool IsWalkable { get; set; }
        public String MapViewChar { get; set; }

        public Grass(int xPos, int yPos, string mapViewChar)
        {
            XPos = xPos;
            YPos = yPos;
            IsWalkable = true;
            MapViewChar = mapViewChar;
        }
    }
}
