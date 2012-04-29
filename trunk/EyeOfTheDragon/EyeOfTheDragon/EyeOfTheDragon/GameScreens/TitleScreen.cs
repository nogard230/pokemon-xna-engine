using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary;
using XRpgLibrary.Controls;

namespace EyesOfTheDragon.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        #region Field region

        Texture2D backgroundImage;
        Texture2D pixel;
        LinkLabel startLabel;
        SpriteFont font;

        #endregion

        #region Constructor region

        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method region

        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;

            backgroundImage = Content.Load<Texture2D>(@"Backgrounds\titlescreen");
            pixel = Content.Load<Texture2D>(@"Backgrounds\pixel");
            font = Content.Load<SpriteFont>(@"Fonts\TitleFont");
            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(225, 600);
            startLabel.Text = "Press ENTER to begin";
            startLabel.Color = Color.White;
            startLabel.SpriteFont = font;
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(startLabel_Selected);

            ControlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(
                backgroundImage,
                GameRef.ScreenRectangle,
                Color.White);

            //GameRef.SpriteBatch.Draw(pixel, new Rectangle(0, 600, 1024, 75), Color.Black);
            GameRef.SpriteBatch.DrawString(font, "Press ENTER to begin", new Vector2(227, 602), Color.Black);

            ControlManager.Draw(GameRef.SpriteBatch);

            if (Transitioning)
            {
                FadeBackBufferTo(GameRef.SpriteBatch, Color.Black, (float)transitionTimer.Milliseconds / 750f, GameRef.ScreenRectangle);
            }


            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Title Screen Methods

        private void startLabel_Selected(object sender, EventArgs e)
        {
            Transition(ChangeType.Push, GameRef.StartMenuScreen);
        }

        #endregion
    }
}
