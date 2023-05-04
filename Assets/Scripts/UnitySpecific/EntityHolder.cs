using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific
{
    public abstract class EntityHolder<TInterface> : MonoBehaviour where TInterface : class
    {
        public abstract TInterface Entity { get; }
    }
}
