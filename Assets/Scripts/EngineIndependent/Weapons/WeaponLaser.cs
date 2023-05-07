using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons
{
    public class WeaponLaser : Weapon
    {
        private readonly ILaserColliderProvider _laserColliderProvider;
        private readonly ITimer _timer;
        private readonly float _laserWidth;
        private readonly float _channelingTime;
        private const CollisionLayers LaserCollisionLayer = CollisionLayers.Laser;

        protected override bool IsShooting => _controlInputProvider.IsShootingLaser;

        private bool _isCurrentlyChanneling;
        private readonly ICollidable[] _hitTargetsBuffer;


        public WeaponLaser(IAmmoProvider ammoProvider, IControlInputProvider controlInputProvider, IPhysicsObject originObject,
            ILaserColliderProvider laserColliderProvider, ITimer timer, float laserWidth, float channelingTime, int maxTargetsPerTick)
            : base(ammoProvider, controlInputProvider, originObject)
        {
            _laserColliderProvider = laserColliderProvider;
            _timer = timer;
            _laserWidth = laserWidth;
            _channelingTime = channelingTime;
            _hitTargetsBuffer = new ICollidable[maxTargetsPerTick];
        }


        public override void Update(float time)
        {
            base.Update(time);
            _timer.Update(time);

            if (_isCurrentlyChanneling)
                PerformShotTick();

            if (_timer.IsFinished)
                _isCurrentlyChanneling = false;
        }


        protected override void PerformShot()
        {
            _isCurrentlyChanneling = true;
            _timer.StartCountdown(_channelingTime);
        }


        private void PerformShotTick()
        {
            var hitCount = _laserColliderProvider.GetHitObjects(_originObject.Position, _originObject.Direction, _laserWidth, _hitTargetsBuffer);

            for (int i = 0; i < hitCount; i++)
                _hitTargetsBuffer[i].CollideWith(LaserCollisionLayer);
        }
    }
}
