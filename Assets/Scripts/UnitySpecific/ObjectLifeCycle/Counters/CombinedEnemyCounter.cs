using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters
{
    public class CombinedEnemyCounter : EntityHolder<IEnemiesCounter>, IEnemiesCounter
    {
        public List<EntityHolder<IEnemiesCounter>> EnemiesCounters;
        public int Count => EnemiesCounters.Sum(i => i.Entity.Count);

        public IEnumerable<IDestroyable> CountedEnemyDestroyables =>
            EnemiesCounters
                .SelectMany(i => i.Entity.CountedEnemyDestroyables)
                .Distinct();

        public override IEnemiesCounter Entity => this;


        public void AddCountedEnemy(IDestroyable destroyable) =>
            throw new NotSupportedException($"{nameof(CombinedEnemyCounter)} is not suppesed to count enemies by itself");


        public void RemoveCountedEnemy(IDestroyable destroyable) =>
            throw new NotSupportedException($"{nameof(CombinedEnemyCounter)} is not suppesed to count enemies by itself");


        public void DestroyCountedEnemies()
        {
            foreach (var counter in EnemiesCounters)
                counter.Entity.DestroyCountedEnemies();
        }
    }
}
