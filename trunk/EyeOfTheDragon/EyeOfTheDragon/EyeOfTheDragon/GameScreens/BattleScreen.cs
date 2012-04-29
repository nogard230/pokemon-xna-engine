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

namespace EyesOfTheDragon.GameScreens
{
    public class BattleScreen : BaseGameState
    {
        #region Field Region


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

        }

        public override void Update(GameTime gameTime)
        {

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
                Matrix.Identity);

            base.Draw(gameTime);

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
