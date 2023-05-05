using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.RandomProviders;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation
{
    public class EnemyInitializer : IInitializable
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly IRandomProvider _randomProvider;
        private readonly float _minimumSpeed;
        private readonly float _maximumSpeed;
        private readonly float _minimumRotation;
        private readonly float _maximumRotation;


        public EnemyInitializer(IPhysicsObject physicsObject, IRandomProvider randomProvider, float minimumSpeed, float maximumSpeed,
            float minimumRotation, float maximumRotation)
        {
            _physicsObject = physicsObject;
            _randomProvider = randomProvider;
            _minimumSpeed = minimumSpeed;
            _maximumSpeed = maximumSpeed;
            _minimumRotation = minimumRotation;
            _maximumRotation = maximumRotation;
        }


        public void Initialize()
        {
            _physicsObject.Rotation = GetRandomRotation();
            _physicsObject.PushForward(GetRandomSpeed());
        }


        private float GetRandomSpeed() =>
            _randomProvider.Next(_minimumSpeed, _maximumSpeed);


        private float GetRandomRotation() =>
            _randomProvider.Next(_minimumRotation, _maximumRotation);
    }
}
