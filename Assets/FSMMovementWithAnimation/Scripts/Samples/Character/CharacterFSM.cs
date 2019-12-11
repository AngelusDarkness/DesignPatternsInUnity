using FSM;
using UnityEngine;


namespace FSMMovementWithAnimation
{
    public class CharacterFSM : FiniteStateMachine
    {

        [SerializeField] private CharacterMovement _characterMovement;
        
        private readonly MoveState _moveState = new MoveState();
        private readonly IdleState _idleState = new IdleState();
        private readonly JumpState _jumpState = new JumpState();
        private void Start() {
            SwitchState(_idleState, _characterMovement);
        }


        protected override void Update() {
            
            base.Update();
            
            if (_characterMovement.IsJumping) {
                return;
            }

            if (Input.GetKeyUp(KeyCode.Space)) {

                if (!IsStateRunning(typeof(MoveState))) {
                    _characterMovement.direction = Directions.kNone;
                }

                SwitchState(_jumpState, _characterMovement);
            } else if (Input.GetKey(KeyCode.A)) {
                if (!_characterMovement.CanMove) {
                    return;
                }

                _characterMovement.direction = Directions.kLeft;
                SwitchState(_moveState, _characterMovement);
                
            } else if (Input.GetKey(KeyCode.D)) {
                if (!_characterMovement.CanMove) {
                    return;
                }

                _characterMovement.direction = Directions.kRight;
                SwitchState(_moveState, _characterMovement);
                
            } else if (Input.GetKey(KeyCode.S)) {
                if (!_characterMovement.CanMove) {
                    return;
                }

                _characterMovement.direction = Directions.kBack;
                SwitchState(_moveState, _characterMovement);
                
            } else if (Input.GetKey(KeyCode.W)) {
                if (!_characterMovement.CanMove) {
                    return;
                }

                _characterMovement.direction = Directions.kForward;
                SwitchState(_moveState, _characterMovement);
            } else  {
                SwitchState(_idleState, _characterMovement);
                
            }
            
        }

    }
}
