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

using XRpgLibrary.BattleClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class BattleScreen : BaseGameState
    {
        #region Field Region

        BattleManager battleManger;

        Texture2D backgroundImage;
        Texture2D battefieldImage;
        Texture2D hpBars;
        Rectangle battleRectange;
        Texture2D pixel;
        LinkLabel attack;
        LinkLabel item;
        LinkLabel pokemon;
        LinkLabel run;

        List<Texture2D> pokemonImages;

        static double opponentHPBarScale = 3.5;
        static double myHPBarScale = 4;
        Rectangle opponentHPBar = new Rectangle(0, 100, (int)(120 * opponentHPBarScale), (int)(35 * opponentHPBarScale));
        Rectangle myHPBar = new Rectangle(1024 - 512, 350, (int)(128 * myHPBarScale), (int)(48 * myHPBarScale));

        #endregion

        #region Property Region


        #endregion

        #region Constructor Region

        public BattleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            battleManger = new BattleManager();
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

            pokemonImages = battleImageLoader.loadPokemonImages(battleManger.MyPokemon, battleManger.OpponentPokemon);

            hpBars = battleImageLoader.loadHPBar();

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

            ControlManager.NextControl();

            ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);

            ControlManager_FocusChanged(attack, null);
        }

        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            //Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {

            if (sender == attack)
            {

            }

            if (sender == item)
            {
                //Transition(ChangeType.Push, GameRef.LoadGameScreen);
            }

            if (sender == pokemon)
            {
                //Transition(ChangeType.Push, GameRef.BattleScreen);
            }

            if (sender == run)
            {
                Transition(ChangeType.Change, GameRef.StartMenuScreen);
            }
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);
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

            #region Draw My Pokemon and Status

            //My Pokemon
            GameRef.SpriteBatch.Draw(
                pokemonImages[0],
                new Rectangle(150, 605 - 250, 250, 250),
                Color.White);

            //My Status Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                myHPBar,
                new Rectangle(128, 0, 128, 48),
                Color.White);

            //My HP Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(myHPBar.X + 73 * myHPBarScale), (int)(myHPBar.Y + 27 * myHPBarScale),
                    (int)(48 * myHPBarScale), (int)(3 * myHPBarScale)),
                new Rectangle(4, 92, 2, 2),
                Color.White);

            //My Pokemon Name
            GameRef.SpriteBatch.DrawString(attack.SpriteFont, "Pidgeot", new Vector2((int)(myHPBar.X + 22 * myHPBarScale), (int)(myHPBar.Y + 12 * myHPBarScale)), Color.Black);

            //My Pokemon Level
            GameRef.SpriteBatch.DrawString(attack.SpriteFont, "100", new Vector2((int)(myHPBar.X + 107 * myHPBarScale), (int)(myHPBar.Y + 12 * myHPBarScale)), Color.Black);

            //My Pokemon Current HP
            GameRef.SpriteBatch.DrawString(attack.SpriteFont, "999", new Vector2((int)(myHPBar.X + 73 * myHPBarScale), (int)(myHPBar.Y + 32 * myHPBarScale)), Color.Black);

            //My Pokemon Totl HP
            GameRef.SpriteBatch.DrawString(attack.SpriteFont, "999", new Vector2((int)(myHPBar.X + 100 * myHPBarScale), (int)(myHPBar.Y + 32 * myHPBarScale)), Color.Black);

            //My Pokemon Gender
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(myHPBar.X + 88 * myHPBarScale), (int)(myHPBar.Y + 12 * myHPBarScale),
                    (int)(6 * myHPBarScale), (int)(9 * myHPBarScale)),
                new Rectangle(68, 58, 6, 9),
                Color.White);

            //My Pokemon XP Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(myHPBar.X + 25 * myHPBarScale), (int)(myHPBar.Y + 44 * myHPBarScale),
                    (int)(96 * myHPBarScale), (int)(2 * myHPBarScale)),
                new Rectangle(4, 98, 2, 2),
                Color.White);

            #endregion

            #region Draw Opponent Pokemon and Status

            //Opponent Pokemon
            GameRef.SpriteBatch.Draw(
                pokemonImages[1],
                new Rectangle(600, 300 - 250, 250, 250),
                Color.White);

            //Opponent Status Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                opponentHPBar,
                new Rectangle(0, 0, 120, 35),
                Color.White);

            //Opponent HP Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(opponentHPBar.X + 50 * opponentHPBarScale), (int)(opponentHPBar.Y + 25 * opponentHPBarScale),
                    (int)(48 * opponentHPBarScale), (int)(3 * opponentHPBarScale)),
                new Rectangle(4, 92, 2, 2),
                Color.White);

            //Opponent Pokemon Name
            GameRef.SpriteBatch.DrawString(attack.SpriteFont, "Fearow", new Vector2((int)(opponentHPBar.X + 3 * opponentHPBarScale), (int)(opponentHPBar.Y + 9 * opponentHPBarScale)), Color.Black);

            //Opponent Pokemon Name
            GameRef.SpriteBatch.DrawString(attack.SpriteFont, "100", new Vector2((int)(opponentHPBar.X + 84 * opponentHPBarScale), (int)(opponentHPBar.Y + 9 * opponentHPBarScale)), Color.Black);

            //Opponent Pokemon Gender
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(opponentHPBar.X + 62 * opponentHPBarScale), (int)(opponentHPBar.Y + 8 * opponentHPBarScale),
                    (int)(7 * myHPBarScale), (int)(9 * myHPBarScale)),
                new Rectangle(76, 58, 7, 9),
                Color.White);

            #endregion

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
