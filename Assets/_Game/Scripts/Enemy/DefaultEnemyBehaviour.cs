using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.Interfaces;
using _Game.Scripts.ScriptableObjects.World_Area.Enemy;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DefaultEnemyBehaviour : MonoBehaviour, IDamageable
{
    public readonly string ANIMATOR_PATROLLING_STATE = "Patrolling";
    public readonly string ANIMATOR_CHASE_STATE = "Chase";
    public readonly string ANIMATOR_ATTACK_STATE = "Attack";

    public EnemySO DefaultEnemyStat;
    public EnemyAI EnemyAI;
    public SpriteRenderer EnemySprite;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _attackPoint;

    public Vector2 MovementInput { get; set; }

    [Title("Debug + checking")] [SerializeField, ReadOnly]
    private float currentSpeed;

    [SerializeField, ReadOnly] private int _currentHP;

    [SerializeField] private List<Vector2> _allPatrollingPoints = new();

    private int _patrollingPointCounting = 0;
    private float _patrolWaitTime = 2;

    [HideInInspector] public Vector2 PatrollingPosition;
    [HideInInspector] public float CurrentPatrolWaitTime;

    protected virtual void OnEnable()
    {
        _currentHP = DefaultEnemyStat.MaxHP;
        CurrentPatrolWaitTime = _patrolWaitTime;
        PatrollingPosition = _allPatrollingPoints[_patrollingPointCounting];
    }

    public virtual void Attack()
    {
        Vector2 targetPosition = EnemyAI.AIData.CurrentTarget.position;
        var attackAngle = Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x);
        _attackPoint.position = new Vector2(Mathf.Cos(attackAngle), Mathf.Sin(attackAngle));

        Collider2D[] hit = Physics2D.OverlapCircleAll(_attackPoint.position, DefaultEnemyStat.AttackRadius,
            DefaultEnemyStat.AttackableLayers);
        if (hit.Length <= 0) return;

        foreach (Collider2D hitObject in hit)
        {
            if (hitObject.GetComponent<IDamageable>() != null)
            {
                hitObject.GetComponent<IDamageable>().TakeHit(DefaultEnemyStat.AttackDamage);
            }
        }
    }

    protected virtual void Dead(string deadAnimTrigger)
    {
        _animator.SetTrigger(deadAnimTrigger);
        gameObject.SetActive(false);
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
        _rigidbody.velocity = MovementInput * currentSpeed;
    }

    #endregion

    public bool TakeHit(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Dead("dead");
            return true;
        }

        return false;
    }
}