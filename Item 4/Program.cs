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

            Map map = new Map(@"../../../GameArea.xml");
            game.currentMap = map;

            Warrior joe = new Warrior(0, 0, "joe", 20);
            joe.map = map;
            NPC joeb = new NPC(0,0,"joeb", 20);
            joeb.map = map;

            game.PlayerJoin(joe);
            game.NPCJoin(joeb);

            map.DrawMap();
            joe.Move();
            Console.ReadKey();
            map.DrawMap();

            /*joe.Attack(joeb);

            Weapon sword = new Weapon("Sword", 3, 5);
            Weapon Longsword = new Weapon("LongSword", 1, 10);

            joe.EquipWeapon(sword);
            joeb.EquipWeapon(Longsword);

            while (joe.Health > 0 & joeb.Health > 0)
            {
                joe.Attack(joeb);
                joeb.Attack(joe);
            }

            game.PlayerLeave(joe);*/

        }
    }
}
