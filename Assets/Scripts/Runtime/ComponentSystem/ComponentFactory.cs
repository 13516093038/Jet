using System;
using System.Linq;
using Core.ComponentSystem;
using Core.UpdateSystem;

namespace Runtime.ComponentSystem
{
    /// <summary>
    /// 组件工厂
    /// </summary>
    public class ComponentFactory : IComponentFactory
    {
        private static long _componentId = 0;
        private UpDateSystemBase _updateSystem;

        public T CreateComponent<T>(IComponent parent = null) where T : class, IComponent
        {
            var component = Activator.CreateInstance<T>();
            Decorate(component);
            component.OnCreate(_componentId++, parent);
            return component;
        }

        public IComponent CreateComponent(Type type, IComponent parent = null)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else if (!type.IsSubclassOf(typeof(IComponent)))
            {
                throw new ArgumentException($"{nameof(type)} must be subclass of {nameof(IComponent)}.", nameof(type));
            }

            var component = Activator.CreateInstance(type) as IComponent;
            Decorate(component);
            component.OnCreate(_componentId++, parent);
            return component;
        }

        public void DestroyComponent(IComponent component)
        {
            RemoveDecorate(component);
            component.Dispose();
        }

        private void Decorate(IComponent component)
        {
            DecorateEntity(component);
            DecorateUpdate(component);
        }

        private void RemoveDecorate(IComponent component)
        {
            RemoveDecorateUpdate(component);
        }

        private void DecorateEntity(IComponent component)
        {
            if (component.GetType().IsSubclassOf(typeof(Entity)) || component.GetType() == typeof(Entity))
            {
                (component as Entity).SetFactory(this);
            }
        }
        
        private void DecorateUpdate(IComponent component)
        {
            if (component.GetType().GetInterfaces().Any( iface => iface == typeof(IUpdate)))
            {
                _updateSystem.RegisterUpdate(component as IUpdate);
            }
        }
        
        private void RemoveDecorateUpdate(IComponent component)
        {
            if (component.GetType().GetInterfaces().Any( iface => iface == typeof(IUpdate)))
            {
                _updateSystem.UnRegisterUpdate(component as IUpdate);
            }
        }

        public ComponentFactory(UpDateSystemBase updateSystem)
        {
            _updateSystem  = updateSystem;
        }
    }
}