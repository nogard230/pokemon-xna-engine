using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EyesOfTheDragon.Components;

using XRpgLibrary;
using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.WorldClasses;
using XRpgLibrary.Controls;

namespace EyesOfTheDragon.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        #region Field Region

        Engine engine = new Engine(32, 32);
        static Player player;
        static World world;

        GridControlManager pauseMenu;
        Texture2D menuBackground;
        LinkLabel pokemon;
        LinkLabel pokedex;
        LinkLabel bag;
        LinkLabel trainer;
        LinkLabel save;
        LinkLabel options;
        
        #endregion

        #region Property Region

        public static World World
        {
            get { return world; }
            set { world = value; }
        }

        public static Player Player
        {
            get { return player; }
            set { player = value; }
        }

        #endregion

        #region Constructor Region

        public GamePlayScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            base.LoadContent();

            SpriteFont pauseFont = GameRef.Content.Load<SpriteFont>(@"Fonts\PauseMenuFont");
            pauseMenu = new GridControlManager(pauseFont);
            pokemon = new LinkLabel();
            pokemon.Text = "Pokemon";
            pokemon.SpriteFont = pauseFont;
            pokedex = new LinkLabel();
            pokedex.Text = "Pokedex";
            pokedex.SpriteFont = pauseFont;
            bag = new LinkLabel();
            bag.Text = "Bag";
            bag.SpriteFont = pauseFont;
            trainer = new LinkLabel();
            trainer.Text = player.Character.Entity.EntityName;
            trainer.SpriteFont = pauseFont;
            save = new LinkLabel();
            save.Text = "Save";
            save.SpriteFont = pauseFont;
            options = new LinkLabel();
            options.Text = "Options";
            options.SpriteFont = pauseFont;

            pauseMenu.AddControl(pokedex, 0);
            pauseMenu.AddControl(pokemon, 1);
            pauseMenu.AddControl(bag, 2);
            pauseMenu.AddControl(trainer, 3);
            pauseMenu.AddControl(save, 4);
            pauseMenu.AddControl(options, 5);
        }

        public override void Update(GameTime gameTime)
        {
            world.Update(gameTime);
            player.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                player.Camera.Transformation);

            base.Draw(gameTime);

            world.DrawLevel(gameTime, GameRef.SpriteBatch, player.Camera);
            player.Draw(gameTime, GameRef.SpriteBatch);
            pauseMenu.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
