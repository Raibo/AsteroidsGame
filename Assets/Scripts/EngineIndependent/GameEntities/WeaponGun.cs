using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class WeaponGun : Weapon
    {
        private readonly IObjectFactory _bulletFactory;


        public WeaponGun(IAmmoProvider ammoHolder, IObjectFactory bulletFactory) : base(ammoHolder) =>
            _bulletFactory = bulletFactory;


        protected override void PerformShot() =>
            _bulletFactory.Create();
    }
}
