using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics.Collisions
{
    public class CircleCastWrapper : EntityHolder<ILaserColliderProvider>, ILaserColliderProvider
    {
        public LayerMask Layer;
        public float CastDistance;

        [Range(1, 100)]
        [Tooltip("This is how big hit buffer array will be and how many targets can be hit in one frame")]
        public int HitBufferCapacity;

        public override ILaserColliderProvider Entity => this;

        private RaycastHit2D[] _raycastBuffer;


        private void Awake() =>
            _raycastBuffer = new RaycastHit2D[HitBufferCapacity];


        public int GetHitObjects(AsteroidsVector2 origin, AsteroidsVector2 direction, float width, ICollidable[] buffer)
        {
            var hitCount = Physics2D.CircleCastNonAlloc(origin.ToUnityVector2(), width, direction.ToUnityVector2(),
                _raycastBuffer, CastDistance, Layer);

            var resultBufferIndex = 0;

            for (int raycastBufferIndex = 0; raycastBufferIndex < hitCount; raycastBufferIndex++)
            {
                if (_raycastBuffer[raycastBufferIndex].transform.TryGetComponent<ICollidable>(out var collidable))
                {
                    buffer[resultBufferIndex] = collidable;
                    resultBufferIndex++;
                }

                if (resultBufferIndex >= buffer.Length)
                    break;
            }

            return resultBufferIndex;
        }
    }
}
