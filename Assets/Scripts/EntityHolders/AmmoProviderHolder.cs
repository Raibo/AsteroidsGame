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

        public IAmmoProvider AmmoProvider;


        private void Awake() =>
            AmmoProvider = new AmmoProvider(CooldownTime, GainChargeTime, MaximumCharges, InitialCharges);
    }
}
