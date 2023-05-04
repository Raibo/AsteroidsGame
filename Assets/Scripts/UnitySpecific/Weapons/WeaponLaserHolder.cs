using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons
{
    public class WeaponLaserHolder : WeaponHolder
    {
        public CircleCastWrapper CircleCastWrapper;
        public float LaserWidth;


        private void Awake() =>
            Weapon = new WeaponLaser(AmmoHolder.AmmoProvider, UserInputWrapper, RigidBodyWrapper, CircleCastWrapper, LaserWidth);


        private void OnValidate() =>
            this.NotifyFieldNotFilled(CircleCastWrapper, nameof(CircleCastWrapper));
    }
}
