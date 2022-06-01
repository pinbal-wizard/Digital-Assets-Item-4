using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class PlayerMapItem : MapItem
    {
        public PlayerMapItem(int xPos, int yPos, string mapViewChar)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.isWalkable = true;
            this.MapViewChar = mapViewChar;
        }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public bool isWalkable { get; set; }
        public string MapViewChar { get; set; }
    }
}
