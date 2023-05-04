using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class WeaponGunHolder : WeaponHolder
    {
        public ObjectFactoryWrapper BulletFactory;


        private void Awake() =>
            Weapon = new WeaponGun(AmmoHolder.AmmoProvider, UserInputWrapper, RigidBodyWrapper, BulletFactory);


        private void OnValidate() =>
            this.NotifyFieldNotFilled(BulletFactory, nameof(BulletFactory));
    }
}
