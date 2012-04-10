using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.WorldClasses;
using RpgLibrary.ItemClasses;
using XRpgLibrary.ItemClasses;

using Microsoft.Xna.Framework;

namespace XRpgLibrary.TileEngine
{
    public class ObjectInteractor
    {
        static TileMap map;
        static Level level;
        static ItemManager manager;
        
        #region Constructors

        public ObjectInteractor(Level currentLevel, ItemManager manager)
        {
            ObjectInteractor.level = currentLevel;
            ObjectInteractor.map = currentLevel.Map;
            ObjectInteractor.manager = manager;
        }

        #endregion

        public static void SetLevel(Level newLevel)
        {
            ObjectInteractor.level = newLevel;
            ObjectInteractor.map = newLevel.Map;
        }

        public static ItemSprite ItemAt(Point point)
        {
            foreach (ItemSprite item in level.Items)
            {
                if(Engine.VectorToCell(item.Sprite.Position).Equals(point))
                {
                    return item;
                }
            }
            return null;
        }

        public static BaseItem TakeItem(Point point)
        {
            ItemSprite item = ObjectInteractor.ItemAt(point);
            if (item != null)
            {
                level.Items.Remove(item);
                if (item.Item is Chest)
                {
                    return manager.OpenChest((Chest)item.Item);
                }
                else
                {
                    return item.Item;
                }
            }
            return null;
        }
    }
}
