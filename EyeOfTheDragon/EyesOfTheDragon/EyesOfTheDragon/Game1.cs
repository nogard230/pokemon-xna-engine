using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using XRpgLibrary;
using RpgLibrary;

using EyesOfTheDragon.GameScreens;
using EyesOfTheDragon.Components;

namespace EyesOfTheDragon
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region XNA Field Region

        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        #endregion

        #region Game State Region

        GameStateManager stateManager;

        public TitleScreen TitleScreen;
        public StartMenuScreen StartMenuScreen;
        public GamePlayScreen GamePlayScreen;
        public CharacterGeneratorScreen CharacterGeneratorScreen;
        public LoadGameScreen LoadGameScreen;
        public SkillScreen SkillScreen;
        
        #endregion

        #region Screen Field Region

        const int screenWidth = 1024;
        const int screenHeight = 768;

        public readonly Rectangle ScreenRectangle;

        #endregion

        #region Frames Per Second Field Region

        private float fps;
        private float updateInterval = 1.0f;
        private float timeSinceLastUpdate = 0.0f;
        private float frameCount = 0;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            ScreenRectangle = new Rectangle(
                0,
                0,
                screenWidth,
                screenHeight);

            Content.RootDirectory = "Content";

            Components.Add(new InputHandler(this));

            stateManager = new GameStateManager(this);
            Components.Add(stateManager);

            TitleScreen = new TitleScreen(this, stateManager);
            StartMenuScreen = new StartMenuScreen(this, stateManager);
            GamePlayScreen = new GamePlayScreen(this, stateManager);
            CharacterGeneratorScreen = new CharacterGeneratorScreen(this, stateManager);
            LoadGameScreen = new LoadGameScreen(this, stateManager);
            SkillScreen = new GameScreens.SkillScreen(this, stateManager);

            stateManager.ChangeState(TitleScreen);

            this.IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            DataManager.ReadEntityData(Content);

            DataManager.ReadArmorData(Content);
            DataManager.ReadShieldData(Content);
            DataManager.ReadWeaponData(Content);

            DataManager.ReadChestData(Content);
            DataManager.ReadKeyData(Content);

            DataManager.ReadSkillData(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCount++;
            timeSinceLastUpdate += elapsed;

            if (timeSinceLastUpdate > updateInterval)
            {
                fps = frameCount / timeSinceLastUpdate;
        #if XBOX360
                System.Diagnostics.Debug.WriteLine("FPS: " + fps.ToString());
        #else
                this.Window.Title = "FPS: " + fps.ToString();
        #endif
                frameCount = 0;
                timeSinceLastUpdate -= updateInterval;
            }

        }
    }
}
