using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Rock : Obstacle
    {
        public Rock(int xPos, int yPos, string mapViewChar, string attributes) : base(xPos, yPos, mapViewChar, attributes)
        {
        }
    }
}
