using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
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
