using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class NPC : Character
    {
        public NPC(int xPos, int yPos, string name, int health)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.Name = name;
            this.Health = health;
            this.EquipWeapon(new Weapon("Fists", 0, 2));
            this.mapReference = new PlayerMapItem(XPos, YPos, "N")
            {
                XPos = xPos,
                YPos = yPos,
                isWalkable = true,
                MapViewChar = "N"
            };  
        }
    }
}
