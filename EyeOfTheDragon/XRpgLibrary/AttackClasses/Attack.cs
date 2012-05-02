using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using RpgLibrary.CharacterClasses;

namespace XRpgLibrary.AttackClasses
{
    public enum AttackType { Physical, Special, Neutral };

    public class Attack
    {
        #region Fields

        string name;
        ElementType attackElementType;
        AttributePair currentPP;
        float accuracy;
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
        public AttributePair Pp
        {
            get { return currentPP; }
            set { currentPP = value; }
        }

        /// <summary>
        /// Gets or sets the accuracy.
        /// </summary>
        public float Accuracy
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

        public Attack(string name)
        {
            Name = name;
            effects = new List<AttackEffect>();
        }

        #endregion

        #region Methods

        public bool useAttack(Pokemon user, Pokemon target)
        {
            if (BattleCalculator.DoesHit(user, target, accuracy))
            {
                Random r = new Random();
                foreach (AttackEffect effect in effects)
                {
                    int hit = r.Next(100);
                    if (hit <= effect.EffectPercentage * 100)
                    {
                        effect.ApplyEffect(user, target, this);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
