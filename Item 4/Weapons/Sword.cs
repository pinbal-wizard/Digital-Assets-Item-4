using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4.Weapons
{
    internal class Sword : Weapon
    {
        public Sword(string name, int minD, int maxD, int range) : base(name, minD, maxD, range)
        {
            minD += 1;
            maxD += 1;
            range = 2;
        }
    }
}
