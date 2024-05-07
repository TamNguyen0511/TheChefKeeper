using System;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.Interfaces;
using _Game.Scripts.ScriptableObjects.Items;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Game.Scripts.PlayerControl
{
    public class PlayerWeaponControl : MonoBehaviour
    {
        public WeaponSO CurrentUsingWeaponData;
        public List<WeaponDataWithAnimAndAttackPoint> WeaponDatas = new();
        
        [SerializeField] private Transform _attackTriggerPoint;

        [SerializeField] private float _attackRange;

        [SerializeField] private float _startTimeBetweenAttack;

        private float _timeBetweenAttack;

        private void OnEnable()
        {
            _startTimeBetweenAttack = CurrentUsingWeaponData.AttackSpeed;
        }

        public void Attack()
        {
            switch (CurrentUsingWeaponData.WeaponType)
            {
                case WeaponType.None:
                    break;
                case WeaponType.Tool:
                    break;
                case WeaponType.Melee:

                    if (_timeBetweenAttack > 0)
                    {
                        _timeBetweenAttack -= Time.deltaTime;
                        return;
                    }

                    // WeaponAnim.SetTrigger(AttackAnimTrigger);
                    Collider2D[] hitteds =
                        Physics2D.OverlapCircleAll(_attackTriggerPoint.position, _attackRange,
                            CurrentUsingWeaponData.DamagableLayer);
                    if (hitteds.Length <= 0)
                    {
                        _timeBetweenAttack = _startTimeBetweenAttack;
                        return;
                    }

                    foreach (Collider2D hit in hitteds)
                        if (hit.GetComponent<IDamageable>() != null)
                            hit.GetComponent<IDamageable>().TakeHit(CurrentUsingWeaponData.BaseDamage);

                    _timeBetweenAttack = _startTimeBetweenAttack;

                    break;
                case WeaponType.Range:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    [System.Serializable]
    public class WeaponDataWithAnimAndAttackPoint
    {
        public WeaponSO Weapon;
        public Animator WeaponAnim;
        public string TriggerAnim = "Attack";
        public Transform AttackPoint;
    }
}