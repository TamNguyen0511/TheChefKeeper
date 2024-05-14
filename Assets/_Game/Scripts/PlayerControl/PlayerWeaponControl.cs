using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Enums;
using _Game.Scripts.Interfaces;
using _Game.Scripts.ScriptableObjects.Items;
using UnityEngine;
using Sirenix.OdinInspector;

namespace _Game.Scripts.PlayerControl
{
    public class PlayerWeaponControl : MonoBehaviour
    {
        public List<WeaponDataWithAnimAndAttackPoint> WeaponDatas = new();
        [ReadOnly] public WeaponSO CurrentUsingWeaponData;

        [SerializeField] private Transform _attackTriggerPoint;

        [SerializeField, Range(0f, 5f)] private float _attackRange;

        [SerializeField] private float _startTimeBetweenAttack;

        private float _timeBetweenAttack;

        private void OnEnable()
        {
            if (CurrentUsingWeaponData == null) return;
            _startTimeBetweenAttack = CurrentUsingWeaponData.AttackSpeed;
        }

        public void Attack()
        {
            var weaponData = GetCurrentWeaponData();
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

                    weaponData.WeaponAnim.SetTrigger(weaponData.TriggerAnim);
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

        private WeaponDataWithAnimAndAttackPoint GetCurrentWeaponData()
        {
            return WeaponDatas.FirstOrDefault(w => w.Weapon == CurrentUsingWeaponData);
        }
    }

    [System.Serializable]
    public class WeaponDataWithAnimAndAttackPoint
    {
        [PreviewField(90), HideLabel, HorizontalGroup("Split", 120)]
        public WeaponSO Weapon;

        [VerticalGroup("Split/Right")] public Animator WeaponAnim;
        [VerticalGroup("Split/Right")] public string TriggerAnim = "Attack";
        [VerticalGroup("Split/Right")] public Transform AttackPoint;
    }
}