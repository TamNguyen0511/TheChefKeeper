using UnityEngine;

namespace _Game.Scripts.PlayerControl
{
    public class PlayerAnimations
    {
        private Animator _animator;

        private readonly int PLAYER_IDLE = Animator.StringToHash("Idle");
        private readonly int PLAYER_MOVE = Animator.StringToHash("Move");
        private readonly int PLAYER_ROLL = Animator.StringToHash("Roll");

        private float _transitionDuration = .1f;

        public PlayerAnimations(Animator animator)
        {
            _animator = animator;
        }

        public float GetNormalizedTime()
        {
            var currentInfo = _animator.GetCurrentAnimatorStateInfo(0);
            var nextInfo = _animator.GetNextAnimatorStateInfo(0);

            if (_animator.IsInTransition(0)&& nextInfo.IsTag("Attack"))
                return nextInfo.normalizedTime;
            if (!_animator.IsInTransition(0) && currentInfo.IsTag("Attack"))
                return currentInfo.normalizedTime;

            return 0f;
        }

        public void PlayIdle()
        {
            _animator.CrossFadeInFixedTime(PLAYER_IDLE, _transitionDuration);
        }

        public void PlayMove()
        {
            _animator.CrossFadeInFixedTime(PLAYER_MOVE, _transitionDuration);
        }

        public void PlayRoll()
        {
            _animator.CrossFadeInFixedTime(PLAYER_ROLL, _transitionDuration);
        }

        public void PlayAttack(string attackName)
        {
            _animator.CrossFadeInFixedTime(attackName, _transitionDuration);
        }
    }
}