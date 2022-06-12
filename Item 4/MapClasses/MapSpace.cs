﻿using System;
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
        private MapItem[,] CreateMap(string backgroundlayerFilepath)
        {
            //Console.WriteLine("Inializing map from {0}", backgroundlayerFilepath);

            XmlDocument backgroundXML = new XmlDocument();
            backgroundXML.Load(backgroundlayerFilepath);

            int ySize = backgroundXML.DocumentElement.ChildNodes.Count;
            int xSize = backgroundXML.DocumentElement.FirstChild.ChildNodes.Count;
            MapItem[,] map = new MapItem[ySize, xSize];

            int y = 0;
            int x = 0;
            foreach (XmlNode row in backgroundXML.DocumentElement.ChildNodes)
            {
                foreach (XmlNode coloum in row.ChildNodes)
                {
                    switch (coloum.InnerText)
                    {
                        case null:
                            map[x, y] = new Grass(x, y, "x", coloum.Attributes.ToString());
                            break;
                        case "_":
                            map[x, y] = new TallGrass(x, y, "_", coloum.Attributes.ToString());
                            break;
                        case ".":
                            map[x, y] = new Grass(x, y, coloum.InnerText, coloum.Attributes.ToString());
                            break;
                        case "@":
                            map[x, y] = new Rock(x, y, coloum.InnerText, coloum.Attributes.ToString());
                            break;
                        default:
                            map[x, y] = new Grass(x, y, "x", coloum.Attributes.ToString());
                            break;
                    }
                    y += 1;
                }
                y = 0;
                x += 1;
            }
            GC.Collect();
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
        private MapItem GetTile(int x, int y)
        {
            if (map[x, y] is not null)
            {
                return map[x, y];
            }
            return new Grass(x,y,".", "Grass");
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0,0);
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(GetTile(i, j).MapViewChar + " ");
                }
                Console.WriteLine();
            }
            foreach (NPC player in currentEntities)
            {
                Console.SetCursorPosition(player.XPos * 2, player.YPos);
                Console.Write(player.MapViewChar);
            }
            foreach (Player player in currentPlayers)
            {
                Console.SetCursorPosition(player.XPos * 2, player.YPos);
                Console.Write(player.MapViewChar);
            }
            Console.SetCursorPosition(0, map.GetLength(0));
        }

        public static int DistanceBetweenTwoPoints(int x1, int y1, int x2, int y2)
        {
            return (int)Math.Ceiling(Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2))));
        }
    }
}
