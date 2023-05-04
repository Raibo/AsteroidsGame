using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
#if UNITY_EDITOR
        public string LinkedAmmoDesctiption;
#endif

        public IWeapon Weapon;

        [Space(15)]
        public UserInputWrapper UserInputWrapper;
        public RigidBodyWrapper RigidBodyWrapper;
        public AmmoProviderHolder AmmoHolder;


        private void FixedUpdate() =>
            Weapon.Update();


        private void OnValidate()
        {
            this.NotifyFieldNotFilled(UserInputWrapper, nameof(UserInputWrapper));
            this.NotifyFieldNotFilled(RigidBodyWrapper, nameof(RigidBodyWrapper));
            this.NotifyFieldNotFilled(AmmoHolder, nameof(AmmoHolder));

            LinkedAmmoDesctiption = AmmoHolder == null
                ? string.Empty
                : AmmoHolder.DeveloperDescription;
        }
    }
}
