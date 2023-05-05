using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using System.Collections.Generic;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters
{
    public class EnemiesCounter : IEnemiesCounter
    {
        public int Count => _destroyables.Count;
        public IEnumerable<IDestroyable> CountedEnemyDestroyables => _destroyables;

        private HashSet<IDestroyable> _destroyables = new HashSet<IDestroyable>();


        public void AddCountedEnemy(IDestroyable enemyDestroyable)
        {
            _destroyables.Add(enemyDestroyable);
            enemyDestroyable.BeginDestroy += RemoveDestroyed;
        }


        public void RemoveCountedEnemy(IDestroyable enemyDestroyable)
        {
            _destroyables.Remove(enemyDestroyable);
            enemyDestroyable.BeginDestroy -= RemoveDestroyed;
        }


        public void DestroyCountedEnemies()
        {
            foreach (var destroyable in _destroyables)
            {
                destroyable.BeginDestroy -= RemoveDestroyed;
                destroyable.Destroy();
            }

            _destroyables.Clear();
        }


        private void RemoveDestroyed(IDestroyable destroyable) =>
            RemoveCountedEnemy(destroyable);
    }
}
