using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class AmmoProviderHolder : EntityHolder<IAmmoProvider>
    {
#if UNITY_EDITOR
        public string DeveloperDescription;
#endif

        public override IAmmoProvider Entity => GetAmmoProvider();

        [Space(15)]
        public int MaximumCharges;
        public int InitialCharges;

        public float CooldownTime;
        public float GainChargeTime;

        private IAmmoProvider _ammoProvider;


        private void Awake() =>
            GetAmmoProvider();


        private void FixedUpdate() =>
            _ammoProvider.Update(Time.deltaTime);


        private IAmmoProvider GetAmmoProvider()
        {
            _ammoProvider ??= new AmmoProvider(new Timer(), new Timer(), CooldownTime, GainChargeTime, MaximumCharges, InitialCharges);
            return _ammoProvider;
        }
    }
}
