using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemManager
    {
        #region Fields Region

        Dictionary<string, TMItem> tms = new Dictionary<string, TMItem>();
        Dictionary<string, RecoveryItem> recoveryItems = new Dictionary<string, RecoveryItem>();
        Dictionary<string, MiscItem> miscItems = new Dictionary<string, MiscItem>();
        Dictionary<string, KeyItem> keyItems = new Dictionary<string, KeyItem>();
        Dictionary<string, BerryItem> berryItems = new Dictionary<string, BerryItem>();

        #endregion

        #region Keys Property Region

        public Dictionary<string, TMItem>.KeyCollection TMKeys
        {
            get { return tms.Keys; }
        }

        public Dictionary<string, RecoveryItem>.KeyCollection RecoveryKeys
        {
            get { return recoveryItems.Keys; }
        }

        public Dictionary<string, MiscItem>.KeyCollection MiscItemKeys
        {
            get { return miscItems.Keys; }
        }

        public Dictionary<string, BerryItem>.KeyCollection BerryItemKeys
        {
            get { return berryItems.Keys; }
        }

        public Dictionary<string, KeyItem>.KeyCollection KeyItemKeys
        {
            get { return keyItems.Keys; }
        }

        #endregion

        #region Constructor Region

        public ItemManager()
        {
        }

        #endregion

        #region TM Methods

        public void AddTM(TMItem tm)
        {
            if (!tms.ContainsKey(tm.Name))
            {
                tms.Add(tm.Name, tm);
            }
        }

        public TMItem GetTM(string name)
        {
            if (tms.ContainsKey(name))
            {
                return (TMItem)tms[name].Clone();
            }

            return null;
        }

        public bool ContainsTM(string name)
        {
            return tms.ContainsKey(name);
        }

        #endregion

        #region Recovery Methods

        public void AddRecoveryItem(RecoveryItem recoveryItem)
        {
            if (!recoveryItems.ContainsKey(recoveryItem.Name))
            {
                recoveryItems.Add(recoveryItem.Name, recoveryItem);
            }
        }

        public RecoveryItem GetRecoveryItem(string name)
        {
            if (recoveryItems.ContainsKey(name))
            {
                return (RecoveryItem)recoveryItems[name].Clone();
            }

            return null;
        }

        public bool ContainsRecoveryItem(string name)
        {
            return recoveryItems.ContainsKey(name);
        }

        #endregion

        #region Shield Methods

        public void AddMiscItem(MiscItem item)
        {
            if (!miscItems.ContainsKey(item.Name))
            {
                miscItems.Add(item.Name, item);
            }
        }

        public MiscItem GetMiscItem(string name)
        {
            if (miscItems.ContainsKey(name))
            {
                return (MiscItem)miscItems[name].Clone();
            }

            return null;
        }

        public bool ContainsMiscItem(string name)
        {
            return miscItems.ContainsKey(name);
        }

        #endregion

        #region Key Item Methods

        public void AddKeyItem(KeyItem item)
        {
            if (!keyItems.ContainsKey(item.Name))
            {
                keyItems.Add(item.Name, item);
            }
        }

        public KeyItem GetKeyItem(string name)
        {
            if (keyItems.ContainsKey(name))
            {
                return (KeyItem)keyItems[name].Clone();
            }

            return null;
        }

        public bool ContainsKeyItem(string name)
        {
            return keyItems.ContainsKey(name);
        }

        #endregion

        #region Berry Methods

        public void AddBerryItem(BerryItem berry)
        {
            if (!berryItems.ContainsKey(berry.Name))
            {
                berryItems.Add(berry.Name, berry);
            }
        }

        public BerryItem GetBerryItem(string name)
        {
            if (berryItems.ContainsKey(name))
            {
                return (BerryItem)berryItems[name].Clone();
            }

            return null;
        }

        public bool ContainsBeryItem(string name)
        {
            return berryItems.ContainsKey(name);
        }

        #endregion

        public BaseItem OpenChest(Chest chest)
        {
            if (miscItems.ContainsKey(chest.Item.Name))
            {
                return (MiscItem)(miscItems[chest.Item.Name].Clone());
            }
            if (recoveryItems.ContainsKey(chest.Item.Name))
            {
                return (RecoveryItem)(recoveryItems[chest.Item.Name].Clone());
            }
            if (tms.ContainsKey(chest.Item.Name))
            {
                return (TMItem)(tms[chest.Item.Name].Clone());
            }
            if (berryItems.ContainsKey(chest.Item.Name))
            {
                return (BerryItem)(berryItems[chest.Item.Name].Clone());
            }
            if (keyItems.ContainsKey(chest.Item.Name))
            {
                return (KeyItem)(keyItems[chest.Item.Name].Clone());
            }
            return null;
        }
    }
}
