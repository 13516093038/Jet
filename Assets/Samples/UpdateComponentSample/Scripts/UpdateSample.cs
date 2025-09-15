using System;
using Core.ComponentSystem;
using Core.UpdateSystem;
using Runtime.ComponentSystem;
using Runtime.UpdateSystem.MonoUpdate;
using Runtime.UpdateSystem.UniTaskUpdate;
using UnityEngine;

namespace Samples.UpdateComponent
{
    public class UpdateSample : EntityMono
    {
        private ComponentFactory _componentFactory; 
        private UpdateTestComponent _updateSample;
        private UpDateSystemBase _uniTaskUpdateSystem;
        
        private void Awake()
        {
            _uniTaskUpdateSystem = new UniTaskUpdateSystem();
            _componentFactory = new ComponentFactory(_uniTaskUpdateSystem);
            Entity = _componentFactory.CreateComponent<Entity>();
            
            _updateSample = this.AddComponentMono<UpdateTestComponent>();
            _uniTaskUpdateSystem.Run();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _uniTaskUpdateSystem.StopRun();
            }
        }
    }
}