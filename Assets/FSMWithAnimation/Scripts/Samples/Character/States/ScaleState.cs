using FSM;
using UnityEngine;

namespace FSMWithAnimation
{
    public class ScaleState : State
    {
        private CharacterAnimator _characterAnimator;
        
        //Methods
        public override void InitState<T>(T param) {
            _characterAnimator = param as CharacterAnimator;
            if (_characterAnimator != null)
            {
                _characterAnimator.ChangeScale(true);
            }
            Debug.Log("Init State: RunState");
        }

        public override void UpdateState(float delta) {
            Debug.Log("Update State: RunState");
        }

        public override void ExitState() {
            Debug.Log("Exit State: RunState");
            if (_characterAnimator != null)
            {
                _characterAnimator.ChangeScale(false);    
            }
        }
    }
}
