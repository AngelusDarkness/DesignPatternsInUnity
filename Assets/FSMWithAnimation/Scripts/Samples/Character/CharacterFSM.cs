using Events;
using FSM;
using UnityEngine;

namespace FSMWithAnimation
{
    public class CharacterFSM : FiniteStateMachine
    {

        [SerializeField] private CharacterAnimator _characterAnimator;
        
        private void Start() {
            SwitchState(new IdleState(), _characterAnimator);
        }


        protected override void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                SwitchState(new ColorState(), _characterAnimator);
            } else if (Input.GetKeyDown(KeyCode.D)) {
                SwitchState(new IdleState(), _characterAnimator);
            } else if (Input.GetKeyDown(KeyCode.S)) {
                SwitchState(new ScaleState(), _characterAnimator);
            }
        
            base.Update();
        }

    }
}
