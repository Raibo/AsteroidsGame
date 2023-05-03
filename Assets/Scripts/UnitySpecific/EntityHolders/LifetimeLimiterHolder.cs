using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.Extensions;
using Assets.Scripts.Wrappers;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
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
