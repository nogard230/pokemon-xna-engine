using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XRpgLibrary.PokemonClasses;

namespace RpgEditor
{
    public partial class FormEvolutionCondition : Form
    {
        public EvolveCondition Condition;
        public EvolutionType EvolveType;

        public FormEvolutionCondition()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormEvolutionCondition_Load);
            this.FormClosing += new FormClosingEventHandler(FormEvolutionCondition_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
        }

        void FormEvolutionCondition_Load(object sender, EventArgs e)
        {

            foreach (EvolutionGender gender in Enum.GetValues(typeof(EvolutionGender)))
            {
                cboGender.Items.Add(gender);
            }

            cboGender.SelectedIndex = 0;

            switch (EvolveType)
            {
                case EvolutionType.Level:
                    mtbLevel.Enabled = true;
                    cboGender.Enabled = true;
                    tbItem.Enabled = false;
                    tbPokemon.Enabled = false;
                    mtbHappiness.Enabled = false;
                    tbLocation.Enabled = false;
                    tbAttack.Enabled = false;
                    break;

                case EvolutionType.LevelWithItem:
                    mtbLevel.Enabled = false;
                    cboGender.Enabled = true;
                    tbItem.Enabled = true;
                    tbPokemon.Enabled = false;
                    mtbHappiness.Enabled = false;
                    tbLocation.Enabled = false;
                    tbAttack.Enabled = false;
                    break;

                case EvolutionType.LevelWithMove:
                    mtbLevel.Enabled = false;
                    cboGender.Enabled = true;
                    tbItem.Enabled = false;
                    tbPokemon.Enabled = false;
                    mtbHappiness.Enabled = false;
                    tbLocation.Enabled = false;
                    tbAttack.Enabled = true;
                    break;

                case EvolutionType.LevelWtihPokemon:
                    mtbLevel.Enabled = false;
                    cboGender.Enabled = true;
                    tbItem.Enabled = false;
                    tbPokemon.Enabled = true;
                    mtbHappiness.Enabled = false;
                    tbLocation.Enabled = false;
                    tbAttack.Enabled = false;
                    break;

                case EvolutionType.Location:
                    mtbLevel.Enabled = false;
                    cboGender.Enabled = true;
                    tbItem.Enabled = false;
                    tbPokemon.Enabled = false;
                    mtbHappiness.Enabled = false;
                    tbLocation.Enabled = true;
                    tbAttack.Enabled = false;
                    break;

                case EvolutionType.Item:
                    mtbLevel.Enabled = false;
                    cboGender.Enabled = true;
                    tbItem.Enabled = true;
                    tbPokemon.Enabled = false;
                    mtbHappiness.Enabled = false;
                    tbLocation.Enabled = false;
                    tbAttack.Enabled = false;
                    break;

                case EvolutionType.Friendship:
                    mtbLevel.Enabled = false;
                    cboGender.Enabled = true;
                    tbItem.Enabled = false;
                    tbPokemon.Enabled = false;
                    mtbHappiness.Enabled = true;
                    tbLocation.Enabled = false;
                    tbAttack.Enabled = false;
                    break;

                default:
                    mtbLevel.Enabled = false;
                    cboGender.Enabled = false;
                    tbItem.Enabled = false;
                    tbPokemon.Enabled = false;
                    mtbHappiness.Enabled = false;
                    tbLocation.Enabled = false;
                    tbAttack.Enabled = false;
                    break;
            }
        }

        void FormEvolutionCondition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            int level = -1;
            EvolutionGender gender = EvolutionGender.Both;
            int happiness = -1;

            if (mtbLevel.Enabled)
            {
                if (!int.TryParse(mtbLevel.Text, out level))
                {
                    MessageBox.Show("Level must be an float value.");
                    return;
                }
            }

            try
            {
                gender = (EvolutionGender)Enum.Parse(typeof(EvolutionGender), cboGender.SelectedItem.ToString());
            }
            catch (ArgumentException)
            {

            }

            if (mtbHappiness.Enabled)
            {
                if (!int.TryParse(mtbHappiness.Text, out happiness))
                {
                    MessageBox.Show("Happiness must be an float value.");
                    return;
                }
            }

            switch (EvolveType)
            {
                case EvolutionType.Level:
                    Condition = EvolveCondition.CreateEvolveByLevel(level, gender);
                    break;

                case EvolutionType.LevelWithItem:
                    Condition = EvolveCondition.CreateEvolveByLevelWithItem(tbItem.Text, gender);
                    break;

                case EvolutionType.LevelWithMove:
                    Condition = EvolveCondition.CreateEvolveByLevelWithAttack(tbAttack.Text, gender);
                    break;

                case EvolutionType.LevelWtihPokemon:
                    Condition = EvolveCondition.CreateEvolveByLevelWithPokemon(tbPokemon.Text, gender);
                    break;

                case EvolutionType.Location:
                    Condition = EvolveCondition.CreateEvolveByLocation(tbLocation.Text, gender);
                    break;

                case EvolutionType.Item:
                    Condition = EvolveCondition.CreateEvolveByItem(tbItem.Text, gender);
                    break;

                case EvolutionType.Friendship:
                    Condition = EvolveCondition.CreateEvolveByFriendship(happiness, gender);
                    break;

                default:
                    Condition = null;
                    break;
            }

            this.FormClosing -= FormEvolutionCondition_FormClosing;
            this.Close();
        }
    }
}
