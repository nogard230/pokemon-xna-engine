using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using XRpgLibrary.PokemonClasses;

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

        public Texture2D loadBattlfiled(string type, string time)
        {
            Texture2D battlefield;

            battlefield = Content.Load<Texture2D>(@"Backgrounds/battlefieldtest");

            return battlefield;
        }

        public List<Texture2D> loadPokemonImages(Pokemon myPokemon, Pokemon opponentPokemon)
        {
            List<Texture2D> pokemon = new List<Texture2D>();

            pokemon.Add(Content.Load<Texture2D>(@"Pokemon/Back/testback"));
            pokemon.Add(Content.Load<Texture2D>(@"Pokemon/Front/test"));

            return pokemon;
        }

        public Texture2D loadHPBar()
        {
            Texture2D bar = Content.Load<Texture2D>(@"GUI/hpbars");

            return bar;
        }
    }
}
