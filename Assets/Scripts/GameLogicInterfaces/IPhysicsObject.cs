using Hudossay.Asteroids.Assets.Scripts.DataStructs;

namespace Hudossay.Asteroids.Assets.Scripts.GameLogicInterfaces
{
    public interface IPhysicsObject
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Velocity { get; }

        public void PushForward(float additionalSpeed);
    }
}
