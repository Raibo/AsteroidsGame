using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Collisions
{
    [RequireComponent(typeof(CollisionHandlerHolder))]
    public class ColliderWrapper : MonoBehaviour, ICollidable
    {
        public Collider2D Collider;
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
            Collider = GetComponent<Collider2D>();
            CollisionHandlerHolder = GetComponent<CollisionHandlerHolder>();
        }
    }
}
