using UnityEngine;
using Component = Core.ComponentSystem.Component;

namespace ComponentSample
{
    public class SampleComponent : Component
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            Debug.Log("SampleComponent OnCreate");
            Debug.Log("SampleComponentId" + Id);
            Debug.Log("parent:" + Parent.GetType());
        }

        public override void Dispose()
        {
            base.Dispose();
            
            Debug.Log("SampleComponent OnDispose");
        }
    }
}