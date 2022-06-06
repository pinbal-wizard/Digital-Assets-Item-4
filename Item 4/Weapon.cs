﻿using System;
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

        public string Name
        {
            get => name;
            set { 
                if(name is null)
                {
                    value = "deafult name";
                }
                name = value + " ";
            }
        }
        public int MaxDamage
        {
            get => maxDamage;
        }
        public int MinDamage
        {
            get => minDamage;
        }

        public Weapon(string name, int minD, int maxD)
        {
            this.name = name;
            this.minDamage = minD;
            this.maxDamage = maxD;
        }
    }
}
