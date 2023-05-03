using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Assets.Scripts.Wrappers;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
{
    [RequireComponent(typeof(DestroyableWrapper))]
    public class DestroyOnCollisionHolder : CollisionHandlerHolder
    {
        public DestroyableWrapper DestroyableWrapper;
        public CollisionLayers DestroyedByLayers;
        public override ICollisionHandler CollisionHandler => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        private void Awake() =>
            _collisionHandler = new DestroyOnCollisionHandler(DestroyableWrapper, DestroyedByLayers);


        private void OnValidate() =>
            DestroyableWrapper = GetComponent<DestroyableWrapper>();
    }
}
