using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.ScriptableObjects.World_Area.Enemy;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DefaultEnemyBehaviour : MonoBehaviour
{
    public readonly string ANIMATOR_IDLE_STATE = "Idle";
    public readonly string ANIMATOR_PATROLLING_STATE = "Patrolling";
    public readonly string ANIMATOR_CHASE_STATE = "Chase";
    public readonly string ANIMATOR_ATTACK_STATE = "Attack";

    public EnemySO DefaultEnemyStat;
    public EnemyAI EnemyAI;
    public EnemyState CurrentState;
    public Rigidbody2D Rigidbody;
    public SpriteRenderer EnemySprite;
    public Animator Animator;

    [ShowInInspector, ReadOnly]
    public Vector2 MovementInput { get; set; }

    [SerializeField, ReadOnly] private float currentSpeed;
    [SerializeField, ReadOnly] private int _currentHP;

    [SerializeField] private List<Vector2> _allPatrollingPoints = new();

    private int _patrollingPointCounting = 0;
    private float _patrolWaitTime = 2;

    [HideInInspector] public Vector2 PatrollingPosition;
    [ReadOnly] public float CurrentPatrolWaitTime;

    protected virtual void Start()
    {
        _currentHP = DefaultEnemyStat.MaxHP;
        CurrentPatrolWaitTime = _patrolWaitTime;
        PatrollingPosition = _allPatrollingPoints[_patrollingPointCounting];
    }

    protected virtual void FixedUpdate()
    {
        // ChasePlayer();
    }

    protected virtual void Attack()
    {
    }

    protected virtual void TakeDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
            Dead("dead");
    }

    protected virtual void Dead(string deadAnimTrigger)
    {
        Animator.SetTrigger(deadAnimTrigger);
    }

    #region Test SMB

    public void ResetWaitingToPatrolTime()
    {
        _patrollingPointCounting++;
        if (_patrollingPointCounting >= _allPatrollingPoints.Count)
            _patrollingPointCounting = 0;

        PatrollingPosition = _allPatrollingPoints[_patrollingPointCounting % _allPatrollingPoints.Count];
        CurrentPatrolWaitTime = _patrolWaitTime;
    }

    public void ChasePlayer()
    {
        if (MovementInput.magnitude > 0 && currentSpeed >= 0)
        {
            currentSpeed += DefaultEnemyStat.Acceleration * DefaultEnemyStat.MaxMoveSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= DefaultEnemyStat.Deacceleration * DefaultEnemyStat.MaxMoveSpeed * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, DefaultEnemyStat.MaxMoveSpeed);
        Rigidbody.velocity = MovementInput * currentSpeed;
    }

    #endregion
}