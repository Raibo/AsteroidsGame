using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class WeaponLaserHolder : WeaponHolder
    {
        public EntityHolder<ILaserColliderProvider> LaserColliderProvider;
        public float LaserWidth;
        public float ChannelingTime;

        [Range(1, 100)]
        [Tooltip("This is how big hit buffer array will be and how many targets can be hit in one frame")]
        public int HitBufferCapacity;


        private void Awake()
        {
            _weapon = new WeaponLaser(AmmoProvider.Entity, ControlInput.Entity, PhysicsObject.Entity,
                LaserColliderProvider.Entity, new Timer(), LaserWidth, ChannelingTime, HitBufferCapacity);
        }


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref LaserColliderProvider);
            this.NotifyFieldNotFilled(LaserColliderProvider, nameof(LaserColliderProvider));
        }
    }
}
