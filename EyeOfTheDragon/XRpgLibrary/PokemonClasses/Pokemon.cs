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
    public enum Gender { Male, Female };
    public enum EXPRate { Erratic, Fast, MediumFast, MediumSlow, Slow, Fluctuating };

    public class Pokemon
    {
        #region Field Region

        string uniqueID;
        string name;
        int level;
        Gender gender;
        int happiness;
        GameItem holdItem;
        ElementType type1;
        ElementType type2;
        Nature nature;
        Ability ability;
        Dictionary<int, Attack> levelUpMoves;
        List<Attack> eggMoves;
        List<Attack> tutoredMoves;
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

        List<Pokemon> evolveTo;
        Pokemon evolveFrom;
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
            private set { name = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the level.
        /// </summary>
        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the gender.
        /// </summary>
        public Gender Gender
        {
            get { return gender; }
            private set { gender = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the happiness.
        /// </summary>
        public int Happiness
        {
            get { return happiness; }
            private set { happiness = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the type1.
        /// </summary>
        public ElementType Type1
        {
            get { return type1; }
            private set { type1 = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the type2.
        /// </summary>
        public ElementType Type2
        {
            get { return type2; }
            private set { type2 = value; }
        }

        public Nature Nature
        {
            get { return nature; }
            private set { nature = value; }
        }

        public Ability Ability
        {
            get { return ability; }
            private set { ability = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the levelupmoves.
        /// </summary>
        public Dictionary<int, Attack> LevelUpMoves
        {
            get { return levelUpMoves; }
            private set { levelUpMoves = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the eggmoves.
        /// </summary>
        public List<Attack> EggMoves
        {
            get { return eggMoves; }
            private set { eggMoves = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the tutoredmoves.
        /// </summary>
        public List<Attack> TutoredMoves
        {
            get { return tutoredMoves; }
            private set { tutoredMoves = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the learnabletms.
        /// </summary>
        public List<int> LearnableTMs
        {
            get { return learnableTMs; }
            private set { learnableTMs = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the moveset.
        /// </summary>
        public List<Attack> Moveset
        {
            get { return moveset; }
            private set { moveset = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basehp.
        /// </summary>
        public int BaseHP
        {
            get { return baseHP; }
            private set { baseHP = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the baseattack.
        /// </summary>
        public int BaseAttack
        {
            get { return baseAttack; }
            private set { baseAttack = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basedefense.
        /// </summary>
        public int BaseDefense
        {
            get { return baseDefense; }
            private set { baseDefense = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basesattack.
        /// </summary>
        public int BaseSAttack
        {
            get { return baseSAttack; }
            private set { baseSAttack = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basesdefense.
        /// </summary>
        public int BaseSDefense
        {
            get { return baseSDefense; }
            private set { baseSDefense = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basespeed.
        /// </summary>
        public int BaseSpeed
        {
            get { return baseSpeed; }
            private set { baseSpeed = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the hpiv.
        /// </summary>
        public int HpIV
        {
            get { return hpIV; }
            private set { hpIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the attackiv.
        /// </summary>
        public int AttackIV
        {
            get { return attackIV; }
            private set { attackIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the defenseiv.
        /// </summary>
        public int DefenseIV
        {
            get { return defenseIV; }
            private set { defenseIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the sattackiv.
        /// </summary>
        public int SAttackIV
        {
            get { return sAttackIV; }
            private set { sAttackIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the sdefenseiv.
        /// </summary>
        public int SDefenseIV
        {
            get { return sDefenseIV; }
            private set { sDefenseIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the speediv.
        /// </summary>
        public int SpeedIV
        {
            get { return speedIV; }
            private set { speedIV = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the evolveto.
        /// </summary>
        public List<Pokemon> EvolveTo
        {
            get { return evolveTo; }
            private set { evolveTo = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the evolvefrom.
        /// </summary>
        public Pokemon EvolveFrom
        {
            get { return evolveFrom; }
            private set { evolveFrom = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the evolvecondition.
        /// </summary>
        public EvolveCondition EvolveCondition
        {
            get { return evolveCondition; }
            private set { evolveCondition = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the egggroup.
        /// </summary>
        public string EggGroup
        {
            get { return eggGroup; }
            private set { eggGroup = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the pokedexnum.
        /// </summary>
        public int PokedexNum
        {
            get { return pokedexNum; }
            private set { pokedexNum = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the pokedexclassification.
        /// </summary>
        public string PokedexClassification
        {
            get { return pokedexClassification; }
            private set { pokedexClassification = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the pokedexentry.
        /// </summary>
        public string PokedexEntry
        {
            get { return pokedexEntry; }
            private set { pokedexEntry = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the heightfeet.
        /// </summary>
        public int HeightFeet
        {
            get { return heightFeet; }
            private set { heightFeet = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the heightinches.
        /// </summary>
        public int HeightInches
        {
            get { return heightInches; }
            private set { heightInches = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the weight.
        /// </summary>
        public float Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the caputrerate.
        /// </summary>
        public int CaputreRate
        {
            get { return caputreRate; }
            private set { caputreRate = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the baseeggsteps.
        /// </summary>
        public int BaseEggSteps
        {
            get { return baseEggSteps; }
            private set { baseEggSteps = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the basehappiness.
        /// </summary>
        public int BaseHappiness
        {
            get { return baseHappiness; }
            private set { baseHappiness = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the xpgrowth.
        /// </summary>
        public EXPRate XpGrowth
        {
            get { return xpGrowth; }
            private set { xpGrowth = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the fleeflag.
        /// </summary>
        public int FleeFlag
        {
            get { return fleeFlag; }
            private set { fleeFlag = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the imagemale.
        /// </summary>
        public string ImageMale
        {
            get { return imageMale; }
            private set { imageMale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the imagefemale.
        /// </summary>
        public string ImageFemale
        {
            get { return imageFemale; }
            private set { imageFemale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the genderratiomale.
        /// </summary>
        public float GenderRatioMale
        {
            get { return genderRatioMale; }
            private set { genderRatioMale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the genderratiofemale.
        /// </summary>
        public float GenderRatioFemale
        {
            get { return genderRatioFemale; }
            private set { genderRatioFemale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the currenthp.
        /// </summary>
        public AttributePair CurrentHP
        {
            get { return currentHP; }
            private set { currentHP = value; }
        }

        #endregion

        /// <summary>
        /// Gets (or sets privately) the currentconditions.
        /// </summary>
        public List<StatusType> CurrentConditions
        {
            get { return currentConditions; }
            private set { currentConditions = value; }
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
            levelUpMoves = new Dictionary<int, Attack>();
            eggMoves = new List<Attack>();
            tutoredMoves = new List<Attack>();
            learnableTMs = new List<int>();
            moveset = new List<Attack>();
            evolveTo = new List<Pokemon>();
        }

        #endregion

        

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
            if (Type1 == type || Type1 == type)
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

        public static Pokemon FromPokemonData(PokemonData data)
        {
            Pokemon pokemon = new Pokemon();

            pokemon.name = data.Name;
            pokemon.uniqueID = data.UniqueID;
            pokemon.level = data.Level;
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

            //pokemon.hpIV = data.HPIV;
            pokemon.hpIV = 25;
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

            //pokemon.currentHP = data.CurrentHP;
            pokemon.currentHP = new AttributePair(pokemon.HPStat);
            pokemon.currentConditions = data.CurrentConditions;

            return pokemon;
        }

        #endregion
    }
}
