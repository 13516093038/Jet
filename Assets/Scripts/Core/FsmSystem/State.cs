namespace Core.FsmSystem
{
    /// <summary>
    /// 状态 基类
    /// </summary>
    /// <typeparam name="T">状态机拥有者</typeparam>
    public class State<T>
    {
        protected T _owner;

        protected internal virtual void OnInit()
        {
            
        }

        protected internal virtual void OnEnter()
        {
            
        }

        protected internal virtual void OnExit()
        {
            
        }
    }
}