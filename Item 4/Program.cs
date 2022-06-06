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

            Warrior warrior = new Warrior(0, 0, "joe", 20,game);
            Console.ReadKey();
            warrior.Leave();
            Console.ReadKey();
            warrior.Join();

            NPC mick = new NPC(2, 2, "mick", 20, game);
            warrior.Attack(mick);
            
            Console.ReadKey();

            NPC joeb = new NPC(0, 0, "joeb", 20, game);
            warrior.Attack(joeb);
            Console.ReadKey();

            joeb.Attack(warrior);
            Console.ReadKey();

        }
    }
}
