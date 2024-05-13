using _Game.Scripts.Helpers.State_Machine;
using _Game.Scripts.Interfaces;
using _Game.Scripts.ScriptableObjects.World_Area;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.SM
{
    [CreateAssetMenu(menuName = "States/Player/Attack")]
    public class PlayerAttackState : State<PlayerStateMachine>
    {
        [SerializeField] private AttackSO _attackData;

        #region State base

        public override void Enter(PlayerStateMachine parent)
        {
            base.Enter(parent);
            parent.Animations.PlayAttack(_attackData.AttackName);
        }

        public override void Tick(float deltaTime)
        {
        }

        public override void FixedTick(float fixedDeltaTime)
        {
        }

        public override void ChangeState()
        {
            if (_runner.Movement.sqrMagnitude != 0)
            {
                _runner.SetState(typeof(PlayerMove3DState));
            }
        }

        #endregion

        public override void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            base.AnimationTriggerEvent(triggerType);
            if (triggerType == AnimationTriggerType.FinishAttack)
            {
                if (_runner.AttackPressed)
                {
                    /// Next combo
                }
                else
                {
                    _runner.SetState(typeof(PlayerIdleState));
                }
            }

            if (triggerType != AnimationTriggerType.HitBox) return;

            var colliders = _attackData.Hit(_runner.transform, _runner.IsFacingRight);
            PerformDamage(colliders);
        }

        private void PerformDamage(Collider[] colliders)
        {
            if (colliders.Length <= 0) return;

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IDamageable damageable))
                    damageable.TakeHit(_attackData.Damage);
            }
        }
    }
}