using System;
using _Game.Scripts.Helpers;
using _Game.Scripts.Helpers.State_Machine;
using _Game.Scripts.Interfaces;
using _Game.Scripts.ScriptableObjects.World_Area;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.SM
{
    [CreateAssetMenu(menuName = "States/Player/Attack")]
    public class PlayerAttackState : State<PlayerStateMachine>
    {
        [SerializeField] private AttackSO[] _attackDatas;

        private int _currentAttackIndex;
        private AttackSO _attackData;
        private float _previousFrameTime;

        private void OnValidate()
        {
            for (int i = 0; i < _attackDatas.Length; i++)
            {
                if (i == _attackDatas.Length - 1)
                    _attackDatas[i].NextComboIndex = 0;
                else
                    _attackDatas[i].NextComboIndex = i + 1;
            }
        }

        #region State base

        public override void Enter(PlayerStateMachine parent)
        {
            base.Enter(parent);
            _attackData = _attackDatas[_currentAttackIndex];
            parent.Animations.PlayAttack(_attackData.AttackName);
        }

        public override void Tick(float deltaTime)
        {
            var normalizeTime = _runner.Animations.GetNormalizedTime();

            if (normalizeTime >= _previousFrameTime && normalizeTime < 1)
            {
                if (_runner.AttackPressed)
                {
                    TryComboAttack(normalizeTime);
                }
            }
            else
            {
                _runner.SetState(typeof(PlayerIdleState));
            }

            _previousFrameTime = normalizeTime;
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

        private void TryComboAttack(float normalizedTime)
        {
            if (normalizedTime < _attackData.ComboAttackTime) return;

            var newCombo = this.Clone();
            newCombo._currentAttackIndex = _attackData.NextComboIndex;

            _runner.SetState(newCombo);
        }
    }
}