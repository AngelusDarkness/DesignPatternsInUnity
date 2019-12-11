using FSM;
using UnityEngine;

namespace FSMMovementWithAnimation
{
    public class IdleState : State
    {
        private CharacterMovement _character;
        
        //Methods
        public override void InitState<T>(T param) {
            Debug.Log("Init State: IdleState");
            _character = param as CharacterMovement;
            
            if(_character == null) return;
            
            _character.CanMove = true;
            _character.IsMoving = false;
        }

        public override void UpdateState(float delta) {
            Debug.Log("Update State: IdleState");
        }

        public override void ExitState() {
            Debug.Log("Exit State: IdleState");
        }

    
    }
}
