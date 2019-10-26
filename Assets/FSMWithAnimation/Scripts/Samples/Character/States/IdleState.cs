using FSM;
using UnityEngine;

namespace FSMWithAnimation
{
    public class IdleState : State
    {
        private CharacterAnimator _characterAnimator;
        
        //Methods
        public override void InitState<T>(T param) {
            Debug.Log("Init State: IdleState");
            _characterAnimator = param as CharacterAnimator;
            if (_characterAnimator != null)
            {
                _characterAnimator.ChangeScale(false);
                _characterAnimator.ChangeColor(false);
            }
        }

        public override void UpdateState(float delta) {
            Debug.Log("Update State: IdleState");
        }

        public override void ExitState() {
            Debug.Log("Exit State: IdleState");
        }

    
    }
}
