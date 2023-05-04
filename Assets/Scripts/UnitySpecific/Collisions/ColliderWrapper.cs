using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Collisions
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
