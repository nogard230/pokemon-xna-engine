using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RpgLibrary.ItemClasses;
using RpgLibrary.TrapClasses;
using RpgLibrary.SkillClasses;

namespace RpgEditor
{
    public partial class FormChestDetails : Form
    {
        #region Field Region

        ChestData chest;

        #endregion

        #region Property Region

        public ChestData Chest
        {
            get { return chest; }
            set { chest = value; }
        }

        #endregion

        #region Constructor Region

        public FormChestDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormChestDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormChestDetails_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Form Event Handler Region

        void FormChestDetails_Load(object sender, EventArgs e)
        {
            cboItem.Items.Clear();

            foreach (string item in FormDetails.ItemManager.MiscItemData.Keys)
                cboItem.Items.Add(FormDetails.ItemManager.MiscItemData[item].Name);
            foreach (string item in FormDetails.ItemManager.RecoveryItemData.Keys)
                cboItem.Items.Add(FormDetails.ItemManager.RecoveryItemData[item].Name);
            foreach (string item in FormDetails.ItemManager.TMItemData.Keys)
                cboItem.Items.Add(FormDetails.ItemManager.TMItemData[item].Name);
            foreach (string item in FormDetails.ItemManager.BerryItemData.Keys)
                cboItem.Items.Add(FormDetails.ItemManager.BerryItemData[item].Name);
            foreach (string item in FormDetails.ItemManager.KeyItemData.Keys)
                cboItem.Items.Add(FormDetails.ItemManager.KeyItemData[item].Name);

            if (chest != null)
            {
                tbName.Text = chest.Name;
            
            }
        }

        void FormChestDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        #endregion
        
        #region Button Event Handler Region

        void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the chest.");
                return;
            }

            ChestData data = new ChestData();

            data.Name = tbName.Text;
            data.Item = (string)cboItem.SelectedItem;

            chest = data;
            this.FormClosing -= FormChestDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            chest = null;
            this.FormClosing -= FormChestDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
