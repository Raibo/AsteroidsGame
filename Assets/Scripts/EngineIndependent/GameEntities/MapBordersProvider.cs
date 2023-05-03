using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class MapBordersProvider : IMapBordersProvider
    {
        private readonly Rectangle _borders;

        public Rectangle Borders => _borders;


        public MapBordersProvider(Rectangle borders) =>
            _borders = borders;
    }
}
