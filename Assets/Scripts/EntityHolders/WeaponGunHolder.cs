using Assets.Scripts.EngineIndependent.GameEntities;
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

        public IWeapon Weapon;

        [Space(15)]
        public UserInputWrapper UserInputWrapper;
        public RigidBodyWrapper RigidBodyWrapper;
        public AmmoProviderHolder AmmoHolder;


        private void Awake() =>
            Weapon = new WeaponGun(AmmoHolder.AmmoProvider, UserInputWrapper, RigidBodyWrapper, null);


        private void OnValidate()
        {
            UserInputWrapper = GetComponent<UserInputWrapper>();
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();

            if (AmmoHolder == null)
            {
                Debug.LogWarning($"Component {nameof(WeaponGunHolder)} of GameObject {gameObject.name} need value for its {nameof(AmmoHolder)}");
                LinkedAmmoDesctiption = string.Empty;
            }
            else
            {
                LinkedAmmoDesctiption = AmmoHolder.DeveloperDescription;
            }
        }
    }
}
