using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal abstract class Weapon 
    {
        protected string name;

        protected int maxDamage = 0;
        protected int minDamage = 0;

        protected int range;

        public string Name //get and set name with deafault name
        {
            get => name;
            set { name = (value ??= "deafult name") + " "; }
        }
        public int MaxDamage
        {
            get { if (maxDamage < 0) { maxDamage = 1; } return maxDamage; }
        }
        public int MinDamage
        {
            get { if (minDamage < 0) { minDamage = 0; } return minDamage; }
        }
        public int Range
        {
            get => range;
        }

        public Weapon(string name, int minD, int maxD, int range)
        {
            this.name = name;
            this.minDamage = minD;
            this.maxDamage = maxD;
            this.range = range;
        }
        
        public Weapon() { }
    }
}
