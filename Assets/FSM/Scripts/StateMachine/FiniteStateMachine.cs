using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace FSM
{
    public class FiniteStateMachine : MonoBehaviour {

        protected State _currentState;
    
        protected delegate void UpdateState(float dt);
        protected UpdateState _updateState;
    
        protected virtual void SwitchState(State newState) {
        
            if (_currentState != null && _currentState.GetType() == newState.GetType()) {
                return;
            }
        
            _currentState?.ExitState();
            _currentState = newState;
            _currentState.InitState();
            _updateState = _currentState.UpdateState;
        }

        protected virtual void SwitchState<T>(State newState, T param)
        {
            if (_currentState != null && _currentState.GetType() == newState.GetType()) {
                return;
            }
        
            _currentState?.ExitState();
            _currentState = newState;
            _currentState.InitState(param);
            _updateState = _currentState.UpdateState;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (_currentState == null) {
                return;
            }
            _updateState(Time.deltaTime);
        }

        protected bool IsStateRunning(Type state) {
            return (_currentState.GetType() == state);
        }
    }    

}

