using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Cliff : Obstacle
    {
        public Cliff(int xPos, int yPos, string mapViewChar, string attributes) : base(xPos, yPos, mapViewChar, attributes)
        {
        }
    }
}
