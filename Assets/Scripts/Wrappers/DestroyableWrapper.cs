using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Assets.Scripts.Wrappers
{
    public abstract class DestroyableWrapper : MonoBehaviour, IDestroyable
    {
        public abstract void Destroy();
    }
}
