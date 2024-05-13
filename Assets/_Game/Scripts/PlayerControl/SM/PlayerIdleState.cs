using _Game.Scripts.Helpers.State_Machine;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.SM
{
    [CreateAssetMenu(menuName = "States/Player/Idle")]
    public class PlayerIdleState : State<PlayerStateMachine>
    {
        public override void Enter(PlayerStateMachine parent)
        {
            base.Enter(parent);
            _runner.Move(Vector2.zero);
            parent.Animations.PlayIdle();
        }

        #region State base

        public override void Tick(float deltaTime)
        {
        }

        public override void FixedTick(float fixedDeltaTime)
        {
        }

        public override void ChangeState()
        {
            if (_runner.AttackPressed)
            {
                _runner.SetState(typeof(PlayerAttackState));
                return;
            }

            if (_runner.Movement.sqrMagnitude != 0)
                _runner.SetState(typeof(PlayerMove3DState));
        }

        #endregion
    }
}