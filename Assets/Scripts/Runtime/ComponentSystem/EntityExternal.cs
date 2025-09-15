using System;
using Core.ComponentSystem;

namespace Runtime.ComponentSystem
{
    public static class EntityExternal
    {
        public static T AddComponentMono<T>(this EntityMono entityMono)  
            where T :class, IComponent
        {
            return entityMono.Entity.AddComponent<T>();
        }

        public static IComponent AddComponent<T>(this EntityMono entityMono, Type componentType)
        {
            return entityMono.Entity.AddComponent(componentType);
        }

        public static void RemoveComponentMono(this EntityMono entityMono, Component component)
        {
            entityMono.Entity.RemoveComponent(component);
        }
    }
}