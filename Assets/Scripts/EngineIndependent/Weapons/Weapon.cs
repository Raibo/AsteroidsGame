using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public event Action ShotOccured;

        protected readonly IAmmoProvider _ammoProvider;
        protected readonly IControlInputProvider _controlInputProvider;
        protected readonly IPhysicsObject _originObject;

        protected abstract bool IsShooting { get; }


        public Weapon(IAmmoProvider ammoProvider, IControlInputProvider controlInputProvider, IPhysicsObject originObject)
        {
            _ammoProvider = ammoProvider;
            _controlInputProvider = controlInputProvider;
            _originObject = originObject;
        }


        public void Update()
        {
            if (IsShooting && _ammoProvider.TryUseCharge())
            {
                PerformShot();
                ShotOccured?.Invoke();
            }
        }


        protected abstract void PerformShot();
    }
}
