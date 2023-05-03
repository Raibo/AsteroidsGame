using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs.Vector2;

namespace Assets.Scripts.Wrappers
{
    public abstract class ObjectFactoryWrapper : MonoBehaviour, IObjectFactory
    {
        public abstract void Create(AsteroidsVector2 origin, AsteroidsVector2 velocity, float rotation);
    }
}
