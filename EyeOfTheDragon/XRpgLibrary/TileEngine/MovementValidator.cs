using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using XRpgLibrary.WorldClasses;
using XRpgLibrary.ItemClasses;
using XRpgLibrary.CharacterClasses;

namespace XRpgLibrary.TileEngine
{
    public class MovementValidator
    {
        static TileMap map;
        static Level level;
        
        #region Constructors

        public MovementValidator(Level currentLevel)
        {
            MovementValidator.level = currentLevel;
            MovementValidator.map = currentLevel.Map;
        }

        #endregion

        public static void SetLevel(Level newLevel)
        {
            MovementValidator.level = newLevel;
            MovementValidator.map = newLevel.Map;
        }

        public static bool CanMove(Point current, Point next, XRpgLibrary.CharacterClasses.MovementType movementType)
        {
            bool canMove = true;
            if (next.X < 0 || next.Y < 0 || next.X >= TileMap.WidthInTiles || next.Y >= TileMap.HeightInTiles)
            {
                return false;
            }

            MoveType tileType = map.TileMoveType(next);

            if (tileType == MoveType.Normal)
            {
                canMove = true;
            }
            else if (tileType == MoveType.Grass)
            {
                canMove = true;
            }
            else if (tileType == MoveType.Blocked)
            {
                canMove = false;
            }
            else if (tileType == MoveType.Warp)
            {
                canMove = true;
            }
            else if (tileType == MoveType.Surf)
            {
                if (movementType == XRpgLibrary.CharacterClasses.MovementType.Surf)
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }
            else if (tileType == MoveType.Waterfall)
            {
                if (movementType == XRpgLibrary.CharacterClasses.MovementType.Waterfall)
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }
            else if (tileType == MoveType.Wirlpool)
            {
                if (movementType == XRpgLibrary.CharacterClasses.MovementType.Whirlpool)
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            foreach (ItemSprite item in level.Items)
            {
                if(Engine.VectorToCell(item.Sprite.Position).Equals(next))
                {
                    canMove = false;
                }
            }

            foreach (Character character in level.Characters)
            {
                if (Engine.VectorToCell(character.Sprite.Position).Equals(next))
                {
                    canMove = false;
                }
            }

            return canMove;
        }
    }
}
