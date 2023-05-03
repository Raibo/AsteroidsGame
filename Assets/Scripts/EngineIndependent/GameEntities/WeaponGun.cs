using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class WeaponGun : Weapon
    {
        private readonly IObjectFactory _bulletFactory;

        protected override bool IsShooting => _controlInputProvider.IsShootingGun;


        public WeaponGun
            (
                IAmmoProvider ammoProvider,
                IControlInputProvider controlInputProvider,
                IPhysicsObject originObject,
                IObjectFactory bulletFactory
            )
            : base(ammoProvider, controlInputProvider, originObject)
        {
            _bulletFactory = bulletFactory;
        }


        protected override void PerformShot() =>
            _bulletFactory.Create(_originObject.Position, _originObject.Velocity, _originObject.Rotation);
    }
}
