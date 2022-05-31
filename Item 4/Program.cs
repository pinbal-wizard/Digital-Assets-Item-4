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

            Warrior joe = new Warrior("joe", 20);
            NPC joeb = new NPC("joeb", 20);

            game.PlayerJoin(joe);

            joe.Attack(joeb);

            Weapon sword = new Weapon("Sword", 3, 5);
            Weapon Longsword = new Weapon("LongSword", 1, 10);

            joe.EquipWeapon(sword);
            joeb.EquipWeapon(Longsword);

            while (joe.Health > 0 & joeb.Health > 0)
            {
                joe.Attack(joeb);
                joeb.Attack(joe);
            }

            game.PlayerLeave(joe);

        }
    }
}
