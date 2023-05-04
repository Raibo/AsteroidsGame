using AsteroidsVector2 = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Vector2;
using UnityVector2 = UnityEngine.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions
{
    public static class Vector2Extensions
    {
        public static AsteroidsVector2 ToAsteroidsVector2(this UnityVector2 vector) =>
            new(vector.x, vector.y);


        public static UnityVector2 ToUnityVector2(this AsteroidsVector2 vector) =>
            new(vector.X, vector.Y);
    }
}
