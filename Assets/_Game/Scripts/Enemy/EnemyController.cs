using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : DefaultEnemyBehaviour
{
    public string EnemyName;

    private void OnEnable()
    {
        EnemyAI.OnMovementInput.AddListener(ChasePlayer);
        // ZoneManager.OnEnterSafeZone += () => PoolManager.Instance.enemyPooler[EnemyName].Release(this);
    }

    private void ChasePlayer(Vector2 moveDir)
    {
        if (CurrentState != EnemyState.Chase)
        {
            Animator.SetTrigger(ANIMATOR_CHASE_STATE);
            ChangeState(EnemyState.Chase);
        }

        MovementInput = moveDir;
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}