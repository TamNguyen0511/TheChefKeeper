using System;
using _Game.Scripts.Helpers.State_Machine;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.SM
{
    public class PlayerStateMachine : StateMachine<PlayerStateMachine>
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _spriteTransform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;

        public PlayerAnimations Animations { get; private set; }
        public Vector2 Movement { get; private set; }
        public bool AttackPressed => _attackPressed;
        private bool _attackPressed;
        public bool IsFacingRight => _isFacingRight;
        private bool _isFacingRight = true;

        public bool RollPressed => _rollPressed;
        private bool _rollPressed;

        #region Unity functions

        protected override void Awake()
        {
            base.Awake();
            Animations = new PlayerAnimations(_animator);
        }

        private void OnEnable()
        {
            _playerInput.MovementEvent += HandleMove;
            _playerInput.RollEvent += HandleRoll;
            _playerInput.RollCancelledEvent += HandleCancelledRoll;
            _playerInput.AttackEvent += HandleAttack;
        }

        private void OnDisable()
        {
            _playerInput.MovementEvent -= HandleMove;
            _playerInput.RollEvent -= HandleRoll;
            _playerInput.RollCancelledEvent -= HandleCancelledRoll;
            _playerInput.AttackEvent -= HandleAttack;
        }

        #endregion

        private void HandleMove(Vector2 movement)
        {
            Movement = movement;
            CheckFlipSprite(movement);
        }

        private void HandleRoll()
        {
            _rollPressed = true;
        }

        private void HandleCancelledRoll()
        {
            _rollPressed = false;
        }

        private void HandleAttack(bool isPressed)
        {
            _attackPressed = isPressed;
        }

        private void CheckFlipSprite(Vector2 velocity)
        {
            if ((!(velocity.x > 0f) || _isFacingRight) && (!(velocity.x < 0f) || !_isFacingRight)) return;

            _isFacingRight = !_isFacingRight;
            _spriteTransform.Rotate(_spriteTransform.rotation.x, 180f, _spriteTransform.rotation.z);
        }

        public void Move(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }
    }
}