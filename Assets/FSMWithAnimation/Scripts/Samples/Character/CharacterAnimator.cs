using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSMWithAnimation
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private int _scaleKey = 0;
        private int _colorKey = 0;

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

