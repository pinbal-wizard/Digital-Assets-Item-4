using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Warrior : Player
    {
        
        public Warrior(Game game, int xPos, int yPos, string name, int health, string mapViewChar) : base(game, xPos, yPos, name, health, mapViewChar)
        {
            health += 10;
            defence += 2;
        }
        public Warrior(Game game,int xPos, int yPos, string name, int health, string mapViewChar, Weapon weapon) : base(game, xPos, yPos, name, health, mapViewChar)
        {
            health += 10;
        }
        public void Block()
        {
            this.defence += 1;
        }

        public override void DisplayInformation()
        {
            Console.WriteLine("Player: {0} is at {1},{2} with {3} health and {4} defence", this.Name, this.XPos, this.YPos, this.Health, this.defence);
        }
    }
}
