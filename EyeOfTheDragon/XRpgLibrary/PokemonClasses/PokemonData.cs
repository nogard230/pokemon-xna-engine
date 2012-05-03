using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.ItemClasses;
using XRpgLibrary.AttackClasses;
using RpgLibrary.EffectClasses;
using XRpgLibrary.AbilityClasses;
using XRpgLibrary.NatureClasses;
using RpgLibrary.CharacterClasses;
using XRpgLibrary.ItemClasses;

namespace XRpgLibrary.PokemonClasses
{
    public class PokemonData
    {

        #region Field Region

        public string UniqueID;
        public string Name;
        public int Level;
        public Gender Gender;
        public int Happiness;
        public BaseItem HoldItem;
        public ElementType Type1;
        public ElementType Type2;
        public Nature Nature;
        public Ability Ability;
        public List<LevelUpMove> LevelUpMoves;
        public List<string> EggMoves;
        public List<string> TutoredMoves;
        public List<int> LearnableTMs;
        public List<Attack> Moveset;

        public int BaseHP;
        public int BaseAttack;
        public int BaseDefense;
        public int BaseSAttack;
        public int BaseSDefense;
        public int BaseSpeed;

        public int HPIV;
        public int AttackIV;
        public int DefenseIV;
        public int SAttackIV;
        public int SDefenseIV;
        public int SpeedIV;

        public List<string> EvolveTo;
        public string EvolveFrom;
        public EvolveCondition EvolveCondition;

        public string EggGroup;

        public int PokedexNum;
        public string PokedexClassification;
        public string PokedexEntry;
        public int HeightFeet;
        public int HeightInches;
        public float Weight;
        public int CaputreRate;
        public int BaseEggSteps;
        public int BaseHappiness;
        public EXPRate XPGrowth;
        public int FleeFlag;

        public string ImageMale;
        public string ImageFemale;


        public float GenderRatioMale;
        public float GenderRatioFemale;

        public AttributePair CurrentHP;

        public List<StatusType> CurrentConditions;

        #endregion

        public PokemonData()
        {
            LevelUpMoves = new List<LevelUpMove>();
            EggMoves = new List<string>();
            TutoredMoves = new List<string>();
            LearnableTMs = new List<int>();
            Moveset = new List<Attack>();

            EvolveTo = new List<string>();

            CurrentConditions = new List<StatusType>();
        }

        public override string ToString()
        {
            string toString = UniqueID;
            toString += ", " + Name;
            toString += ", " + Level;
            toString += ", " + Gender.ToString();
            toString += ", " + Happiness;
            //toString += ", " + HoldItem.ToString();
            toString += ", " + Type1.ToString();
            toString += ", " + Type2.ToString();
            //toString += ", " + Nature.ToString();
            //toString += ", " + Ability.ToString();

            foreach (LevelUpMove move in LevelUpMoves)
                toString += ", " + move.ToString();

            foreach (string attack in EggMoves)
                toString += ", " + attack.ToString();

            foreach (string attack in TutoredMoves)
                toString += ", " + attack.ToString();

            foreach (int tm in LearnableTMs)
                toString += ", " + tm.ToString();

            foreach (Attack attack in Moveset)
                toString += ", " + attack.ToString();

            toString += ", " + BaseHP;
            toString += ", " + BaseAttack;
            toString += ", " + BaseDefense;
            toString += ", " + BaseSAttack;
            toString += ", " + BaseSDefense;
            toString += ", " + BaseDefense;

            toString += ", " + HPIV;
            toString += ", " + AttackIV;
            toString += ", " + DefenseIV;
            toString += ", " + SAttackIV;
            toString += ", " + SDefenseIV;
            toString += ", " + SpeedIV;

            foreach (string pokemon in EvolveTo)
                toString += ", " + pokemon.ToString();

            toString += ", " + EvolveFrom.ToString();
            toString += ", " + EvolveCondition.ToString();

            toString += ", " + EggGroup;

            toString += ", " + PokedexNum;
            toString += ", " + PokedexClassification;
            toString += ", " + PokedexEntry;
            toString += ", " + HeightFeet;
            toString += ", " + HeightInches;
            toString += ", " + Weight;
            toString += ", " + CaputreRate;
            toString += ", " + BaseEggSteps;
            toString += ", " + BaseHappiness;
            toString += ", " + XPGrowth;
            toString += ", " + FleeFlag;

            toString += ", " + ImageMale;
            toString += ", " + ImageFemale;

            toString += ", " + GenderRatioMale;
            toString += ", " + GenderRatioFemale;
            //toString += ", " + CurrentHP.ToString();
            
            foreach(StatusType status in CurrentConditions)
                toString += ", " + status.ToString();

            return toString;
        }

    }
}
