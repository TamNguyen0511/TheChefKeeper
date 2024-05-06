using UnityEngine;

namespace _Game.Scripts.Enemy.SMB
{
    public class ChaseBase : EnemySmbBase
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _enemyBehaviour.EnemyAI.OnMovementInput.AddListener(ChasePlayer);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _enemyBehaviour.EnemyAI.OnMovementInput.RemoveListener(ChasePlayer);
            _enemyBehaviour.ChasePlayer();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_enemyBehaviour.EnemyAI.AIData.CurrentTarget == null)
            {
                animator.SetBool(_enemyBehaviour.ANIMATOR_CHASE_STATE, false);
                return;
            }

            _enemyBehaviour.ChasePlayer();
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        private void ChasePlayer(Vector2 moveDir)
        {
            _enemyBehaviour.MovementInput = moveDir;
        }
    }
}