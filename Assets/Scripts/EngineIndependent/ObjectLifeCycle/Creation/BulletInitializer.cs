using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation
{
    public class BulletInitializer : IInitializable
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly float _speed;


        public BulletInitializer(IPhysicsObject physicsObject, float speed)
        {
            _physicsObject = physicsObject;
            _speed = speed;
        }


        public void Initialize() =>
            _physicsObject.PushForward(_speed);
    }
}
