using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameEntities
{
    public class SpaceTeleporter
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly IMapBordersProvider _mapBordersProvider;


        public SpaceTeleporter(IPhysicsObject physicsObject, IMapBordersProvider mapBordersProvider)
        {
            _physicsObject = physicsObject;
            _mapBordersProvider = mapBordersProvider;
        }


        public void Update()
        {
            var newPosition = _physicsObject.Position;
            var borders = _mapBordersProvider.Borders;

            if (_physicsObject.Position.X < borders.XMin)
                newPosition.X += borders.Width;

            if (_physicsObject.Position.Y < borders.YMin)
                newPosition.Y += borders.Height;

            if (_physicsObject.Position.X > borders.XMax)
                newPosition.X -= borders.Width;

            if (_physicsObject.Position.Y > borders.YMax)
                newPosition.Y -= borders.Height;

            if (newPosition != _physicsObject.Position)
                _physicsObject.Position = newPosition;
        }
    }
}
