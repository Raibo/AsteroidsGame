using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
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
    }
}
