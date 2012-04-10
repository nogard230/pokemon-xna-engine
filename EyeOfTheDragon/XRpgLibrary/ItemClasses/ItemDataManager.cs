using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemDataManager
    {
        #region Field Region

        readonly Dictionary<string, MiscItemData> miscItemData = new Dictionary<string, MiscItemData>();
        readonly Dictionary<string, RecoveryItemData> recoveryData = new Dictionary<string, RecoveryItemData>();
        readonly Dictionary<string, TMItemData> tmData = new Dictionary<string, TMItemData>();
        readonly Dictionary<string, BerryItemData> berryData = new Dictionary<string, BerryItemData>();
        readonly Dictionary<string, KeyItemData> keyItemData = new Dictionary<string, KeyItemData>();
        readonly Dictionary<string, ChestData> chestData = new Dictionary<string, ChestData>();

        #endregion

        #region Property Region

        public Dictionary<string, MiscItemData> MiscItemData
        {
            get { return miscItemData; }
        }

        public Dictionary<string, RecoveryItemData> RecoveryItemData
        {
            get { return recoveryData; }
        }

        public Dictionary<string, TMItemData> TMItemData
        {
            get { return tmData; }
        }

        public Dictionary<string, BerryItemData> BerryItemData
        {
            get { return berryData; }
        }

        public Dictionary<string, KeyItemData> KeyItemData
        {
            get { return keyItemData; }
        }

        public Dictionary<string, ChestData> ChestData
        {
            get { return chestData; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region
        #endregion
    }
}