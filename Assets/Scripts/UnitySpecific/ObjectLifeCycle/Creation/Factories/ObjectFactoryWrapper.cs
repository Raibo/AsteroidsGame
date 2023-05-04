using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public abstract class ObjectFactoryWrapper : MonoBehaviour, IObjectFactory
    {
        public abstract void Create(AsteroidsVector2 origin, AsteroidsVector2 velocity, float rotation);
    }
}
