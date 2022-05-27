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
            Weapon sword = new Weapon("Sword", 1, 5);
            Player joe = new Player("joe",10);
            Player joeb = new Player("joeb", 20);

            joe.EquipWeapon(sword);
            while (joeb.Health >=0)
            {
                joe.Attack(joeb);
                Console.ReadKey();
            }

        }
    }
}
