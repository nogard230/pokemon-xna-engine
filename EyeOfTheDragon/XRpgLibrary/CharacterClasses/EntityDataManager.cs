using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using XRpgLibrary.AttackClasses;
using XRpgLibrary.NatureClasses;

namespace RpgLibrary.CharacterClasses
{
    public class EntityDataManager
    {
        #region Field Region

        readonly static Dictionary<string, EntityData> entityData = new Dictionary<string, EntityData>();
        readonly static Dictionary<string, PokemonData> pokemonData = new Dictionary<string, PokemonData>();

        #endregion

        #region Property Region

        public static Dictionary<string, EntityData> EntityData
        {
            get { return entityData; }
        }

        public static Dictionary<string, PokemonData> PokemonData
        {
            get { return pokemonData; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region
        public static Pokemon GetGenericPokemonFromData(string ID, int level)
        {
            Pokemon pokemon = Pokemon.FromPokemonData(PokemonData[ID], level);
            Random r = new Random();
            pokemon.HpIV = r.Next(1, 32);
            pokemon.AttackIV = r.Next(1, 32);
            pokemon.DefenseIV = r.Next(1, 32);
            pokemon.SAttackIV = r.Next(1, 32);
            pokemon.SDefenseIV = r.Next(1, 32);
            pokemon.SpeedIV = r.Next(1, 32);

            pokemon.Nature = Nature.GetRandomNature();

            int rGender = r.Next(101);
            if (rGender >= pokemon.GenderRatioFemale * 100)
            {
                pokemon.Gender = Gender.Male;
            }
            else if (rGender < pokemon.GenderRatioFemale * 100)
            {
                pokemon.Gender = Gender.Female;
            }

            if (pokemon.GenderRatioFemale == 0 && pokemon.GenderRatioMale == 0)
            {
                pokemon.Gender = Gender.None;
            }

            for (int i = pokemon.LevelUpMoves.Count - 1; i >= 0; i--)
            {
                if (pokemon.LevelUpMoves[i].level < level)
                {
                    pokemon.Moveset.Add(AttackDataManager.GetAttack(pokemon.LevelUpMoves[i].attack));
                }
                if (pokemon.Moveset.Count == 4)
                {
                    break;
                }
            }

            pokemon.CurrentHP = new AttributePair(pokemon.HPStat);

            return pokemon;

        }
        #endregion
    }
}
