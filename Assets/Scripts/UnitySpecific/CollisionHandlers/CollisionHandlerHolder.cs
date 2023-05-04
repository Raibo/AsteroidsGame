using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers
{
    public abstract class CollisionHandlerHolder : MonoBehaviour
    {
        public abstract ICollisionHandler CollisionHandler { get; }
    }
}
