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

        bool contact;
        int priority;
        bool sound;
        bool punch;
        bool snatchable;
        bool groundable;
        bool defrosts;
        bool reflectable;
        bool blockable;
        bool copyable;

        string description;

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
        /// Gets or sets the currentpp.
        /// </summary>
        public AttributePair CurrentPP
        {
            get { return currentPP; }
            set { currentPP = value; }
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

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public bool Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        /// <summary>
        /// Gets or sets the sound.
        /// </summary>
        public bool Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        /// <summary>
        /// Gets or sets the punch.
        /// </summary>
        public bool Punch
        {
            get { return punch; }
            set { punch = value; }
        }

        /// <summary>
        /// Gets or sets the snatchable.
        /// </summary>
        public bool Snatchable
        {
            get { return snatchable; }
            set { snatchable = value; }
        }

        /// <summary>
        /// Gets or sets the groundable.
        /// </summary>
        public bool Groundable
        {
            get { return groundable; }
            set { groundable = value; }
        }

        /// <summary>
        /// Gets or sets the defrosts.
        /// </summary>
        public bool Defrosts
        {
            get { return defrosts; }
            set { defrosts = value; }
        }

        /// <summary>
        /// Gets or sets the reflectable.
        /// </summary>
        public bool Reflectable
        {
            get { return reflectable; }
            set { reflectable = value; }
        }

        /// <summary>
        /// Gets or sets the blackable.
        /// </summary>
        public bool Blockable
        {
            get { return blockable; }
            set { blockable = value; }
        }

        /// <summary>
        /// Gets or sets the copyable.
        /// </summary>
        public bool Copyable
        {
            get { return copyable; }
            set { copyable = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        #region Constructor

        public Attack(string name)
        {
            Name = name;
            effects = new List<AttackEffect>();
        }

        private Attack()
        {

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

        public static Attack AttackFromData(AttackData data)
        {
            Attack attack = new Attack();

            attack.name = data.Name;
            attack.attackElementType = data.AttackElementType;
            attack.currentPP = data.CurrentPP;
            attack.accuracy = data.Accuracy;
            attack.effects = data.Effects;
            attack.attackType = data.AttackType;

            attack.contact = data.Contact;
            attack.priority = data.Priority;
            attack.sound = data.Sound;
            attack.punch = data.Punch;
            attack.snatchable = data.Snatchable;
            attack.groundable = data.Groundable;
            attack.defrosts = data.Defrosts;
            attack.reflectable = data.Reflectable;
            attack.blockable = data.Blockable;
            attack.copyable = data.Copyable;

            attack.description = data.Description;

            return attack;
        }

        #endregion
    }
}
