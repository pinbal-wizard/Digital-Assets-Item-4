using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class Warrior : Player
    {
        public Warrior(string name, int health)
        {
            this.Name = name;
            this.Health = health;
            this.EquipWeapon(new Weapon("Fists", 0, 2) );
        }
        public Warrior(string name, int health, Weapon weapon)
        {
            this.Name = name;
            this.Health = health;
            this.EquipWeapon(weapon);
        }

    }
}
