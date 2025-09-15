using System;
using System.Collections.Concurrent;

namespace Core.ReferenceSystem
{
    public static class ReferenceSystem
    {
        private static ConcurrentDictionary<Type, ReferencePool> _pools =  new ConcurrentDictionary<Type, ReferencePool>();

        public static T Acquire<T>() where T : class, IReference
        {
           return Acquire(typeof(T)) as T;
        }

        public static IReference Acquire(Type type)
        {
            if (_pools.TryGetValue(type, out ReferencePool pool))
            {
                return pool.Acquire(type);
            }
            else
            {
                pool = new ReferencePool();
                _pools.TryAdd(type, pool);
                return pool.Acquire(type);
            }
        }

        public static void Release(IReference reference)
        {
            if (_pools.TryGetValue(reference.GetType(), out ReferencePool pool))
            {
                pool.Release(reference);
            }
            else
            {
                pool = new ReferencePool();
                _pools.TryAdd(reference.GetType(), pool);
                pool.Release(reference);
            }
        }
    }
}