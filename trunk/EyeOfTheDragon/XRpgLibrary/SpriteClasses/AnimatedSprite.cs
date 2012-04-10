using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.TileEngine;

using XRpgLibrary.CharacterClasses;

namespace XRpgLibrary.SpriteClasses
{

    public enum Direction {Up, Down, Left, Right};

    public class AnimatedSprite
    {
        #region Field Region

        Dictionary<AnimationKey, Animation> animations;
        AnimationKey currentAnimation;
        bool isAnimating;
        bool isTurning;
        Direction movementDirection;

        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        float speed = 200.0f;
        Timer animationTimer;
        Timer turningTimer;

        float previousX;
        float previousY;

        #endregion

        #region Property Region

        public Direction DirectionFacing
        {
            get { return movementDirection; }
            set { movementDirection = value; }
        }

        public AnimationKey CurrentAnimation
        {
            get { return currentAnimation; }
            set { currentAnimation = value; }
        }

        public bool IsAnimating
        {
            get { return isAnimating; }
            set { isAnimating = value; }
        }

        public int Width
        {
            get { return animations[currentAnimation].FrameWidth; }
        }

        public int Height
        {
            get { return animations[currentAnimation].FrameHeight; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(speed, 1.0f, 400.0f); }
        }

        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                    velocity.Normalize();
            }
        }

        #endregion

        #region Constructor Region

        public AnimatedSprite(Texture2D sprite, Dictionary<AnimationKey, Animation> animation)
        {
            texture = sprite;
            animations = new Dictionary<AnimationKey, Animation>();
            animationTimer = new Timer(6.25);
            animationTimer.Elapsed += new ElapsedEventHandler(AnimationUpdate);
            animationTimer.Enabled = false;

            turningTimer = new Timer(100);
            turningTimer.Elapsed += new ElapsedEventHandler(TurnElapsed);
            turningTimer.Enabled = false;

            foreach (AnimationKey key in animation.Keys)
                animations.Add(key, (Animation)animation[key].Clone());
        }

        #endregion

        #region Method Region

        public bool CanMoveTo()
        {
            bool canMove = false;
            if (movementDirection == Direction.Up)
            {
                if (position.Y - 32 >= 0)
                {
                    canMove = true;
                }
            }
            else if (movementDirection == Direction.Down)
            {
                if (position.Y + 32 < TileMap.HeightInPixels)
                {
                    canMove = true;
                }
            }
            else if (movementDirection == Direction.Left)
            {
                if (position.X - 32 >= 0)
                {
                    canMove = true;
                }
            }
            else if (movementDirection == Direction.Right)
            {
                if (position.X + 32 < TileMap.WidthInPixels)
                {
                    canMove = true;
                }
            }
            


            return canMove;
        }

        public void AnimationUpdate(object sender, ElapsedEventArgs e)
        {
            if (!isTurning && isAnimating)
            {
                if (movementDirection == Direction.Up)
                    position.Y -= 2;
                else if (movementDirection == Direction.Down)
                    position.Y += 2;
                else if (movementDirection == Direction.Left)
                    position.X -= 2;
                else if (movementDirection == Direction.Right)
                    position.X += 2;
                LockToMap();

                if( Math.Abs(position.X - previousX) >= 32 || Math.Abs(position.Y - previousY) >= 32 ||
                    (position.X == previousX && position.Y == previousY))
                {
                    animationTimer.Enabled = false;
                    isAnimating = false;
                }

            }
        }

        public void TurnElapsed(object sender, ElapsedEventArgs e)
        {
            isTurning = false;
            turningTimer.Enabled = false;
        }

        public void Update(GameTime gameTime)
        {
            if (isAnimating)
                animations[currentAnimation].Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                position,
                animations[currentAnimation].CurrentFrameRect,
                Color.White);
        }

        public void Move(Direction direction, MovementType movementType)
        {
            if (movementDirection != direction)
            {
                movementDirection = direction;
                isTurning = true;
                turningTimer.Enabled = true;
                return;
            }
            else if (!isTurning)
            {

                previousX = position.X;
                previousY = position.Y;

                Point current = Engine.VectorToCell(position);
                Point next = NextPoint();

                if (!next.Equals(current) && MovementValidator.CanMove(current, next, movementType))
                {
                    isAnimating = true;
                    animationTimer.Enabled = true;
                }
            }
        }

        public void LockToMap()
        {
            position.X = MathHelper.Clamp(position.X, 0, TileMap.WidthInPixels - Width);
            position.Y = MathHelper.Clamp(position.Y, 0, TileMap.HeightInPixels - Height);
        }

        public Point NextPoint()
        {
            Point current = Engine.VectorToCell(position);
            Point next;

            switch (movementDirection)
            {
                case Direction.Up:
                    next = new Point(current.X, current.Y - 1);
                    break;
                case Direction.Down:
                    next = new Point(current.X, current.Y + 1);
                    break;
                case Direction.Left:
                    next = new Point(current.X - 1, current.Y);
                    break;
                case Direction.Right:
                    next = new Point(current.X + 1, current.Y);
                    break;
                default:
                    next = current;
                    break;
            }

            return next;
        }

        #endregion
    }
}
