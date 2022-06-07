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
        private List<Player> currentPlayers;
        private List<NPC> currentEntities;
        private MapSpace currentMap;

        public List<Player> CurrentPlayers { get => currentPlayers; }
        public List<NPC> CurrentEntities { get => currentEntities; }
        public MapSpace CurrentMap { get => currentMap; }

        public Game()
        {
            this.currentPlayers = new List<Player> { };
            this.currentEntities = new List<NPC> { };
            this.currentMap = new MapSpace( new MapItem[,,] { });
        }
        public Game(List<Player> currentplayers, MapSpace map)
        {
            currentPlayers = currentplayers;
            currentMap = map;
            currentEntities = new List<NPC> { };
        }

        public void PlayerJoin(Player player)
        {
            int xOffset = 0;
            int yOffset = 0;
            while (currentMap.Map[xOffset,yOffset, (int)Layer.Top] is not null)
            {
                Console.WriteLine("Something in the way");
                xOffset += 1;
            }
            currentMap.Map[xOffset, yOffset, (int)Layer.Top] = player;
            currentPlayers.Add(player);
            UpdateGui();
        }

        public void PlayerLeave(Player player)
        {
            currentPlayers.Remove(player);
            currentMap.Map[player.XPos, player.YPos, (int)Layer.Top] = null;
            Console.WriteLine("{0} has left", player.Name);
            UpdateGui();
        }

        public void CheckCurrentPlayers()
        {
            currentPlayers.Clear();
            foreach (MapItem tile in currentMap.Map)
            {
                if (tile is not Player) { continue; }
                Player player = (Player)tile;
                Console.WriteLine("{0} is connected", player.Name);
                currentPlayers.Add(player);
            }
        }
        
        public void NPCJoin(NPC player)
        {
            int xOffset = 0;
            int yOffset = 0;
            currentEntities.Add(player);
            while (currentMap.Map[player.XPos + xOffset, player.YPos + yOffset, (int)Layer.Top] is not null)
            {
                Console.WriteLine("Something in the way");
                xOffset += 1;
            }
            currentMap.Map[player.XPos + xOffset, player.YPos + yOffset, (int)Layer.Top] = player;
            UpdateGui();
        }

        public void NPCLeave(NPC player)
        {
            currentEntities.Remove(player);
            currentMap.Map[player.XPos, player.YPos, (int)Layer.Top] = null;
            UpdateGui();
        }

        public void ChangeMap(MapSpace map)
        {
            currentMap = map;
            UpdateGui();
        }

        private void UpdateGui()
        {
            currentMap.DrawMap();
            for (int i = 0; i < currentPlayers.Count; i++)
            {
                Console.WriteLine("{4}: {0} is at {1},{2} with {3} health", currentPlayers[i].Name, currentPlayers[i].XPos, currentPlayers[i].YPos, currentPlayers[i].Health, i);
            }
            for (int i = 0; i < currentEntities.Count; i++)
            {
                Console.WriteLine("{4}: {0} is at {1},{2} with {3} health", currentEntities[i].Name, currentEntities[i].XPos, currentEntities[i].YPos, currentEntities[i].Health, i);
            }
        }
        
        public void ProcessTurn()
        {
            UpdateGui();

            foreach (Player player in currentPlayers)
            {
                Console.WriteLine("{0}'s turn",player.Name); 
                player.PlayerInput();
            }
        }
    }
}
