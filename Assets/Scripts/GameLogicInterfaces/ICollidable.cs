namespace Hudossay.Asteroids.Assets.Scripts.GameLogicInterfaces
{
    public interface ICollidable
    {
        void CollideWith(ICollidable otherCollidable);
    }
}
