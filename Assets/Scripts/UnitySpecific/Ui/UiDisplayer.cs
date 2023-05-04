using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Ui
{
    public class UiDisplayer : MonoBehaviour
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public AmmoProviderHolder AmmoProviderHolder;
        public Text Text;

        private IPhysicsObject _physicsObject;
        private IAmmoProvider _ammoProvider;


        private void Awake()
        {
            _physicsObject = RigidBodyWrapper;
            _ammoProvider = AmmoProviderHolder.AmmoProvider;
        }


        private void Update()
        {
            var laserCooldown = _ammoProvider.IsChargeReady ? 0f : _ammoProvider.RemainingCooldownTime;

            Text.text = $"Position = {_physicsObject.Position.X : #0.0};{_physicsObject.Position.Y: #0.0}\n" +
                $"Angle = {_physicsObject.Rotation : ##0.0}\n" +
                $"Speed = {_physicsObject.Velocity.Magnitude : #0.0}\n" +
                $"Laser Ammo = {_ammoProvider.AvailableCharges}\n" +
                $"Laser Cooldown = {laserCooldown: #0.0}";
        }
    }
}
