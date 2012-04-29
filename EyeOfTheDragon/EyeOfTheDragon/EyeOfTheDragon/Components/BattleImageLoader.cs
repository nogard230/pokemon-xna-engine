using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EyesOfTheDragon.Components
{
    class BattleImageLoader
    {
        ContentManager Content;
        Texture2D backgroundCollection;

        public BattleImageLoader(Game game)
        {
            Content = game.Content;
            backgroundCollection = Content.Load<Texture2D>(@"Backgrounds/battlebgs");
        }

        public Texture2D loadBattleBackground(string backgroundType, string time)
        {
            Texture2D background;
            //Rectangle source;

            background = Content.Load<Texture2D>(@"Backgrounds/battleTest");

            return background;
        }

        public Texture2D loadBattlfiled(string type, string time)
        {
            Texture2D battlefield;

            battlefield = Content.Load<Texture2D>(@"Backgrounds/battlefieldtest");

            return battlefield;
        }
    }
}
