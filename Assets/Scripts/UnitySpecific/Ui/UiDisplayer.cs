using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Ui
{
    public class UiDisplayer : MonoBehaviour
    {
        public EntityHolder<IPhysicsObject> ShipPhysicsObject;
        public EntityHolder<IAmmoProvider> LaserAmmoProvider;
        public Text Text;

        private IPhysicsObject _physicsObject;
        private IAmmoProvider _ammoProvider;


        private void Awake()
        {
            _physicsObject = ShipPhysicsObject.Entity;
            _ammoProvider = LaserAmmoProvider.Entity;
        }


        private void Update()
        {
            var laserCooldown = _ammoProvider.RemainingCooldownTime;

            Text.text = $"Position = {_physicsObject.Position.X: #0.0};{_physicsObject.Position.Y: #0.0}\n" +
                $"Angle = {_physicsObject.Rotation: ##0.0}\n" +
                $"Speed = {_physicsObject.Velocity.Magnitude: #0.0}\n" +
                $"Laser Ammo = {_ammoProvider.AvailableCharges}\n" +
                $"Laser Cooldown = {laserCooldown: #0.0}";
        }
    }
}
