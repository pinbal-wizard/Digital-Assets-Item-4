using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Item_4
{
    public class MapSpace
    {
        private MapItem[,,] map;  

        public MapItem[,,] Map
        {
            get
            {
                return map;
            }
        }
        public MapSpace(MapItem[,,] map)
        {
            this.map = map;
        }
        public MapSpace(string backgroundlayerFilepath)
        {
            Console.WriteLine("Inializing map from {0}", backgroundlayerFilepath);

            XmlDocument backgroundXML = new XmlDocument();
            backgroundXML.Load(backgroundlayerFilepath);

            int ySize = backgroundXML.DocumentElement.ChildNodes.Count;
            int xSize = backgroundXML.DocumentElement.FirstChild.ChildNodes.Count;
            MapItem[,,] map = new MapItem[ySize, xSize, 2];

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
                    map[x, y,(int)Layer.Bottom] = new Grass(x, y, coloum.InnerText);
                    x += 1;
                }
                x = 0;
                y += 1;
            }
            this.map = map;
        }

        public MapItem GetTile(int x, int y)
        {
            if (map[x, y,(int)Layer.Top] is not null)
            {
                return map[x, y, (int)Layer.Top];
            }
            if (map[x, y,(int)Layer.Bottom] is not null)
            {
                return map[x, y, (int)Layer.Bottom];
            }
            return new Grass(x,y,".");
        }

        public void DrawMap()
        {
            Console.Clear();
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(GetTile(j, i).MapViewChar + " ");
                }
                Console.WriteLine();
            }
        }

        public static int DistanceBetweenTwoPoints(int x1, int y1, int x2, int y2)
        {
            return (int)Math.Ceiling(Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2))));
        }

        public void UpdatePos(int x, int y)
        {
            var temp = map[x, y, (int)Layer.Top];
            map[x, y, (int)Layer.Top] = null;
            map[temp.XPos, temp.YPos, (int)Layer.Top] = temp;
        }
    }
}
