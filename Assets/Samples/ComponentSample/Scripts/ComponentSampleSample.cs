using System;
using Core.ComponentSystem;
using Runtime.ComponentSystem;
using Runtime.UpdateSystem.UniTaskUpdate;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ComponentSample
{
    public class ComponentSampleSample : EntityMono
    {
        private SampleEntity _entity;
        private ComponentFactory _componentFactory;
        
        private void Awake()
        {
            _componentFactory =  new ComponentFactory(new UniTaskUpdateSystem());
            this.Entity = _componentFactory.CreateComponent<Entity>();
            _entity =  this.AddComponentMono<SampleEntity>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.RemoveComponentMono(_entity);
            }
        }
    }
}

