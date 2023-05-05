using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;
using AsteroidsTimer = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Timer;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.VisualEffects
{
    public class WeaponShotVisuals : MonoBehaviour
    {
        public GameObject VisualGameObject;
        public EntityHolder<IWeapon> Weapon;

        public float ShowTime;

        private ITimer _timer;


        private void Start()
        {
            _timer = new AsteroidsTimer();
            Weapon.Entity.ShotOccured += ShowVisuals;
        }


        private void FixedUpdate()
        {
            _timer.Update(Time.deltaTime);

            if (_timer.IsFinished && VisualGameObject.activeSelf)
                VisualGameObject.SetActive(false);
        }


        private void ShowVisuals()
        {
            _timer.StartCountdown(ShowTime);
            VisualGameObject.SetActive(true);
        }


        private void OnDestroy() =>
            Weapon.Entity.ShotOccured -= ShowVisuals;


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref Weapon);
            this.NotifyFieldNotFilled(Weapon, nameof(Weapon));
        }
    }
}
