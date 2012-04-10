using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RpgLibrary.ItemClasses;
using RpgLibrary.EffectClasses;

namespace RpgEditor
{
    public partial class FormRecoveryItemDetails : Form
    {
        #region Field Region

        RecoveryItemData recoveryItem;

        #endregion

        #region Property Region

        public RecoveryItemData RecoveryItem
        {
            get { return recoveryItem; }
            set { recoveryItem = value; }
        }

        #endregion

        #region Constructor Region

        public FormRecoveryItemDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormRecoveryItemDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormRecoveryItemDetails_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

        }

        #endregion

        #region Event Handler Region

        void FormRecoveryItemDetails_Load(object sender, EventArgs e)
        {
            cbStatusCured.Items.Add("None");
            foreach (StatusType type in Enum.GetValues(typeof(StatusType)))
                cbStatusCured.Items.Add(type);

            if (recoveryItem != null)
            {
                tbName.Text = recoveryItem.Name;
                tbType.Text = recoveryItem.Type;
                mtbPrice.Text = recoveryItem.Price.ToString();
                mtbSellPrice.Text = recoveryItem.SellPrice.ToString();

                mtbHealthHealed.Text = recoveryItem.HealValue.ToString();
                mtbPercentHealthHealed.Text = recoveryItem.HealPercentage.ToString();
                cbCanRevive.Checked = recoveryItem.CanRevive;
                mtbLevelsGained.Text = recoveryItem.LevelsGained.ToString();
                mtbPPRestored.Text = recoveryItem.PPRestoreValue.ToString();
                nudMovesPPRestored.Value = recoveryItem.MovesRestored;
                cbStatusCured.SelectedText = recoveryItem.StatusCured.ToString();
                cbCureAllStatuses.Checked = recoveryItem.CureAllStatuses;
            }
        }

        void FormRecoveryItemDetails_FormClosing(object sender, FormClosingEventArgs e)
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
            int healthHealed = 0;
            float percentageHealed = 0;
            int levelsGained = 0;
            int ppRestored = 0;
            int movesRestored = 0;
            StatusType statusCured;

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

            int.TryParse(mtbHealthHealed.Text, out healthHealed);
            float.TryParse(mtbPercentHealthHealed.Text, out percentageHealed);
            int.TryParse(mtbLevelsGained.Text, out levelsGained);
            int.TryParse(mtbPPRestored.Text, out ppRestored);
            movesRestored = (int)nudMovesPPRestored.Value;

            recoveryItem = new RecoveryItemData();
            recoveryItem.Name = tbName.Text;
            recoveryItem.Type = tbType.Text;
            recoveryItem.Price = price;
            recoveryItem.SellPrice = sellPrice;
            recoveryItem.HealValue = healthHealed;
            recoveryItem.HealPercentage = percentageHealed;
            recoveryItem.CanRevive = cbCanRevive.Checked;
            recoveryItem.LevelsGained = levelsGained;
            recoveryItem.PPRestoreValue = ppRestored;
            recoveryItem.MovesRestored = movesRestored;

            if (cbStatusCured.SelectedIndex != 0)
            {
                try
                {
                    statusCured = (StatusType)Enum.Parse(typeof(StatusType), cbStatusCured.SelectedText);
                    recoveryItem.StatusCured = statusCured;
                }
                catch (ArgumentException)
                {

                }
            }

            recoveryItem.CureAllStatuses = cbCureAllStatuses.Checked;


            this.FormClosing -= FormRecoveryItemDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            recoveryItem = null;
            this.FormClosing -= FormRecoveryItemDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
