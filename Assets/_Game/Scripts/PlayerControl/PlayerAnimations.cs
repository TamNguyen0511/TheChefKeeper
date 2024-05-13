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

        public void PlayIdle()
        {
            _animator.CrossFade(PLAYER_IDLE, _transitionDuration);
        }

        public void PlayMove()
        {
            _animator.CrossFade(PLAYER_MOVE, _transitionDuration);
        }

        public void PlayRoll()
        {
            _animator.CrossFade(PLAYER_ROLL, _transitionDuration);
        }
    }
}