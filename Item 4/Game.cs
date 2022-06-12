using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Game
    {
        private MapSpace currentMap;

        internal MapSpace CurrentMap { get => currentMap; }

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
                ClearCurrentConsoleLine();
                player.DisplayInformation();
            }
            foreach (NPC player in currentMap.CurrentEntities)
            {
                ClearCurrentConsoleLine();
                player.DisplayInformation();
            }
        }
        
        public void ProcessTurn()
        {
            UpdateGui();
            
            foreach (Player player in currentMap.CurrentPlayers)
            {
                ClearCurrentConsoleLine();
                Console.WriteLine("{0}'s turn",player.Name);
                player.PlayerInput();

                UpdateGui();
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
