using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class WeaponGunHolder : WeaponHolder
    {
        public EntityHolder<IObjectFactory> BulletFactory;


        private void Awake() =>
            _weapon = new WeaponGun(AmmoProvider.Entity, ControlInput.Entity, PhysicsObject.Entity, BulletFactory.Entity);


        private void OnValidate() =>
            this.NotifyFieldNotFilled(BulletFactory, nameof(BulletFactory));
    }
}
