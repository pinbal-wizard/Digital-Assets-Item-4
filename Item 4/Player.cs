using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public abstract class Player : Character
    {
        public void PlayerInput()
        {
            Console.Write("Awaiting Player Input..  ");
            ConsoleKey input = Console.ReadKey().Key;
            Console.Write("\b\b");
            switch (input.ToString()) {
                case "W":
                    Console.WriteLine("You pressed W");
                    this.yPos -= 1;
                    break;
                case "A":
                    Console.WriteLine("You pressed A");
                    this.xPos -= 1;
                    break;
                case "S":
                    Console.WriteLine("You pressed S");
                    this.yPos += 1;
                    break;
                case "D":
                    Console.WriteLine("You pressed D");
                    this.xPos += 1;
                    break;
            }
        }
        public void Join()
        {
            game.CurrentMap.PlayerJoin(this);
        }
        public void Leave()
        {
            game.CurrentMap.PlayerLeave(this);
        }        
    }
}
