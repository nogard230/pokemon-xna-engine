using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{

    public struct MovementTile
    {
        public XRpgLibrary.TileEngine.MoveType type;
        public int warpX;
        public int warpY;
        public string warpLevel;
        public XRpgLibrary.SpriteClasses.Direction warpDirection;

        public MovementTile(XRpgLibrary.TileEngine.MoveType mType)
        {
            type = mType;
            warpX = -1;
            warpY = -1;
            warpLevel = null;
            warpDirection = XRpgLibrary.SpriteClasses.Direction.Up;
        }

        public MovementTile(XRpgLibrary.TileEngine.WarpTile tile)
        {
            type = tile.TileType;
            warpX = tile.WarpToPoint.X;
            warpY = tile.WarpToPoint.Y;
            warpLevel = tile.WarpToLevel;
            warpDirection = tile.WarpToDirection;
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

        public void SetTile(int x, int y, XRpgLibrary.TileEngine.MovementTile tile)
        {
            MovementTile mTile;
            if (tile is XRpgLibrary.TileEngine.WarpTile)
            {
                mTile = new MovementTile((XRpgLibrary.TileEngine.WarpTile)tile);
            }
            else
            {
                mTile = new MovementTile(tile.TileType);
            }
            Layer[y * Width + x] = mTile;
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
