using System;
using UnityEngine;

namespace FSM
{
    public class CharacterFSM : FiniteStateMachine
    { 
    
        private void Start() {
            SwitchState(new IdleState());
        }

        protected override void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SwitchState(new WalkState());
            } else if (Input.GetKeyDown(KeyCode.W) && IsStateRunning(typeof(WalkState))) {
                SwitchState(new RunState());
            } else if (Input.GetKeyDown(KeyCode.S)) {
                SwitchState(new IdleState());
            }
        
            base.Update();
        }
    }
    

}
