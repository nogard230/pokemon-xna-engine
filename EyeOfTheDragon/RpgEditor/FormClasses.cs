﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RpgLibrary.CharacterClasses;
using System.IO;

namespace RpgEditor
{
    public partial class FormClasses : FormDetails
    {
        #region Field Region
        #endregion

        #region Constructor Region

        public FormClasses()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #endregion

        #region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEntityData frmEntityData = new FormEntityData())
            {
                frmEntityData.ShowDialog();

                if (frmEntityData.EntityData != null)
                {
                    AddEntity(frmEntityData.EntityData);
                }
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                EntityData data = EntityDataManager.EntityData[entity];
                EntityData newData = null;

                using (FormEntityData frmEntityData = new FormEntityData())
                {
                    frmEntityData.EntityData = data;
                    frmEntityData.ShowDialog();

                    if (frmEntityData.EntityData == null)
                        return;

                    if (frmEntityData.EntityData.EntityName == entity)
                    {
                        EntityDataManager.EntityData[entity] = frmEntityData.EntityData;
                        FillListBox();
                        return;
                    }

                    newData = frmEntityData.EntityData;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (EntityDataManager.EntityData.ContainsKey(newData.EntityName))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                EntityDataManager.EntityData.Add(newData.EntityName, newData);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete " + entity + "?",
                    "Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    EntityDataManager.EntityData.Remove(entity);

                    if (File.Exists(FormMain.ClassPath + @"\" + entity + ".xml"))
                        File.Delete(FormMain.ClassPath + @"\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Method Region

        private void AddEntity(EntityData entityData)
        {
            if (EntityDataManager.EntityData.ContainsKey(entityData.EntityName))
            {
                DialogResult result = MessageBox.Show(
                    entityData.EntityName + " already exists. Do you want to overwrite it?",
                    "Existing Character Class",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                EntityDataManager.EntityData[entityData.EntityName] = entityData;

                FillListBox();
                return;
            }

            lbDetails.Items.Add(entityData.ToString());

            EntityDataManager.EntityData.Add(
                entityData.EntityName,
                entityData);
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in EntityDataManager.EntityData.Keys)
                lbDetails.Items.Add(EntityDataManager.EntityData[s]);
        }

        #endregion
    }
}
