using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{

    public struct MovementTile
    {
        public XRpgLibrary.TileEngine.MoveType type;

        public MovementTile(XRpgLibrary.TileEngine.MoveType mType)
        {
            type = mType;
        }
    }

    public class MovementLayerData
    {
        public string MapLayerName;
        public int Width;
        public int Height;
        public MovementTile[] Layer;

        private MovementLayerData()
        {
        }

        public MovementLayerData(string mapLayerName, int width, int height)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;

            Layer = new MovementTile[height * width];
        }

        public MovementLayerData(string mapLayerName, int width, int height, XRpgLibrary.TileEngine.MoveType type)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;

            Layer = new MovementTile[height * width];

            MovementTile tile = new MovementTile(type);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    SetTile(x, y, tile);
        }

        public void SetTile(int x, int y, MovementTile tile)
        {
            Layer[y * Width + x] = tile;
        }

        public void SetTile(int x, int y, XRpgLibrary.TileEngine.MoveType type)
        {
            Layer[y * Width + x] = new MovementTile(type);
        }

        public MovementTile GetTile(int x, int y)
        {
            return Layer[y * Width + x];
        }
    }
}
