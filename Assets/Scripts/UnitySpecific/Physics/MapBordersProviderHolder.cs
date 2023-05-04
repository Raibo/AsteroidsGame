using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics
{
    public class MapBordersProviderHolder : MonoBehaviour
    {
        public IMapBordersProvider MapBordersProvider => GetMapBorders();

        public float LeftBorder;
        public float RightBorder;
        public float BottomBorder;
        public float TopBorder;

        private IMapBordersProvider _mapBordersProvider;


        private IMapBordersProvider GetMapBorders()
        {
            _mapBordersProvider ??= new MapBordersProvider(new Rectangle(LeftBorder, RightBorder, BottomBorder, TopBorder));
            return _mapBordersProvider;
        }
    }
}
