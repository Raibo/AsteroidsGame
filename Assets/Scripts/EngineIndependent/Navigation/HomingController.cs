using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Extensions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation
{
    public class HomingController
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly IPhysicsObject _homingTarget;
        private readonly float _homingSpeed;

        private readonly float XRange;
        private readonly float YRange;
        private readonly Vector2[] _directionBuffer;

        private readonly Vector2[] _displacementVectors = new Vector2[]
        {
            new(-1,-1),
            new(-1,0),
            new(-1,1),
            new(0,-1),
            new(0,0),
            new(0,1),
            new(1,-1),
            new(1,0),
            new(1,1),
        };


        public HomingController(IPhysicsObject physicsObject, IPhysicsObject homingTarget, IMapBordersProvider mapBordersProvider,
            float homingSpeed)
        {
            _physicsObject = physicsObject;
            _homingTarget = homingTarget;
            _homingSpeed = homingSpeed;

            var borders = mapBordersProvider.Borders;
            XRange = borders.XMax - borders.XMin;
            YRange = borders.YMax - borders.YMin;
            _directionBuffer = new Vector2[9];
        }


        public void Update() =>
            _physicsObject.Velocity = _homingSpeed * GetShortestDirection().Normalized;


        private Vector2 GetShortestDirection()
        {
            var targetDirection = _homingTarget.Position - _physicsObject.Position;

            for (int i = 0; i < _displacementVectors.Length; i++)
                _directionBuffer[i] = targetDirection + new Vector2(_displacementVectors[i].X * XRange, _displacementVectors[i].Y * YRange);

            var shortestDirection = _directionBuffer.MinBy(v => v.SqrMagnitude);
            return shortestDirection;
        }
    }
}
