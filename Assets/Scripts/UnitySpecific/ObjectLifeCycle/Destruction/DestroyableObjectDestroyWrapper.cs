using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction
{
    public class DestroyableObjectDestroyWrapper : EntityHolder<IDestroyable>, IDestroyable
    {
        public override IDestroyable Entity => this;

        public void Destroy() =>
            Destroy(gameObject);
    }
}
