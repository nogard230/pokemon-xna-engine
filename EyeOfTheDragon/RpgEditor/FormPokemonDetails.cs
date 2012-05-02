using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XRpgLibrary.PokemonClasses;
using XRpgLibrary;
using XRpgLibrary.AttackClasses;
using XRpgLibrary.AbilityClasses;
using XRpgLibrary.NatureClasses;
using XRpgLibrary.ItemClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormPokemonDetails : Form
    {
        #region Field Region

        PokemonData pokemon;

        #endregion

        #region Property Region

        public PokemonData Pokemon
        {
            get { return pokemon; }
            set { pokemon = value; }
        }

        #endregion

        public FormPokemonDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormPokemonDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormPokemonDetails_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #region Event Handler Region

        void FormPokemonDetails_Load(object sender, EventArgs e)
        {
            foreach (ElementType element in Enum.GetValues(typeof(ElementType)))
            {
                cboPType.Items.Add(element);
                cboSType.Items.Add(element);
            }

            foreach (EXPRate rate in Enum.GetValues(typeof(EXPRate)))
            {
                cboExpGrowth.Items.Add(rate);
            }
            cboSType.SelectedIndex = cboSType.Items.Count - 1;

            cboExpGrowth.SelectedIndex = 0;
            cboPType.SelectedIndex = 0;
            cboSType.SelectedIndex = 0;

            if (pokemon != null)
            {
                tbName.Text = pokemon.Name;
                tbUniqueID.Text = pokemon.UniqueID;
                cboPType.SelectedItem = pokemon.Type1;
                cboSType.SelectedItem = pokemon.Type2;
                mtbBaseHP.Text = pokemon.BaseHP.ToString();
                mtbBaseAttack.Text = pokemon.BaseAttack.ToString();
                mtbBaseDefense.Text = pokemon.BaseDefense.ToString();
                mtbBaseSAttack.Text = pokemon.BaseSAttack.ToString();
                mtbBaseSDefense.Text = pokemon.BaseSDefense.ToString();
                mtbBaseSpeed.Text = pokemon.BaseSpeed.ToString();

                tbMaleImage.Text = pokemon.ImageMale;
                tbFemaleImage.Text = pokemon.ImageFemale;

                tbEggGroup.Text = pokemon.EggGroup;
                mtbCaptureRate.Text = pokemon.CaputreRate.ToString();
                mtbBaseEggSteps.Text = pokemon.BaseEggSteps.ToString();
                mtbBaseHappiness.Text = pokemon.BaseHappiness.ToString();
                cboExpGrowth.SelectedItem = pokemon.XPGrowth;

                mtbPokedexNum.Text = pokemon.PokedexNum.ToString();
                tbPokedexClassification.Text = pokemon.PokedexClassification;
                mtbHeight.Text = (pokemon.HeightFeet * 12 + pokemon.HeightInches).ToString();
                mtbWeight.Text = pokemon.Weight.ToString();
                tbPokedexEntry.Text = pokemon.PokedexEntry;
            }
        }

        void FormPokemonDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            pokemon = new PokemonData();

            string name;
            int level;
            Gender gender;
            int happiness;
            GameItem holdItem;
            ElementType type1;
            ElementType type2;
            Nature nature;
            Ability ability;
            Dictionary<int, Attack> levelUpMoves;
            List<Attack> eggMoves;
            List<Attack> tutoredMoves;
            List<string> learnableTMs;
            List<Attack> moveset;

            int baseHP;
            int baseAttack;
            int baseDefense;
            int baseSAttack;
            int baseSDefense;
            int baseSpeed;

            int hpIV;
            int attackIV;
            int defenseIV;
            int sAttackIV;
            int sDefenseIV;
            int speedIV;

            List<Pokemon> evolveTo;
            Pokemon evolveFrom;
            EvolveCondition evolveCondition;

            string eggGroup;

            int pokedexNum;
            string pokedexClassification;
            string pokedexEntry;
            int heightFeet;
            int heightInches;
            float weight;
            int caputreRate;
            int baseEggSteps;
            int baseHappiness;
            EXPRate xpGrowth;
            int fleeFlag;

            string imageMale;
            string imageFemale;

            float genderRatioMale;
            float genderRatioFemale;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the Pokemon.");
                return;
            }

            if (string.IsNullOrEmpty(tbUniqueID.Text))
            {
                MessageBox.Show("You must enter a unique ID for the Pokemon.");
                return;
            }

            try
            {
                type1 = (ElementType)Enum.Parse(typeof(ElementType), cboPType.SelectedItem.ToString());
                pokemon.Type1 = type1;
            }
            catch (ArgumentException)
            {

            }

            if (cboSType.SelectedIndex != 0)
            {
                try
                {
                    type2 = (ElementType)Enum.Parse(typeof(ElementType), cboSType.SelectedItem.ToString());
                    pokemon.Type2 = type2;
                }
                catch (ArgumentException)
                {

                }
            }

            if (!int.TryParse(mtbBaseHP.Text, out baseHP))
            {
                MessageBox.Show("Base HP must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbBaseAttack.Text, out baseAttack))
            {
                MessageBox.Show("Base Attack must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbBaseDefense.Text, out baseDefense))
            {
                MessageBox.Show("Base Defense must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbBaseSAttack.Text, out baseSAttack))
            {
                MessageBox.Show("Base Special Attack must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbBaseSDefense.Text, out baseSDefense))
            {
                MessageBox.Show("Base Special Defense must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbBaseSpeed.Text, out baseSpeed))
            {
                MessageBox.Show("Base Speed must be an integer value.");
                return;
            }

            if (string.IsNullOrEmpty(tbMaleImage.Text))
            {
                MessageBox.Show("You must enter a image for the Pokemon.");
                return;
            }

            if (!int.TryParse(mtbCaptureRate.Text, out caputreRate))
            {
                MessageBox.Show("Capture Rate must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbBaseEggSteps.Text, out baseEggSteps))
            {
                MessageBox.Show("Base Egg Steps must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbBaseHappiness.Text, out baseHappiness))
            {
                MessageBox.Show("Base Happiness must be an integer value.");
                return;
            }

            try
            {
                xpGrowth = (EXPRate)Enum.Parse(typeof(EXPRate), cboExpGrowth.SelectedItem.ToString());
                pokemon.XPGrowth = xpGrowth;
            }
            catch (ArgumentException)
            {

            }

            if (!int.TryParse(mtbPokedexNum.Text, out pokedexNum))
            {
                MessageBox.Show("Pokedex Number must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbHeight.Text, out heightFeet))
            {
                MessageBox.Show("Height must be an integer value.");
                return;
            }

            if (!float.TryParse(mtbWeight.Text, out weight))
            {
                MessageBox.Show("Weight must be an float value.");
                return;
            }

            
            pokemon.Name = tbName.Text;
            pokemon.UniqueID = tbUniqueID.Text;
            
            pokemon.BaseHP = baseHP;
            pokemon.BaseAttack = baseAttack;
            pokemon.BaseDefense = baseDefense;
            pokemon.BaseSAttack = baseSAttack;
            pokemon.BaseSDefense = baseSDefense;
            pokemon.BaseSpeed = baseSpeed;
            pokemon.ImageMale = tbMaleImage.Text;
            pokemon.ImageFemale = tbFemaleImage.Text;

            pokemon.EggGroup = tbEggGroup.Text;
            pokemon.CaputreRate = caputreRate;
            pokemon.BaseEggSteps = baseEggSteps;
            pokemon.BaseHappiness = baseHappiness;

            pokemon.PokedexNum = pokedexNum;
            pokemon.PokedexClassification = tbPokedexClassification.Text;
            pokemon.HeightFeet = heightFeet / 12;
            pokemon.HeightInches = heightFeet % 12;
            pokemon.Weight = weight;
            pokemon.PokedexEntry = tbPokedexEntry.Text;

            this.FormClosing -= FormPokemonDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            pokemon = null;
            this.FormClosing -= FormPokemonDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
