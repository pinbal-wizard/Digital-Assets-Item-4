﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public class Warrior : Player
    {
        public Warrior(int xPos, int yPos, string name, int health, Game game)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.Name = name;
            this.health = health;
            this.EquipWeapon(new Weapon("Fists", 1, 1));
            this.isWalkable = false;
            this.mapViewChar = "W";
            this.game = game;
            game.CurrentMap.PlayerJoin(this);
            this.defence += 2;
        }
        public Warrior(int xPos, int yPos, string name, int health, Weapon weapon, Game game)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.Name = name;
            this.health = health;
            this.EquipWeapon(weapon);
            this.isWalkable = false;
            this.mapViewChar = "W";
            this.game = game;
            game.CurrentMap.PlayerJoin(this);
            this.defence += 2;
        }

    }
}
