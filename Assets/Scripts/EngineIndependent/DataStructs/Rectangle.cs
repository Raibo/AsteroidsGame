using System;

namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs
{
    [Serializable]
    public struct Rectangle
    {
        public float XMin;
        public float XMax;
        public float YMin;
        public float YMax;

        public float Width => XMax - XMin;
        public float Height => YMax - YMin;


        public Rectangle(float xMin, float xMax, float yMin, float yMax)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
        }
    }
}
