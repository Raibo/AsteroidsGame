using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
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
