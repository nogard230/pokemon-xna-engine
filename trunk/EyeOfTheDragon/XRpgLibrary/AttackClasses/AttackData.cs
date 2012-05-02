using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using RpgLibrary.CharacterClasses;


namespace XRpgLibrary.AttackClasses
{
    public class AttackData
    {
        #region Fields

        public string Name;
        public ElementType AttackElementType;
        public AttributePair CurrentPP;
        public float Accuracy;
        public List<AttackEffect> Effects;
        public AttackType AttackType;

        public bool Contact;
        public int Priority;
        public bool Sound;
        public bool Punch;
        public bool Snatchable;
        public bool Groundable;
        public bool Defrosts;
        public bool Reflectable;
        public bool Blockable;
        public bool Copyable;

        public string Description;

        #endregion

        public AttackData()
        {
            Effects = new List<AttackEffect>();
        }

        #region Virtual Method Region

        public override string ToString()
        {
            string toString = Name;
            toString += ", " + AttackElementType.ToString();
            toString += ", " + CurrentPP.ToString();
            toString += ", " + Accuracy.ToString();

            foreach (AttackEffect effect in Effects)
                toString += ", " + effect.ToString();

            toString += ", " + AttackType.ToString();
            toString += ", " + Contact.ToString();
            toString += ", " + Priority.ToString();
            toString += ", " + Sound.ToString();
            toString += ", " + Punch.ToString();
            toString += ", " + Snatchable.ToString();
            toString += ", " + Groundable.ToString();
            toString += ", " + Defrosts.ToString();
            toString += ", " + Reflectable.ToString();
            toString += ", " + Blockable.ToString();
            toString += ", " + Copyable.ToString();

            toString += ", " + Description;

            return toString;
        }

        #endregion
    }
}
