namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation
{
    public interface IControlInputProvider
    {
        SteeringDirection SteeringDirection { get; }
        bool IsAccelerating { get; }
        bool IsShootingGun { get; }
        bool IsShootingLaser { get; }
    }
}
