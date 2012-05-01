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
            p1.Name = "Pidgeot";
            p1.Level = 100;
            p1.Gender = Gender.Male;
            p1.Happiness = 255;
            p1.Type1 = ElementType.Flying;
            p1.Type2 = ElementType.Normal;
            p1.Nature = new NatureClasses.Nature("Brave");
            p1.Ability = new AbilityClasses.Ability();

            AttackClasses.Attack wingAttack = new AttackClasses.Attack("Wing Attack");
            wingAttack.Effects.Add(new AttackClasses.AttackEffects.BasicDamage(60, 100));
            wingAttack.AttackType = AttackClasses.AttackType.Physical;
            wingAttack.AttackElementType = ElementType.Flying;
            wingAttack.Pp = new RpgLibrary.CharacterClasses.AttributePair(20);
            AttackClasses.Attack quickAttack = new AttackClasses.Attack("Quick Attack");
            quickAttack.Effects.Add(new AttackClasses.AttackEffects.BasicDamage(40, 100));
            quickAttack.AttackType = AttackClasses.AttackType.Physical;
            quickAttack.AttackElementType = ElementType.Normal;

            p1.Moveset.Add(wingAttack);
            p1.Moveset.Add(quickAttack);
            p1.BaseHP = 83;
            p1.BaseAttack = 80;
            p1.BaseDefense = 75;
            p1.BaseSAttack = 60;
            p1.BaseSDefense = 70;
            p1.BaseSpeed = 91;

            PokemonData p2 = new PokemonData();
            p2.Name = "Fearow";
            p2.Level = 100;
            p2.Gender = Gender.Female;
            p2.Happiness = 0;
            p2.Type1 = ElementType.Flying;
            p2.Type2 = ElementType.Normal;
            p2.Nature = new NatureClasses.Nature("Timid");
            p2.Ability = new AbilityClasses.Ability();
            p2.Moveset.Add(new AttackClasses.Attack("Wing Attack"));
            p2.Moveset.Add(new AttackClasses.Attack("Quick Attack"));
            p2.BaseHP = 65;
            p2.BaseAttack = 90;
            p2.BaseDefense = 65;
            p2.BaseSAttack = 61;
            p2.BaseSDefense = 61;
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
