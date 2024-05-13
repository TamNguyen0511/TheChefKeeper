using _Game.Scripts.Helpers.State_Machine;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.SM
{
    [CreateAssetMenu(menuName = ("States/Player/Roll"))]
    public class PlayerRollState : State<PlayerStateMachine>
    {
        [SerializeField] private float _rollSpeed = 50f;
        [SerializeField] private float _rollTime = .5f;

        [Header("DEBUG")] [SerializeField] private bool _debug = true;

        private Vector3 _movementDirection;
        private float _elapsedTime;

        public override void Enter(PlayerStateMachine parent)
        {
            base.Enter(parent);
            
            parent.Animations.PlayRoll();

            var playerInput = new Vector3(parent.Movement.normalized.x, 0, parent.Movement.normalized.y);

            _elapsedTime = 0f;

            var startingPos = parent.transform.position;
            _movementDirection = startingPos + playerInput * _rollSpeed;

            if (!_debug) return;

            Debug.DrawLine(startingPos, _movementDirection,
                Color.red, 0.2f);
        }

        #region State base

        public override void Tick(float deltaTime)
        {
            _elapsedTime += deltaTime;
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            if (!(_elapsedTime < _rollTime)) return;

            // each fixed frame we move a fraction towards the end value
            _runner.Move(_movementDirection * (_elapsedTime / _rollTime));
        }

        public override void ChangeState()
        {
            if (_elapsedTime >= _rollTime)
            {
                _runner.SetState(typeof(PlayerIdleState));
            }
        }

        #endregion
    }
}