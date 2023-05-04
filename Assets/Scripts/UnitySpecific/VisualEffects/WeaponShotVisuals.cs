using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.VisualEffects
{
    public class WeaponShotVisuals : MonoBehaviour
    {
        public GameObject VisualGameObject;
        public EntityHolder<IWeapon> Weapon;

        public float ShowTime;


        private void Start() =>
            Weapon.Entity.ShotOccured += ShowVisuals;


        private async void ShowVisuals()
        {
            VisualGameObject.SetActive(true);
            await Task.Delay(TimeSpan.FromSeconds(ShowTime));
            VisualGameObject.SetActive(false);
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
