using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormPokemon : FormDetails
    {
        public FormPokemon()
        {
            InitializeComponent();

            //btnAdd.Click += new EventHandler(btnAdd_Click);
            //btnEdit.Click += new EventHandler(btnEdit_Click);
            //btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        /*#region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormMiscItemDetails frmMiscDetails = new FormMiscItemDetails())
            {
                frmMiscDetails.ShowDialog();

                if (frmMiscDetails.MiscItem != null)
                {
                    AddMiscItem(frmMiscDetails.MiscItem);
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

                MiscItemData data = itemManager.MiscItemData[entity];
                MiscItemData newData = null;

                using (FormMiscItemDetails frmMiscItemData = new FormMiscItemDetails())
                {
                    frmMiscItemData.MiscItem = data;
                    frmMiscItemData.ShowDialog();

                    if (frmMiscItemData.MiscItem == null)
                        return;

                    if (frmMiscItemData.MiscItem.Name == entity)
                    {
                        itemManager.MiscItemData[entity] = frmMiscItemData.MiscItem;
                        FillListBox();
                        return;
                    }

                    newData = frmMiscItemData.MiscItem;
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
                itemManager.MiscItemData.Add(newData.Name, newData);
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

                    if (File.Exists(FormMain.ItemPath + @"\Misc\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Misc\" + entity + ".xml");
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

        private void AddMiscItem(MiscItemData miscItemData)
        {
            if (FormDetails.ItemManager.MiscItemData.ContainsKey(miscItemData.Name))
            {
                DialogResult result = MessageBox.Show(
                    miscItemData.Name + " already exists. Overwrite it?",
                    "Existing Misc Item",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemManager.MiscItemData[miscItemData.Name] = miscItemData;
                FillListBox();
                return;
            }

            itemManager.MiscItemData.Add(miscItemData.Name, miscItemData);
            lbDetails.Items.Add(miscItemData);
        }

        #endregion*/
    }
}
