using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class NPC : Character
    {
        public NPC(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }
    }
}
