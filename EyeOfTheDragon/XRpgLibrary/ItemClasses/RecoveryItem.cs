using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.EffectClasses;

namespace RpgLibrary.ItemClasses
{
    public class RecoveryItem : BaseItem
    {
        #region Field Region

        int healValue;
        float healPercentage;
        bool canRevive;
        int levelsGained;
        int ppRestoreValue;
        int movesRestored;
        StatusType statusCured;
        bool cureAllStatuses;

        #endregion

        #region Property Region

        public int HealValue
        {
            get { return healValue; }
            protected set { healValue = value; }
        }

        public float HealPercentage
        {
            get { return healPercentage; }
            protected set { healPercentage = value; }
        }

        public bool CanRevive
        {
            get { return canRevive; }
            protected set { canRevive = value; }
        }

        public int LevelsGained
        {
            get { return levelsGained; }
            protected set { levelsGained = value; }
        }

        public int PPRestoreValue
        {
            get { return ppRestoreValue; }
            protected set { ppRestoreValue = value; }
        }

        public int MovesRestored
        {
            get { return movesRestored; }
            protected set { movesRestored = value; }
        }

        public StatusType StatusCured
        {
            get { return statusCured; }
            protected set { statusCured = value; }
        }

        public bool CureAllStatuses
        {
            get { return cureAllStatuses; }
            protected set { cureAllStatuses = value; }
        }

        #endregion

        #region Constructor Region

        public RecoveryItem(
                string recoveryName,
                string recoveryType,
                int price,
                int sellPrice,
                int healValue,
                float healPercentage,
                bool canRevive,
                int levelsGained,
                int ppRestoreValue,
                int movesRestored,
                StatusType statusCured,
                bool cureAllStatuses)
            : base(recoveryName, recoveryType, price, sellPrice)
        {
            HealValue = healValue;
            HealPercentage = healPercentage;
            CanRevive = canRevive;
            LevelsGained = levelsGained;
            PPRestoreValue = ppRestoreValue;
            MovesRestored = movesRestored;
            StatusCured = statusCured;
            CureAllStatuses = cureAllStatuses;
        }

        public RecoveryItem(RecoveryItemData data)
            : base(data.Name, data.Type, data.Price, data.SellPrice)
        {
            HealValue = data.HealValue;
            HealPercentage = data.HealPercentage;
            CanRevive = data.CanRevive;
            LevelsGained = data.LevelsGained;
            PPRestoreValue = data.PPRestoreValue;
            MovesRestored = data.MovesRestored;
            StatusCured = data.StatusCured;
            CureAllStatuses = data.CureAllStatuses;
        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {

            RecoveryItem recoveryItem = new RecoveryItem(
                Name,
                Type,
                Price,
                SellPrice,
                HealValue,
                HealPercentage,
                CanRevive,
                LevelsGained,
                PPRestoreValue,
                MovesRestored,
                StatusCured,
                CureAllStatuses);

            return recoveryItem;
        }

        public override string ToString()
        {
            string recoveryString = base.ToString() + ", ";
            recoveryString += HealValue.ToString() + ", ";
            recoveryString += HealPercentage.ToString() + ", ";
            recoveryString += CanRevive.ToString() + ", ";
            recoveryString += LevelsGained.ToString() + ", ";
            recoveryString += PPRestoreValue.ToString() + ", ";
            recoveryString += MovesRestored.ToString() + ", ";
            recoveryString += StatusCured.ToString() + ", ";
            recoveryString += CureAllStatuses.ToString();

            return recoveryString;
        }

        #endregion
    }
}
