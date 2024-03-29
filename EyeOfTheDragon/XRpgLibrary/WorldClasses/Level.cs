﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.TileEngine;
using XRpgLibrary.CharacterClasses;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.ItemClasses;

namespace XRpgLibrary.WorldClasses
{
    public class Level
    {
        #region Field Region

        readonly TileMap map;
        readonly List<Character> characters;
        readonly List<ItemSprite> items;

        #endregion

        #region Property Region

        public TileMap Map
        {
            get { return map; }
        }

        public List<Character> Characters
        {
            get { return characters; }
        }

        public List<ItemSprite> Items
        {
            get { return items; }
        }

        #endregion

        #region Constructor Region

        public Level(TileMap tileMap)
        {
            map = tileMap;
            characters = new List<Character>();
            items = new List<ItemSprite>();
            characters = new List<Character>();
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            foreach (Character character in characters)
            {
                if (!character.Sprite.IsAnimating)
                {
                    WarpTile tile = map.IsWarpTile(Engine.VectorToCell(character.Sprite.Position));
                    if (tile != null)
                    {
                        character.Sprite.Position = new Vector2(tile.WarpToPoint.X * 32, tile.WarpToPoint.Y * 32);
                        character.Sprite.DirectionFacing = tile.WarpToDirection;
                    }
                }
                character.Update(gameTime);
            }

            foreach (ItemSprite sprite in items)
                sprite.Update(gameTime);

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            map.Draw(spriteBatch, camera);

            foreach (Character character in characters)
                character.Draw(gameTime, spriteBatch);

            foreach (ItemSprite sprite in items)
                sprite.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}
