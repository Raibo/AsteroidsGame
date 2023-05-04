using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    [RequireComponent(typeof(UserInputWrapper))]
    [RequireComponent(typeof(AmmoProviderHolder))]
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class WeaponGunHolder : MonoBehaviour
    {
#if UNITY_EDITOR
        public string LinkedAmmoDesctiption;
#endif

        private IWeapon _weapon;

        [Space(15)]
        public UserInputWrapper UserInputWrapper;
        public RigidBodyWrapper RigidBodyWrapper;
        public AmmoProviderHolder AmmoHolder;
        public ObjectFactoryWrapper BulletFactory;


        private void Awake() =>
            _weapon = new WeaponGun(AmmoHolder.AmmoProvider, UserInputWrapper, RigidBodyWrapper, BulletFactory);


        private void FixedUpdate() =>
            _weapon.Update();


        private void OnValidate()
        {
            UserInputWrapper = GetComponent<UserInputWrapper>();
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();

            this.NotifyFieldNotFilled(AmmoHolder, nameof(AmmoHolder));
            this.NotifyFieldNotFilled(BulletFactory, nameof(BulletFactory));

            LinkedAmmoDesctiption = AmmoHolder == null
                ? string.Empty
                : AmmoHolder.DeveloperDescription;
        }
    }
}
