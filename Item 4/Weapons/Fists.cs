using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Fists : Weapon
    {
        public Fists() : base()
        {
            minDamage = 1;
            maxDamage = 1;
            range = 1;
            name = "Fists";
        }
    }
}
