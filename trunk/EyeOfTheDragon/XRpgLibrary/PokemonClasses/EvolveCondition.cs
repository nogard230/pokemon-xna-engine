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
        EvolutionType type; 
        EvolutionGender gender; 
        int level;
        BaseItem item;
        string attack;
        string pokemonID;
        int friendship;
        string location;

        private EvolveCondition(EvolutionType evolType, EvolutionGender evolGender, int evolLevel, BaseItem evolItem, string evolAttack, string evolPokemonID, int evolFriendship, string evolLocation)
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

        public static EvolveCondition CreateEvolveByLevel(int level, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.Level, gender, level, null, "", "", -1, "");
        }

        public static EvolveCondition CreateEvolveByLevelWithItem(BaseItem item, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.LevelWithItem, gender, -1, item, "", "", -1, "");
        }

        public static EvolveCondition CreateEvolveByLevelWithItem(string attack, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.LevelWithMove, gender, -1, null, attack, "", -1, "");
        }

        public static EvolveCondition CreateEvolveByLevelWithPokemon(string pokemonID, EvolutionGender gender = EvolutionGender.Both)
        {
            return new EvolveCondition(EvolutionType.LevelWtihPokemon, gender, -1, null, "", pokemonID, -1, "");
        }

        public static EvolveCondition CreateEvolveByItem(BaseItem item, EvolutionGender gender = EvolutionGender.Both)
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
                    if (pokemon.HoldItem.Name == item.Name )
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
                    if (usedItem.Name == item.Name)
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
            if (gender == EvolutionGender.Female && pokemon.Gender == Gender.Female)
            {
                return true;
            }
            else if (gender == EvolutionGender.Male && pokemon.Gender == Gender.Male)
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
    }
}
