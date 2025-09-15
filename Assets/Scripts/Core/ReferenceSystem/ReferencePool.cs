using System;
using System.Collections.Concurrent;

namespace Core.ReferenceSystem
{
    public class ReferencePool
    {
        private ConcurrentQueue<IReference> _references;

        public ReferencePool()
        {
            _references = new ConcurrentQueue<IReference>();
        }

        internal IReference Acquire(Type type)
        {
            if (_references.Count <= 0)
            {
                return Activator.CreateInstance(type) as IReference;
            }
            else
            {
                _references.TryDequeue(out var reference);
                return reference as IReference;
            }
        }

        internal T Acquire<T>() where T : class, IReference
        {
            return (T)Acquire(typeof(T));
        }

        internal void Release(IReference reference)
        {
            _references.Enqueue(reference);
        }
    }
}