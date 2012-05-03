using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.AttackClasses
{
    public class AttackDataManager
    {
        #region Field Region

        readonly static Dictionary<string, AttackData> attackData = new Dictionary<string, AttackData>();

        #endregion

        #region Property Region

        public static Dictionary<string, AttackData> AttackData
        {
            get { return attackData; }
        }

        #endregion

        #region Constructor Region

        public AttackDataManager()
        {
        }

        #endregion

        #region Method Region
        public static Attack GetAttack(string attackName)
        {
            Attack attack = Attack.AttackFromData(AttackData[attackName]);
            return attack;
        }
        #endregion

        #region Virtual Method region
        #endregion
    }
}
