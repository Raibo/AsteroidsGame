using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction
{
    public interface IDestroyable
    {
        public event Action<IDestroyable> BeginDestroy;
        public void Destroy();
    }
}
