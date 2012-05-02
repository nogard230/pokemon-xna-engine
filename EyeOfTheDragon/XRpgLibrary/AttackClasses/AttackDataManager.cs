using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.AttackClasses
{
    public class AttackDataManager
    {
        #region Field Region

        readonly Dictionary<string, AttackData> attackData;

        #endregion

        #region Property Region

        public Dictionary<string, AttackData> AttackData
        {
            get { return attackData; }
        }

        #endregion

        #region Constructor Region

        public AttackDataManager()
        {
            attackData = new Dictionary<string, AttackData>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region
        #endregion
    }
}
