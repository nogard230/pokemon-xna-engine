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

using EyesOfTheDragon.Components;

//using XRpgLibrary.BattleClases;

namespace EyesOfTheDragon.GameScreens
{
    public class BattleScreen : BaseGameState
    {
        #region Field Region

        //BattleManager battleManger;

        Texture2D backgroundImage;
        Texture2D battefieldImage;
        Rectangle battleRectange;
        Texture2D pixel;
        LinkLabel attack;
        LinkLabel item;
        LinkLabel pokemon;
        LinkLabel run;

        #endregion

        #region Property Region


        #endregion

        #region Constructor Region

        public BattleScreen(Game game, GameStateManager manager)
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

            BattleImageLoader battleImageLoader = new BattleImageLoader(Game);

            backgroundImage = battleImageLoader.loadBattleBackground("water", "day");
            battefieldImage = battleImageLoader.loadBattlfiled("water", "day");

            battleRectange = new Rectangle(0, 0, 1024, 576);

            attack = new LinkLabel();
            attack.Text = "Fight";
            attack.Size = attack.SpriteFont.MeasureString(attack.Text);
            attack.Selected += new EventHandler(menuItem_Selected);
            attack.Position = new Vector2(30, 600);

            ControlManager.Add(attack);

            item = new LinkLabel();
            item.Text = "Bag";
            item.Size = item.SpriteFont.MeasureString(item.Text);
            item.Selected += new EventHandler(menuItem_Selected);
            item.Position = new Vector2(600, 600);

            ControlManager.Add(item);

            pokemon = new LinkLabel();
            pokemon.Text = "Pokemon";
            pokemon.Size = pokemon.SpriteFont.MeasureString(pokemon.Text);
            pokemon.Selected += new EventHandler(menuItem_Selected);
            pokemon.Position = new Vector2(30, 700);

            ControlManager.Add(pokemon);

            run = new LinkLabel();
            run.Text = "Run";
            run.Size = run.SpriteFont.MeasureString(run.Text);
            run.Selected += new EventHandler(menuItem_Selected);
            run.Position = new Vector2(600, 700);

            ControlManager.Add(run);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {

            if (sender == attack)
                

            if (sender == item)
                //Transition(ChangeType.Push, GameRef.LoadGameScreen);

            if (sender == pokemon)
                //Transition(ChangeType.Push, GameRef.BattleScreen);

            if (sender == run)
                Transition(ChangeType.Pop, GameRef.StartMenuScreen);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            GameRef.SpriteBatch.Draw(
                backgroundImage,
                battleRectange,
                Color.White);

            GameRef.SpriteBatch.Draw(
                battefieldImage,
                battleRectange,
                Color.White);

            ControlManager.Draw(GameRef.SpriteBatch);

            base.Draw(gameTime);

            if (Transitioning)
            {
                FadeBackBufferTo(GameRef.SpriteBatch, Color.Black, (float)transitionTimer.Milliseconds / 750f, GameRef.ScreenRectangle);
            }

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
