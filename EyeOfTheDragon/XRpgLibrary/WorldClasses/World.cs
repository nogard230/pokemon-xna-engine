﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;

namespace XRpgLibrary.WorldClasses
{
    public class World : DrawableGameComponent
    {
        #region Graphic Field and Property Region

        Rectangle screenRect;

        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }

        #endregion

        #region Item Field and Property Region

        ItemManager itemManager = new ItemManager();

        public ItemManager ItemManager
        {
            get { return itemManager; }
        }

        #endregion

        #region Level Field and Property Region

        readonly List<Level> levels = new List<Level>();
        int currentLevel = -1;

        public List<Level> Levels
        {
            get { return levels; }
        }

        public int CurrentLevel
        {
            get { return currentLevel; }
            set
            {
                if (value < 0 || value >= levels.Count)
                    throw new IndexOutOfRangeException();

                if (levels[value] == null)
                    throw new NullReferenceException();

                currentLevel = value;

                MovementValidator.SetLevel(levels[currentLevel]);
                ObjectInteractor.SetLevel(levels[currentLevel]);
                ObjectInteractor.SetManager(itemManager);
            }
        }

        #endregion

        #region Constructor Region

        public World(Game game, Rectangle screenRectangle)
            : base(game)
        {
            screenRect = screenRectangle;
        }

        #endregion

        #region Method Region

        public override void Update(GameTime gameTime)
        {
            levels[currentLevel].Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void DrawLevel(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            levels[currentLevel].Draw(gameTime, spriteBatch, camera);
        }

        #endregion
    }
}
