using FSM;
using UnityEngine;

namespace FSMMovementWithAnimation {
    
    public class MoveState : State {
        private CharacterMovement _character;
        private Vector3 _nextPosition;

        public override void InitState<T>(T param) {
            Debug.Log("Init State: MoveState");
            _character = param as CharacterMovement;
          
        }

        public override void UpdateState(float delta) {
            Debug.Log("Update State: MoveState");
            if (_character.CanMove) {
                CalculateStep(_character.direction);
            }

            if (_character.IsMoving) {
                Move();
            }

        }

        public override void ExitState() {
            Debug.Log("Exit State: MoveState");
        }
        
        
        
        void CalculateStep(Directions direction) {
            _nextPosition = _character.transform.position;
            //Calculate next vector position with step according to direction input.
            switch(direction) {
                case Directions.kUp:
                    _nextPosition = _character.transform.position + Vector3.up * _character.Step;
                    break;
                case Directions.kDown:
                    _nextPosition = _character.transform.position + Vector3.down * _character.Step;
                    break;
                case Directions.kLeft:
                    _nextPosition = _character.transform.position + Vector3.left * _character.Step;
                    break;
                case Directions.kRight:
                    _nextPosition = _character.transform.position + Vector3.right * _character.Step;
                    break;
                case Directions.kForward:
                    _nextPosition = _character.transform.position + Vector3.forward * _character.Step;
                    break;
                case Directions.kBack:
                    _nextPosition = _character.transform.position + Vector3.back * _character.Step;
                    break;
            }

            _character.IsMoving = (direction != Directions.kNone);
        }

        void Move() {
            //Just moving towards next vector position at specified speed.		
            _character.transform.position = Vector3.MoveTowards(_character.transform.position,
                                                                _nextPosition,
                                                        Time.deltaTime * _character.Speed);

            if (!(Vector3.Distance(_character.transform.position, _nextPosition) < Mathf.Epsilon)) return;
            
            _character.IsMoving = false;
            _character.CanMove = true;
        }
    }
}

