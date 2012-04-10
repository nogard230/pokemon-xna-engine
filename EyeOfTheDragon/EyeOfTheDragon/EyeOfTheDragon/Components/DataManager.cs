using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using RpgLibrary.TrapClasses;
using RpgLibrary.WorldClasses;

namespace EyesOfTheDragon.Components
{
    static class DataManager
    {
        #region Field Region

        static Dictionary<string, MiscItemData> miscItems = new Dictionary<string, MiscItemData>();
        static Dictionary<string, RecoveryItemData> recoveryItems = new Dictionary<string, RecoveryItemData>();
        static Dictionary<string, TMItemData> tmItems = new Dictionary<string, TMItemData>();
        static Dictionary<string, BerryItemData> berryItems = new Dictionary<string, BerryItemData>();

        static Dictionary<string, KeyItemData> keyItems = new Dictionary<string, KeyItemData>();
        static Dictionary<string, ChestData> chests = new Dictionary<string, ChestData>();

        static Dictionary<string, EntityData> entities = new Dictionary<string, EntityData>();

        static Dictionary<string, SkillData> skills = new Dictionary<string, SkillData>();

        static Dictionary<string, LevelData> levels = new Dictionary<string, LevelData>();
        static Dictionary<string, MapData> maps = new Dictionary<string, MapData>();

        #endregion

        #region Property Region

        public static Dictionary<string, MiscItemData> MiscData
        {
            get { return miscItems; }
        }

        public static Dictionary<string, RecoveryItemData> RecoveryData
        {
            get { return recoveryItems; }
        }

        public static Dictionary<string, TMItemData> TMData
        {
            get { return tmItems; }
        }

        public static Dictionary<string, BerryItemData> BerryData
        {
            get { return berryItems; }
        }

        public static Dictionary<string, EntityData> EntityData
        {
            get { return entities; }
        }

        public static Dictionary<string, ChestData> ChestData
        {
            get { return chests; }
        }

        public static Dictionary<string, KeyItemData> KeyItemData
        {
            get { return keyItems; }
        }

        public static Dictionary<string, SkillData> SkillData
        {
            get { return skills; }
        }

        public static Dictionary<string, LevelData> LevelData
        {
            get { return levels; }
        }

        public static Dictionary<string, MapData> MapData
        {
            get { return maps; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static void ReadEntityData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Classes", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Classes\" + Path.GetFileNameWithoutExtension(name);
                EntityData data = Content.Load<EntityData>(filename);
                EntityData.Add(data.EntityName, data);
            }
        }

        public static void ReadMiscItemData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Misc", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Misc\" + Path.GetFileNameWithoutExtension(name);
                MiscItemData data = Content.Load<MiscItemData>(filename);
                miscItems.Add(data.Name, data);
            }
        }

        public static void ReadRecoveryItemData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Recovery", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Recovery\" + Path.GetFileNameWithoutExtension(name);
                RecoveryItemData data = Content.Load<RecoveryItemData>(filename);
                RecoveryData.Add(data.Name, data);
            }
        }

        public static void ReadTMItemData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\TM", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\TM\" + Path.GetFileNameWithoutExtension(name);
                TMItemData data = Content.Load<TMItemData>(filename);
                TMData.Add(data.Name, data);
            }
        }

        public static void ReadBerryItemData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Berry", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Berry\" + Path.GetFileNameWithoutExtension(name);
                BerryItemData data = Content.Load<BerryItemData>(filename);
                BerryData.Add(data.Name, data);
            }
        }

        public static void ReadKeyItemData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Keys_Items", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Keys_Items\" + Path.GetFileNameWithoutExtension(name);
                KeyItemData data = Content.Load<KeyItemData>(filename);
                KeyItemData.Add(data.Name, data);
            }
        }

        public static void ReadChestData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Chests", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Chests\" + Path.GetFileNameWithoutExtension(name);
                ChestData data = Content.Load<ChestData>(filename);
                ChestData.Add(data.Name, data);
            }
        }

        public static void ReadSkillData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Skills", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Skills\" + Path.GetFileNameWithoutExtension(name);
                SkillData data = Content.Load<SkillData>(filename);
                SkillData.Add(data.Name, data);
            }
        }

        public static void ReadLevelData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Levels", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Levels\" + Path.GetFileNameWithoutExtension(name);
                LevelData data = Content.Load<LevelData>(filename);
                LevelData.Add(data.LevelName, data);
            }
        }

        public static void ReadMapData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Levels\Maps", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Levels\Maps\" + Path.GetFileNameWithoutExtension(name);
                MapData data = Content.Load<MapData>(filename);
                MapData.Add(data.MapName, data);
            }
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
