using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RpgLibrary.CharacterClasses;

namespace XRpgLibrary.Controls
{
    public class AttackControl : Control
    {
        Color highlightColor;
        Texture2D controlBackground;
        Rectangle location;
        string text;
        Texture2D type;
        Rectangle typeLocation;
        AttributePair attackPP;

        public AttackControl(Texture2D background, Rectangle position, Texture2D elementSymbols, Rectangle elementLocation, string name, AttributePair pp, Color highlight)
        {
            controlBackground = background;
            location = position;
            type = elementSymbols;
            typeLocation = elementLocation;
            text = name;
            attackPP = pp;
            highlightColor = highlight;

            Name = name;
            enabled = true;
            tabStop = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color color;
            if (this.hasFocus)
            {
                color = highlightColor;
            }
            else
            {
                color = Color.White;
            }

            spriteBatch.Draw(
                controlBackground,
                location,
                color);

            spriteBatch.DrawString(SpriteFont, text, new Vector2(location.X + 15, location.Y + 4), Color.Black);

            spriteBatch.Draw(
                type,
                new Rectangle(location.X + 20, location.Y + 44, 64, 32),
                typeLocation,
                color);

            spriteBatch.DrawString(ControlManager.SpriteFont, attackPP.CurrentValue + "/" + attackPP.MaximumValue, new Vector2(location.X + 105, location.Y + 39), Color.Black);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
                base.OnSelected(null);
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
