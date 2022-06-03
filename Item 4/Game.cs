using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Game
    {
        public List<Player> currentPlayers;
        public List<NPC> currentEntities;
        public Map currentMap;

        public Game()
        {
            currentPlayers = new List<Player> { };
            currentEntities = new List<NPC> { };
        }
        public Game(List<Player> currentplayers, Map map)
        {
            currentPlayers = currentplayers;
            currentMap = map;
            currentEntities = new List<NPC> { };
        }

        public void PlayerJoin(Player player)
        {
            int xOffset = 0;
            int yOffset = 0;
            currentPlayers.Add(player);
            while (currentMap.movingLayer[player.mapReference.XPos + xOffset, player.mapReference.YPos + yOffset] is not null)
            {
                Console.WriteLine("Something in the way");
                xOffset += 1;
            }
            currentMap.movingLayer[player.mapReference.XPos + xOffset, player.mapReference.YPos + yOffset] = player.mapReference;
            Console.WriteLine("{0} has joined", player.Name);
        }

        public void NPCJoin(NPC player)
        {
            int xOffset = 0;
            int yOffset = 0;
            currentEntities.Add(player);
            while (currentMap.movingLayer[player.mapReference.XPos + xOffset, player.mapReference.YPos + yOffset] is not null)
            {
                Console.WriteLine("Something in the way");
                xOffset += 1;
            }
            currentMap.movingLayer[player.mapReference.XPos + xOffset, player.mapReference.YPos + yOffset] = player.mapReference;
        }
        public void PlayerLeave(Player player)
        {
            currentPlayers.Remove(player);
            Console.WriteLine("{0} has left", player.Name);
        }
        public void NPCLeave(NPC player)
        {
            currentEntities.Remove(player);
        }

        public void ChangeMap(Map map)
        {
            currentMap = map;
        }

        public void UpdateGui()
        {
            currentMap.DrawMap();
            for (int i = 0; i < currentPlayers.Count; i++)
            {
                Console.WriteLine("{4}: {0} is at {1},{2} with {3} health", currentPlayers[i].Name, currentPlayers[i].XPos, currentPlayers[i].YPos, currentPlayers[i].Health, i);
            }
            for (int i = 0; i < currentEntities.Count; i++)
            {
                Console.WriteLine("{4}: {0} is at {1},{2} with {3} health", currentEntities[i].Name, currentEntities[i].XPos, currentEntities[i].YPos, currentPlayers[i].Health, i);
            }
        }
    }
}
