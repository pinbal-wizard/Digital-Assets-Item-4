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
        protected string mapViewChar = "C";

        public int Health
        {
            get
            {
                if (health <= 0)
                {
                    Console.WriteLine("{0} is Dead!", this.name);
                    return 0;
                }
                else
                {
                    //DEFAULT value here. 
                    return health;
                }
            }
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
            get => name ?? "default name";   
            set                           
            {
                name = value;
            }
        }
        public int Defence
        {
            get { return defence; }
        }
        public int XPos
        {
            get
            {
                if (xPos < 0)
                {
                    xPos = 0;
                }
                else if (xPos > game.CurrentMap.Map.GetLength(1) -1)
                {
                    xPos = game.CurrentMap.Map.GetLength(1);
                }
                return xPos;
            }
        }
        public int YPos
        {
            get
            {
                if (yPos < 0)
                {
                    yPos = 0;
                }
                else if (xPos > game.CurrentMap.Map.GetLength(1) -1)
                {
                    xPos = game.CurrentMap.Map.GetLength(1);
                }
                return yPos;
            }
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
            if (defence >= damage)
            {
                Console.WriteLine(" but {0}'s armour blocked all damage",Name);
                return;
            }
            damage -= defence;
            Console.WriteLine(" for {0} but {1}'s armour blocked {2}",damage, this.Name, this.defence);
            this.Health -= damage;
        }

        public void Block()
        {
            this.defence += 1;
        }
    }
}
