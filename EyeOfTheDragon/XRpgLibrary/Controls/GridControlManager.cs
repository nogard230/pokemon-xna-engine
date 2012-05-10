using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class GridControlManager
    {
        #region Fields and Properties

        int selectedRow = 0;
        int selectedColumn = 0;
        bool acceptInput = true;
        bool visible = true;
        List<List<Control>> controls = new List<List<Control>>();
        int count = 0;

        static SpriteFont spriteFont;

        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
        }

        public bool AcceptInput
        {
            get { return acceptInput; }
            set { acceptInput = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set
            {
                foreach (List<Control> list in controls)
                {
                    foreach (Control c in list)
                    {
                        c.Visible = value;
                    }
                }
                AcceptInput = value;
                visible = value;
            }
        }

        #endregion


        #region Event Region

        public event EventHandler FocusChanged;

        #endregion

        #region Constructors

        public GridControlManager(SpriteFont spriteFont) 
            : base() 
        {
            GridControlManager.spriteFont = spriteFont;
        }

        #endregion

        /// <summary>
        /// Gets or sets the selectedrow.
        /// </summary>
        public int SelectedRow
        {
            get { return selectedRow; }
            set 
            {
                controls[selectedRow][selectedColumn].HasFocus = false;
                selectedRow = value;
                controls[selectedRow][selectedColumn].HasFocus = true;
            }
        }

        /// <summary>
        /// Gets or sets the selectedcolumn.
        /// </summary>
        public int SelectedColumn
        {
            get { return selectedColumn; }
            set 
            {
                controls[selectedRow][selectedColumn].HasFocus = false;
                selectedColumn = value;
                controls[selectedRow][selectedColumn].HasFocus = true;
            }
        }

        #region Methods

        public bool AddBlank(int row)
        {
            if (row == controls.Count)
            {
                controls.Add(new List<Control>());
            }
            else if (row > controls.Count)
            {
                return false;
            }
            controls[row].Add(new BlankGridSpace());
            count++;
            return true;
        }

        public bool AddBlank(int row, int jumpR, int jumpC)
        {
            if (row == controls.Count)
            {
                controls.Add(new List<Control>());
            }
            else if (row > controls.Count)
            {
                return false;
            }
            controls[row].Add(new BlankGridSpace(jumpR, jumpC));
            count++;
            return true;
        }

        public bool AddControl(Control c, int row)
        {
            if (row == controls.Count)
            {
                controls.Add(new List<Control>());
            }
            else if (row > controls.Count)
            {
                return false;
            }
            controls[row].Add(c);
            count++;
            return true;
        }

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (count == 0)
                return;
            foreach (List<Control> list in controls)
            {
                foreach (Control c in list)
                {
                    if (c.Enabled)
                        c.Update(gameTime);
                }
            }

            foreach (List<Control> list in controls)
            {
                foreach (Control c in list)
                {
                    if (c.HasFocus)
                    {
                        c.HandleInput(playerIndex);
                        break;
                    }
                }
            }

            if (!AcceptInput)
                return;

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex) ||
                InputHandler.KeyPressed(Keys.Up))
                SelectAboveControl();

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex) ||
                InputHandler.KeyPressed(Keys.Down))
               SelectBelowControl();

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadLeft, playerIndex) ||
                InputHandler.KeyPressed(Keys.Left))
                SelectLeftControl();

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyPressed(Keys.Right))
                SelectRightControl();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<Control> list in controls)
            {
                foreach (Control c in list)
                {
                    if (c.Visible)
                        c.Draw(spriteBatch);
                }
            }
        }

        public void SelectAboveControl()
        {
            if (count == 0)
                return;

            int currentControl = selectedRow;

            controls[selectedRow][selectedColumn].HasFocus = false;

            do
            {
                selectedRow--;

                if (selectedRow < 0)
                    selectedRow = controls.Count - 1;
                if (controls[selectedRow].Count > selectedColumn)
                {
                    if (controls[selectedRow][selectedColumn].TabStop && controls[selectedRow][selectedColumn].Enabled)
                    {
                        if (FocusChanged != null)
                            FocusChanged(controls[selectedRow][selectedColumn], null);

                        break;
                    }
                    else if (controls[selectedRow][selectedColumn] is BlankGridSpace)
                    {
                        BlankGridSpace blank = (BlankGridSpace)controls[selectedRow][selectedColumn];
                        if (blank.JumpToR >= 0 && blank.JumpToC >= 0)
                        {
                            selectedRow = blank.JumpToR;
                            selectedColumn = blank.JumpToC;
                            if (controls[selectedRow][selectedColumn].TabStop && controls[selectedRow][selectedColumn].Enabled)
                            {
                                if (FocusChanged != null)
                                    FocusChanged(controls[selectedRow][selectedColumn], null);

                                break;
                            }
                        }
                    }
                }
                else
                {
                    int nextColumn = controls[selectedRow].Count - 1;
                    if (controls[selectedRow][nextColumn].TabStop && controls[selectedRow][nextColumn].Enabled)
                    {
                        if (FocusChanged != null)
                        {
                            FocusChanged(controls[selectedRow][selectedColumn], null);
                        }
                        selectedColumn = nextColumn;
                        break;
                    }
                }

            } while (currentControl != selectedRow);

            controls[selectedRow][selectedColumn].HasFocus = true;
        }

        public void SelectBelowControl()
        {
            if (count == 0)
                return;

            int currentControl = selectedRow;

            controls[selectedRow][selectedColumn].HasFocus = false;

            do
            {
                selectedRow++;

                if (selectedRow == controls.Count)
                    selectedRow = 0;
                if (controls[selectedRow].Count > selectedColumn)
                {
                    if (controls[selectedRow][selectedColumn].TabStop && controls[selectedRow][selectedColumn].Enabled)
                    {
                        if (FocusChanged != null)
                            FocusChanged(controls[selectedRow][selectedColumn], null);

                        break;
                    }
                }
                else
                {
                    int nextColumn = controls[selectedRow].Count - 1;
                    if (controls[selectedRow][nextColumn].TabStop && controls[selectedRow][nextColumn].Enabled)
                    {
                        if (FocusChanged != null)
                        {
                            FocusChanged(controls[selectedRow][selectedColumn], null);
                        }
                        selectedColumn = nextColumn;
                        break;
                    }
                }

            } while (currentControl != selectedRow);

            controls[selectedRow][selectedColumn].HasFocus = true;
        }

        public void SelectLeftControl()
        {
            if (controls[selectedRow].Count == 0)
                return;

            int currentControl = selectedColumn;

            controls[selectedRow][selectedColumn].HasFocus = false;

            do
            {
                selectedColumn--;

                if (selectedColumn < 0)
                {
                    selectedColumn = controls[selectedRow].Count - 1;
                }
                if (controls[selectedRow][selectedColumn].TabStop && controls[selectedRow][selectedColumn].Enabled)
                {
                    if (FocusChanged != null)
                        FocusChanged(controls[selectedRow][selectedColumn], null);

                    break;
                }


            } while (currentControl != selectedColumn);

            controls[selectedRow][selectedColumn].HasFocus = true;
        }

        public void SelectRightControl()
        {
            if (controls[selectedRow].Count == 0)
                return;

            int currentControl = selectedColumn;

            controls[selectedRow][selectedColumn].HasFocus = false;

            do
            {
                selectedColumn++;

                if (selectedColumn == controls[selectedRow].Count)
                {
                    selectedColumn = 0;
                }
                if (controls[selectedRow][selectedColumn].TabStop && controls[selectedRow][selectedColumn].Enabled)
                {
                    if (FocusChanged != null)
                        FocusChanged(controls[selectedRow][selectedColumn], null);

                    break;
                }


            } while (currentControl != selectedColumn);

            controls[selectedRow][selectedColumn].HasFocus = true;
        }

        #endregion
    }
}
