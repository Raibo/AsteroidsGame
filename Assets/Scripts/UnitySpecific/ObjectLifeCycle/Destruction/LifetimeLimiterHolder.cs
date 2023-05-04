using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction
{
    public class LifetimeLimiterHolder : EntityHolder<LifetimeLimiter>
    {
        public float Lifetime;
        public EntityHolder<IDestroyable> Destroyable;
        public override LifetimeLimiter Entity => _lifetimeLimiter;


        private LifetimeLimiter _lifetimeLimiter;


        private void Awake() =>
            _lifetimeLimiter = new LifetimeLimiter(Destroyable.Entity, Lifetime);


        private void FixedUpdate() =>
            _lifetimeLimiter.Update(Time.deltaTime);


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref Destroyable);
            this.NotifyFieldNotFilled(Destroyable, nameof(Destroyable));
        }
    }
}
