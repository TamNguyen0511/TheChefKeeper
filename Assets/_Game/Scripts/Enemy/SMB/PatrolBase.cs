using UnityEngine;

namespace _Game.Scripts.Enemy.SMB
{
    public class PatrolBase : EnemySmbBase
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
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

            _enemyBehaviour.transform.position = Vector2.MoveTowards(_enemyBehaviour.transform.position,
                _enemyBehaviour.PatrollingPosition,
                _enemyBehaviour.DefaultEnemyStat.MaxMoveSpeed / 2 * Time.deltaTime);

            if (Vector2.Distance(_enemyBehaviour.transform.position, _enemyBehaviour.PatrollingPosition) < 0.2f)
            {
                animator.SetBool(_enemyBehaviour.ANIMATOR_PATROLLING_STATE, false);
            }
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