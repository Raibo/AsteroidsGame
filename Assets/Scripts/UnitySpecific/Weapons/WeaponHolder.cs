using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class WeaponHolder : EntityHolder<IWeapon>
    {
#if UNITY_EDITOR
        public string LinkedAmmoDesctiption;
#endif

        public override IWeapon Entity => _weapon;

        [Space(15)]
        public EntityHolder<IControlInputProvider> ControlInput;
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public EntityHolder<IAmmoProvider> AmmoProvider;

        protected IWeapon _weapon;


        private void FixedUpdate() =>
            _weapon.Update();


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref ControlInput);
            this.AssignIfEmpty(ref PhysicsObject);
            this.AssignIfEmpty(ref AmmoProvider);

            this.NotifyFieldNotFilled(ControlInput, nameof(ControlInput));
            this.NotifyFieldNotFilled(PhysicsObject, nameof(PhysicsObject));
            this.NotifyFieldNotFilled(AmmoProvider, nameof(AmmoProvider));

#if UNITY_EDITOR
            if (AmmoProvider is AmmoProviderHolder ammoProviderHolder)
            {
                LinkedAmmoDesctiption = AmmoProvider == null
                    ? string.Empty
                    : ammoProviderHolder.DeveloperDescription;
            }
#endif
        }
    }
}
