using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Player
    {
        Random rnd = new Random();
        private Weapon heldItem;
        public string name;
        private int health;

        public int Health 
        {
            get => health;
            set => health = value;
        }

        public Player(string name,int health)
        {
            this.name = name;
            this.health = health;
        }

        public void EquipWeapon(Weapon weapon)
        {
            this.heldItem = weapon;
        }

        public void Attack(Player target)
        {
            int damage = rnd.Next(heldItem.MinDamage, heldItem.MaxDamage);
            target.Health -= damage;
            Console.WriteLine("{0} dealt {1} damage to {2}", this.name, damage, target.name);
            target.OnTakeDamage();
        }

        public void OnTakeDamage()
        {
            if(this.health <= 0)
            {
                Console.WriteLine("{0} has died!", this.name);
                return;
            }
            Console.WriteLine("{0} has {1} health remaining", this.name, this.health);
        }
    }
}
