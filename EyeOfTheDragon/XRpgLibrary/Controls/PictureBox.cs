﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class PictureBox : Control
    {
        #region Field Region

        Texture2D image;
        Rectangle sourceRect;
        Rectangle destRect;
        Color selectedColor;

        #endregion

        #region Property Region

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public Rectangle SourceRectangle
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return destRect; }
            set { destRect = value; }
        }
        
        #endregion

        #region Constructors

        public PictureBox(Texture2D image, Rectangle destination)
        {
            Image = image;
            DestinationRectangle = destination;
            SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
            enabled = true;
            tabStop = true;
            selectedColor = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            Image = image;
            DestinationRectangle = destination;
            SourceRectangle = source;
            Color = Color.White;
            enabled = true;
            tabStop = true;
            selectedColor = Color.White;
        }
        
        public PictureBox(Texture2D image, Rectangle destination, Rectangle source, Color highlight)
        {
            Image = image;
            DestinationRectangle = destination;
            SourceRectangle = source;
            Color = Color.White;
            enabled = true;
            tabStop = true;
            selectedColor = highlight;
        }

        #endregion

        #region Abstract Method Region

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hasFocus)
            {
                spriteBatch.Draw(image, destRect, sourceRect, selectedColor);
            }
            else
            {
                spriteBatch.Draw(image, destRect, sourceRect, color);
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
                base.OnSelected(null);
        }

        #endregion

        #region Picture Box Methods

        public void SetPosition(Vector2 newPosition)
        {
            destRect = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                sourceRect.Width,
                sourceRect.Height);
        }

        #endregion
    }
}
