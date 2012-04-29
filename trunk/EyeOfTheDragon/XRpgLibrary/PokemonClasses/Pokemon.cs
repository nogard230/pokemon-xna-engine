﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.ItemClasses;
using XRpgLibrary.AttackClasses;
using RpgLibrary.EffectClasses;
using XRpgLibrary.AbilityClasses;
using XRpgLibrary.NatureClasses;

namespace XRpgLibrary.PokemonClasses
{
    class Pokemon
    {
        #region Field Region
        
        string name;
        int level;
        ElementType type1;
        ElementType type2;
        Nature nature;
        Ability ability;
        Dictionary<int, Attack> levelUpMoves;
        List<Attack> eggMoves;
        List<Attack> tutoredMoves;
        List<TMItem> learnableTMs;
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
        decimal weight;
        int caputreRate;
        int baseEggSteps;
        int baseHappiness;
        int xpGrowth;
        int fleeFlag;

        decimal genderRatioMale;
        decimal genderRatioFemale;

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
        public List<TMItem> LearnableTMs
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
        public decimal Weight
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
        public int XpGrowth
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
        /// Gets (or sets privately) the genderratiomale.
        /// </summary>
        public decimal GenderRatioMale
        {
            get { return genderRatioMale; }
            private set { genderRatioMale = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the genderratiofemale.
        /// </summary>
        public decimal GenderRatioFemale
        {
            get { return genderRatioFemale; }
            private set { genderRatioFemale = value; }
        }

        #endregion

        #region Stats

        public int HP
        {
            get { return (int)Math.Floor((((HpIV + 2 * BaseHP + 100.0) * Level) / 100.0 + 10.0)); }
        }

        public int Attack
        {
            get { return (int)Math.Floor((((AttackIV + 2 * BaseAttack) * Level) / 100.0 + 5.0) * Nature.AttackEffect); }
        }

        public int Defense
        {
            get { return (int)Math.Floor((((DefenseIV + 2 * BaseDefense) * Level) / 100.0 + 5.0) * Nature.DefenseEffect); }
        }

        public int SpecialAttack
        {
            get { return (int)Math.Floor((((SAttackIV + 2 * BaseSAttack) * Level) / 100.0 + 5.0) * Nature.SpecialAttackEffect); }
        }

        public int SpecialDefense
        {
            get { return (int)Math.Floor((((SDefenseIV + 2 * BaseSDefense) * Level) / 100.0 + 5.0) * Nature.SpecialDefenseEffect); }
        }

        public int Speed
        {
            get { return (int)Math.Floor((((SpeedIV + 2 * BaseSpeed) * Level) / 100.0 + 5.0) * Nature.SpeedEffect); }
        }

        #endregion

        #region Constructor

        public Pokemon()
        {
            levelUpMoves = new Dictionary<int, Attack>();
            eggMoves = new List<Attack>();
            tutoredMoves = new List<Attack>();
            learnableTMs = new List<TMItem>();
            moveset = new List<Attack>();
            evolveTo = new List<Pokemon>();
        }

        #endregion

        

        #region Methods

        public void damage(int damage)
        {
            
        }

        public void heal(int heal)
        {

        }

        public void applyCondition(StatusType status)
        {

        }

        public bool isType(ElementType type)
        {
            if (Type1 == type || Type1 == type)
                return true;
            else
                return false;
        }

        #endregion
    }
}