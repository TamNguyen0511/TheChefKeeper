using UnityEngine;

namespace _Game.Scripts.Enemy.SMB
{
    public class IdleBase : EnemySmbBase
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _enemyBehaviour.ResetWaitingToPatrolTime();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_enemyBehaviour.EnemyAI.AIData.CurrentTarget != null)
            {
                animator.SetBool(_enemyBehaviour.ANIMATOR_CHASE_STATE, true);
                return;
            }

            _enemyBehaviour.CurrentPatrolWaitTime -= Time.deltaTime;

            if (_enemyBehaviour.CurrentPatrolWaitTime <= 0)
                animator.SetBool(_enemyBehaviour.ANIMATOR_PATROLLING_STATE, true);
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }
    }
}