using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public enum Layer
    {
        Bottom,
        Top
    }
    public class Game
    {
        private MapSpace currentMap;


        public MapSpace CurrentMap { get => currentMap; }

        public Game()
        {
            this.currentMap = new MapSpace( new MapItem[,] { });
        }
        public Game(List<Player> currentplayers, MapSpace map)
        {
            currentMap = map;
        }


        public void ChangeMap(MapSpace map)
        {
            currentMap = map;
            UpdateGui();
        }

        private void UpdateGui()
        {
            currentMap.DrawMap();
            Console.WriteLine();
            foreach (Player player in currentMap.CurrentPlayers)
            {
                Console.WriteLine("Player: {0} is at {1},{2} with {3} health", player.Name, player.XPos, player.YPos, player.Health);
            }
            foreach (NPC player in currentMap.CurrentEntities)
            {
                Console.WriteLine("NPC: {0} is at {1},{2} with {3} health", player.Name, player.XPos, player.YPos, player.Health);
            }
        }
        
        public void ProcessTurn()
        {
            UpdateGui();
            
            foreach (Player player in currentMap.CurrentPlayers)
            {
                Console.WriteLine("{0}'s turn",player.Name); 
                player.PlayerInput();
                UpdateGui();
            }
        }
    }
}
