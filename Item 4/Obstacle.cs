using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class Obstacle : MapItem
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public bool IsWalkable { get; set; }
        public String MapViewChar { get; set; }

        public Obstacle(int xPos, int yPos, string mapViewChar)
        {
            XPos = xPos;
            YPos = yPos;
            IsWalkable = false;
            MapViewChar = mapViewChar;
        }
    }
}
