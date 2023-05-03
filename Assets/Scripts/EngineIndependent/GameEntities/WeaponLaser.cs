using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class WeaponLaser : Weapon
    {
        private readonly ILaserColliderProvider _laserColliderProvider;
        private readonly float _laserWidth;

        private const CollisionLayers LaserCollisionLayer = CollisionLayers.Laser;

        protected override bool IsShooting => _controlInputProvider.IsShootingLaser;


        public WeaponLaser
            (
                IAmmoProvider ammoProvider,
                IControlInputProvider controlInputProvider,
                IPhysicsObject originObject,
                ILaserColliderProvider laserColliderProvider,
                float laserWidth
            )
            : base(ammoProvider, controlInputProvider, originObject)
        {
            _laserColliderProvider = laserColliderProvider;
            _laserWidth = laserWidth;
        }


        protected override void PerformShot()
        {
            var hitObjects = _laserColliderProvider.GetHitObjects(_originObject.Position, _originObject.Direction, _laserWidth);

            for (int i = 0; i < hitObjects.Length; i++)
                hitObjects[i].CollideWith(LaserCollisionLayer);
        }
    }
}
