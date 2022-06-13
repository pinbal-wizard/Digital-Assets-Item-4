using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Bow : Weapon
    {
        public Bow(string name, int minD, int maxD, int range) : base(name, minD, maxD, range)
        {
            range += 10;
        }
    }
}
