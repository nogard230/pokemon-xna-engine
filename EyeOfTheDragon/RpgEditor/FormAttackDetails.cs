using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using XRpgLibrary.AttackClasses;
using XRpgLibrary;
using RpgLibrary.CharacterClasses;

namespace RpgEditor
{
    public partial class FormAttackDetails : Form
    {
        AttackData attack;

        public AttackData Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public FormAttackDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormAttackDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormAttackDetails_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnRemove.Click += new EventHandler(btnRemove_Click);
        }

        #region Form Event Handler Region

        void FormAttackDetails_Load(object sender, EventArgs e)
        {
            foreach (ElementType element in Enum.GetValues(typeof(ElementType)))
            {
                cboElement.Items.Add(element);
            }

            foreach (AttackType type in Enum.GetValues(typeof(AttackType)))
            {
                cboType.Items.Add(type);
            }

            cboElement.SelectedIndex = 0;
            cboType.SelectedIndex = 0;

            try
            {
                Assembly assembly = Assembly.Load(@"XRpgLibrary");
                string @namespace = "XRpgLibrary.AttackClasses.AttackEffects";

                var q = from t in assembly.GetTypes()
                        where t.IsClass && t.Namespace == @namespace
                        select t;
                List<Type> classes = q.ToList();

                foreach (Type effectClass in classes)
                {
                    lbEffects.Items.Add(effectClass.Name);
                }
            }
            catch
            {
                System.Console.WriteLine("Error loading assembly");
            }

            if (Attack != null)
            {
                tbName.Text = Attack.Name;
                cboElement.SelectedItem = Attack.AttackElementType;
                mtbPP.Text = Attack.CurrentPP.MaximumValue.ToString();
                mtbAccuracy.Text = attack.Accuracy.ToString();
                cboType.SelectedItem = attack.AttackType;

                cbContact.Checked = attack.Contact;
                mtbPriority.Text = attack.Priority.ToString();
                cbSound.Checked = attack.Sound;
                cbPunch.Checked = attack.Punch;
                cbSnatchable.Checked = attack.Snatchable;
                cbGroundable.Checked = attack.Groundable;
                cbDefrosts.Checked = attack.Defrosts;
                cbReflectable.Checked = attack.Reflectable;
                cbBlockable.Checked = attack.Blockable;
                cbCopyable.Checked = attack.Copyable;

                tbDescritpion.Text = attack.Description;

                foreach (AttackEffect effect in Attack.Effects)
                {
                    string data = effect.ToString();
                    lbSelectedEffects.Items.Add(effect);
                }
            }
        }

        void FormAttackDetails_FormClosing(object sender, FormClosingEventArgs e)
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
            int pp = 0;
            int accuracy = 0;
            int priority = 0;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must provide a name for the attack.");
                return;
            }

            AttackData newAttack = new AttackData();

            newAttack.Name = tbName.Text;

            try
            {
                newAttack.AttackElementType = (ElementType)Enum.Parse(typeof(ElementType), cboElement.SelectedItem.ToString());
            }
            catch (ArgumentException)
            {

            }

            if (!int.TryParse(mtbPP.Text, out pp))
            {
                MessageBox.Show("PP must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbAccuracy.Text, out accuracy))
            {
                MessageBox.Show("Accuracy must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbPriority.Text, out priority))
            {
                MessageBox.Show("Priority must be an integer value.");
                return;
            }


            newAttack.CurrentPP = new AttributePair(pp);
            newAttack.Accuracy = accuracy / 100f;

            foreach (AttackEffect effect in lbSelectedEffects.Items)
            {
                newAttack.Effects.Add(effect);
            }

            try
            {
                newAttack.AttackType = (AttackType)Enum.Parse(typeof(AttackType), cboType.SelectedItem.ToString());
            }
            catch (ArgumentException)
            {

            }

            newAttack.Contact = cbContact.Checked;
            newAttack.Priority = priority;
            newAttack.Sound = cbSound.Checked;
            newAttack.Punch = cbPunch.Checked;
            newAttack.Snatchable = cbSnatchable.Checked;
            newAttack.Groundable = cbGroundable.Checked;
            newAttack.Defrosts = cbDefrosts.Checked;
            newAttack.Reflectable = cbReflectable.Checked;
            newAttack.Blockable = cbBlockable.Checked;
            newAttack.Copyable = cbCopyable.Checked;

            newAttack.Description = tbDescritpion.Text;

            attack = newAttack;
            this.FormClosing -= FormAttackDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            attack = null;
            this.FormClosing -= FormAttackDetails_FormClosing;
            this.Close();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {

        }

        void btnRemove_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
