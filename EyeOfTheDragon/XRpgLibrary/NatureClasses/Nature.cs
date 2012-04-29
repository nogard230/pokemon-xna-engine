using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.NatureClasses
{
    class Nature
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

        
    }
}
