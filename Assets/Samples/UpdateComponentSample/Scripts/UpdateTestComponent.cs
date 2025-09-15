using System.Linq;
using Core.ComponentSystem;
using Core.UpdateSystem;
using UnityEngine;

namespace Samples.UpdateComponent
{
    public class UpdateTestComponent : Entity, IUpdate
    {
        private bool _canUpdate = true;

        void IUpdate.Update()
        {
            Debug.Log("update");
        }

        bool IUpdate.CanUpdate => _canUpdate;
    }
}