using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class EnemyInitializerHolder : InitializableHolder, IInitializable
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public float MinimumSpeed;
        public float MaximumSpeed;
        public float MinimumRotation;
        public float MaximumRotation;
        public override IInitializable Initializable => _initializable;

        private IInitializable _initializable;


        public void Initialize() =>
            _initializable.Initialize();


        private void Awake()
        {
            _initializable = new EnemyInitializer(RigidBodyWrapper, new SystemRandomProvider(), MinimumSpeed, MaximumSpeed,
                MinimumRotation, MaximumRotation);
        }


        private void OnValidate() =>
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
    }
}
