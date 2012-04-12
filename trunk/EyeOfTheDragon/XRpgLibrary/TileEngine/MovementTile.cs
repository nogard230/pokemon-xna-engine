using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using XRpgLibrary.WorldClasses;
using XRpgLibrary.SpriteClasses;

namespace XRpgLibrary.TileEngine
{
    public enum MoveType {Normal, Grass, Surf, Waterfall, Wirlpool, Dive, Blocked, Warp, Drop_North, Drop_South, Drop_East, Drop_West};

    public class MovementTile
    {
        #region Field Region

        MoveType tileType;
        Point warpToPoint;
        Level warpToLevel;
        Direction warpToDirection;

        #endregion

        #region Property Region

        public MoveType TileType
        {
            get { return tileType; }
            private set { tileType = value; }
        }

        #endregion

        #region Constructor Region

        public MovementTile(MoveType type)
        {
            TileType = type;
        }

        #endregion
    }
}
