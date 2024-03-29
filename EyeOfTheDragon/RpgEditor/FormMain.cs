﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormMain : Form
    {
        #region Field Region

        RolePlayingGame rolePlayingGame;
        FormClasses frmClasses;
        FormMiscItem frmMiscItem;
        FormRecoveryItem frmRecoveryItem;
        FormTMItem frmTM;
        //FormKey frmKey;
        FormChest frmChest;
        FormSkill frmSkill;
        FormPokemon frmPokemon;
        FormAttack frmAttack;

        static string gamePath = "";
        static string classPath = "";
        static string itemPath = "";
        static string chestPath = "";
        static string keyPath = "";
        static string skillPath = "";
        static string pokemonPath = "";
        static string attackPath = "";

        #endregion

        #region Property Region

        public static string GamePath
        {
            get { return gamePath; }
        }

        public static string ClassPath
        {
            get { return classPath; }
        }

        public static string ItemPath
        {
            get { return itemPath; }
        }

        public static string ChestPath
        {
            get { return chestPath; }
        }

        public static string KeyPath
        {
            get { return keyPath; }
        }

        public static string SkillPath
        {
            get { return skillPath; }
        }

        public static string PokemonPath
        {
            get { return pokemonPath; }
        }

        public static string AttackPath
        {
            get { return attackPath; }
        }

        #endregion

        #region Constructor Region

        public FormMain()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);

            newGameToolStripMenuItem.Click += new EventHandler(newGameToolStripMenuItem_Click);
            openGameToolStripMenuItem.Click += new EventHandler(openGameToolStripMenuItem_Click);
            saveGameToolStripMenuItem.Click += new EventHandler(saveGameToolStripMenuItem_Click);
            exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);

            classesToolStripMenuItem.Click += new EventHandler(classesToolStripMenuItem_Click);
            miscItemToolStripMenuItem.Click += new EventHandler(miscItemToolStripMenuItem_Click);
            recoveryItemToolStripMenuItem.Click += new EventHandler(recoveryItemToolStripMenuItem_Click);
            tmItemToolStripMenuItem.Click += new EventHandler(tmItemToolStripMenuItem_Click);
            //berryItemToolStripMenuItem.Click += new EventHandler(berryItemToolStripMenuItem_Click);
            //keyItemsToolStripMenuItem.Click += new EventHandler(keyItemsToolStripMenuItem_Click);

            chestsToolStripMenuItem.Click += new EventHandler(chestsToolStripMenuItem_Click);

            skillsToolStripMenuItem.Click += new EventHandler(skillsToolStripMenuItem_Click);

            pokemonToolStripMenuItem.Click += new EventHandler(pokemonToolStripMenuItem_Click);
            attacksToolStripMenuItem.Click += new EventHandler(attacksToolStripMenuItem_Click);
        }

        #endregion

        #region Menu Item Event Handler Region

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Unsaved changes will be lost. Are you sure you want to exit?",
                "Exit?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewGame frmNewGame = new FormNewGame())
            {
                DialogResult result = frmNewGame.ShowDialog();

                if (result == DialogResult.OK && frmNewGame.RolePlayingGame != null)
                {
                    FolderBrowserDialog folderDialog = new FolderBrowserDialog();

                    folderDialog.Description = "Select folder to create game in.";
                    folderDialog.SelectedPath = Application.StartupPath;

                    DialogResult folderResult = folderDialog.ShowDialog();

                    if (folderResult == DialogResult.OK)
                    {
                        try
                        {

                            gamePath = Path.Combine(folderDialog.SelectedPath, "Game");
                            classPath = Path.Combine(gamePath, "Classes");
                            itemPath = Path.Combine(gamePath, "Items");
                            chestPath = Path.Combine(gamePath, "Chests");
                            skillPath = Path.Combine(gamePath, "Skills");
                            pokemonPath = Path.Combine(gamePath, "Pokemon");
                            attackPath = Path.Combine(gamePath, "Attacks");

                            if (Directory.Exists(gamePath))
                                throw new Exception("Selected directory already exists.");

                            Directory.CreateDirectory(gamePath);
                            Directory.CreateDirectory(classPath);
                            Directory.CreateDirectory(itemPath + @"\Misc");
                            Directory.CreateDirectory(itemPath + @"\Recovery");
                            Directory.CreateDirectory(itemPath + @"\TM");
                            Directory.CreateDirectory(itemPath + @"\Berry");
                            Directory.CreateDirectory(itemPath + @"\Key_Item");
                            Directory.CreateDirectory(chestPath);
                            Directory.CreateDirectory(skillPath);
                            Directory.CreateDirectory(pokemonPath);
                            Directory.CreateDirectory(attackPath);

                            rolePlayingGame = frmNewGame.RolePlayingGame;
                            XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"\Game.xml", rolePlayingGame);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }

                        classesToolStripMenuItem.Enabled = true;
                        itemsToolStripMenuItem.Enabled = true;
                        chestsToolStripMenuItem.Enabled = true;
                        skillsToolStripMenuItem.Enabled = true;
                        pokemonToolStripMenuItem.Enabled = true;
                        attacksToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        void openGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            folderDialog.Description = "Select Game folder";
            folderDialog.SelectedPath = Application.StartupPath;

            bool tryAgain = false;

            do
            {
                DialogResult folderResult = folderDialog.ShowDialog();
                DialogResult msgBoxResult;

                if (folderResult == DialogResult.OK)
                {
                    if (File.Exists(folderDialog.SelectedPath + @"\Game\Game.xml"))
                    {
                        try
                        {
                            OpenGame(folderDialog.SelectedPath);
                            tryAgain = false;
                        }
                        catch (Exception ex)
                        {
                            msgBoxResult = MessageBox.Show(
                                ex.ToString(),
                                "Error opening game.",
                                MessageBoxButtons.RetryCancel);

                            if (msgBoxResult == DialogResult.Cancel)
                                tryAgain = false;
                            else if (msgBoxResult == DialogResult.Retry)
                                tryAgain = true;
                        }
                    }
                    else
                    {

                        msgBoxResult = MessageBox.Show(
                            "Game not found, try again?",
                            "Game does not exist",
                            MessageBoxButtons.RetryCancel);

                        if (msgBoxResult == DialogResult.Cancel)
                            tryAgain = false;
                        else if (msgBoxResult == DialogResult.Retry)
                            tryAgain = true;
                    }
                }

            } while (tryAgain);
        }

        void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rolePlayingGame != null)
            {
                try
                {
                    XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"\Game.xml", rolePlayingGame);
                    FormDetails.WriteEntityData();
                    FormDetails.WriteItemData();
                    FormDetails.WriteChestData();
                    FormDetails.WriteKeyData();
                    FormDetails.WriteSkillData();
                    FormDetails.WriteAttackData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error saving game.");
                }
            }
        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmClasses == null)
            {
                frmClasses = new FormClasses();
                frmClasses.MdiParent = this;
            }

            frmClasses.Show();
            frmClasses.BringToFront();
        }

        void miscItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMiscItem == null)
            {
                frmMiscItem = new FormMiscItem();
                frmMiscItem.MdiParent = this;
            }

            frmMiscItem.Show();
            frmMiscItem.BringToFront();
        }

        void recoveryItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmRecoveryItem == null)
            {
                frmRecoveryItem = new FormRecoveryItem();
                frmRecoveryItem.MdiParent = this;
            }

            frmRecoveryItem.Show();
            frmRecoveryItem.BringToFront();
        }

        void tmItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTM == null)
            {
                frmTM = new FormTMItem();
                frmTM.MdiParent = this;
            }

            frmTM.Show();
            frmTM.BringToFront();
        }

        void chestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChest == null)
            {
                frmChest = new FormChest();
                frmChest.MdiParent = this;
            }

            frmChest.Show();
            frmChest.BringToFront();
        }

        void keysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmKey == null)
            //{
            //    frmKey = new FormKey();
            //    frmKey.MdiParent = this;
            //}

            //frmKey.Show();
            //frmKey.BringToFront();
        }

        void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSkill == null)
            {
                frmSkill = new FormSkill();
                frmSkill.MdiParent = this;
            }

            frmSkill.Show();
            frmSkill.BringToFront();
        }

        void pokemonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPokemon == null)
            {
                frmPokemon = new FormPokemon();
                frmPokemon.MdiParent = this;
            }

            frmPokemon.Show();
            frmPokemon.BringToFront();
        }
        void attacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAttack == null)
            {
                frmAttack = new FormAttack();
                frmAttack.MdiParent = this;
            }

            frmAttack.Show();
            frmAttack.BringToFront();
        }
        

        #endregion

        #region Method Region

        private void OpenGame(string path)
        {
            gamePath = Path.Combine(path, "Game");
            classPath = Path.Combine(gamePath, "Classes");
            itemPath = Path.Combine(gamePath, "Items");
            keyPath = Path.Combine(gamePath, "Keys");
            chestPath = Path.Combine(gamePath, "Chests");
            skillPath = Path.Combine(gamePath, "Skills");
            pokemonPath = Path.Combine(gamePath, "Pokemon");
            attackPath = Path.Combine(gamePath, "Attacks");

            if (!Directory.Exists(keyPath))
            {
                Directory.CreateDirectory(keyPath);
            }

            if (!Directory.Exists(chestPath))
            {
                Directory.CreateDirectory(chestPath);
            }

            if (!Directory.Exists(skillPath))
            {
                Directory.CreateDirectory(skillPath);
            }

            if (!Directory.Exists(pokemonPath))
            {
                Directory.CreateDirectory(pokemonPath);
            }

            if (!Directory.Exists(attackPath))
            {
                Directory.CreateDirectory(attackPath);
            }

            rolePlayingGame = XnaSerializer.Deserialize<RolePlayingGame>(
                gamePath + @"\Game.xml");

            FormDetails.ReadEntityData();
            FormDetails.ReadItemData();
            FormDetails.ReadKeyData();
            FormDetails.ReadChestData();
            FormDetails.ReadSkillData();
            FormDetails.ReadAttackData();

            PrepareForms();
        }

        private void PrepareForms()
        {
            if (frmClasses == null)
            {
                frmClasses = new FormClasses();
                frmClasses.MdiParent = this;
            }

            frmClasses.FillListBox();

            if (frmMiscItem == null)
            {
                frmMiscItem = new FormMiscItem();
                frmMiscItem.MdiParent = this;
            }

            frmMiscItem.FillListBox();

            if (frmRecoveryItem == null)
            {
                frmRecoveryItem = new FormRecoveryItem();
                frmRecoveryItem.MdiParent = this;
            }

            frmRecoveryItem.FillListBox();

            if (frmChest == null)
            {
                frmChest = new FormChest();
                frmChest.MdiParent = this;
            }

            frmChest.FillListBox();

            if (frmSkill == null)
            {
                frmSkill = new FormSkill();
                frmSkill.MdiParent = this;
            }

            frmSkill.FillListBox();

            if (frmPokemon == null)
            {
                frmPokemon = new FormPokemon();
                frmPokemon.MdiParent = this;
            }

            frmPokemon.FillListBox();

            if (frmAttack == null)
            {
                frmAttack = new FormAttack();
                frmAttack.MdiParent = this;
            }

            frmAttack.FillListBox();

            classesToolStripMenuItem.Enabled = true;
            itemsToolStripMenuItem.Enabled = true;
            chestsToolStripMenuItem.Enabled = true;
            skillsToolStripMenuItem.Enabled = true;
            pokemonToolStripMenuItem.Enabled = true;
            attacksToolStripMenuItem.Enabled = true;
        }

        #endregion
    }
}
