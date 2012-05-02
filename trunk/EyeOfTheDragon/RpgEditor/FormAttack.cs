using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XRpgLibrary.AttackClasses;

namespace RpgEditor
{
    public partial class FormAttack : FormDetails
    {
        public FormAttack()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #region Button Event Handler Region


        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormAttackDetails frmAttackDetails = new FormAttackDetails())
            {
                frmAttackDetails.ShowDialog();

                if (frmAttackDetails.Attack != null)
                {
                    AddAttack(frmAttackDetails.Attack);
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

                AttackData data = attackManager.AttackData[entity];
                AttackData newData = null;

                using (FormAttackDetails frmAttackDetails = new FormAttackDetails())
                {
                    frmAttackDetails.Attack = data;
                    frmAttackDetails.ShowDialog();

                    if (frmAttackDetails.Attack == null)
                        return;

                    if (frmAttackDetails.Attack.Name == entity)
                    {
                        attackManager.AttackData[entity] = frmAttackDetails.Attack;
                        FillListBox();
                        return;
                    }

                    newData = frmAttackDetails.Attack;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (attackManager.AttackData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                attackManager.AttackData.Add(newData.Name, newData);
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
                    skillManager.SkillData.Remove(entity);

                    if (File.Exists(FormMain.SkillPath + @"\" + entity + ".xml"))
                        File.Delete(FormMain.SkillPath + @"\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.AttackManager.AttackData.Keys)
                lbDetails.Items.Add(FormDetails.AttackManager.AttackData[s]);
        }

        private void AddAttack(AttackData attackData)
        {
            if (FormDetails.AttackManager.AttackData.ContainsKey(attackData.Name))
            {
                DialogResult result = MessageBox.Show(
                    attackData.Name + " already exists. Overwrite it?",
                    "Existing attack",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                attackManager.AttackData[attackData.Name] = attackData;
                FillListBox();
                return;
            }

            attackManager.AttackData.Add(attackData.Name, attackData);
            lbDetails.Items.Add(attackData);
        }

        #endregion    
    }
}
