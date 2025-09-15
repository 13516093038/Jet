using Core.ComponentSystem;
using UnityEngine;

namespace ComponentSample
{
    public class SampleEntity : Entity
    {
        public SampleComponent SampleComponent;

        protected override void OnCreate()
        {
            base.OnCreate();

            SampleComponent = AddComponent<SampleComponent>();
            
            Debug.Log("SampleComponent OnCreate");
            Debug.Log("SampleComponentId" + Id);
            Debug.Log("parent:" + Parent.GetType());
        }

        public override void Dispose()
        {
            Debug.Log("SampleEntity OnDispose");
        }
    }
}