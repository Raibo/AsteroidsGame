using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using System;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction
{
    public class DestroyableObjectDestroyWrapper : EntityHolder<IDestroyable>, IDestroyable
    {
        public override IDestroyable Entity => this;

        public event Action<IDestroyable> BeginDestroy;


        public void Destroy()
        {
            BeginDestroy?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
