using System;
using _Game.Scripts.Enums;
using _Game.Scripts.Interfaces;
using _Game.Scripts.ScriptableObjects.Items;
using _Game.Scripts.ScriptableObjects.World_Area;
using _Game.Scripts.Systems.Drag_and_Drop;
using UnityEngine;

namespace _Game.Scripts.Items.Weapons
{
    public class Weapon : InventoryItem, IWeapon
    {
        public Animator WeaponAnim;

        public string AttackAnimTrigger;

        [SerializeField] private Transform _attackTriggerPoint;

        [SerializeField] private float _attackRange;

        [SerializeField] private float _startTimeBetweenAttack;
        private float _timeBetweenAttack;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            WeaponSO weaponInfo = BaseItemData as WeaponSO;
            if (weaponInfo == null) return;
            
            _startTimeBetweenAttack = weaponInfo.AttackSpeed;
        }

        private void Update()
        {
            if (_timeBetweenAttack <= 0) return;
            _timeBetweenAttack -= Time.deltaTime;
        }

        #region IWeapon

        public virtual void Attack()
        {
            WeaponSO weaponInfo = BaseItemData as WeaponSO;
            if (weaponInfo == null) return;
            switch (weaponInfo.WeaponType)
            {
                case WeaponType.None:
                    break;
                case WeaponType.Tool:
                    break;
                case WeaponType.Melee:
                    if (_timeBetweenAttack <= 0)
                    {
                        WeaponAnim.SetTrigger(AttackAnimTrigger);
                        Collider2D[] hitteds =
                            Physics2D.OverlapCircleAll(_attackTriggerPoint.position, _attackRange,
                                weaponInfo.DamagableLayer);
                        if (hitteds.Length > 0)
                            foreach (Collider2D hit in hitteds)
                                if (hit.GetComponent<IDamageable>() != null)
                                    hit.GetComponent<IDamageable>().TakeHit(weaponInfo.BaseDamage);

                        _timeBetweenAttack = _startTimeBetweenAttack;
                    }
                    else
                        _timeBetweenAttack -= Time.deltaTime;

                    break;
                case WeaponType.Range:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void HoldAttack()
        {
        }

        #endregion

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackTriggerPoint.position, _attackRange);
        }
    }
}