using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.BattleClasses
{
    public class BattleManager
    {

        #region Private Members
        Pokemon myPokemon;
        Pokemon opponentPokemon;
        #endregion Private Members

        #region Constructors
        public BattleManager()
        {
            PokemonData p1 = new PokemonData();

            PokemonData p2 = new PokemonData();

            p2.BaseSpeed = 100;

            MyPokemon = Pokemon.FromPokemonData(p1);
            OpponentPokemon = Pokemon.FromPokemonData(p2);

        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the mypokemon.
        /// </summary>
        public Pokemon MyPokemon
        {
            get { return myPokemon; }
            set { myPokemon = value; }
        }

        /// <summary>
        /// Gets or sets the opponentpokemon.
        /// </summary>
        public Pokemon OpponentPokemon
        {
            get { return opponentPokemon; }
            set { opponentPokemon = value; }
        }
        #endregion Public Attributes

    }
}
