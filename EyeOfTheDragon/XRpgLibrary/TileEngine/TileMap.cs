using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.CharacterClasses;

namespace XRpgLibrary.TileEngine
{
    public class TileMap
    {
        #region Field Region

        List<Tileset> tilesets;
        List<ILayer> mapLayers;

        static int mapWidth;
        static int mapHeight;

        #endregion

        #region Property Region

        public static int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }

        public static int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }

        public static int WidthInTiles
        {
            get { return mapWidth; }
        }

        public static int HeightInTiles
        {
            get { return mapHeight; }
        }

        #endregion

        #region Constructor Region

        public TileMap(List<Tileset> tilesets, MapLayer baseLayer, MapLayer buildingLayer, MapLayer splatterLayer, MovementLayer movementLayer)
        {
            this.tilesets = tilesets;
            this.mapLayers = new List<ILayer>();

            mapLayers.Add(baseLayer);

            AddLayer(buildingLayer);
            AddLayer(splatterLayer);
            AddLayer(movementLayer);

            mapWidth = baseLayer.Width;
            mapHeight = baseLayer.Height;
        }

        public TileMap(Tileset tileset, MapLayer baseLayer)
        {
            tilesets = new List<Tileset>();
            tilesets.Add(tileset);

            mapLayers = new List<ILayer>();
            mapLayers.Add(baseLayer);

            mapWidth = baseLayer.Width;
            mapHeight = baseLayer.Height;
        }

        #endregion

        #region Method Region

        public void AddLayer(ILayer layer)
        {
            if (layer is MapLayer)
            {
                if (!(((MapLayer)layer).Width == mapWidth && ((MapLayer)layer).Height == mapHeight))
                    throw new Exception("Map layer size exception");
            }
            else if (layer is MovementLayer)
            {
                if (!(((MovementLayer)layer).Width == mapWidth && ((MovementLayer)layer).Height == mapHeight))
                    throw new Exception("Map layer size exception");
            }

            mapLayers.Add(layer);
        }

        public void AddTileset(Tileset tileset)
        {
            tilesets.Add(tileset);
        }

        public void Update(GameTime gameTime)
        {
            foreach (ILayer layer in mapLayers)
            {
                layer.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (ILayer layer in mapLayers)
            {
                if (layer is MapLayer)
                    layer.Draw(spriteBatch, camera, tilesets);
            }
        }

        public MoveType TileMoveType(Point p)
        {
            foreach (ILayer layer in mapLayers)
            {
                if (layer is MovementLayer)
                {
                    return ((MovementLayer)layer).GetTile(p.X, p.Y).TileType;
                    
                }
            }
            return MoveType.Blocked;
        }

        public bool TileOccupied(int x, int y)
        {

            return false;
        }


        #endregion
    }
}
