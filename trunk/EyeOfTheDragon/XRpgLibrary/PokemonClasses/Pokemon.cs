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

using Microsoft.Xna.Framework;

namespace XRpgLibrary.PokemonClasses
{
    public enum Gender { Male, Female, None };
    public enum EXPRate { Erratic, Fast, MediumFast, MediumSlow, Slow, Fluctuating };

    public struct LevelUpMove
    {
        
        #region Public Members
        public int level;
        public string attack;
        #endregion Public Members

        #region Constructors
        public LevelUpMove(int l, string a)
        {
            level = l;
            attack = a;
        }
        #endregion Constructors

        public string ToString()
        {
            string toString = attack + ", " + level;
            return toString;
        }
    }

    public class Pokemon
    {
        #region Field Region

        string uniqueID;
        string name;
        int level;
        Gender gender;
        int happiness;
        BaseItem holdItem;
        ElementType type1;
        ElementType type2;
        Nature nature;
        Ability ability;
        List<LevelUpMove> levelUpMoves;
        List<string> eggMoves;
        List<string> tutoredMoves;
        List<int> learnableTMs;
        List<Attack> moveset;

        int baseHP;
        int baseAttack;
        int baseDefense;
        int baseSAttack;
        int baseSDefense;
        int baseSpeed;

        int hpIV;
        int attackIV;
        int defenseIV;
        int sAttackIV;
        int sDefenseIV;
        int speedIV;

        List<string> evolveTo;
        string evolveFrom;
        EvolveCondition evolveCondition;

        string eggGroup;

        int pokedexNum;
        string pokedexClassification;
        string pokedexEntry;
        int heightFeet;
        int heightInches;
        float weight;
        int caputreRate;
        int baseEggSteps;
        int baseHappiness;
        EXPRate xpGrowth;
        int fleeFlag;

        string imageMale;
        string imageFemale;

        float genderRatioMale;
        float genderRatioFemale;

        int criticalStage = 0;
        int attackStage = 0;
        int defenseStage = 0;
        int sAttackStage = 0;
        int sDefenseStage = 0;
        int speedStage = 0;
        int accuracyStage = 0;
        int evasionStage = 0;
        AttributePair currentHP;

        List<StatusType> currentConditions;

        #endregion

        #region Properites

        /// <summary>
        /// Gets (or sets privately) the name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the level.
        /// </summary>
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the gender.
        /// </summary>
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the happiness.
        /// </summary>
        public int Happiness
        {
            get { return happiness; }
            set { happiness = value; }
        }

        /// <summary>
        /// Gets or sets the holditem.
        /// </summary>
        public BaseItem HoldItem
        {
            get { return holdItem; }
            set { holdItem = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the type1.
        /// </summary>
        public ElementType Type1
        {
            get { return type1; }
            set { type1 = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the type2.
        /// </summary>
        public ElementType Type2
        {
            get { return type2; }
            set { type2 = value; }
        }

        public Nature Nature
        {
            get { return nature; }
            set { nature = value; }
        }

        public Ability Ability
        {
            get { return ability; }
            set { ability = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the levelupmoves.
        /// </summary>
        public List<LevelUpMove> LevelUpMoves
        {
            get { return levelUpMoves; }
            set { levelUpMoves = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the eggmoves.
        /// </summary>
        public List<string> EggMoves
        {
            get { return eggMoves; }
            set { eggMoves = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the tutoredmoves.
        /// </summary>
        public List<string> TutoredMoves
        {
            get { return tutoredMoves; }
            set { tutoredMoves = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the learnabletms.
        /// </summary>
        public List<int> LearnableTMs
        {
            get { return learnableTMs; }
            set { learnableTMs = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the moveset.
        /// </summary>
        public List<Attack> Moveset
        {
            get { return moveset; }
            set { moveset = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basehp.
        /// </summary>
        public int BaseHP
        {
            get { return baseHP; }
            set { baseHP = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the baseattack.
        /// </summary>
        public int BaseAttack
        {
            get { return baseAttack; }
            set { baseAttack = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basedefense.
        /// </summary>
        public int BaseDefense
        {
            get { return baseDefense; }
            set { baseDefense = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basesattack.
        /// </summary>
        public int BaseSAttack
        {
            get { return baseSAttack; }
            set { baseSAttack = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basesdefense.
        /// </summary>
        public int BaseSDefense
        {
            get { return baseSDefense; }
            set { baseSDefense = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basespeed.
        /// </summary>
        public int BaseSpeed
        {
            get { return baseSpeed; }
            set { baseSpeed = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the hpiv.
        /// </summary>
        public int HpIV
        {
            get { return hpIV; }
            set { hpIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the attackiv.
        /// </summary>
        public int AttackIV
        {
            get { return attackIV; }
            set { attackIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the defenseiv.
        /// </summary>
        public int DefenseIV
        {
            get { return defenseIV; }
            set { defenseIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the sattackiv.
        /// </summary>
        public int SAttackIV
        {
            get { return sAttackIV; }
            set { sAttackIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the sdefenseiv.
        /// </summary>
        public int SDefenseIV
        {
            get { return sDefenseIV; }
            set { sDefenseIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the speediv.
        /// </summary>
        public int SpeedIV
        {
            get { return speedIV; }
            set { speedIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the evolveto.
        /// </summary>
        public List<string> EvolveTo
        {
            get { return evolveTo; }
            set { evolveTo = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the evolvefrom.
        /// </summary>
        public string EvolveFrom
        {
            get { return evolveFrom; }
            set { evolveFrom = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the evolvecondition.
        /// </summary>
        public EvolveCondition EvolveCondition
        {
            get { return evolveCondition; }
            set { evolveCondition = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the egggroup.
        /// </summary>
        public string EggGroup
        {
            get { return eggGroup; }
            set { eggGroup = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the pokedexnum.
        /// </summary>
        public int PokedexNum
        {
            get { return pokedexNum; }
            set { pokedexNum = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the pokedexclassification.
        /// </summary>
        public string PokedexClassification
        {
            get { return pokedexClassification; }
            set { pokedexClassification = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the pokedexentry.
        /// </summary>
        public string PokedexEntry
        {
            get { return pokedexEntry; }
            set { pokedexEntry = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the heightfeet.
        /// </summary>
        public int HeightFeet
        {
            get { return heightFeet; }
            set { heightFeet = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the heightinches.
        /// </summary>
        public int HeightInches
        {
            get { return heightInches; }
            set { heightInches = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the weight.
        /// </summary>
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the caputrerate.
        /// </summary>
        public int CaputreRate
        {
            get { return caputreRate; }
            set { caputreRate = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the baseeggsteps.
        /// </summary>
        public int BaseEggSteps
        {
            get { return baseEggSteps; }
            set { baseEggSteps = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basehappiness.
        /// </summary>
        public int BaseHappiness
        {
            get { return baseHappiness; }
            set { baseHappiness = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the xpgrowth.
        /// </summary>
        public EXPRate XpGrowth
        {
            get { return xpGrowth; }
            set { xpGrowth = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the fleeflag.
        /// </summary>
        public int FleeFlag
        {
            get { return fleeFlag; }
            set { fleeFlag = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the imagemale.
        /// </summary>
        public string ImageMale
        {
            get { return imageMale; }
            set { imageMale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the imagefemale.
        /// </summary>
        public string ImageFemale
        {
            get { return imageFemale; }
            set { imageFemale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the genderratiomale.
        /// </summary>
        public float GenderRatioMale
        {
            get { return genderRatioMale; }
            set { genderRatioMale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the genderratiofemale.
        /// </summary>
        public float GenderRatioFemale
        {
            get { return genderRatioFemale; }
            set { genderRatioFemale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the currenthp.
        /// </summary>
        public AttributePair CurrentHP
        {
            get { return currentHP; }
            set { currentHP = value; }
        }

        #endregion

        /// <summary>
        /// Gets (or sets privately) the currentconditions.
        /// </summary>
        public List<StatusType> CurrentConditions
        {
            get { return currentConditions; }
            set { currentConditions = value; }
        }

        #region Stats

        public int HPStat
        {
            get { return (int)Math.Floor((((HpIV + 2 * BaseHP + 100.0) * Level) / 100.0 + 10.0)); }
        }

        public int AttackStat
        {
            get { return (int)Math.Floor((((AttackIV + 2 * BaseAttack * AttackStageModifier) * Level) / 100.0 + 5.0) * Nature.AttackEffect); }
        }

        public int DefenseStat
        {
            get { return (int)Math.Floor((((DefenseIV + 2 * BaseDefense * DefenseStageModifier) * Level) / 100.0 + 5.0) * Nature.DefenseEffect); }
        }

        public int SpecialAttackStat
        {
            get { return (int)Math.Floor((((SAttackIV + 2 * BaseSAttack * SpecialAttackStageModifier) * Level) / 100.0 + 5.0) * Nature.SpecialAttackEffect); }
        }

        public int SpecialDefenseStat
        {
            get { return (int)Math.Floor((((SDefenseIV + 2 * BaseSDefense * SpecialDefenseStageModifier) * Level) / 100.0 + 5.0) * Nature.SpecialDefenseEffect); }
        }

        public int SpeedStat
        {
            get { return (int)Math.Floor((((SpeedIV + 2 * BaseSpeed * SpeedStageModifier) * Level) / 100.0 + 5.0) * Nature.SpeedEffect); }
        }

        /// <summary>
        /// Gets (or sets privately) the criticalstage.
        /// </summary>
        public int CriticalStage
        {
            get
            { return criticalStage; }
            private set { criticalStage = (int)MathHelper.Clamp(value, 1, 5); }
        }

        /// <summary>
        /// Gets (or sets privately) the attackstage.
        /// </summary>
        public int AttackStage
        {
            get { return attackStage; }
            private set { attackStage = (int) MathHelper.Clamp(value, -6, 6); }
        }

        /// <summary>
        /// Gets (or sets privately) the defensestage.
        /// </summary>
        public int DefenseStage
        {
            get { return defenseStage; }
            private set { defenseStage = (int)MathHelper.Clamp(value, -6, 6); }
        }

        /// <summary>
        /// Gets (or sets privately) the sattackstage.
        /// </summary>
        public int SAttackStage
        {
            get { return sAttackStage; }
            private set { sAttackStage = (int)MathHelper.Clamp(value, -6, 6); }
        }

        /// <summary>
        /// Gets (or sets privately) the sdefensestage.
        /// </summary>
        public int SDefenseStage
        {
            get { return sDefenseStage; }
            private set { sDefenseStage = (int)MathHelper.Clamp(value, -6, 6); }
        }

        /// <summary>
        /// Gets (or sets privately) the speedstage.
        /// </summary>
        public int SpeedStage
        {
            get { return speedStage; }
            private set { speedStage = (int)MathHelper.Clamp(value, -6, 6); }
        }

        /// <summary>
        /// Gets (or sets privately) the accuracystage.
        /// </summary>
        public int AccuracyStage
        {
            get { return accuracyStage; }
            private set { accuracyStage = (int)MathHelper.Clamp(value, -6, 6); }
        }

        /// <summary>
        /// Gets (or sets privately) the evasionstage.
        /// </summary>
        public int EvasionStage
        {
            get { return evasionStage; }
            private set { evasionStage = (int)MathHelper.Clamp(value, -6, 6); }
        }

        public float AttackStageModifier
        {
            get { return statStageModifier(attackStage); }
        }

        public float DefenseStageModifier
        {
            get { return statStageModifier(defenseStage); }
        }

        public float SpecialAttackStageModifier
        {
            get { return statStageModifier(sAttackStage); }
        }

        public float SpecialDefenseStageModifier
        {
            get { return statStageModifier(sDefenseStage); }
        }

        public float SpeedStageModifier
        {
            get { return statStageModifier(speedStage); }
        }

        public float AccuracyStageModifier
        {
            get { return AEStageModifier(accuracyStage); }
        }

        public float EvasionStageModifier
        {
            get { return AEStageModifier(evasionStage); }
        }

        #endregion

        #region Constructor

        private Pokemon()
        {
            levelUpMoves = new List<LevelUpMove>();
            eggMoves = new List<string>();
            tutoredMoves = new List<string>();
            learnableTMs = new List<int>();
            moveset = new List<Attack>();
            evolveTo = new List<string>();
        }

        #endregion

        /// <summary>
        /// Gets or sets the uniqueid.
        /// </summary>
        public string UniqueID
        {
            get { return uniqueID; }
            set { uniqueID = value; }
        }

        

        #region Methods

        public void damage(int damage)
        {
            currentHP.Damage(damage);
        }

        public void heal(int heal)
        {
            currentHP.Heal(heal);
        }

        public void applyCondition(StatusType status)
        {
            currentConditions.Add(status);
        }

        public bool clearCondition(StatusType status)
        {
            if (currentConditions.Contains(status))
            {
                currentConditions.Remove(status);
                return true;
            }
            return false;
        }

        public bool isType(ElementType type)
        {
            if (Type1 == type || Type2 == type)
                return true;
            else
                return false;
        }

        public float statStageModifier(int stage)
        {
            switch (stage)
            {
                case -6:
                    return 0.25f;

                case -5:
                    return 0.29f;

                case -4:
                    return 0.33f;

                case -3:
                    return 0.4f;

                case -2:
                    return 0.5f;

                case -1:
                    return 0.67f;

                case 0:
                    return 1;

                case 1:
                    return 1.5f;

                case 2:
                    return 2f;

                case 3:
                    return 2.5f;

                case 4:
                    return 3f;

                case 5:
                    return 3.5f;

                case 6:
                    return 4f;

                default:
                    return 1f;
            }
        }

        public float AEStageModifier(int stage)
        {
            switch (stage)
            {
                case -6:
                    return 0.33f;

                case -5:
                    return 0.38f;

                case -4:
                    return 0.43f;

                case -3:
                    return 0.5f;

                case -2:
                    return 0.6f;

                case -1:
                    return 0.75f;

                case 0:
                    return 1;

                case 1:
                    return 1.33f;

                case 2:
                    return 1.67f;

                case 3:
                    return 2f;

                case 4:
                    return 2.33f;

                case 5:
                    return 2.67f;

                case 6:
                    return 3f;

                default:
                    return 1f;
            }
        }

        public float CriticalStageModifier()
        {
            switch (criticalStage)
            {
                case 1:
                    return 0.0625f;

                case 2:
                    return 0.125f;

                case 3:
                    return 0.25f;

                case 4:
                    return 0.333f;

                case 5:
                    return 0.5f;

                default:
                    return 0.0625f;
            }
        }

        public void modifyStatStage(Stat stat, int modifyAmount)
        {
            switch (stat)
            {
                case Stat.Attack:
                    AttackStage += modifyAmount;
                    return;

                case Stat.Defense:
                    DefenseStage += modifyAmount;
                    return;

                case Stat.SAttack:
                    SAttackStage += modifyAmount;
                    return;

                case Stat.SDefense:
                    SDefenseStage += modifyAmount;
                    return;

                case Stat.Speed:
                    SpeedStage += modifyAmount;
                    return;

                case Stat.Accuracy:
                    AccuracyStage += modifyAmount;
                    return;

                case Stat.Evasion:
                    EvasionStage += modifyAmount;
                    return;

                case Stat.Critical:
                    CriticalStage += modifyAmount;
                    return;

                default:
                    return;
            }
        }

        public static Pokemon FromPokemonData(PokemonData data, int level = 5)
        {
            Pokemon pokemon = new Pokemon();

            pokemon.name = data.Name;
            pokemon.uniqueID = data.UniqueID;
            if (data.Level == 0)
            {
                pokemon.level = level;
            }
            pokemon.gender = data.Gender;
            pokemon.happiness = data.Happiness;
            pokemon.type1 = data.Type1;
            pokemon.type2 = data.Type2;
            pokemon.nature = data.Nature;
            pokemon.ability = data.Ability;
            pokemon.levelUpMoves = data.LevelUpMoves;
            pokemon.eggMoves = data.EggMoves;
            pokemon.tutoredMoves = data.TutoredMoves;
            pokemon.learnableTMs = data.LearnableTMs;
            pokemon.moveset = data.Moveset;

            pokemon.baseHP = data.BaseHP;
            pokemon.baseAttack = data.BaseAttack;
            pokemon.baseDefense = data.BaseDefense;
            pokemon.baseSAttack = data.BaseSAttack;
            pokemon.baseSDefense = data.BaseSDefense;
            pokemon.baseSpeed = data.BaseSpeed;

            pokemon.hpIV = data.HPIV;
            pokemon.attackIV = data.AttackIV;
            pokemon.defenseIV = data.DefenseIV;
            pokemon.sAttackIV = data.SAttackIV;
            pokemon.sDefenseIV = data.SAttackIV;
            pokemon.speedIV = data.SpeedIV;

            pokemon.evolveTo = data.EvolveTo;
            pokemon.evolveFrom = data.EvolveFrom;
            pokemon.evolveCondition = data.EvolveCondition;

            pokemon.eggGroup = data.EggGroup;

            pokemon.pokedexNum = data.PokedexNum;
            pokemon.pokedexEntry = data.PokedexEntry;
            pokemon.pokedexClassification = data.PokedexClassification;
            pokemon.heightFeet = data.HeightFeet;
            pokemon.heightInches = data.HeightInches;
            pokemon.weight = data.Weight;
            pokemon.caputreRate = data.CaputreRate;
            pokemon.baseEggSteps = data.BaseEggSteps;
            pokemon.baseHappiness = data.BaseHappiness;
            pokemon.xpGrowth = data.XPGrowth;
            pokemon.fleeFlag = data.FleeFlag;

            pokemon.imageMale = data.ImageMale;
            pokemon.imageFemale = data.ImageFemale;

            pokemon.genderRatioMale = data.GenderRatioMale;
            pokemon.genderRatioFemale = data.GenderRatioFemale;

            pokemon.currentHP = new AttributePair(pokemon.HPStat);
            pokemon.currentConditions = data.CurrentConditions;

            return pokemon;
        }

        #endregion
    }
}
