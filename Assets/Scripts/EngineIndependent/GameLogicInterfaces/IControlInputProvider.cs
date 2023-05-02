using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;

namespace Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IControlInputProvider
    {
        SteeringDirection SteeringDirection { get; }
        bool IsAccelerating { get; }
        bool IsShootingGun { get; }
        bool IsShootingLaser { get; }
    }
}
