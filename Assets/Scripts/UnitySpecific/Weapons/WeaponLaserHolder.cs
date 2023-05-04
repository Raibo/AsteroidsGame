using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class WeaponLaserHolder : WeaponHolder
    {
        public EntityHolder<ILaserColliderProvider> LaserColliderProvider;
        public float LaserWidth;


        private void Awake()
        {
            _weapon = new WeaponLaser(AmmoProvider.Entity, ControlInput.Entity, PhysicsObject.Entity,
                LaserColliderProvider.Entity, LaserWidth);
        }


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref LaserColliderProvider);
            this.NotifyFieldNotFilled(LaserColliderProvider, nameof(LaserColliderProvider));
        }
    }
}
