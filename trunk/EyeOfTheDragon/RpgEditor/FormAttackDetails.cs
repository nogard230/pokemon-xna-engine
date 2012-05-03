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
using RpgLibrary.EffectClasses;

namespace RpgEditor
{
    public partial class FormAttackDetails : Form
    {
        AttackData attack;
        List<AttackEffect> addedEffects;
        List<Type> effectClasses;

        public AttackData Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public FormAttackDetails()
        {
            InitializeComponent();

            effectClasses = new List<Type>();
            addedEffects = new List<AttackEffect>();

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
                    effectClasses.Add(effectClass);
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
                mtbAccuracy.Text = (attack.Accuracy * 100).ToString();
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
                    addedEffects.Add(effect);
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

            foreach (AttackEffect effect in addedEffects)
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
            Form effectOptions = new Form();
            effectOptions.Text = "Effect Details";
            Type t = effectClasses[lbEffects.SelectedIndex];
            AttackEffect effect = (AttackEffect)Activator.CreateInstance(t);
            List<PropertyInfo> properties = new List<PropertyInfo>();

            properties = effect.GetType().GetProperties().ToList<PropertyInfo>();
            List<Control> controls = new List<Control>();
            int yPos = 10;
            foreach (PropertyInfo property in properties)
            {
                Label label = new Label();
                label.Text = property.Name + ": ";
                label.Location = new Point(100 - label.Width, yPos);

                if (property.PropertyType.Equals(typeof(bool)))
                {
                    CheckBox cBox = new CheckBox();
                    cBox.Location = new Point(110, yPos);
                    controls.Add(cBox);
                    effectOptions.Controls.Add(cBox);
                }
                else if (property.PropertyType.IsEnum)
                {
                    ComboBox cbBox = new ComboBox();
                    cbBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbBox.Location = new Point(110, yPos);

                    for(int i = 0; i < Enum.GetValues(property.PropertyType).Length; i++)
                    {
                        Enum type = (Enum)Enum.GetValues(property.PropertyType).GetValue(i);
                        cbBox.Items.Add(type);
                    }
                    cbBox.SelectedIndex = 0;

                    controls.Add(cbBox);
                    effectOptions.Controls.Add(cbBox);
                }
                else
                {
                    TextBox tBox = new TextBox();
                    tBox.Location = new Point(110, yPos);
                    controls.Add(tBox);
                    effectOptions.Controls.Add(tBox);
                }
                effectOptions.Controls.Add(label);
                yPos += 30;
            }

            Button btnEffectOK = new Button();
            btnEffectOK.Text = "OK";
            btnEffectOK.Location = new Point(effectOptions.Width / 2 - btnEffectOK.Width / 2, effectOptions.Height - 100);
            btnEffectOK.Click += new EventHandler(btnEffectOK_Click);
            effectOptions.Controls.Add(btnEffectOK);

            effectOptions.ShowDialog();

            for(int i = 0; i < properties.Count; i++)
            {
                PropertyInfo property = properties[i];
                if (property.CanWrite)
                {
                    object pValue = null;

                    if (controls[i].GetType().Equals(typeof(CheckBox)))
                    {
                        Control c = controls[i];
                        if (c is CheckBox)
                        {
                            pValue = ((CheckBox)c).Checked;
                        }
                    }
                    else if (controls[i].GetType().Equals(typeof(ComboBox)))
                    {
                        Control c = controls[i];
                        if (c is ComboBox)
                        {
                            string v = ((ComboBox)c).SelectedItem.ToString();
                            try
                            {
                                pValue = Enum.Parse(property.PropertyType, v);
                            }
                            catch (ArgumentException)
                            {

                            }
                        }
                    }
                    else
                    {
                        Control c = controls[i];
                        if (c is TextBox)
                        {
                            string v = ((TextBox)c).Text;
                            try
                            {
                                pValue = Convert.ChangeType(v, property.PropertyType);
                            }
                            catch
                            {

                            }

                        }
                    }

                    property.SetValue(effect, pValue, null);
                }

            }

            addedEffects.Add(effect);
            lbSelectedEffects.Items.Add(effect);
        }

        void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbSelectedEffects.SelectedItem != null)
            {
                string name = lbSelectedEffects.SelectedItem.GetType().Name;

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete " + name + "?",
                    "Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    addedEffects.RemoveAt(lbSelectedEffects.SelectedIndex);
                    lbSelectedEffects.Items.RemoveAt(lbSelectedEffects.SelectedIndex);
                }
            }
        }

        void btnEffectOK_Click(object sender, EventArgs e)
        {
            ((Form)((Button)sender).Parent).Close();
        }

        #endregion
    }
}
