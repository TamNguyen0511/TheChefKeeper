using _Game.Scripts.Helpers.State_Machine;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.SM
{
    [CreateAssetMenu(menuName = "States/Player/Move")]
    public class PlayerMoveState : State<PlayerStateMachine>
    {
        [SerializeField] [Range(0f, 50f)] private float _speed = 25f;
        private Vector2 _playerInput;

        #region State base

        public override void Tick(float deltaTime)
        {
            _playerInput = _runner.Movement;
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            var speedMultiplier = 10;
            _runner.Move(_playerInput * (_speed * speedMultiplier * fixedDeltaTime));
        }

        public override void ChangeState()
        {
            if (_playerInput.sqrMagnitude > 0.1f) return;

            _runner.SetState(typeof(PlayerIdleState));
        }

        #endregion
    }
}