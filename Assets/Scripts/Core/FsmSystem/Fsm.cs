using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Core.ReferenceSystem;

namespace Core.FsmSystem
{
    public class Fsm<T> : IReference, IFsm
    {
        private ConcurrentDictionary<Type, State<T>> _states  = new ConcurrentDictionary<Type, State<T>>();
        private State<T> _currentState;
        
        public T Owner { get; internal set; }

        public void Create(T owner, List<State<T>> states)
        {
            Owner  = owner;
            foreach (var state in states)
            {
                _states.TryAdd(state.GetType(), state);
                state.OnInit();
            }
        }
        
        public void Run(State<T> state)
        {
            if (_currentState != null)
            {
                throw new Exception("Fsm already running.");
            }
            else
            {
                _currentState = state;
                _currentState.OnEnter();
            }
        }
        
        public void ChangeState(State<T> state)
        {
            _currentState.OnExit();
            _currentState = state;
            _currentState.OnEnter();
        }
        
        void IReference.Clear()
        {
            _states.Clear();
        }
    }
}