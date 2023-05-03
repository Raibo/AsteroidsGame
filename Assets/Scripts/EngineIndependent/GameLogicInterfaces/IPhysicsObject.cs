using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;

namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IPhysicsObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; }
        public float Rotation { get; set; }
        public Vector2 Velocity { get; set; }

        public void PushForward(float additionalSpeed);
        public void EnforceSpeedLimit(float maxSpeed);
    }
}
