using System;
using _Game.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.PlayerControl
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10f)]
        private float _moveSpeed;

        [SerializeField]
        private Animator _characterAnimator;
        [SerializeField]
        private Transform _visualBody;

        #region Local variable

        private Rigidbody2D _rb;

        private CharacterState _currentCharacterState;
        private bool _isWalking;
        private bool _isFacingLeft;
        [SerializeField,ReadOnly]
        private Vector2 _inputVector;
        private Vector2 _lastInputVector;

        #endregion

        private void Start()
        {
            if (_rb == null && GetComponent<Rigidbody2D>() != null)
            {
                _rb = GetComponent<Rigidbody2D>();
            }
        }

        private void Update()
        {
            AnimationHandle();
            // if (_inputVector.x < 0 && !_isFacingLeft || _inputVector.x > 0 && _isFacingLeft)
            //     Flip();
        }

        private void FixedUpdate()
        {
            HandleMovement(_inputVector);
        }

        public void SetInputVector(Vector2 inputVector)
        {
            _inputVector = inputVector;
        }

        #region Local functions

        private void HandleMovement(Vector2 moveInput)
        {
            _rb.MovePosition(_rb.position + (moveInput * _moveSpeed * Time.fixedDeltaTime));
        }

        private void AnimationHandle()
        {
            _characterAnimator.SetFloat("MoveX", _inputVector.x);
            _characterAnimator.SetFloat("MoveY", _inputVector.y);
            _characterAnimator.SetFloat("MoveMagnitude", _inputVector.magnitude);
        }

        private void Flip()
        {
            Vector3 scale = _visualBody.localScale;
            scale.x *= -1;
            _visualBody.localScale = scale;
            _isFacingLeft = !_isFacingLeft;
        }

        #endregion
    }
}