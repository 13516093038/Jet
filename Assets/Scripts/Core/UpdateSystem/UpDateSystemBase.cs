using System;
using System.Collections.Generic;
using Core.ComponentSystem;

namespace Core.UpdateSystem
{
    public abstract class UpDateSystemBase
    {
        private readonly HashSet<IUpdate> _updateComponents = new HashSet<IUpdate>();
        private readonly HashSet<IUpdate> _tempUpdateComponents = new HashSet<IUpdate>();
        private bool _canUpdate;

        public bool IsRunning { get; protected set; }
        
        public abstract void Run();
        public abstract void StopRun();

        public void RegisterUpdate(IUpdate update)
        {
            if (HasUpdateComponent(update))
            {
                throw new Exception($"Cannot register an update of {update.GetType()}"); 
            }
            else
            {
                _updateComponents.Add(update);
            }
        }

        public void UnRegisterUpdate(IUpdate update)
        {
            if (!HasUpdateComponent(update))
            {
                throw new Exception($"Cannot unregister an update of {update.GetType()}");
            }
            else
            {
                _updateComponents.Remove(update);
            }
        }

        public bool HasUpdateComponent(IUpdate update)
        {
            return _updateComponents.Contains(update);
        }

        protected void Update()
        {
            _tempUpdateComponents.Clear();
            
            foreach (var updateComponent in _updateComponents)
            {
                if (updateComponent == null)
                {
                    throw new NullReferenceException();
                }
                else if (!updateComponent.CanUpdate)
                {
                    continue;
                }

                _tempUpdateComponents.Add(updateComponent);
            }

            foreach (var tempUpdateComponent in _tempUpdateComponents)
            {
                tempUpdateComponent.Update();
            }
        }
    }
}