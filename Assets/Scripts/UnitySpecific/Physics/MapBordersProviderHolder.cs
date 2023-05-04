using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics
{
    public class MapBordersProviderHolder : EntityHolder<IMapBordersProvider>
    {
        public override IMapBordersProvider Entity => GetMapBorders();

        public float LeftBorder;
        public float RightBorder;
        public float BottomBorder;
        public float TopBorder;

        IMapBordersProvider _entity;


        private IMapBordersProvider GetMapBorders()
        {
            _entity ??= new MapBordersProvider(new Rectangle(LeftBorder, RightBorder, BottomBorder, TopBorder));
            return _entity;
        }
    }
}
