using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Item_4
{
    public class Program
    {
        static void Main()
        {
            Game game = new Game();

            MapSpace map = new MapSpace(@"../../../GameArea.xml");  
            game.ChangeMap(map);

            Warrior warrior = new Warrior(game, 1, 1, "Warrior", 10, "W" );
            //Healer healer= new Healer(game, 1, 1, "Healer", 10, "H");
            NPC Joe = new NPCMage(game, 1, 1, "Joe", 10, "N", true);
            NPC Joe2 = new NPCWarrior(game, 1, 1, "Joe2", 10, "n", false);
            
            while (true)
            {
                game.ProcessTurn();
            }
        }
    }
}
