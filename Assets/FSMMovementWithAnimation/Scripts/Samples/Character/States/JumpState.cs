using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

namespace FSMMovementWithAnimation {
    
    public class JumpState : State {
        private CharacterMovement _character;
        private Vector3 _jumpAcceleration = Vector3.zero;
        private Vector3 _jumpVelocity = Vector3.zero;
        private Vector3 _nextPosition = Vector3.zero;
        private float _groundY = 0f;
        
        public override void InitState<T>(T param) {
            Debug.Log("Init State: JumpState");
            _character = param as CharacterMovement;
            _character.CanMove = true;
            _character.IsMoving = false;
            CalculateStep(_character.direction);
            CalculateJump();
        }

        public override void UpdateState(float delta) {
            Debug.Log("Update State: JumpState");

            if (_character.IsJumping) {
                Jump();
            }

        }

        public override void ExitState() {
            Debug.Log("Exit State: JumpState");
        }
        
        void CalculateJump() {
            var jumpDistance = Vector3.up * _character.DistanceLength;		
            _jumpVelocity = 2 * _character.JumpHeight * jumpDistance / _character.DistanceLength;		
            _jumpAcceleration =  -2 * _character.JumpHeight * Vector3.Scale(jumpDistance, jumpDistance) / Mathf.Pow(_character.DistanceLength,2);		
            _character.IsJumping = true;
        }
        
        void CalculateStep(Directions direction) {
            _nextPosition = _character.transform.position;
            //Calculate next vector position with step according to direction input.
            switch(direction) {
                case Directions.kUp:
                    _nextPosition = _character.transform.position + Vector3.up * (_character.DistanceLength * 2);
                    break;
                case Directions.kDown:
                    _nextPosition = _character.transform.position + Vector3.down * (_character.DistanceLength * 2);
                    break;
                case Directions.kLeft:
                    _nextPosition = _character.transform.position + Vector3.left * (_character.DistanceLength * 2);
                    break;
                case Directions.kRight:
                    _nextPosition = _character.transform.position + Vector3.right * (_character.DistanceLength * 2);
                    break;
                case Directions.kForward:
                    _nextPosition = _character.transform.position + Vector3.forward * (_character.DistanceLength * 2);
                    break;
                case Directions.kBack:
                    _nextPosition = _character.transform.position + Vector3.back * (_character.DistanceLength * 2);
                    break;
            }
            
        }

        
        void Jump() {
            if (_character.direction != Directions.kNone) {
                _character.transform.position = Vector3.MoveTowards(_character.transform.position, 
                    _nextPosition,
                    Time.deltaTime * _character.Speed);    
            }
            
            _character.transform.position += _jumpVelocity * Time.deltaTime + _jumpAcceleration/2 * Mathf.Pow(Time.deltaTime , 2);
            _jumpVelocity += _jumpAcceleration * Time.deltaTime;

            var distanceLeft = _jumpVelocity.y - _jumpAcceleration.y;
            Debug.Log($"Jumping: {distanceLeft}");
            if (!(distanceLeft < Mathf.Epsilon)) return;
            
            _character.IsJumping = false;
            Debug.Log($"Jumping Completed: {distanceLeft}");
            //Reset Y position to ground level.
            var pos = _character.transform.position;
            pos.y = _groundY;
            _character.transform.position = pos;

        }
    }

}
