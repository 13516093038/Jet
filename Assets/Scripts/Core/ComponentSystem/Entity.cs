using System;
using System.Collections.Generic;

namespace Core.ComponentSystem
{
    /// <summary>
    /// 实体类
    /// </summary>
    public class Entity : Component
    {
        private List<IComponent> _children;
        protected IComponentFactory _factory;

        protected override void OnCreate()
        {
            base.OnCreate();
            
            _children = new List<IComponent>();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (var child in _children)
            {
                _factory.DestroyComponent(child);
            }
        }

        public T AddComponent<T>() where T :class, IComponent
        {
            var component = _factory.CreateComponent<T>(this);
            _children.Add(component);
            return component as T;
        }

        public IComponent AddComponent(Type type)
        {
            var component = _factory.CreateComponent(type, this);
            _children.Add(component);
            return component;
        }

        public void RemoveComponent(Component component)
        {
            _factory.DestroyComponent(component);
        }

        public void Recycle()
        {
            _factory.DestroyComponent(this);
        }

        internal void SetFactory(IComponentFactory factory)
        {
            _factory = factory;
        } 
    }
}