using FSM;
using UnityEngine;

namespace FSMWithAnimation
{
    public class ColorState : State
    {
        private CharacterAnimator _characterAnimator;
        
        //Methods
        public override void InitState<T>(T param) {
            Debug.Log("Init State: Color  State");
            _characterAnimator = param as CharacterAnimator;
            if (_characterAnimator != null)
            {
                _characterAnimator.ChangeColor(true);
            }
        }

        public override void UpdateState(float delta) {
                
            Debug.Log("Update State: ColorState");
        }

        public override void ExitState() {
            Debug.Log("Exit State: ColorState");
            if (_characterAnimator != null)
            {
                _characterAnimator.ChangeColor(false);
            }
        }
    }
}
