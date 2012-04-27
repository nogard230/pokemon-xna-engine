using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RpgLibrary.WorldClasses;

namespace XRpgLibrary.TileEngine
{
    public class MovementLayer : ILayer
    {
        #region Field Region

        MovementTile[,] layer;

        #endregion

        #region Property Region

        public int Width
        {
            get { return layer.GetLength(1); }
        }

        public int Height
        {
            get { return layer.GetLength(0); }
        }

        #endregion

        #region Constructor Region

        public MovementLayer(MovementTile[,] map)
        {
            this.layer = (MovementTile[,])map.Clone();
        }

        public MovementLayer(int width, int height)
        {
            layer = new MovementTile[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    layer[y, x] = new MovementTile(MoveType.Normal);
                }
            }
        }

        #endregion

        #region Method Region

        public MovementTile GetTile(int x, int y)
        {
            return layer[y, x];
        }

        public void SetTile(int x, int y, MovementTile tile)
        {
            layer[y, x] = tile;
        }

        public void SetTile(int x, int y, MoveType type)
        {
            layer[y, x] = new MovementTile(type);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets)
        {
        }

        public static MovementLayer FromMovementLayerData(MovementLayerData data)
        {
            MovementLayer layer = new MovementLayer(data.Width, data.Height);

            for (int y = 0; y < data.Height; y++)
                for (int x = 0; x < data.Width; x++)
                {
                    if (data.GetTile(x, y).type == MoveType.Warp)
                    {
                        RpgLibrary.WorldClasses.MovementTile tileData = data.GetTile(x, y);
                        layer.SetTile(
                            x,
                            y,
                            new WarpTile(new Point(tileData.warpX, tileData.warpY), tileData.warpLevel, tileData.warpDirection));
                    }
                    else
                    {
                        layer.SetTile(
                            x,
                            y,
                            data.GetTile(x, y).type);
                    }
                }

            return layer;
        }

        #endregion
    }
}
