using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons
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

            foreach (ICollidable collidable in hitObjects)
                collidable.CollideWith(LaserCollisionLayer);
        }
    }
}
