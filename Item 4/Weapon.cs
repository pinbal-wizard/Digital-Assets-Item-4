using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class Weapon : Item
    {
        private int maxDamage = 0;
        private int minDamage = 0;

        public int MaxDamage
        {
            get => maxDamage;
            set => maxDamage = value;
        }
        public int MinDamage
        {
            get => minDamage;
            set => minDamage = value;
        }

        public Weapon(string name, int minD, int maxD)
        {
            this.Name = name;
            this.minDamage = minD;
            this.maxDamage = maxD;
        }
    }
}
