using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RpgLibrary.ItemClasses;
using RpgLibrary.CharacterClasses;
using RpgLibrary.SkillClasses;
using XRpgLibrary.PokemonClasses;

namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        #region Field Region

        protected static ItemDataManager itemManager;
        protected static EntityDataManager entityDataManager;
        protected static SkillDataManager skillManager;

        #endregion

        #region Property Region

        public static ItemDataManager ItemManager
        {
            get { return itemManager; }
        }

        public static EntityDataManager EntityDataManager
        {
            get { return entityDataManager; }
        }

        public static SkillDataManager SkillManager
        {
            get { return skillManager; }
        }

        #endregion

        #region Constructor Region

        public FormDetails()
        {
            InitializeComponent();

            if (FormDetails.itemManager == null)
                itemManager = new ItemDataManager();

            if (FormDetails.entityDataManager == null)
                entityDataManager = new EntityDataManager();

            if (FormDetails.skillManager == null)
                skillManager = new SkillDataManager();

            this.FormClosing += new FormClosingEventHandler(FormDetails_FormClosing);
        }

        #endregion

        #region Event Handler Region

        void FormDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }

            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = false;
                this.Close();
            }
        }

        #endregion

        #region Method Region

        public static void WriteEntityData()
        {
            foreach (string s in EntityDataManager.EntityData.Keys)
            {
                XnaSerializer.Serialize<EntityData>(
                    FormMain.ClassPath + @"\" + s + ".xml",
                    EntityDataManager.EntityData[s]);
            }

            foreach (string s in EntityDataManager.PokemonData.Keys)
            {
                XnaSerializer.Serialize<PokemonData>(
                    FormMain.PokemonPath + @"\" + s + ".xml",
                    EntityDataManager.PokemonData[s]);
            }
        }

        public static void WriteItemData()
        {
            foreach (string s in ItemManager.MiscItemData.Keys)
            {
                XnaSerializer.Serialize<MiscItemData>(
                    FormMain.ItemPath + @"\Misc\" + s + ".xml",
                    ItemManager.MiscItemData[s]);
            }

            foreach (string s in ItemManager.RecoveryItemData.Keys)
            {
                XnaSerializer.Serialize<RecoveryItemData>(
                    FormMain.ItemPath + @"\Recovery\" + s + ".xml",
                    ItemManager.RecoveryItemData[s]);
            }

            foreach (string s in ItemManager.TMItemData.Keys)
            {
                XnaSerializer.Serialize<TMItemData>(
                    FormMain.ItemPath + @"\TM\" + s + ".xml",
                    ItemManager.TMItemData[s]);
            }

            foreach (string s in ItemManager.BerryItemData.Keys)
            {
                XnaSerializer.Serialize<BerryItemData>(
                    FormMain.ItemPath + @"\Berry\" + s + ".xml",
                    ItemManager.BerryItemData[s]);
            }

            foreach (string s in ItemManager.KeyItemData.Keys)
            {
                XnaSerializer.Serialize<KeyItemData>(
                    FormMain.ItemPath + @"\Key_Item\" + s + ".xml",
                    ItemManager.KeyItemData[s]);
            }

        }

        public static void WriteKeyData()
        {
            foreach (string s in ItemManager.KeyItemData.Keys)
            {
                XnaSerializer.Serialize<KeyItemData>(
                    FormMain.KeyPath + @"\" + s + ".xml",
                    ItemManager.KeyItemData[s]);
            }
        }

        public static void WriteChestData()
        {
            foreach (string s in ItemManager.ChestData.Keys)
            {
                XnaSerializer.Serialize<ChestData>(
                    FormMain.ChestPath + @"\" + s + ".xml",
                    ItemManager.ChestData[s]);
            }
        }

        public static void WriteSkillData()
        {
            foreach (string s in SkillManager.SkillData.Keys)
            {
                XnaSerializer.Serialize<SkillData>(
                    FormMain.SkillPath + @"\" + s + ".xml",
                    SkillManager.SkillData[s]);
            }
        }

        public static void ReadEntityData()
        {
            entityDataManager = new EntityDataManager();

            string[] fileNames = Directory.GetFiles(FormMain.ClassPath, "*.xml");

            foreach (string s in fileNames)
            {
                EntityData entityData = XnaSerializer.Deserialize<EntityData>(s);
                entityDataManager.EntityData.Add(entityData.EntityName, entityData);
            }

            fileNames = Directory.GetFiles(FormMain.PokemonPath, "*.xml");

            foreach (string s in fileNames)
            {
                PokemonData pokemonData = XnaSerializer.Deserialize<PokemonData>(s);
                entityDataManager.PokemonData.Add(pokemonData.UniqueID, pokemonData);
            }
        }

        public static void ReadItemData()
        {
            itemManager = new ItemDataManager();

            string[] fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "Misc"),
                "*.xml");

            foreach (string s in fileNames)
            {
                MiscItemData miscItemData = XnaSerializer.Deserialize<MiscItemData>(s);
                itemManager.MiscItemData.Add(miscItemData.Name, miscItemData);
            }

            fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "Recovery"),
                "*.xml");

            foreach (string s in fileNames)
            {
                RecoveryItemData recoveryItemData = XnaSerializer.Deserialize<RecoveryItemData>(s);
                itemManager.RecoveryItemData.Add(recoveryItemData.Name, recoveryItemData);
            }

            fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "TM"),
                "*.xml");

            foreach (string s in fileNames)
            {
                TMItemData tmItemData = XnaSerializer.Deserialize<TMItemData>(s);
                itemManager.TMItemData.Add(tmItemData.Name, tmItemData);
            }

            fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "Berry"),
                "*.xml");

            foreach (string s in fileNames)
            {
                BerryItemData berryItemData = XnaSerializer.Deserialize<BerryItemData>(s);
                itemManager.BerryItemData.Add(berryItemData.Name, berryItemData);
            }

            fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "Key_Item"),
                "*.xml");

            foreach (string s in fileNames)
            {
                KeyItemData keyItemData = XnaSerializer.Deserialize<KeyItemData>(s);
                itemManager.KeyItemData.Add(keyItemData.Name, keyItemData);
            }

        }

        public static void ReadKeyData()
        {
            //string[] fileNames = Directory.GetFiles(FormMain.KeyPath, "*.xml");

            //foreach (string s in fileNames)
            //{
            //    KeyItemData keyData = XnaSerializer.Deserialize<KeyItemData>(s);
            //    itemManager.KeyData.Add(keyData.Name, keyData);
            //}
        }

        public static void ReadChestData()
        {
            string[] fileNames = Directory.GetFiles(FormMain.ChestPath, "*.xml");

            foreach (string s in fileNames)
            {
                ChestData chestData = XnaSerializer.Deserialize<ChestData>(s);
                itemManager.ChestData.Add(chestData.Name, chestData);
            }
        }

        public static void ReadSkillData()
        {
            skillManager = new SkillDataManager();

            string[] fileNames = Directory.GetFiles(FormMain.SkillPath, "*.xml");

            foreach (string s in fileNames)
            {
                SkillData chestData = XnaSerializer.Deserialize<SkillData>(s);
                skillManager.SkillData.Add(chestData.Name, chestData);
            }
        }
        #endregion
    }
}
