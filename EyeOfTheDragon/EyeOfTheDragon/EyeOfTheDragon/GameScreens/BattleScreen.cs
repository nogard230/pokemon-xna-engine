﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EyesOfTheDragon.Components;

using XRpgLibrary;
using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.WorldClasses;
using XRpgLibrary.Controls;
using XRpgLibrary.PokemonClasses;

using XRpgLibrary.BattleClasses;
using RpgLibrary.CharacterClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class BattleScreen : BaseGameState
    {
        private enum SelectedControl { Fight, Bag, Pokemon, Run, Attack1, Attack2, Attack3, Attack4, Back };
        private enum SelectedMenu { Main, Attack };

        #region Field Region

        BattleManager battleManger;

        Texture2D backgroundImage;
        Texture2D battefieldImage;
        Texture2D battleHUD;
        Texture2D attackFrame;
        Texture2D typeSymbols;
        Texture2D hpBars;
        Rectangle battleRectange;
        Texture2D pixel;

        Color fightHighlight = Color.White;
        Color bagHighlight = Color.White;
        Color pokemonHighlight = Color.White;
        Color runHighlight = Color.White;
        Color attack1Highlight = Color.White;
        Color attack2Highlight = Color.White;
        Color attack3Highlight = Color.White;
        Color attack4Highlight = Color.White;
        Color backHighlight = Color.White;

        SelectedControl selectedControl = SelectedControl.Fight;
        SelectedControl selectedAttack = SelectedControl.Attack1;
        SelectedMenu selectedMenu = SelectedMenu.Main;

        GridControlManager mainMenuManager = new GridControlManager(ControlManager.SpriteFont);
        PictureBox fight;
        PictureBox bag;
        PictureBox pokemon;
        PictureBox run;

        GridControlManager attackManager = new GridControlManager(ControlManager.SpriteFont);
        AttackControl attack1;
        AttackControl attack2;
        AttackControl attack3;
        AttackControl attack4;
        PictureBox back;

        List<GifAnimation.GifAnimation> pokemonImages;

        static double opponentHPBarScale = 3.5;
        static double myHPBarScale = 4;
        Rectangle opponentHPBar = new Rectangle(0, 100, (int)(120 * opponentHPBarScale), (int)(35 * opponentHPBarScale));
        Rectangle myHPBar = new Rectangle(1024 - 512, 350, (int)(128 * myHPBarScale), (int)(48 * myHPBarScale));
        Rectangle maleGenderSymbol = new Rectangle(68, 58, 6, 9);
        Rectangle femaleGenderSymbol = new Rectangle(76, 58, 7, 9);
        Rectangle greenHealth = new Rectangle(5, 92, 1, 3);
        Rectangle yellowHealth = new Rectangle(8, 92, 1, 3);
        Rectangle redHealth = new Rectangle(11, 92, 1, 3);
        Rectangle xpBar = new Rectangle(5, 98, 1, 3);

        #endregion

        #region Property Region


        #endregion

        #region Constructor Region

        public BattleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            battleManger = new BattleManager();
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            BattleImageLoader battleImageLoader = new BattleImageLoader(Game);

            backgroundImage = battleImageLoader.loadBattleBackground("water", "day");
            battefieldImage = battleImageLoader.loadBattlfieled("water", "day");
            battleHUD = battleImageLoader.loadHUD();
            attackFrame = battleImageLoader.loadAttackFrame();
            typeSymbols = battleImageLoader.loadTypeSymbols();
            pixel = Game.Content.Load<Texture2D>(@"Backgrounds/pixel");

            battleManger.MyPokemon = EntityDataManager.GetGenericPokemonFromData("18", 100);
            battleManger.OpponentPokemon = EntityDataManager.GetGenericPokemonFromData("22", 100);

            pokemonImages = battleImageLoader.loadPokemonImages(battleManger.MyPokemon, battleManger.OpponentPokemon);

            hpBars = battleImageLoader.loadHPBar();

            battleRectange = new Rectangle(0, 0, 1024, 576);

            fight = new PictureBox(battleHUD, new Rectangle(455, 660, 114, 26), new Rectangle(515, 185, 57, 13), Color.LightBlue);
            fight.Selected += new EventHandler(mainMenu_Selected);
            bag = new PictureBox(battleHUD, new Rectangle(0, 648, 156, 120), new Rectangle(518, 218, 78, 60), Color.LightBlue);
            bag.Selected += new EventHandler(mainMenu_Selected);
            pokemon = new PictureBox(battleHUD, new Rectangle(868, 648, 156, 120), new Rectangle(696, 220, 78, 60), Color.LightBlue);
            pokemon.Selected += new EventHandler(mainMenu_Selected);
            run = new PictureBox(battleHUD, new Rectangle(436, 713, 152, 55), new Rectangle(608, 235, 76, 44), Color.LightBlue);
            run.Selected += new EventHandler(mainMenu_Selected);

            mainMenuManager.AddBlank(0, 0, 1);
            mainMenuManager.AddControl(fight, 0);
            mainMenuManager.AddControl(bag, 1);
            mainMenuManager.AddControl(run, 1);
            mainMenuManager.AddControl(pokemon, 1);
            mainMenuManager.SelectedRow = 0;
            mainMenuManager.SelectedColumn = 1;
            

            attack1 = new AttackControl(attackFrame, new Rectangle(270, 581, 205, 90), typeSymbols, new Rectangle(240, 0, 32, 16), 
                battleManger.MyPokemon.Moveset[0].Name, battleManger.MyPokemon.Moveset[0].CurrentPP, Color.LightBlue);
            attack1.Selected += new EventHandler(attack_Selected);
            attack2 = new AttackControl(attackFrame, new Rectangle(577, 581, 205, 90), typeSymbols, new Rectangle(240, 0, 32, 16), 
                battleManger.MyPokemon.Moveset[1].Name, battleManger.MyPokemon.Moveset[1].CurrentPP, Color.LightBlue);
            attack2.Selected += new EventHandler(attack_Selected);
            attack3 = new AttackControl(attackFrame, new Rectangle(270, 674, 205, 90), typeSymbols, new Rectangle(240, 0, 32, 16), 
                battleManger.MyPokemon.Moveset[2].Name, battleManger.MyPokemon.Moveset[2].CurrentPP, Color.LightBlue);
            attack3.Selected += new EventHandler(attack_Selected);
            attack4 = new AttackControl(attackFrame, new Rectangle(577, 674, 205, 90), typeSymbols, new Rectangle(240, 0, 32, 16), 
                battleManger.MyPokemon.Moveset[3].Name, battleManger.MyPokemon.Moveset[3].CurrentPP, Color.LightBlue);
            attack4.Selected += new EventHandler(attack_Selected);

            back = new PictureBox(battleHUD, new Rectangle(868, 648, 156, 120), new Rectangle(696, 220, 78, 60), Color.LightBlue);

            attackManager.AddControl(attack1, 0);
            attackManager.AddControl(attack2, 0);
            attackManager.AddControl(attack3, 1);
            attackManager.AddControl(attack4, 1);
            attackManager.AddControl(back, 1);
            attackManager.SelectedRow = 0;
            attackManager.SelectedColumn = 0;
            attackManager.Visible = false;
            
            HighlightControl(selectedControl);
        }

        void mainMenu_Selected(object sender, EventArgs e)
        {
            if (sender == fight)
            {
                mainMenuManager.Visible = false;
                attackManager.Visible = true;
            }

            if (sender == bag)
            {

            }

            if (sender == pokemon)
            {

            }

            if (sender == run)
            {
                Transition(ChangeType.Change, GameRef.StartMenuScreen);
            }
        }

        void attack_Selected(object sender, EventArgs e)
        {
            if (sender == attack1)
            {
                battleManger.MyPokemon.Moveset[0].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                attackManager.Visible = false;
                mainMenuManager.Visible = true;
                //InputHandler.Flush();
            }

            if (sender == attack2)
            {
                battleManger.MyPokemon.Moveset[1].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                attackManager.Visible = false;
                mainMenuManager.Visible = true;
                //InputHandler.Flush();
            }

            if (sender == attack3)
            {
                battleManger.MyPokemon.Moveset[2].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                attackManager.Visible = false;
                mainMenuManager.Visible = true;
                //InputHandler.Flush();
            }

            if (sender == attack4)
            {
                battleManger.MyPokemon.Moveset[3].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                attackManager.Visible = false;
                mainMenuManager.Visible = true;
                //InputHandler.Flush();
            }

            if (sender == back)
            {
                attackManager.Visible = false;
                mainMenuManager.Visible = true;
                //InputHandler.Flush();
                //selectedMenu = SelectedMenu.Main;
                //HighlightControl(selectedControl);
            }
        }

        public override void Update(GameTime gameTime)
        {

            //UpdateControls();

            if (mainMenuManager.Visible)
            {
                mainMenuManager.Update(gameTime, playerIndexInControl);
            }
            else if (attackManager.Visible)
            {
                attackManager.Update(gameTime, playerIndexInControl);
            }

            pokemonImages[0].Update(gameTime.ElapsedGameTime.Ticks);
            pokemonImages[1].Update(gameTime.ElapsedGameTime.Ticks);

            base.Update(gameTime);
        }

        private void UpdateControls()
        {
            if (InputHandler.KeyPressed(Keys.Up))
            {
                if (selectedMenu == SelectedMenu.Main)
                {
                    if (selectedControl != SelectedControl.Fight)
                    {
                        HighlightControl(SelectedControl.Fight);
                    }
                }

                if (selectedMenu == SelectedMenu.Attack)
                {
                    if (selectedAttack == SelectedControl.Attack3)
                    {
                        HighlightControl(SelectedControl.Attack1);
                    }

                    if (selectedAttack == SelectedControl.Attack4)
                    {
                        HighlightControl(SelectedControl.Attack2);
                    }

                    if (selectedAttack == SelectedControl.Back)
                    {
                        HighlightControl(SelectedControl.Attack4);
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.Down))
            {
                if (selectedMenu == SelectedMenu.Main)
                {
                    if (selectedControl == SelectedControl.Fight)
                    {
                        HighlightControl(SelectedControl.Run);
                    }
                }

                if (selectedMenu == SelectedMenu.Attack)
                {
                    if (selectedAttack == SelectedControl.Attack1)
                    {
                        HighlightControl(SelectedControl.Attack3);
                    }

                    else if (selectedAttack == SelectedControl.Attack2)
                    {
                        HighlightControl(SelectedControl.Attack4);
                    }

                }
            }

            if (InputHandler.KeyPressed(Keys.Left))
            {
                if (selectedMenu == SelectedMenu.Main)
                {
                    if (selectedControl == SelectedControl.Pokemon)
                    {
                        HighlightControl(SelectedControl.Run);
                    }
                    else if (selectedControl == SelectedControl.Run || selectedControl == SelectedControl.Fight)
                    {
                        HighlightControl(SelectedControl.Bag);
                    }
                }

                if (selectedMenu == SelectedMenu.Attack)
                {
                    if (selectedAttack == SelectedControl.Attack2)
                    {
                        HighlightControl(SelectedControl.Attack1);
                    }

                    if (selectedAttack == SelectedControl.Attack4)
                    {
                        HighlightControl(SelectedControl.Attack3);
                    }

                    else if (selectedAttack == SelectedControl.Back)
                    {
                        HighlightControl(SelectedControl.Attack4);
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.Right))
            {
                if (selectedMenu == SelectedMenu.Main)
                {
                    if (selectedControl == SelectedControl.Bag)
                    {
                        HighlightControl(SelectedControl.Run);
                    }
                    else if (selectedControl == SelectedControl.Run || selectedControl == SelectedControl.Fight)
                    {
                        HighlightControl(SelectedControl.Pokemon);
                    }
                }

                if (selectedMenu == SelectedMenu.Attack)
                {
                    if (selectedAttack == SelectedControl.Attack1)
                    {
                        HighlightControl(SelectedControl.Attack2);
                    }

                    else if (selectedAttack == SelectedControl.Attack3)
                    {
                        HighlightControl(SelectedControl.Attack4);
                    }

                    else if (selectedAttack == SelectedControl.Attack2 || selectedAttack == SelectedControl.Attack4)
                    {
                        HighlightControl(SelectedControl.Back);
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.Enter))
            {
                if (selectedMenu == SelectedMenu.Main)
                {
                    if (selectedControl == SelectedControl.Fight)
                    {
                        selectedMenu = SelectedMenu.Attack;
                        if (selectedAttack == SelectedControl.Back)
                        {
                            selectedAttack = SelectedControl.Attack1;
                        }
                        HighlightControl(selectedAttack);
                    }

                    if (selectedControl == SelectedControl.Run)
                    {
                        Transition(ChangeType.Change, GameRef.StartMenuScreen);
                    }
                }

                else if (selectedMenu == SelectedMenu.Attack)
                {
                    if (selectedAttack == SelectedControl.Back)
                    {
                        selectedMenu = SelectedMenu.Main;
                        HighlightControl(selectedControl);
                    }

                    if (selectedAttack == SelectedControl.Attack1)
                    {
                        battleManger.MyPokemon.Moveset[0].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                        selectedMenu = SelectedMenu.Main;
                        HighlightControl(selectedControl);
                    }

                    if (selectedAttack == SelectedControl.Attack2)
                    {
                        if (battleManger.MyPokemon.Moveset.Count >= 2)
                        {
                            battleManger.MyPokemon.Moveset[1].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                            selectedMenu = SelectedMenu.Main;
                            HighlightControl(selectedControl);
                        }
                    }

                    if (selectedAttack == SelectedControl.Attack3)
                    {
                        if (battleManger.MyPokemon.Moveset.Count >= 3)
                        {
                            battleManger.MyPokemon.Moveset[2].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                            selectedMenu = SelectedMenu.Main;
                            HighlightControl(selectedControl);
                        }
                    }

                    if (selectedAttack == SelectedControl.Attack4)
                    {
                        if (battleManger.MyPokemon.Moveset.Count >= 4)
                        {
                            battleManger.MyPokemon.Moveset[3].useAttack(battleManger.MyPokemon, battleManger.OpponentPokemon);
                            selectedMenu = SelectedMenu.Main;
                            HighlightControl(selectedControl);
                        }
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            GameRef.SpriteBatch.Draw(
                backgroundImage,
                battleRectange,
                Color.White);

            GameRef.SpriteBatch.Draw(
                battefieldImage,
                battleRectange,
                Color.White);

            GameRef.SpriteBatch.Draw(
                pixel,
                new Rectangle(0, 576, 1024, 192),
                Color.Gray);


            drawMyPokemon();

            drawOpponentPokemon();

            drawHUD();

            base.Draw(gameTime);

            if (Transitioning)
            {
                FadeBackBufferTo(GameRef.SpriteBatch, Color.Black, (float)transitionTimer.Milliseconds / 750f, GameRef.ScreenRectangle);
            }

            GameRef.SpriteBatch.End();
        }

        private void drawHUD()
        {
            if (mainMenuManager.Visible)
            {
                //top
                GameRef.SpriteBatch.Draw(
                    battleHUD,
                    new Rectangle(0, 576, 1024, 96),
                    new Rectangle(91, 166, 334, 91),
                    Color.White);

                //bottom
                GameRef.SpriteBatch.Draw(
                    battleHUD,
                    new Rectangle(0, 678, 1024, 96),
                    new Rectangle(91, 257, 334, 91),
                    Color.White);

                mainMenuManager.Draw(GameRef.SpriteBatch);

                //Bag
                //GameRef.SpriteBatch.Draw(
                //    battleHUD,
                //    new Rectangle(0, 648, 156, 120),
                //    new Rectangle(518, 218, 78, 60),
                //    bagHighlight);

                //Pokemon
                //GameRef.SpriteBatch.Draw(
                //    battleHUD,
                //    new Rectangle(868, 648, 156, 120),
                //    new Rectangle(696, 220, 78, 60),
                //    pokemonHighlight);

                //Run
                //GameRef.SpriteBatch.Draw(
                //    battleHUD,
                //    new Rectangle(436, 713, 152, 55),
                //    new Rectangle(608, 235, 76, 44),
                //    runHighlight);

                //Fight
                //GameRef.SpriteBatch.Draw(
                //    battleHUD,
                //    new Rectangle(455, 660, 114, 26),
                //    new Rectangle(515, 185, 57, 13),
                //    fightHighlight);
            }

            if (attackManager.Visible)
            {
                //top
                GameRef.SpriteBatch.Draw(
                    battleHUD,
                    new Rectangle(0, 576, 1024, 34),
                    new Rectangle(142, 238, 226, 17),
                    Color.White);

                //bottom
                GameRef.SpriteBatch.Draw(
                    battleHUD,
                    new Rectangle(0, 734, 1024, 34),
                    new Rectangle(142, 256, 226, 17),
                    Color.White);

                //Attack 1
                //DrawAttack(new Rectangle(270, 581, 205, 90), 1, attack1Highlight);
                attackManager.Draw(GameRef.SpriteBatch);

                //Attack 2
                //DrawAttack(new Rectangle(577, 581, 205, 90), 2, attack2Highlight);

                //Attack 3
                //DrawAttack(new Rectangle(270, 674, 205, 90), 3, attack3Highlight);

                //Attack 4
                //DrawAttack(new Rectangle(577, 674, 205, 90), 4, attack4Highlight);

                //Back
                //GameRef.SpriteBatch.Draw(
                //battleHUD,
                //new Rectangle(868, 648, 156, 120),
                //new Rectangle(696, 220, 78, 60),
                //backHighlight);
            }
        }

        private Rectangle DrawAttack(Rectangle attackLocation, int num, Color highlight)
        {
            int attack = num - 1;
            GameRef.SpriteBatch.Draw(
                attackFrame,
                attackLocation,
                highlight);
            //new Rectangle(270, 581, 205, 90)
            if (battleManger.MyPokemon.Moveset.Count >= 1)
            {
                GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont, battleManger.MyPokemon.Moveset[attack].Name,
                    new Vector2(attackLocation.X + 15, attackLocation.Y + 4), Color.Black);

                GameRef.SpriteBatch.Draw(
                    typeSymbols,
                    new Rectangle(attackLocation.X + 20, attackLocation.Y + 44, 64, 32),
                    new Rectangle(240, 0, 32, 16),
                    highlight);

                GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont,
                    battleManger.MyPokemon.Moveset[0].Pp.CurrentValue.ToString() + "/" + battleManger.MyPokemon.Moveset[attack].Pp.MaximumValue.ToString(),
                    new Vector2(attackLocation.X + 105, attackLocation.Y + 39), Color.Black);
            }
            return attackLocation;
        }

        private void drawOpponentPokemon()
        {
            Pokemon opponentPokemon = battleManger.OpponentPokemon;
            Rectangle genderSymbol;
            double healthPercentage = battleManger.OpponentPokemon.CurrentHP.CurrentValue / (double)battleManger.OpponentPokemon.CurrentHP.MaximumValue;
            Rectangle healthColor;

            if (opponentPokemon.Gender == Gender.Female)
            {
                genderSymbol = femaleGenderSymbol;
            }
            else
            {
                genderSymbol = maleGenderSymbol;
            }

            if (healthPercentage > 0.5)
            {
                healthColor = greenHealth;
            }
            else if (healthPercentage > 0.25)
            {
                healthColor = yellowHealth;
            }
            else
            {
                healthColor = redHealth;
            }

            //Opponent Pokemon
            GameRef.SpriteBatch.Draw(pokemonImages[1].GetTexture(), new Rectangle(600, 300 - 300, 300, 300), Color.White);

            //Opponent Status Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                opponentHPBar,
                new Rectangle(0, 0, 120, 35),
                Color.White);

            //Opponent HP Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(opponentHPBar.X + 50 * opponentHPBarScale), (int)(opponentHPBar.Y + 25 * opponentHPBarScale),
                    (int)(48 * healthPercentage * opponentHPBarScale), (int)(3 * opponentHPBarScale)),
                healthColor,
                Color.White);

            //Opponent Pokemon Name
            GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont, battleManger.OpponentPokemon.Name, new Vector2((int)(opponentHPBar.X + 3 * opponentHPBarScale), (int)(opponentHPBar.Y + 9 * opponentHPBarScale)), Color.Black);

            //Opponent Pokemon Name
            GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont, battleManger.OpponentPokemon.Level.ToString(), new Vector2((int)(opponentHPBar.X + 84 * opponentHPBarScale), (int)(opponentHPBar.Y + 9 * opponentHPBarScale)), Color.Black);

            //Opponent Pokemon Gender
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(opponentHPBar.X + 62 * opponentHPBarScale), (int)(opponentHPBar.Y + 8 * opponentHPBarScale),
                    (int)(7 * myHPBarScale), (int)(9 * myHPBarScale)),
                genderSymbol,
                Color.White);
        }

        private void drawMyPokemon()
        {
            Pokemon myPokemon = battleManger.MyPokemon;
            Rectangle genderSymbol;
            int maxHealth = battleManger.MyPokemon.CurrentHP.MaximumValue;
            int currentHealth = battleManger.MyPokemon.CurrentHP.CurrentValue;
            double healthPercentage = battleManger.MyPokemon.CurrentHP.CurrentValue / (double) battleManger.MyPokemon.CurrentHP.MaximumValue;
            Rectangle healthColor;

            if (myPokemon.Gender == Gender.Female)
            {
                genderSymbol = femaleGenderSymbol;
            }
            else
            {
                genderSymbol = maleGenderSymbol;
            }

            if (healthPercentage > 0.5)
            {
                healthColor = greenHealth;
            }
            else if (healthPercentage > 0.25)
            {
                healthColor = yellowHealth;
            }
            else
            {
                healthColor = redHealth;
            }

            //My Pokemon
            GameRef.SpriteBatch.Draw(pokemonImages[0].GetTexture(), new Rectangle(150, 605 - 300, 300, 300), Color.White);

            //My Status Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                myHPBar,
                new Rectangle(128, 0, 128, 48),
                Color.White);

            //My HP Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(myHPBar.X + 73 * myHPBarScale), (int)(myHPBar.Y + 27 * myHPBarScale),
                    (int)(48 * healthPercentage * myHPBarScale), (int)(3 * myHPBarScale)),
                healthColor,
                Color.White);

            //My Pokemon Name
            GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont, battleManger.MyPokemon.Name, new Vector2((int)(myHPBar.X + 22 * myHPBarScale), (int)(myHPBar.Y + 12 * myHPBarScale)), Color.Black);

            //My Pokemon Level
            GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont, battleManger.MyPokemon.Level.ToString(), new Vector2((int)(myHPBar.X + 107 * myHPBarScale), (int)(myHPBar.Y + 12 * myHPBarScale)), Color.Black);

            //My Pokemon Current HP
            GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont, currentHealth.ToString(), new Vector2((int)(myHPBar.X + 73 * myHPBarScale), (int)(myHPBar.Y + 32 * myHPBarScale)), Color.Black);

            //My Pokemon Totl HP
            GameRef.SpriteBatch.DrawString(ControlManager.SpriteFont, maxHealth.ToString(), new Vector2((int)(myHPBar.X + 100 * myHPBarScale), (int)(myHPBar.Y + 32 * myHPBarScale)), Color.Black);

            //My Pokemon Gender
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(myHPBar.X + 88 * myHPBarScale), (int)(myHPBar.Y + 12 * myHPBarScale),
                    (int)(6 * myHPBarScale), (int)(9 * myHPBarScale)),
                genderSymbol,
                Color.White);

            //My Pokemon XP Bar
            GameRef.SpriteBatch.Draw(
                hpBars,
                new Rectangle((int)(myHPBar.X + 25 * myHPBarScale), (int)(myHPBar.Y + 44 * myHPBarScale),
                    (int)(96 * myHPBarScale), (int)(2 * myHPBarScale)),
                xpBar,
                Color.White);
        }

        private void HighlightControl(SelectedControl selected)
        {
            fightHighlight = Color.White;
            bagHighlight = Color.White;
            pokemonHighlight = Color.White;
            runHighlight = Color.White;
            attack1Highlight = Color.White;
            attack2Highlight = Color.White;
            attack3Highlight = Color.White;
            attack4Highlight = Color.White;
            backHighlight = Color.White;
            switch (selected)
            {
                case SelectedControl.Fight:
                    fightHighlight = Color.LightBlue;
                    selectedControl = SelectedControl.Fight;
                    break;

                case SelectedControl.Bag:
                    bagHighlight = Color.LightBlue;
                    selectedControl = SelectedControl.Bag;
                    break;

                case SelectedControl.Pokemon:
                    pokemonHighlight = Color.LightBlue;
                    selectedControl = SelectedControl.Pokemon;
                    break;

                case SelectedControl.Run:
                    runHighlight = Color.LightBlue;
                    selectedControl = SelectedControl.Run;
                    break;

                case SelectedControl.Attack1:
                    attack1Highlight = Color.LightBlue;
                    selectedAttack = SelectedControl.Attack1;
                    break;

                case SelectedControl.Attack2:
                    attack2Highlight = Color.LightBlue;
                    selectedAttack = SelectedControl.Attack2;
                    break;

                case SelectedControl.Attack3:
                    attack3Highlight = Color.LightBlue;
                    selectedAttack = SelectedControl.Attack3;
                    break;

                case SelectedControl.Attack4:
                    attack4Highlight = Color.LightBlue;
                    selectedAttack = SelectedControl.Attack4;
                    break;

                case SelectedControl.Back:
                    backHighlight = Color.LightBlue;
                    selectedAttack = SelectedControl.Back;
                    break;
            }
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
