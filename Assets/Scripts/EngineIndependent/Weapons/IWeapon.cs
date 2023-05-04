using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons
{
    public interface IWeapon
    {
        public event Action ShotOccured;
        public void Update();
    }
}
