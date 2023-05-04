namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics
{
    public class MapBordersProvider : IMapBordersProvider
    {
        private readonly Rectangle _borders;

        public Rectangle Borders => _borders;


        public MapBordersProvider(Rectangle borders) =>
            _borders = borders;
    }
}
