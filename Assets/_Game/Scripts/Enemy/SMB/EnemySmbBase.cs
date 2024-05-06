using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Enemy.SMB
{
    public class EnemySmbBase : StateMachineBehaviour
    {
        [SerializeField, ReadOnly] protected DefaultEnemyBehaviour _enemyBehaviour;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_enemyBehaviour == null)
            {
                if (animator.GetComponent<DefaultEnemyBehaviour>())
                    _enemyBehaviour = animator.GetComponent<DefaultEnemyBehaviour>();
                else if (animator.transform.parent.GetComponent<DefaultEnemyBehaviour>())
                    _enemyBehaviour = animator.transform.parent.GetComponent<DefaultEnemyBehaviour>();
            }
        }

        // public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
        //     int layerIndex)
        // {
        // }
        //
        // public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
        //     int layerIndex)
        // {
        // }
        //
        // public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo,
        //     int layerIndex)
        // {
        // }
        //
        // public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo,
        //     int layerIndex)
        // {
        // }
    }
}