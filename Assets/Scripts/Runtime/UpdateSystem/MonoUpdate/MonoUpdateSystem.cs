using Core.UpdateSystem;
using UnityEngine;

namespace Runtime.UpdateSystem.MonoUpdate
{
    public class MonoUpdateSystem :  UpDateSystemBase
    {
        private UpdateMonoBehavior _updateMonoBehavior;
        
        public override void Run()
        {
            if (_updateMonoBehavior == null)
            {
                _updateMonoBehavior = new GameObject("MonoUpdateSystem").AddComponent<UpdateMonoBehavior>();
            }

            if (IsRunning)
            {
                return;
            }

            IsRunning = true;

            _updateMonoBehavior.enabled = true;
            _updateMonoBehavior.UpdateAction = Update;
        }

        public override void StopRun()
        {
            if (!IsRunning)
            {
                return;
            }
            _updateMonoBehavior.enabled = false;
        }
    }
}