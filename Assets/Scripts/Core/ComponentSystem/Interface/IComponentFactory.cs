using System;

namespace Core.ComponentSystem
{
    /// <summary>
    /// 组件工厂类接口 （抽象工厂模式）
    /// </summary>
    public interface  IComponentFactory
    {
        public T CreateComponent<T>(IComponent parent = null) where T : class, IComponent;
        
        public IComponent CreateComponent(Type type, IComponent parent = null);
        
        public void DestroyComponent(IComponent component);
    }
}