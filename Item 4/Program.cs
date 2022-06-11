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

            Warrior player = new Warrior(1, 1, "Warrior", 10, new Weapon("Fists", 1, 1), game);
            NPC Joe = new NPC(1, 1, "Joe", 10, game);
            NPC Joe2 = new NPC(1, 2, "Joe2", 10, game);

            while (true)
            {
                game.ProcessTurn();
            }
            Console.ReadKey();

        }
    }
}
