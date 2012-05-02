using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace RpgLibrary.CharacterClasses
{
    public class EntityDataManager
    {
        #region Field Region

        readonly Dictionary<string, EntityData> entityData = new Dictionary<string, EntityData>();
        readonly Dictionary<string, PokemonData> pokemonData = new Dictionary<string, PokemonData>();

        #endregion

        #region Property Region

        public Dictionary<string, EntityData> EntityData
        {
            get { return entityData; }
        }

        public Dictionary<string, PokemonData> PokemonData
        {
            get { return pokemonData; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region
        #endregion
    }
}
