using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.CharacterClasses;

namespace RpgLibrary.EffectClasses
{
    public enum StatusType { None, Burn, Poison, Bad_Poison, Confusion, Sleep, Freeze, Curse, Encore, Flinch, Indentify, 
        Infatuation, LeechSeed, Target, Nightmare, Trapped, PerishSong, Taunt, Torment };

    public class StatusCondition : BaseEffect
    {
        #region Field Region

        protected string name;

        #endregion

        #region Property Region

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        #endregion

        #region Constructor Region

        protected StatusCondition()
        {
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method Region

        public override void Apply(Entity entity)
        {

        }

        #endregion

    }
}
