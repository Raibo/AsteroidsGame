using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class BulletInitializationHolder : InitializableHolder, IInitializable
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public float Speed;
        public override IInitializable Initializable => _initializable;

        private IInitializable _initializable;


        public void Initialize() =>
            _initializable.Initialize();


        private void Awake() =>
            _initializable = new BulletInitializer(RigidBodyWrapper, Speed);


        private void OnValidate() =>
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
    }
}
