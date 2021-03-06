using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal abstract class Player : Character
    {
        protected Player(Game game, int xPos, int yPos, string name, int health, string mapViewChar) 
        : base(game, xPos, yPos, name, health, mapViewChar) { game.CurrentMap.PlayerJoin(this); }
        
        public virtual ConsoleKey PlayerInput() //base player input commands
        {
            Console.Write("Awaiting Player Input..  ");
            ConsoleKey input = Console.ReadKey().Key;
            Console.Write("\b\b\n");
            switch (input.ToString()) {
                case "W":
                    if (yPos == 0) { break; }
                    if (!game.CurrentMap.Map[this.yPos - 1, this.xPos].IsWalkable) { break; }
                    this.yPos -= 1;
                    break;
                case "A":
                    if (xPos == 0) { break; }
                    if (!game.CurrentMap.Map[this.yPos, this.xPos - 1].IsWalkable) { break; }
                    this.xPos -= 1;
                    break;
                case "S":
                    if (yPos == game.CurrentMap.Map.GetLength(0) - 1) { break; }
                    if (!game.CurrentMap.Map[this.yPos + 1, this.xPos].IsWalkable) { break; }
                    this.yPos += 1;
                    break;
                case "D":
                    if (xPos == game.CurrentMap.Map.GetLength(1) - 1) { break; }
                    if (!game.CurrentMap.Map[this.yPos, this.xPos + 1].IsWalkable) { break; }
                    this.xPos += 1;
                    break;
                case "E":
                    foreach (NPC enemy in game.CurrentMap.CurrentEntities)
                    {
                        if (enemy.IsHostile & heldItem.Range >= MapSpace.DistanceBetweenTwoPoints(XPos, YPos, enemy.XPos, enemy.YPos))
                        {
                            this.Attack(enemy);
                        }
                    }
                    break;
                default:
                    return input;
            }
            return ConsoleKey.Enter;
        }
        public void Join() //join the game
        {
            game.CurrentMap.PlayerJoin(this);
        }
        public void Leave() //leave the game
        {
            game.CurrentMap.PlayerLeave(this);
        }
       
    }
}
