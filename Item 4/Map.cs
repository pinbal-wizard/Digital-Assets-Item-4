using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Item_4
{
    public class Map
    {
        public MapItem[,] movingLayer;  //moving layer is for anything that can move around the map
        public MapItem[,] backgroundLayer;    //background layer provides what the area should be if no moving thing is on the tile

        public Map(MapItem[,] movinglayer, MapItem[,] backgroundlayer)
        {
            movingLayer = movinglayer;
            backgroundLayer = backgroundlayer;
        }
        public Map(string backgroundlayerFilepath)
        {
            Console.WriteLine("Inializing map from {0}", backgroundlayerFilepath);

            XmlDocument backgroundXML = new XmlDocument();
            backgroundXML.Load(backgroundlayerFilepath);

            int ySize = backgroundXML.DocumentElement.ChildNodes.Count;
            int xSize = backgroundXML.DocumentElement.FirstChild.ChildNodes.Count;
            MapItem[,] backgroundLayer = new MapItem[ySize, xSize];
            MapItem[,] movinglayer = new MapItem[ySize, xSize];

            movingLayer = movinglayer;

            int y = 0;
            int x = 0;
            foreach (XmlNode row in backgroundXML.DocumentElement.ChildNodes)
            {
                foreach (XmlNode coloum in row.ChildNodes)
                {
                    if (coloum.InnerText == null)
                    {
                        coloum.InnerText = "x";
                    }
                    backgroundLayer[x, y] = new Grass(x, y, coloum.InnerText);
                    y += 1;
                }
                y = 0;
                x += 1;
            }
            this.backgroundLayer = backgroundLayer;
        }

        public MapItem GetTile(int x, int y)
        {
            if (movingLayer[x, y] is not null)
            {
                return movingLayer[x, y];
            }
            if (backgroundLayer[x, y] is not null)
            {
                return backgroundLayer[x, y];
            }
            return new Grass(x,y,".");
        }

        public void DrawMap()
        {
            Console.Clear();
            for(int i = 0; i < backgroundLayer.GetLength(0); i++)
            {
                for(int j = 0; j < backgroundLayer.GetLength(1); j++)
                {
                    Console.Write(GetTile(i, j).MapViewChar + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Drew map");
        }

        public void MoveMovingObject(int fromX, int fromY, int toX, int toY)
        {
            if (movingLayer[toX, toY] is not null)
            {
                Console.WriteLine("cannot move to {0} {1}", toX, toY);
            }
            movingLayer[toX, toY] = movingLayer[fromX, fromY];
            movingLayer[fromX, fromY] = null;
        }
    }
}
