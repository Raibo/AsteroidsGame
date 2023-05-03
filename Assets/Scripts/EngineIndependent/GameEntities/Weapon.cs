using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public abstract class Weapon : IWeapon
    {
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
                PerformShot();
        }


        protected abstract void PerformShot();
    }
}
