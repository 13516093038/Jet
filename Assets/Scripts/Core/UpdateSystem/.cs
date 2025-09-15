using System.Collections.Generic;
using Core.UpdateSystem;

namespace Core.UpdateSystem
{
    public abstract class UpDateSystemBase
    {
        private readonly List<IUpdate> _updateComponents  = new List<IUpdate>();
        private readonly List<IUpdate> _tempUpdateComponents = new List<IUpdate>();
        
        public bool IsRunning { get; protected set; }
        public abstract void Run();

        public abstract void StopRun();

        public void Register(IUpdate updateComponent)
        {
            if (!HasUpdateComponent(updateComponent))
            {
                _updateComponents.Add(updateComponent);
            }
            else
            {
                throw new System.Exception("Already Registered UpdateComponent");
            }
        }

        public void Unregister(IUpdate updateComponent)
        {
            if (HasUpdateComponent(updateComponent))
            {
                _updateComponents.Remove(updateComponent);
            }
            else
            {
                throw new System.Exception("Not Registered UpdateComponent");
            }
        }

        public bool HasUpdateComponent(IUpdate updateComponent)
        {
            return  _updateComponents.Contains(updateComponent);
        }

        protected void Update()
        {
            _tempUpdateComponents.Clear();
            
            foreach (var updateComponents in _updateComponents)
            {
                if (updateComponents == null)
                {
                    throw new System.Exception("Update Components are null");
                }
                else if (!updateComponents.CanUpdate)
                {
                    continue;
                }
                
                _tempUpdateComponents.Add(updateComponents);
            }

            foreach (var tempUpdateComponent in _tempUpdateComponents)
            {
                tempUpdateComponent.Update();
            }
        }
    }
}