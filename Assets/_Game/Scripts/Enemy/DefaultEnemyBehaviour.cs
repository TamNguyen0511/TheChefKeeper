using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.ScriptableObjects.World_Area.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;

public class DefaultEnemyBehaviour : MonoBehaviour
{
    public EnemySO DefaultEnemyStat;
    public EnemyAI EnemyAI;
    public EnemyState CurrentState;
    public Rigidbody2D Rigidbody;
    public SpriteRenderer EnemySprite;
    public Animator Animator;
    [ShowInInspector]
    public Vector2 MovementInput { get; set; }

    [SerializeField]
    private float currentSpeed;
    private int _currentHP;

    protected virtual void Start()
    {
        _currentHP = DefaultEnemyStat.MaxHP;
    }

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

    public virtual void StateHandle()
    {
        switch (CurrentState)
        {
            case EnemyState.Chase:
                break;
        }
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
}