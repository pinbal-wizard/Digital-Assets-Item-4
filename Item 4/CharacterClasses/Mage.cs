using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Mage : Player
    {
        protected int mana;

        public int Mana { get; }
        
        public Mage(Game game, int xPos, int yPos, string name, int health, string mapViewChar) : base(game, xPos, yPos, name, health, mapViewChar)
        {
            mana = 500;
        }
        
        public void CastMagic() //not implemented yet
        {
            if (mana > 0)
            {
                mana--;
                Console.WriteLine("You cast a magic spell!");
            }
            else
            {
                Console.WriteLine("You don't have enough mana to cast a spell!");
            }
            throw new NotImplementedException();
        }

        public override void DisplayInformation() //information to display to the user
        {
            Console.WriteLine("Player: {0} is at {1},{2} with {3} health and {4} mana", this.Name, this.XPos, this.YPos, this.Health, this.mana);
        }
    }
}
