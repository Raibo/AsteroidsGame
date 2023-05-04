using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific
{
    public abstract class EntityHolder<TEntity> : MonoBehaviour where TEntity : class
    {
        public abstract TEntity Entity { get; }
    }
}
