using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.Controls
{
    class BlankGridSpace : Control
    {
        #region Private Members
        int jumpToR = -1;
        int jumpToC = -1;
        #endregion Private Members

        #region Constructors
        public BlankGridSpace()
        {
            enabled = false;
            tabStop = false;
        }

        public BlankGridSpace(int r, int c)
        {
            enabled = false;
            tabStop = false;
            jumpToR = r;
            jumpToC = c;
        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the jumptor.
        /// </summary>
        public int JumpToR
        {
            get { return jumpToR; }
            set { jumpToR = value; }
        }

        /// <summary>
        /// Gets or sets the jumptoc.
        /// </summary>
        public int JumpToC
        {
            get { return jumpToC; }
            set { jumpToC = value; }
        }
        #endregion Public Attributes

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
        }

        public override void HandleInput(Microsoft.Xna.Framework.PlayerIndex playerIndex)
        {
            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

        }
    }
}
