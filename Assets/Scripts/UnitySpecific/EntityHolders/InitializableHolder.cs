using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
{
    public abstract class InitializableHolder : MonoBehaviour
    {
        public abstract IInitializable Initializable { get; }
    }
}
