using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public abstract class Character
    {
        Random rnd = new Random();
        private Weapon heldItem;
        public string name;
        private int health;
        private bool dead;

        public int xPos;
        public int yPos;
        public Map map;
        public PlayerMapItem mapReference;

        public int Health
        {
            get { return health; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("{0} is Dead!", this.name);
                    health = 0;
                    dead = true;
                    return;
                }
                health = value;
                Console.WriteLine("{1} has {0} health remaining", this.health, this.Name);
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value is null)
                    name = "default name";
                else
                    name = value;
            }
        }

        public int XPos
        {
            get { return xPos; }
            set
            {
                xPos = value;
            }
        }

        public int YPos
        {
            get { return yPos; }
            set
            {
                yPos = value;
            }
        }


        public void EquipWeapon(Weapon weapon)
        {
            this.heldItem = weapon;
        }

        public void Attack(Character target)
        {
            if (dead) { return; }
            int damage = rnd.Next(heldItem.MinDamage, heldItem.MaxDamage);
            Console.WriteLine("{0} dealt {1} damage to {2}", this.Name, damage, target.Name);
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}
