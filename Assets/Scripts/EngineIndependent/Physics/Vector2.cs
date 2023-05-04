using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics
{
    [Serializable]
    public struct Vector2
    {
        public float X;
        public float Y;

        public float Magnitude => MathF.Sqrt(X * X + Y * Y);
        public float SqrMagnitude => X * X + Y * Y;
        public Vector2 Normalized => SqrMagnitude == 0 ? Zero : this / Magnitude;
        public static Vector2 Zero => new(0f, 0f);


        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }


        public override int GetHashCode() =>
            HashCode.Combine(X, Y);


        public override bool Equals(object obj) =>
            obj is Vector2 other && Equals(other);


        public bool Equals(Vector2 other) =>
            X == other.X && Y == other.Y;


        public static bool operator ==(Vector2 a, Vector2 b) =>
            a.Equals(b);


        public static bool operator !=(Vector2 a, Vector2 b) =>
            !a.Equals(b);


        public static Vector2 operator +(Vector2 vector1, Vector2 vector2) =>
            new(vector1.X + vector2.X, vector1.Y + vector2.Y);


        public static Vector2 operator -(Vector2 vector1, Vector2 vector2) =>
            new(vector1.X - vector2.X, vector1.Y - vector2.Y);


        public static Vector2 operator *(float scalar, Vector2 vector) =>
            new(scalar * vector.X, scalar * vector.Y);


        public static Vector2 operator *(Vector2 vector, float scalar) =>
            new(scalar * vector.X, scalar * vector.Y);


        public static Vector2 operator /(Vector2 vector, float scalar) =>
            new(vector.X / scalar, vector.Y / scalar);


        public override string ToString() =>
            $"({X}, {Y})";
    }
}
