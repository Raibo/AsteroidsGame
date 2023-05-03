using Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
{
    public class AmmoProviderHolder : MonoBehaviour
    {
#if UNITY_EDITOR
        public string DeveloperDescription;
#endif

        [Space(15)]
        public int MaximumCharges;
        public int InitialCharges;

        public float CooldownTime;
        public float GainChargeTime;

        private IAmmoProvider _ammoProvider;

        public IAmmoProvider AmmoProvider => GetAmmoProvider();


        private void Awake() =>
            GetAmmoProvider();


        private void FixedUpdate() =>
            _ammoProvider.Update(Time.deltaTime);


        private IAmmoProvider GetAmmoProvider()
        {
            _ammoProvider ??= new AmmoProvider(CooldownTime, GainChargeTime, MaximumCharges, InitialCharges);
            return _ammoProvider;
        }
    }
}
