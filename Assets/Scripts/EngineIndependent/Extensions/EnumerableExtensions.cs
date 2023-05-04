using System;
using System.Collections.Generic;
using System.Linq;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Extensions
{
    public static class EnumerableExtensions
    {
        public static T MinBy<T>(this IEnumerable<T> collection, Func<T, IComparable> valueSelector)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (!collection.Any())
                throw new ArgumentException($"{nameof(collection)} is empty");

            var minimumElement = collection.First();
            var minimumValue = valueSelector(minimumElement);

            foreach (var element in collection)
            {
                var elementValue = valueSelector(element);

                if (elementValue.CompareTo(minimumValue) < 0)
                {
                    minimumElement = element;
                    minimumValue = elementValue;
                }
            }

            return minimumElement;
        }
    }
}
