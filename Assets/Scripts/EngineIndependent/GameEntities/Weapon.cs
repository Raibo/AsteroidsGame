using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using System;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public abstract class Weapon : IWeapon, IDisposable
    {
        private readonly IAmmoProvider _ammoProvider;
        private bool _isShooting;


        public Weapon(IAmmoProvider ammoProvider)
        {
            _ammoProvider = ammoProvider;
            _ammoProvider.ChargeReady += OnChargeReady;
        }

        public void StartShooting()
        {
            _isShooting = true;

            if (_ammoProvider.TryUseCharge())
                PerformShot();
        }


        public void StopShooting()
        {
            _isShooting = false;
        }


        public void Dispose() =>
            _ammoProvider.ChargeReady -= OnChargeReady;


        private void OnChargeReady()
        {
            if (_isShooting && _ammoProvider.TryUseCharge())
                PerformShot();
        }


        protected abstract void PerformShot();
    }
}
