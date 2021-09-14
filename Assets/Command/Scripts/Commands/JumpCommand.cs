using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern {
    
    public class JumpCommand : ICommand {

        private Transform _transform;
        private float _movementSpeed = 10f;
        private float _distanceLength = 3;
        private float _jumpHeight = 3;

        //Private members
        private Directions _direction;

        private Vector3 _jumpAcceleration = Vector3.zero;
        private Vector3 _jumpSpeed = Vector3.zero;
        private Vector3 _nextPosition = Vector3.zero;
        private bool _isJumping;
        private float _groundY = 0f;

        public void Prepare(Transform transform) {
            _transform = transform;
            CalculateStep(_direction);
            CalculateJump();
        }
        
        public void Execute() {
            if (_isJumping) {
                Jump();
            }
        }

        
        void CalculateJump() {
            var jumpDistance = Vector3.up * _distanceLength;
            _jumpSpeed = 2 * _jumpHeight * jumpDistance / _distanceLength;
            _jumpAcceleration = -2 * _jumpHeight * Vector3.Scale(jumpDistance, jumpDistance) /
                                Mathf.Pow(_distanceLength, 2);
            _isJumping = true;
        }

        void CalculateStep(Directions direction) {
            _nextPosition = _transform.position;
            //Calculate next vector position with step according to direction input.
            switch (direction) {
                case Directions.kUp:
                    _nextPosition = _transform.position + Vector3.up * (_distanceLength * 2);
                    break;
                case Directions.kDown:
                    _nextPosition = _transform.position + Vector3.down * (_distanceLength * 2);
                    break;
                case Directions.kLeft:
                    _nextPosition = _transform.position + Vector3.left * (_distanceLength * 2);
                    break;
                case Directions.kRight:
                    _nextPosition = _transform.position + Vector3.right * (_distanceLength * 2);
                    break;
                case Directions.kForward:
                    _nextPosition = _transform.position + Vector3.forward * (_distanceLength * 2);
                    break;
                case Directions.kBack:
                    _nextPosition = _transform.position + Vector3.back * (_distanceLength * 2);
                    break;
            }

        }


        void Jump() {
            Debug.Log("Start Jump");
            if (_direction != Directions.kNone) {
                _transform.position = Vector3.MoveTowards(_transform.position,
                    _nextPosition,
                    Time.deltaTime * _movementSpeed);
            }

            _transform.position += _jumpSpeed * Time.deltaTime + _jumpAcceleration / 2 * Mathf.Pow(Time.deltaTime, 2);
            _jumpSpeed += _jumpAcceleration * Time.deltaTime;

            var distanceLeft = _jumpSpeed.y - _jumpAcceleration.y;
            // Debug.Log($"Jumping: {distanceLeft}");
            if (!(distanceLeft < Mathf.Epsilon)) return;

            _isJumping = false;
            // Debug.Log($"Jumping Completed: {distanceLeft}");
            //Reset Y position to ground level.
            var pos = _transform.position;
            pos.y = _groundY;
            _transform.position = pos;
        }
    }
}