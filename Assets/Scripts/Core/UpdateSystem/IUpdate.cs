using Core.ComponentSystem;

namespace Core.UpdateSystem
{
    public interface IUpdate
    {
        internal void Update();
        internal bool CanUpdate { get; }
    }
}