namespace Core.ComponentSystem
{
    /// <summary>
    /// 组件类
    /// </summary>
    public class Component : IComponent
    {
        private long _id;
        private IComponent _parent;
        
        /// <summary>
        /// 是否已经被回收
        /// </summary>
        public bool IsDisposed => _id == 0;
        
        /// <summary>
        /// 父组件
        /// </summary>
        public IComponent Parent => _parent;

        /// <summary>
        /// 创建时调用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parent"></param>
        void IComponent.OnCreate(long id, IComponent parent)
        {
            //初始化
            _id = id;
            _parent  = parent;
            
            OnCreate();
        }

        /// <summary>
        /// 组件的唯一ID
        /// </summary>
        public long Id => _id;
        
        /// <summary>
        /// 留给子类调用
        /// </summary>
        protected virtual void OnCreate()
        {
            
        }
        
        /// <summary>
        /// 回收时调用
        /// </summary>
        public virtual void Dispose()
        {
            
        }
    }
}