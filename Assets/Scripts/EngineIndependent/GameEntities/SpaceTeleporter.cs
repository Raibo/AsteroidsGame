using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameEntities
{
    public class SpaceTeleporter
    {
        private readonly IPhysicsObject _physicsObject;
        private Rectangle _rectangle;


        public SpaceTeleporter(IPhysicsObject physicsObject, Rectangle rectangle)
        {
            _physicsObject = physicsObject;
            _rectangle = rectangle;
        }


        public void Update()
        {
            var newPosition = _physicsObject.Position;

            if (_physicsObject.Position.X < _rectangle.XMin)
                newPosition.X += _rectangle.Width;

            if (_physicsObject.Position.Y < _rectangle.YMin)
                newPosition.Y += _rectangle.Height;

            if (_physicsObject.Position.X > _rectangle.XMax)
                newPosition.X -= _rectangle.Width;

            if (_physicsObject.Position.Y > _rectangle.YMax)
                newPosition.Y -= _rectangle.Height;

            if (newPosition != _physicsObject.Position)
                _physicsObject.Position = newPosition;
        }
    }
}
