using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : DefaultEnemyBehaviour
{
    public string EnemyName;

    private void OnEnable()
    {
        GetComponent<EnemyAI>().OnMovementInput.AddListener(SetMoveDirection);
        // ZoneManager.OnEnterSafeZone += () => PoolManager.Instance.enemyPooler[EnemyName].Release(this);
    }

    private void SetMoveDirection(Vector2 moveDir)
    {
        MovementInput = moveDir;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}