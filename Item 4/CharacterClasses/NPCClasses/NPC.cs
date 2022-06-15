using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal abstract class NPC : Character
    {
        private bool isHostile;

        public bool IsHostile //not implemented yet
        {
            get{ return isHostile;} 
        }
        public NPC(Game game, int xPos, int yPos, string name, int health, string mapViewChar, bool isHostile) 
            : base(game, xPos, yPos, name, health, mapViewChar)
        {
            game.CurrentMap.NPCJoin(this);
            this.isHostile = isHostile;
        }
    }
}
