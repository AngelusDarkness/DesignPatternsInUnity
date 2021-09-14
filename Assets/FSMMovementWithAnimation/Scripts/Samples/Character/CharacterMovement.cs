using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSMMovementWithAnimation {
    public class CharacterMovement : MonoBehaviour {
        
        
        [SerializeField] private Animator _animator;
        
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _step = 1;
        
        [SerializeField] private float _jumpHeight = 3;
        [SerializeField] private float _distanceLength = 3;

        private int _scaleKey = 0;
        private int _colorKey = 0;

        
        public Directions direction { set; get; }
        public float Speed => _speed;
        public float Step => _step;

        public float JumpHeight => _jumpHeight;
        public float DistanceLength => _distanceLength;
        public bool IsMoving { set; get; }
        public bool CanMove { set; get; }
        public bool IsJumping { set; get; }

        private void Start()
        {
            _scaleKey = Animator.StringToHash("Scale");
            _colorKey = Animator.StringToHash("Color");
        }
        

        public void ChangeScale(bool value)
        {
            _animator.SetBool(_scaleKey, value);
        }
        
        public void ChangeColor(bool value)
        {
            _animator.SetBool(_colorKey, value);
        }
        
        
    }    

}

