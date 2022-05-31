using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    internal class Map
    {
        public int size = 256;
        public MapItem[,] movingLayer;  //moving layer is for anything that can move around the map
        public MapItem[,] backgroundLayer;    //background layer provides what the area should be if no moving thing is on the tile

        public Map(MapItem[,] movinglayer, MapItem[,] backgroundlayer)
        {
            movingLayer = movinglayer;
            backgroundLayer = backgroundlayer;
        }

        public MapItem GetTile(int x, int y)
        {
            if (movingLayer[x,y] is not null)
            {
                return movingLayer[x,y];
            }
            if (backgroundLayer[x, y] is not null)
            {
                return backgroundLayer[x, y];
            }
        return null;
        }

        public void MoveMovingObject(int fromX, int fromY, int toX, int toY)
        {
            if(movingLayer[toX,toY] is not null)
            {
                Console.WriteLine("cannot move to {0} {1}",toX,toY);
            }
            movingLayer[toX, toY] = movingLayer[fromX, fromY];
        }
    }
}
