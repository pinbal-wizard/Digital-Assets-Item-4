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
        public Map currentMap;

        public Game()
        {
            currentPlayers = new List<Player>{ };
        }
        public Game(List<Player> currentplayers, Map map)
        {
            currentPlayers = currentplayers;
            currentMap = map;
        }

        public void PlayerJoin(Player player)
        {
            currentPlayers.Add(player);
            Console.WriteLine("{0} has joined",player.Name);
        }

        public void PlayerLeave(Player player)
        {
            currentPlayers.Remove(player);
            Console.WriteLine("{0} has left", player.Name);
        }

        public void ChangeMap(Map map)
        {
            currentMap = map;
        }
    }
}
