using System;

namespace Assets.Scripts.EngineIndependent.DataStructs
{
    [Flags]
    public enum CollisionLayer
    {
        None = 0,
        PlayerShip = 1 << 0,
        Bullet = 1 << 1,
        Laser = 1 << 2,
        Enemy = 1 << 3,

        All = ~(~0 << 4),
    }
}
