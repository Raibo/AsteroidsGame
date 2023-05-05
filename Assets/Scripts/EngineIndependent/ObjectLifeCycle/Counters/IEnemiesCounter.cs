using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using System.Collections.Generic;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters
{
    public interface IEnemiesCounter
    {
        public int Count { get; }
        public IEnumerable<IDestroyable> CountedEnemyDestroyables { get; }
        void AddCountedEnemy(IDestroyable destroyable);
        void RemoveCountedEnemy(IDestroyable destroyable);
        void DestroyCountedEnemies();
    }
}
