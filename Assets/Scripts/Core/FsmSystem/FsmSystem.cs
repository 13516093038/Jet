using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Core.FsmSystem
{
    /// <summary>
    /// 状态机系统基类
    /// </summary>
    public static class FsmSystem
    {
        // private static ConcurrentDictionary<object, IFsm> _fsms = new ConcurrentDictionary<object, IFsm>();
        //
        // public static Fsm<T> CreateFsm<T>(T owner, List<State<T>> states)
        // {
        //     if (_fsms.ContainsKey(owner))
        //     {
        //         throw new Exception("Fsm already created");
        //     }
        //     var fsm = ReferenceSystem.ReferenceSystem.Acquire(typeof(Fsm<T>));
        //     
        // }
        //
        // public void DestroyFsm(Fsm fsm);
        //
        // public bool HasFsm<T>(T owner);
        //
        // public void ChangeState<T>() where T : IState;
        //
        // public void ChangeState(Type type);
    }
}