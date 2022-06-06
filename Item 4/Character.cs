using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public abstract class Character : MapItem
    {
        protected Game game;
        Random rnd = new Random();
        protected Weapon heldItem;
        protected string name;
        protected int health;
        protected bool dead;
        protected int defence;

        protected bool isWalkable = false;
        protected int xPos;
        protected int yPos;
        protected string mapViewChar;

        public int Health
        {
            get => health;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("{0} is Dead!", this.name);
                    dead = true;
                }
                Console.WriteLine("{1} has {0} health remaining", value, this.Name);
            }
        }
        public string Name
        {
            get => name;   //this is the problem we had with the propories only returning 0 as we had get{ return name; }
            set            // as we return the value of the prportiy **before** we had changed it
            {
                if (value is null)
                    name = "default name";
                name = value;
            }
        }
        public int Defence
        {
            get { return defence; }
        }
        public int XPos
        {
            get { return xPos; }
        }
        public int YPos
        {
            get { return yPos; }
        }
        public bool IsWalkable { get; }
        public string MapViewChar { get => mapViewChar; }

        public void EquipWeapon(Weapon weapon)
        {
            this.heldItem = weapon;
        }
        public void Attack(Character target)
        {
            if (dead) 
            {
                Console.WriteLine("{0} is dead and can't attack!", this.name);
                return; 
            }
            if (MapSpace.DistanceBetweenTwoPoints(this.xPos, this.yPos, target.xPos,target.yPos) > 1)
            {
                Console.WriteLine("{0} is too far away to attack!", target.name);
                return;
            }
            int damage = rnd.Next(heldItem.MinDamage, heldItem.MaxDamage);
            Console.Write("{0} has been attacked by {1} with {1}'s {2}", target.Name, this.Name, heldItem.Name);
            target.TakeDamage(damage);
        }
        public void TakeDamage(int damage)
        {
            if (damage <= defence)
            {
                Console.WriteLine(" but {0}'s armour blocked all damage",Name);
                return;
            }
            damage -= defence;
            Console.WriteLine(" for {0} but {1}'s armour blocked {2}",damage, this.Name, this.defence);
            this.Health -= damage;
        }
    }
}
