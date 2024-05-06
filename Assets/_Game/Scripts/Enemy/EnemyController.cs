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
        // EnemyAI.OnMovementInput.AddListener(ChasePlayer);
        // ZoneManager.OnEnterSafeZone += () => PoolManager.Instance.enemyPooler[EnemyName].Release(this);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}