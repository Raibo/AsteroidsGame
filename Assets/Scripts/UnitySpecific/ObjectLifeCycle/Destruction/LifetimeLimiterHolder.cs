using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction
{
    public class LifetimeLimiterHolder : MonoBehaviour
    {
        public float Lifetime;
        public DestroyableWrapper Destroyable;
        public LifetimeLimiter LifetimeLimiter;


        private void Awake() =>
            LifetimeLimiter = new LifetimeLimiter(Destroyable, Lifetime);


        private void FixedUpdate() =>
            LifetimeLimiter.Update(Time.deltaTime);


        private void OnValidate()
        {
            Destroyable = GetComponent<DestroyableWrapper>();
            this.NotifyFieldNotFilled(Destroyable, nameof(Destroyable));
        }
    }
}
