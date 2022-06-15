using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class NPCWarrior : NPC
    {
        
        public NPCWarrior(Game game, int xPos, int yPos, string name, int health, string mapViewChar, bool isHostile)
            : base(game, xPos, yPos, name, health, mapViewChar, isHostile)
        {
            health += 10;
            defence += 2;
        }
        public NPCWarrior(Game game, int xPos, int yPos, string name, int health, string mapViewChar, bool isHostile, Weapon weapon)
            : base(game, xPos, yPos, name, health, mapViewChar, isHostile) //Constructor if warrior has weapon
        {
            health += 10;
            heldItem = weapon;
        }
        public void Block()
        {
            this.defence += 1;
        }

        public override void DisplayInformation() //information to display when warrior is selected
        {
            Console.WriteLine("NPC: {0} is at {1},{2} with {3} health and {4} defence", this.Name, this.XPos, this.YPos, this.Health, this.defence);
        }
    }
}
