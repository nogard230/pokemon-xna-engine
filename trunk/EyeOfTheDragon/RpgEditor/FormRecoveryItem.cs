using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormRecoveryItem : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public FormRecoveryItem()
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
            using (FormRecoveryItemDetails frmRecoveryItemDetails = new FormRecoveryItemDetails())
            {
                frmRecoveryItemDetails.ShowDialog();

                if (frmRecoveryItemDetails.RecoveryItem != null)
                {
                    AddRecoveryItem(frmRecoveryItemDetails.RecoveryItem);
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

                RecoveryItemData data = itemManager.RecoveryItemData[entity];
                RecoveryItemData newData = null;

                using (FormRecoveryItemDetails frmRecoveryItemData = new FormRecoveryItemDetails())
                {
                    frmRecoveryItemData.RecoveryItem = data;
                    frmRecoveryItemData.ShowDialog();

                    if (frmRecoveryItemData.RecoveryItem == null)
                        return;

                    if (frmRecoveryItemData.RecoveryItem.Name == entity)
                    {
                        itemManager.RecoveryItemData[entity] = frmRecoveryItemData.RecoveryItem;
                        FillListBox();
                        return;
                    }

                    newData = frmRecoveryItemData.RecoveryItem;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemManager.RecoveryItemData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemManager.RecoveryItemData.Add(newData.Name, newData);
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
                    itemManager.RecoveryItemData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\Recovery\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Recovery\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemManager.RecoveryItemData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.RecoveryItemData[s]);
        }

        private void AddRecoveryItem(RecoveryItemData recoveryItemData)
        {
            if (FormDetails.ItemManager.RecoveryItemData.ContainsKey(recoveryItemData.Name))
            {
                DialogResult result = MessageBox.Show(
                    recoveryItemData.Name + " already exists. Overwrite it?",
                    "Existing Recovery Item",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemManager.RecoveryItemData[recoveryItemData.Name] = recoveryItemData;
                FillListBox();
                return;
            }

            itemManager.RecoveryItemData.Add(recoveryItemData.Name, recoveryItemData);
            lbDetails.Items.Add(recoveryItemData);
        }

        #endregion    
    }
}
