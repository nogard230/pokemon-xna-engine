using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses
{
    public enum AttackType { Physical, Special, Neutral };

    public class Attack
    {
        #region Fields

        string name;
        ElementType attackElementType;
        int pp;
        int maxPP;
        decimal accuracy;
        List<AttackEffect> effects;
        AttackType attackType;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the attacktype.
        /// </summary>
        public ElementType AttackElementType
        {
            get { return attackElementType; }
            set { attackElementType = value; }
        }

        /// <summary>
        /// Gets or sets the pp.
        /// </summary>
        public int Pp
        {
            get { return pp; }
            set { pp = value; }
        }

        /// <summary>
        /// Gets or sets the maxpp.
        /// </summary>
        public int MaxPP
        {
            get { return maxPP; }
            set { maxPP = value; }
        }

        /// <summary>
        /// Gets or sets the accuracy.
        /// </summary>
        public decimal Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        /// <summary>
        /// Gets or sets the effects.
        /// </summary>
        public List<AttackEffect> Effects
        {
            get { return effects; }
            set { effects = value; }
        }


        public AttackType AttackType
        {
            get { return attackType; }
            set { attackType = value; }
        }

        #endregion

        #region Constructor

        public Attack()
        {
            effects = new List<AttackEffect>();
        }

        #endregion

        #region Methods

        #endregion
    }
}
