using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
{
    public abstract class CollisionHandlerHolder : MonoBehaviour
    {
        public abstract ICollisionHandler CollisionHandler { get; }
    }
}
