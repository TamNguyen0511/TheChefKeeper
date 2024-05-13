using System;
using _Game.Scripts.Helpers.State_Machine;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.SM
{
    public class PlayerStateMachine : StateMachine<PlayerStateMachine>
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _spriteTransform;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Vector2 Movement { get; private set; }
        private bool _isFacingRight = true;

        #region Unity functions

        private void OnEnable()
        {
            _playerInput.MovementEvent += HandleMove;
        }

        private void OnDisable()
        {
            _playerInput.MovementEvent -= HandleMove;
        }

        #endregion

        private void HandleMove(Vector2 movement)
        {
            Movement = movement;
            CheckFlipSprite(movement);
        }

        private void CheckFlipSprite(Vector2 velocity)
        {
            if ((!(velocity.x > 0f) || _isFacingRight) && (!(velocity.x < 0f) || !_isFacingRight)) return;

            _isFacingRight = !_isFacingRight;
            _spriteTransform.Rotate(_spriteTransform.rotation.x, 180f, _spriteTransform.rotation.z);
        }

        public void Move(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }
    }
}