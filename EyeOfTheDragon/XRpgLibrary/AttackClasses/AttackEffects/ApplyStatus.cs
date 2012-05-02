using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using RpgLibrary.EffectClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class ApplyStatus : AttackEffect
    {
        #region Private Members
        StatusType status;
        bool targetAffected;
        #endregion Private Members

        #region Constructors
        public ApplyStatus(StatusType statusToApply, bool appliedToTarget, float effectPercentage)
            : base(effectPercentage)
        {
            status = statusToApply;
            targetAffected = appliedToTarget;
        }

        public ApplyStatus()
            : base(1f)
        {

        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public StatusType Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Gets or sets the targetaffected.
        /// </summary>
        public bool TargetAffected
        {
            get { return targetAffected; }
            set { targetAffected = value; }
        }
        #endregion Public Attributes

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            if (targetAffected)
            {
                target.applyCondition(status);
            }
            else
            {
                user.applyCondition(status);
            }
        }

        public override string ToString()
        {
            string toString = "Apply Status";
            toString += ", " + status.ToString();
            toString += ", " + targetAffected;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
