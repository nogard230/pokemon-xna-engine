using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormTMItemDetails : Form
    {
        #region Field Region

        TMItemData tmItem = null;

        #endregion

        #region Property Region

        public TMItemData TMItem
        {
            get { return tmItem; }
            set { tmItem = value; }
        }

        #endregion

        #region Constructor Region

        public FormTMItemDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormTMItemDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormTMItemDetails_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Handler Region

        void FormTMItemDetails_Load(object sender, EventArgs e)
        {

            if (tmItem != null)
            {
                tbTMName.Text = tmItem.Name;
                cboAttack.SelectedValue = tmItem.MoveTaught;
            }
        }

        void FormTMItemDetails_FormClosing(object sender, FormClosingEventArgs e)
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

            if (string.IsNullOrEmpty(tbTMName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }

            tmItem = new TMItemData();
            tmItem.Name = tbTMName.Text;
            tmItem.Type = "TM";
            tmItem.Price = price;
            tmItem.SellPrice = sellPrice;
            tmItem.MoveTaught = (string)cboAttack.SelectedValue;

            this.FormClosing -= FormTMItemDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            tmItem = null;
            this.FormClosing -= FormTMItemDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
