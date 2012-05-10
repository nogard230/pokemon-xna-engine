using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using XRpgLibrary.PokemonClasses;
using XRpgLibrary.SpriteClasses;

namespace EyesOfTheDragon.Components
{
    public class BattleImageLoader
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

        public Texture2D loadBattlfieled(string type, string time)
        {
            Texture2D battlefield;

            battlefield = Content.Load<Texture2D>(@"Backgrounds/battlefieldtest");

            return battlefield;
        }

        public List<GifAnimation.GifAnimation> loadPokemonImages(Pokemon myPokemon, Pokemon opponentPokemon)
        {
            List<GifAnimation.GifAnimation> pokemon = new List<GifAnimation.GifAnimation>();

            pokemon.Add(Content.Load<GifAnimation.GifAnimation>(@"Pokemon/Back/" + myPokemon.ImageMale));
            pokemon.Add(Content.Load<GifAnimation.GifAnimation>(@"Pokemon/Front/" + opponentPokemon.ImageMale));

            return pokemon;
        }

        public Texture2D loadHPBar()
        {
            Texture2D bar = Content.Load<Texture2D>(@"GUI/hpbars");

            return bar;
        }

        public Texture2D loadHUD()
        {
            Texture2D hud = Content.Load<Texture2D>(@"GUI/battlehud");

            return hud;
        }

        public Texture2D loadAttackFrame()
        {
            return Content.Load<Texture2D>(@"GUI/attacktile");
        }

        public Texture2D loadTypeSymbols()
        {
            return Content.Load<Texture2D>(@"GUI/typeicons");
        }
    }
}
