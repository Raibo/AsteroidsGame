using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation
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
