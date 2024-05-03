using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.ScriptableObjects.World_Area.Enemy;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class DefaultEnemyBehaviour : MonoBehaviour
{
    public const string ANIMATOR_IDLE_STATE = "Idle";
    public const string ANIMATOR_PATROLLING_STATE = "Patrolling";
    public const string ANIMATOR_CHASE_STATE = "Chase";
    public const string ANIMATOR_ATTACK_STATE = "Attack";

    public EnemySO DefaultEnemyStat;
    public EnemyAI EnemyAI;
    public EnemyState CurrentState;
    public Rigidbody2D Rigidbody;
    public SpriteRenderer EnemySprite;
    public Animator Animator;

    [ShowInInspector]
    public Vector2 MovementInput { get; set; }

    [SerializeField] private float currentSpeed;
    private int _currentHP;

    [SerializeField] private List<Vector2> _allPatrollingPoints = new();
    [SerializeField] private Vector2 _patrollingPosition;
    private int _patrollingPointCounting = 0;
    private float _patrolWaitTime = 2;
    [SerializeField] private float _currentPatrolWaitTime;

    protected virtual void Start()
    {
        _currentHP = DefaultEnemyStat.MaxHP;
        _currentPatrolWaitTime = _patrolWaitTime;
        _patrollingPosition = _allPatrollingPoints[_patrollingPointCounting];
    }

    // private void Update()
    // {
    //     if (CurrentState != EnemyState.Patrolling) return;
    //
    //     transform.position = Vector2.MoveTowards(transform.position, _patrollingPosition,
    //         DefaultEnemyStat.MaxMoveSpeed / 2 * Time.deltaTime);
    //
    //     if (Vector2.Distance(transform.position, _patrollingPosition) < 0.2f)
    //     {
    //         if (_currentPatrolWaitTime <= 0)
    //         {
    //             _patrollingPosition = _allPatrollingPoints[_patrollingPointCounting % _allPatrollingPoints.Count];
    //             _currentPatrolWaitTime = _patrolWaitTime;
    //         }
    //         else
    //         {
    //             _currentPatrolWaitTime -= Time.deltaTime;
    //             Animator.SetTrigger(ANIMATOR_IDLE_STATE);
    //             _patrollingPointCounting++;
    //         }
    //     }
    //     else
    //     {
    //         Animator.SetTrigger(ANIMATOR_PATROLLING_STATE);
    //     }
    // }

    protected virtual void FixedUpdate()
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

    public virtual async void ChangeState(EnemyState newState)
    {
        CurrentState = CurrentState == newState ? CurrentState : newState;
    }

    // private void ChasePlayer(Vector2 moveDir)
    // {
    //     MovementInput = moveDir;
    //     Debug.Log("Getted here");
    //     Animator.SetTrigger(ANIMATOR_CHASE_STATE);
    // }

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
}