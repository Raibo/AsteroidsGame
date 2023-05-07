using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics.Collisions
{
    public class ColliderWrapper : EntityHolder<ICollidable>, ICollidable
    {
        public Collider2D Collider;
        public EntityHolder<ICollisionHandler> CollisionHandler;
        public CollisionLayers CollisionLayers;

        public override ICollidable Entity => this;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            var otherObject = collision.gameObject;

            if (otherObject.TryGetComponent<ICollidable>(out var collidable))
                collidable.CollideWith(CollisionLayers);
        }


        public void CollideWith(CollisionLayers collisionLayer) =>
            CollisionHandler.Entity.HandleCollision(collisionLayer);


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            Collider = GetComponent<Collider2D>();
            this.AssignIfEmpty(ref CollisionHandler);
            this.NotifyFieldNotFilled(CollisionHandler, nameof(CollisionHandler));
        }
    }
}
