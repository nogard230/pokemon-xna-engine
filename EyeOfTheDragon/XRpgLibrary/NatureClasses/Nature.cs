using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.NatureClasses
{
    public class Nature
    {
        #region Private Members
        string name;
        float attackEffect = 1;
        float defenseEffect = 1;
        float specialAttackEffect = 1;
        float specialDefenseEffect = 1;
        float speedEffect = 1;
        #endregion Private Members


        #region Public Attributes
        /// <summary>
        /// Gets (or sets privately) the name.
        /// </summary>
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the attackeffect.
        /// </summary>
        public float AttackEffect
        {
            get { return attackEffect; }
            private set { attackEffect = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the defenseeffect.
        /// </summary>
        public float DefenseEffect
        {
            get { return defenseEffect; }
            private set { defenseEffect = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the specialattackeffect.
        /// </summary>
        public float SpecialAttackEffect
        {
            get { return specialAttackEffect; }
            private set { specialAttackEffect = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the specialdefenseeffect.
        /// </summary>
        public float SpecialDefenseEffect
        {
            get { return specialDefenseEffect; }
            private set { specialDefenseEffect = value; }
        }

        /// <summary>
        /// Gets (or sets privately) the speedeffect.
        /// </summary>
        public float SpeedEffect
        {
            get { return speedEffect; }
            private set { speedEffect = value; }
        }
        #endregion Public Attributes

        #region Constructors
        public Nature(string natureName)
        {
            name = natureName;
        }
        #endregion Constructors

        #region Defined Natures

        public static Nature Hardy
        {
            get { return new Nature("Hardy"); }
        }

        public static Nature Lonely
        {
            get 
            { 
                Nature nature = new Nature("Lonely");
                nature.attackEffect = 1.1f;
                nature.defenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Brave
        {
            get
            {
                Nature nature = new Nature("Brave");
                nature.attackEffect = 1.1f;
                nature.speedEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Adamamt
        {
            get
            {
                Nature nature = new Nature("Adamamt");
                nature.attackEffect = 1.1f;
                nature.specialAttackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Naughty
        {
            get
            {
                Nature nature = new Nature("Naught");
                nature.attackEffect = 1.1f;
                nature.specialDefenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Bold
        {
            get
            {
                Nature nature = new Nature("Bold");
                nature.defenseEffect = 1.1f;
                nature.attackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Docile
        {
            get
            {
                Nature nature = new Nature("Docile");

                return nature;
            }
        }

        public static Nature Relaxed
        {
            get
            {
                Nature nature = new Nature("Relaxed");
                nature.defenseEffect = 1.1f;
                nature.speedEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Impish
        {
            get
            {
                Nature nature = new Nature("Impish");
                nature.defenseEffect = 1.1f;
                nature.specialAttackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Lax
        {
            get
            {
                Nature nature = new Nature("Lax");
                nature.defenseEffect = 1.1f;
                nature.specialDefenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Timid
        {
            get
            {
                Nature nature = new Nature("Timid");
                nature.speedEffect = 1.1f;
                nature.attackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Hasty
        {
            get
            {
                Nature nature = new Nature("Hasty");
                nature.speedEffect = 1.1f;
                nature.defenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Serious
        {
            get
            {
                Nature nature = new Nature("Serious");

                return nature;
            }
        }

        public static Nature Jolly
        {
            get
            {
                Nature nature = new Nature("Jolly");
                nature.speedEffect = 1.1f;
                nature.specialAttackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Naive
        {
            get
            {
                Nature nature = new Nature("Naive");
                nature.speedEffect = 1.1f;
                nature.specialDefenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Modest
        {
            get
            {
                Nature nature = new Nature("Modest");
                nature.specialAttackEffect = 1.1f;
                nature.attackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Mild
        {
            get
            {
                Nature nature = new Nature("Mild");
                nature.specialAttackEffect = 1.1f;
                nature.defenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Quiet
        {
            get
            {
                Nature nature = new Nature("Quiet");
                nature.specialAttackEffect = 1.1f;
                nature.speedEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Bashful
        {
            get
            {
                Nature nature = new Nature("Bashful");

                return nature;
            }
        }

        public static Nature Rash
        {
            get
            {
                Nature nature = new Nature("Rash");
                nature.specialAttackEffect = 1.1f;
                nature.specialDefenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Calm
        {
            get
            {
                Nature nature = new Nature("Calm");
                nature.specialDefenseEffect = 1.1f;
                nature.attackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Gentle
        {
            get
            {
                Nature nature = new Nature("Gentle");
                nature.specialDefenseEffect = 1.1f;
                nature.defenseEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Sassy
        {
            get
            {
                Nature nature = new Nature("Sassy");
                nature.specialDefenseEffect = 1.1f;
                nature.speedEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Careful
        {
            get
            {
                Nature nature = new Nature("Careful");
                nature.specialDefenseEffect = 1.1f;
                nature.specialAttackEffect = 0.9f;

                return nature;
            }
        }

        public static Nature Quirky
        {
            get
            {
                Nature nature = new Nature("Quirky");

                return nature;
            }
        }
        #endregion

        public static Nature GetRandomNature()
        {
            Random r = new Random();
            int n = r.Next(26);

            switch (n)
            {
                case 0:
                    return Hardy;

                case 1:
                    return Lonely;

                case 2:
                    return Brave;

                case 3:
                    return Adamamt;

                case 4:
                    return Naughty;

                case 5:
                    return Bold;

                case 6:
                    return Docile;

                case 7:
                    return Relaxed;

                case 8:
                    return Impish;

                case 9:
                    return Lax;

                case 10:
                    return Timid;

                case 11:
                    return Hasty;

                case 12:
                    return Serious;

                case 13:
                    return Jolly;

                case 14:
                    return Naive;

                case 15:
                    return Modest;

                case 16:
                    return Mild;

                case 17:
                    return Quiet;

                case 18:
                    return Bashful;

                case 19:
                    return Rash;

                case 20:
                    return Calm;

                case 21:
                    return Gentle;

                case 22:
                    return Sassy;

                case 23:
                    return Careful;

                case 24:
                    return Quirky;
                    
                default:
                    return Hardy;
            }

        }
    }
}
