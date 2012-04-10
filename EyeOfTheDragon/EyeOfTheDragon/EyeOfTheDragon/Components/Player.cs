using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary;
using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace EyesOfTheDragon.Components
{
    public class Player
    {
        #region Field Region

        Camera camera;
        Game1 gameRef;
        readonly Character character;
        MovementType movementType;
        List<BaseItem> inventory;

        #endregion

        #region Property Region

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public AnimatedSprite Sprite
        {
            get { return character.Sprite; }
        }

        public Character Character
        {
            get { return character; }
        }

        #endregion

        #region Constructor Region

        public Player(Game game, Character character)
        {
            gameRef = (Game1)game;
            camera = new Camera(gameRef.ScreenRectangle);
            //camera.Zoom = 4f;
            movementType = MovementType.Walk;
            inventory = new List<BaseItem>();
            this.character = character;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
            Sprite.Update(gameTime);

            if (Sprite.IsAnimating == false)
            {

                if (InputHandler.KeyDown(Keys.W) ||
                    InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
                {
                    Sprite.CurrentAnimation = AnimationKey.Up;
                    Sprite.Move(Direction.Up, movementType);
                }

                else if (InputHandler.KeyDown(Keys.S) ||
                    InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
                {
                    Sprite.CurrentAnimation = AnimationKey.Down;
                    Sprite.Move(Direction.Down, movementType);
                }

                else if (InputHandler.KeyDown(Keys.A) ||
                    InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
                {
                    Sprite.CurrentAnimation = AnimationKey.Left;
                    Sprite.Move(Direction.Left, movementType);
                }

                else if (InputHandler.KeyDown(Keys.D) ||
                    InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
                {
                    Sprite.CurrentAnimation = AnimationKey.Right;
                    Sprite.Move(Direction.Right, movementType);
                }
                else if (InputHandler.KeyDown(Keys.Z) ||
                    InputHandler.ButtonDown(Buttons.A, PlayerIndex.One))
                {
                    Point interactPoint = Sprite.NextPoint();

                    BaseItem recievedItem = ObjectInteractor.TakeItem(interactPoint);
                    if (recievedItem != null)
                    {
                        inventory.Add(recievedItem);
                    }
                }
 
            }

            //if (motion != Vector2.Zero)
            //{
            //    //Sprite.IsAnimating = true;
            //    motion.Normalize();

            //    //Sprite.Position += motion * Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //    //Sprite.Position += motion;
            //    if (canMove)
            //    {
            //        if (motion.Y > 0)
            //        {
            //            Sprite.Move(Direction.Down);
            //            canMove = false;
            //            movementTimer.Enabled = true;
            //        }
            //        else if (motion.Y < 0)
            //        {
            //            Sprite.Move(Direction.Up);
            //            canMove = false;
            //            movementTimer.Enabled = true;
            //        }
            //        else if (motion.X > 0)
            //        {
            //            Sprite.Move(Direction.Right);
            //            canMove = false;
            //            movementTimer.Enabled = true;
            //        }
            //        else if (motion.X < 0)
            //        {
            //            Sprite.Move(Direction.Left);
            //            canMove = false;
            //            movementTimer.Enabled = true;
            //        }
            //    }

                //Sprite.LockToMap();
                

            if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            //else
            //{
            //    //Sprite.IsAnimating = false;
            //}

            if (InputHandler.KeyReleased(Keys.F) ||
                InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                camera.ToggleCameraMode();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }

            if (camera.CameraMode != CameraMode.Follow)
            {
                if (InputHandler.KeyReleased(Keys.C) ||
                    InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    camera.LockToSprite(Sprite);
                }
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            character.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}
