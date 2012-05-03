using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.ItemClasses;
using RpgLibrary.ItemClasses;

namespace XRpgLibrary.PokemonClasses
{
    public enum EvolutionType { Level, LevelWithItem, LevelWithMove, LevelWtihPokemon, Item, Friendship, Location };
    public enum EvolutionGender { Both, Male, Female };

    public class EvolveCondition
    {
        #region Private Members
        EvolutionType type; 
        EvolutionGender gender; 
        int level;
        string item;
        string attack;
        string pokemonID;
        int friendship;
        string location;
        #endregion Private Members

        #region Constructors
        private EvolveCondition(EvolutionType evolType, EvolutionGender evolGender, int evolLevel, string evolItem, string evolAttack, string evolPokemonID, int evolFriendship, string evolLocation)
        {
            type = evolType;
            gender = evolGender;
            level = evolLevel;
            item = evolItem;
            attack = evolAttack;
            pokemonID = evolPokemonID;
            friendship = evolFriendship;
            location = evolLocation;
        }

        private EvolveCondition()
        {

        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public EvolutionType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public EvolutionGender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        /// <summary>
        /// Gets or sets the attack.
        /// </summary>
        public string Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        /// <summary>
        /// Gets or sets the pokemonid.
        /// </summary>
        public string PokemonID
        {
            get { return pokemonID; }
            set { pokemonID = value; }
        }

        /// <summary>
        /// Gets or sets the friendship.
        /// </summary>
        public int Friendship
        {
            get { return friendship; }
            set { friendship = value; }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        #endregion Public Attributes

        public static EvolveCondition CreateEvolveByLevel(int level, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.Level, gender, level, null, "", "", -1, "");
        }

        public static EvolveCondition CreateEvolveByLevelWithItem(string item, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.LevelWithItem, gender, -1, item, "", "", -1, "");
        }

        public static EvolveCondition CreateEvolveByLevelWithAttack(string attack, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.LevelWithMove, gender, -1, null, attack, "", -1, "");
        }

        public static EvolveCondition CreateEvolveByLevelWithPokemon(string pokemonID, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.LevelWtihPokemon, gender, -1, null, "", pokemonID, -1, "");
        }

        public static EvolveCondition CreateEvolveByItem(string item, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.Item, gender, -1, item, "", "", -1, "");
        }

        public static EvolveCondition CreateEvolveByFriendship(int friendship, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.Friendship, gender, -1, null, "", "", friendship, "");
        }

        public static EvolveCondition CreateEvolveByLocation(string location, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.Location, gender, -1, null, "", "", -1, location);
        }

        public bool CanEvolve(Pokemon pokemon, BaseItem usedItem = null, string currentLocation = "")
        {
            switch (type)
            {
                case EvolutionType.Level:
                    if (pokemon.Level >= level)
                    {
                        return CheckGender(pokemon);
                    }
                    else
                    {
                        return false;
                    }

                case EvolutionType.LevelWithItem:
                    if (pokemon.HoldItem.Name == item )
                    {
                        return CheckGender(pokemon);
                    }
                    else
                    {
                        return false;
                    }

                case EvolutionType.LevelWtihPokemon:
                    return false;

                case EvolutionType.Item:
                    if (usedItem.Name == item)
                    {
                        return CheckGender(pokemon);
                    }
                    else
                    {
                        return false;
                    }

                case EvolutionType.Friendship:
                    if (pokemon.Happiness >= friendship)
                    {
                        return CheckGender(pokemon);
                    }
                    else
                    {
                        return false;
                    }

                case EvolutionType.Location:
                    if (currentLocation == location)
                    {
                        return CheckGender(pokemon);
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }

        private bool CheckGender(Pokemon pokemon)
        {
            if (gender == EvolutionGender.Female && pokemon.Gender == PokemonClasses.Gender.Female)
            {
                return true;
            }
            else if (gender == EvolutionGender.Male && pokemon.Gender == PokemonClasses.Gender.Male)
            {
                return true;
            }
            else if (gender == EvolutionGender.Both)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string toString = type.ToString();
            toString += ", " + gender.ToString();
            toString += ", " + level;
            toString += ", " + item;
            toString += ", " + attack;
            toString += ", " + pokemonID;
            toString += ", " + friendship;
            toString += ", " + location;

            return toString;
        }
    }
}
