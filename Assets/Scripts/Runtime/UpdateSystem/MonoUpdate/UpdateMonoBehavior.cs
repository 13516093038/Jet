using System;
using UnityEngine;

namespace Runtime.UpdateSystem.MonoUpdate
{
    internal class UpdateMonoBehavior : MonoBehaviour
    {
        public Action UpdateAction;
        
        private void Update()
        {
            UpdateAction?.Invoke();
        }
    }
}