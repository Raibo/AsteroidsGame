using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction
{
    public abstract class DestroyableWrapper : MonoBehaviour, IDestroyable
    {
        public abstract void Destroy();
    }
}
