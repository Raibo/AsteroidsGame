using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class BulletInitializator : IInitializable
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly float _speed;


        public BulletInitializator(IPhysicsObject physicsObject, float speed)
        {
            _physicsObject = physicsObject;
            _speed = speed;
        }


        public void Initialise() =>
            _physicsObject.PushForward(_speed);
    }
}
