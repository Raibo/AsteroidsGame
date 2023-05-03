using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.Extensions;
using Assets.Scripts.Wrappers;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
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
