using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Item_4
{
    internal class MapSpace
    {
        private List<Player> currentPlayers;
        private List<NPC> currentEntities;
        private MapItem[,] map;

        public List<Player> CurrentPlayers { get => currentPlayers; }

        public List<NPC> CurrentEntities { get => currentEntities; }
        
        public MapItem[,] Map { get => map; }

        public MapSpace(MapItem[,] map)
        {
            this.map = map;
            this.currentPlayers = new List<Player> { };
            this.currentEntities = new List<NPC> { };

        }
        
        public MapSpace(string backgroundlayerFilepath)
        {
            this.currentPlayers = new List<Player> { };
            this.currentEntities = new List<NPC> { };

            this.map = CreateMap(backgroundlayerFilepath);
        }
        private MapItem[,] CreateMap(string backgroundlayerFilepath)  //creates the map from xml file and returns it
        {
            //Console.WriteLine("Inializing map from {0}", backgroundlayerFilepath);

            XmlDocument backgroundXML = new XmlDocument();
            backgroundXML.Load(backgroundlayerFilepath);

            int ySize = backgroundXML.DocumentElement.ChildNodes.Count; 
            int xSize = backgroundXML.DocumentElement.FirstChild.ChildNodes.Count;
            MapItem[,] map = new MapItem[ySize, xSize]; //make array the size of xml file

            int y = 0;
            int x = 0;
            foreach (XmlNode row in backgroundXML.DocumentElement.ChildNodes)
            {
                foreach (XmlNode coloum in row.ChildNodes)
                {
                    switch (coloum.InnerText) //switch case for all the different map items (will become based on tags instead of hardcoded)
                    {
                        default:
                            map[x, y] = new Grass(x, y, "x", coloum.Attributes.ToString());
                            break;
                        case ".":
                            map[x, y] = new Grass(x, y, coloum.InnerText, coloum.Attributes.ToString());
                            break;
                        case "_":
                            map[x, y] = new TallGrass(x, y, coloum.InnerText, coloum.Attributes.ToString());
                            break;
                        case "|":
                            map[x, y] = new Tree(x, y, coloum.InnerText, coloum.Attributes.ToString());
                            break;
                        case "@":
                            map[x, y] = new Rock(x, y, coloum.InnerText, coloum.Attributes.ToString());
                            break;
                        case "-":
                            map[x, y] = new Cliff(x, y, coloum.InnerText, coloum.Attributes.ToString());
                            break;

                    }
                    y += 1;
                }
                y = 0;
                x += 1;
            }
            GC.Collect(); //garbage collect xml as it is no longer needed
            return map;
        }
        
        public void PlayerJoin(Player player)
        {
            Console.WriteLine("{0} has joined", player.Name);
            currentPlayers.Add(player);
        }

        public void PlayerLeave(Player player)
        {
            currentPlayers.Remove(player);
            Console.WriteLine("{0} has left", player.Name);
        }

        public void NPCJoin(NPC player)
        {
            currentEntities.Add(player);
        }

        public void NPCLeave(NPC player)
        {
            currentEntities.Remove(player);
        }
        private MapItem GetTile(int x, int y) //get tile at position
        {
            if (map[x, y] is not null)
            {
                return map[x, y];
            }
            return new Grass(x,y,".", "Grass");
        }

        public void DrawMap() //draw the map starting from top left
        {
            Console.SetCursorPosition(0,0);
            for(int i = 0; i < map.GetLength(0); i++) //draw the background
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(GetTile(i, j).MapViewChar + " ");
                }
                Console.WriteLine();
            }
            foreach (NPC player in currentEntities) //draw the entities
            {
                Console.SetCursorPosition(player.XPos * 2, player.YPos);
                Console.Write(player.MapViewChar);
            }
            foreach (Player player in currentPlayers) //draw the players
            {
                Console.SetCursorPosition(player.XPos * 2, player.YPos);
                Console.Write(player.MapViewChar);
            }
            Console.SetCursorPosition(0, map.GetLength(0)); //set cursor to bottom left of map
        }

        public static int DistanceBetweenTwoPoints(int x1, int y1, int x2, int y2)
        {
            return (int)Math.Ceiling(Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2))));
        }
    }
}
