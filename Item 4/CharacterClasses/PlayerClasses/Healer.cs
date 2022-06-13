using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Healer : Player
    {
        protected int mana;
        
        public int Mana { get; }

        public Healer(Game game, int xPos, int yPos, string name, int health, string mapViewChar) : base(game, xPos, yPos, name, health, mapViewChar)
        {
            mana = 100;
        }

        public void Heal(Character target, int amount) //heal target and reduce mana from healing
        {
            if (mana >= amount * 10) //if not enough mana cant heal
            {
                mana -= amount * 10;
                target.Heal(amount);
                return;
            }
        }

        public override ConsoleKey PlayerInput()  //player input but with healer specific commands
        {
            RegenMana();
            ConsoleKey input = base.PlayerInput();
            if (input == ConsoleKey.Enter) { return input; }
            switch (input.ToString())
            {
                case "R":
                    RegenMana();
                    break;
                case "H":
                    Heal(this, 10);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            return input;
        }
        public void RegenMana()
        {
            mana += 10;
        }
        public override void DisplayInformation() //information to display to user
        {
            Console.WriteLine("Player: {0} is at {1},{2} with {3} health and {4} mana", this.Name, this.XPos, this.YPos, this.Health, this.mana);
        }
    }
}
