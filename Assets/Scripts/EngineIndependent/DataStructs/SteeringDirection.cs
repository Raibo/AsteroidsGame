using System;

namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs
{
    [Flags]
    public enum SteeringDirection
    {
        None = 0,
        Left = 1 << 0,
        Right = 1 << 1,

        All = ~(~0 << 2),
    }
}
