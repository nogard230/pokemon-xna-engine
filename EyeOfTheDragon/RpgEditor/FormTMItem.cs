using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormTMItem : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public FormTMItem()
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
            using (FormTMItemDetails frmTMItemDetails = new FormTMItemDetails())
            {
                frmTMItemDetails.ShowDialog();

                if (frmTMItemDetails.TMItem != null)
                {
                    AddTMItem(frmTMItemDetails.TMItem);
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

                TMItemData data = itemManager.TMItemData[entity];
                TMItemData newData = null;

                using (FormTMItemDetails frmTMItemDetails = new FormTMItemDetails())
                {
                    frmTMItemDetails.TMItem = data;
                    frmTMItemDetails.ShowDialog();

                    if (frmTMItemDetails.TMItem == null)
                        return;

                    if (frmTMItemDetails.TMItem.Name == entity)
                    {
                        itemManager.TMItemData[entity] = frmTMItemDetails.TMItem;
                        FillListBox();
                        return;
                    }

                    newData = frmTMItemDetails.TMItem;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemManager.MiscItemData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemManager.TMItemData.Add(newData.Name, newData);
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
                    itemManager.MiscItemData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\TM\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\TM\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemManager.MiscItemData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.MiscItemData[s]);
        }

        private void AddTMItem(TMItemData tmItemData)
        {
            if (FormDetails.ItemManager.TMItemData.ContainsKey(tmItemData.Name))
            {
                DialogResult result = MessageBox.Show(
                    tmItemData.Name + " already exists. Overwrite it?",
                    "Existing Misc Item",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemManager.TMItemData[tmItemData.Name] = tmItemData;
                FillListBox();
                return;
            }

            itemManager.TMItemData.Add(tmItemData.Name, tmItemData);
            lbDetails.Items.Add(tmItemData);
        }

        #endregion
    }
}
