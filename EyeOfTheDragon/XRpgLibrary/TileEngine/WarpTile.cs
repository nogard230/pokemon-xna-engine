using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using XRpgLibrary.WorldClasses;
using XRpgLibrary.SpriteClasses;

namespace XRpgLibrary.TileEngine
{
    public class WarpTile : MovementTile
    {
        #region Field Region

        Point warpToPoint;
        String warpToLevel;
        Direction warpToDirection;

        #endregion

        #region Property Region

        public Point WarpToPoint
        {
            get { return warpToPoint; }
            private set { warpToPoint = value; }
        }

        public String WarpToLevel
        {
            get { return warpToLevel; }
            private set { warpToLevel = value; }
        }

        public Direction WarpToDirection
        {
            get { return warpToDirection; }
            private set { warpToDirection = value; }
        }

        #endregion

        #region Constructor Region

        public WarpTile(Point point, String level, Direction direction)
            : base(MoveType.Warp)
        {
            WarpToPoint = point;

            if (level != null)
            {
                WarpToLevel = level;
            }

            if (direction != null)
            {
                WarpToDirection = direction;
            }
        }

        #endregion
    }
}
