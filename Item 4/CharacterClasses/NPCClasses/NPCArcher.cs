using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class NPCArcher : NPC
    {
        public NPCArcher(Game game, int xPos, int yPos, string name, int health,string mapViewChar, bool isHostile) 
            : base(game, xPos, yPos, name, health, mapViewChar, isHostile)
        {
            throw new NotImplementedException();
        }
    }
}
