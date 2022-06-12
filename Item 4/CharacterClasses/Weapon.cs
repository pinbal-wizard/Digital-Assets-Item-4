using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class Weapon 
    {
        private string name;

        private int maxDamage = 0;
        private int minDamage = 0;

        private int range;

        public string Name //get and set name with deafault name
        {
            get => name;
            set { name = (value ??= "deafult name") + " "; }
        }
        public int MaxDamage
        {
            get => maxDamage;
        }
        public int MinDamage
        {
            get => minDamage;
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
    }
}
