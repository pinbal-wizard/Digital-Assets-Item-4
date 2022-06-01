using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class Warrior : Player
    {
        public Warrior(int xPos, int yPos, string name, int health)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.Name = name;
            this.Health = health;
            this.EquipWeapon(new Weapon("Fists", 0, 2));
            this.mapReference = new PlayerMapItem(XPos, YPos,"W")
            {
                XPos = xPos,
                YPos = yPos,
                isWalkable = true,
                MapViewChar = "W"
            };
        }
        public Warrior(int xPos, int yPos,string name, int health, Weapon weapon)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.Name = name;
            this.Health = health;
            this.EquipWeapon(weapon);
            this.mapReference = new PlayerMapItem(XPos, YPos,"W")
            {
                XPos = xPos,
                YPos = yPos,
                isWalkable = true,
                MapViewChar = "W"
            };
        }

    }
}
