using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Weapons;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.VisualEffects
{
    public class WeaponShotVisuals : MonoBehaviour
    {
        public GameObject VisualGameObject;
        public WeaponHolder WeaponHolder;

        public float ShowTime;


        private void Start() =>
            WeaponHolder.Weapon.ShotOccured += ShowVisuals;


        private async void ShowVisuals()
        {
            VisualGameObject.SetActive(true);
            await Task.Delay(TimeSpan.FromSeconds(ShowTime));
            VisualGameObject.SetActive(false);
        }


        private void OnDestroy() =>
            WeaponHolder.Weapon.ShotOccured -= ShowVisuals;
    }
}
