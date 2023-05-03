using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EntityHolders;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Assets.Scripts.Wrappers
{
    [RequireComponent(typeof(CollisionHandlerHolder))]
    public class ColliderWrapper : MonoBehaviour, ICollidable
    {
        public Collider Collider;
        public CollisionHandlerHolder CollisionHandlerHolder;
        public CollisionLayers CollisionLayers;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            var otherObject = collision.gameObject;

            if (otherObject.TryGetComponent<ICollidable>(out var collidable))
                collidable.CollideWith(CollisionLayers);
        }


        public void CollideWith(CollisionLayers collisionLayer) =>
            CollisionHandlerHolder.CollisionHandler.HandleCollision(collisionLayer);


        private void OnValidate()
        {
            Collider = GetComponent<Collider>();
            CollisionHandlerHolder = GetComponent<CollisionHandlerHolder>();
        }
    }
}
