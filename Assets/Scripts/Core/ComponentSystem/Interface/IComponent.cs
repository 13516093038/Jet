using System;

namespace Core.ComponentSystem
{
    /// <summary>
    /// Component接口
    /// </summary>
    public interface IComponent : IDisposable
    {
        public long Id { get; }
        
        public bool IsDisposed { get; }
        
        public IComponent Parent { get;}

        internal void OnCreate(long id, IComponent parent = null);
    }
}