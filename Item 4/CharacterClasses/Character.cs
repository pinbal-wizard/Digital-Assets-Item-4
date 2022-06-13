using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal abstract class Character : MapItem
    {
        protected Game game;
        protected int xPos;
        protected int yPos;
        protected string name;
        protected int health;
        protected bool isWalkable = false;
        protected string mapViewChar = "C";
        protected int defence;
        protected Weapon heldItem;
        protected bool dead;
        protected List<Weapon> backpack;

        Random rnd = new Random();

        public int Health  //get and set health if health is less than or equal to 0, set dead to true
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
        public string Name //get and set name if no name set to default name
        {
            get => name ??= "default name";
            set
            {
                name = value;
            }
        }
        public int Defence
        {
            get { return defence; }
        }
        public int XPos  //get x position of character and dont let it go out of the map
        {
            get
            {
                if (xPos < 0)
                {
                    xPos = 0;
                }
                else if (xPos > game.CurrentMap.Map.GetLength(1) - 1)
                {
                    xPos = game.CurrentMap.Map.GetLength(1) - 1;
                }
                return xPos;
            }
        }
        public int YPos  //get y position of character and dont let it go out of the map
        {
            get
            {
                if (yPos < 0)
                {
                    yPos = 0;
                }
                else if (yPos > game.CurrentMap.Map.GetLength(0) - 1)
                {
                    yPos = game.CurrentMap.Map.GetLength(0) - 1;
                }
                return yPos;
            }
        }

        public bool IsWalkable { get => false; } //player is never walkable             (doesent work anyway)
        public string MapViewChar { get => mapViewChar; } //charactor the player sees on the map
        public List<Weapon> Bacpack { get => backpack; }

        public Character(Game game, int xPos, int yPos, string name, int health, string mapViewChar)
        {            
            this.game = game;
            this.xPos = xPos;
            this.yPos = yPos;
            this.Name = name;
            this.health = health;
            this.isWalkable = false;
            this.mapViewChar = mapViewChar;
            this.heldItem = new Fists();
        }

        public void EquipWeapon(Weapon weapon)
        {
            this.heldItem = weapon;
        }
        public void EquipWeapon(int IndexInBackpack)
        {   
            this.heldItem = backpack[IndexInBackpack];
        }

        public void Attack(Character target)
        {
            if (dead) //cant attack if dead
            {
                Console.WriteLine("{0} is dead and can't attack!", this.name);
                return;
            }
            if (MapSpace.DistanceBetweenTwoPoints(this.xPos, this.yPos, target.xPos, target.yPos) > heldItem.Range) //if target is too far away dont attack
            {
                Console.WriteLine("{0} is too far away to attack!", target.name);
                return;
            }
            int damage = rnd.Next(heldItem.MinDamage, heldItem.MaxDamage);
            Console.Write("{0} has been attacked by {1} with {1}'s {2}", target.Name, this.Name, heldItem.Name);
            target.TakeDamage(damage);    //attack target
        }
        
        public void TakeDamage(int damage)
        {
            MapItem currentTile = game.CurrentMap.Map[this.yPos, this.xPos];
            if (currentTile is Cover) //if in a tile with cover half damadge
            {
                damage = damage / 2;
            }

            if (defence >= damage) //if defence is greater than damage, no damage is taken
            {
                Console.WriteLine(" but {0}'s armour blocked all damage", Name);
                return;
            }
            damage -= defence; //reduce damage by defence
            Console.WriteLine(" for {0} but {1}'s armour blocked {2}", damage, this.Name, this.defence);
            this.Health -= damage; //take damage
        }

        public void Heal(int amount) //healer heal
        {
            health += amount;
        }
        
        public void Heal() //self heal
        {
            health += 2;
        }

        public virtual void DisplayInformation() //information to display on the map
        {
            Console.WriteLine("Player: {0} is at {1},{2} with {3} health", this.Name, this.XPos, this.YPos, this.Health);
        }
    }
}
