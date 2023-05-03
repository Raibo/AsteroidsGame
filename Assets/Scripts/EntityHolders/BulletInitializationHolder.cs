using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class BulletInitializationHolder : InitializableHolder
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public float Speed;
        public override IInitializable Initializable => _initializable;

        private IInitializable _initializable;


        private void Awake() =>
            _initializable = new BulletInitializator(RigidBodyWrapper, Speed);


        private void OnValidate() =>
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
    }
}
