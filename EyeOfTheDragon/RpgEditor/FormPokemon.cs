using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XRpgLibrary.PokemonClasses;

namespace RpgEditor
{
    public partial class FormPokemon : FormDetails
    {
        public FormPokemon()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormPokemonDetails frmPokemonDetails = new FormPokemonDetails())
            {
                frmPokemonDetails.ShowDialog();

                if (frmPokemonDetails.Pokemon != null)
                {
                    AddPokemon(frmPokemonDetails.Pokemon);
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

                PokemonData data = entityDataManager.PokemonData[entity];
                PokemonData newData = null;

                using (FormPokemonDetails frmPokemonDetails = new FormPokemonDetails())
                {
                    frmPokemonDetails.Pokemon = data;
                    frmPokemonDetails.ShowDialog();

                    if (frmPokemonDetails.Pokemon == null)
                        return;

                    if (frmPokemonDetails.Pokemon.UniqueID == entity)
                    {
                        entityDataManager.PokemonData[entity] = frmPokemonDetails.Pokemon;
                        FillListBox();
                        return;
                    }

                    newData = frmPokemonDetails.Pokemon;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (entityDataManager.PokemonData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                entityDataManager.PokemonData.Add(newData.UniqueID, newData);
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
                    entityDataManager.PokemonData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\Pokemon\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Pokemon\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.entityDataManager.PokemonData.Keys)
                lbDetails.Items.Add(FormDetails.entityDataManager.PokemonData[s]);
        }

        private void AddPokemon(PokemonData pokemonData)
        {
            if (FormDetails.entityDataManager.PokemonData.ContainsKey(pokemonData.UniqueID))
            {
                DialogResult result = MessageBox.Show(
                    pokemonData.UniqueID + " already exists. Overwrite it?",
                    "Existing Pokemon",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                entityDataManager.PokemonData[pokemonData.UniqueID] = pokemonData;
                FillListBox();
                return;
            }

            entityDataManager.PokemonData.Add(pokemonData.UniqueID, pokemonData);
            lbDetails.Items.Add(pokemonData);
        }

        #endregion
    }
}
