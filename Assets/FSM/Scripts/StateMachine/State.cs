using System.Collections;
using System.Collections.Generic;
using FSMWithAnimation;
using UnityEngine;

namespace FSM
{
    public abstract class State {
        public virtual void InitState() { }
        public virtual void InitState<T>(T param) { }

        public abstract void UpdateState(float delta);

        public abstract void ExitState();

    
    }    
}

