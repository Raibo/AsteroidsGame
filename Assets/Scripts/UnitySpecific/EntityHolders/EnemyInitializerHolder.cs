using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Assets.Scripts.EntityHolders;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders
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
