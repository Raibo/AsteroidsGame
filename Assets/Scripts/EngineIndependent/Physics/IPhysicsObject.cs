namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics
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
