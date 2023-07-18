using System;
using System.Collections.Generic;

namespace CodeBase.Units.Units
{
    public class StateMachine
    {
        private readonly Dictionary<Type, BaseState> _states = new Dictionary<Type, BaseState>();
        private BaseState _previousState;
        private BaseState _currentState;
        private bool _enabled = true;

        public event Action<BaseState> StateChanged;
        
        public BaseState PreviousState => _previousState;
        public BaseState CurrentState => _currentState;

        public void Enable() => 
            _enabled = true;

        public void Disable()
        {
            _enabled = false;
            _currentState?.Exit();
            _previousState = _currentState;
        }
        
        public void AddState<T>(T state) where T : BaseState => 
            _states.Add(typeof(T), state);

        public void ChangeState<T>() where T : BaseState
        {
            _currentState?.Exit();
            _previousState = _currentState;
            _currentState = _states[typeof(T)];
            _currentState.Enter();
            
            StateChanged?.Invoke(_currentState);
        }

        public void GoToNextState()
        {
            _currentState.GoToNextState();
        }

        public void Update()
        {
            if(!_enabled)
                return;
            _currentState.Update();
        }

        public void FixedUpdate()
        {
            if(!_enabled)
                return;
            _currentState.FixedUpdate();
        }
    }
}