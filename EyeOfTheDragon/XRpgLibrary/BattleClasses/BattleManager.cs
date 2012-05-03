using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;

using XRpgLibrary.PokemonClasses;
using RpgLibrary.CharacterClasses;

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
