using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RpgLibrary.ItemClasses;
using RpgLibrary.CharacterClasses;

namespace RpgEditor
{
    public partial class FormMiscItemDetails : Form
    {
        #region Field Region

        MiscItemData miscItem = null;

        #endregion

        #region Property Region

        public MiscItemData MiscItem
        {
            get { return miscItem; }
            set { miscItem = value; }
        }

        #endregion

        #region Constructor Region

        public FormMiscItemDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormArmorDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormMiscItemDetails_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Handler Region

        void FormArmorDetails_Load(object sender, EventArgs e)
        {

            if (miscItem != null)
            {
                tbName.Text = miscItem.Name;
                tbType.Text = miscItem.Type;
                mtbPrice.Text = miscItem.Price.ToString();
                mtbSellPrice.Text = miscItem.SellPrice.ToString();
            }
        }

        void FormMiscItemDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            int price = 0;
            int sellPrice = 0;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }

            if (!int.TryParse(mtbPrice.Text, out price))
            {
                MessageBox.Show("Price must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbSellPrice.Text, out sellPrice))
            {
                MessageBox.Show("Sell Price must be an integer value.");
                return;
            }

            miscItem = new MiscItemData();
            miscItem.Name = tbName.Text;
            miscItem.Type = tbType.Text;
            miscItem.Price = price;
            miscItem.SellPrice = sellPrice;

            this.FormClosing -= FormMiscItemDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            miscItem = null;
            this.FormClosing -= FormMiscItemDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
