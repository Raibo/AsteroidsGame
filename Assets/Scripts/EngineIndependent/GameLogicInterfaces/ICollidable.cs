﻿namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface ICollidable
    {
        void CollideWith(ICollidable otherCollidable);
    }
}