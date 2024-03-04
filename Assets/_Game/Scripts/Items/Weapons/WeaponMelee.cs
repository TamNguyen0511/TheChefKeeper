using System;
using _Game.Scripts.PlayerControl.Enemies;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Items.Weapons
{
    public class WeaponMelee : Weapon
    {
        [SerializeField]
        private Transform _attackTriggerPoint;

        [SerializeField]
        private float _attackRange;

        [SerializeField]
        private float _timeBetweenAttack;
        [SerializeField]
        private float _startTimeBetweenAttack;

        private void Update()
        {
            if (_timeBetweenAttack <= 0) return;
            _timeBetweenAttack -= Time.deltaTime;
        }

        public override void Attack()
        {
            if (_timeBetweenAttack <= 0)
            {
                WeaponAnim.SetTrigger(AttackAnimTrigger);
                Collider2D[] hitteds =
                    Physics2D.OverlapCircleAll(_attackTriggerPoint.position, _attackRange, WeaponInfo.DamagableLayer);
                if (hitteds.Length > 0)
                    foreach (Collider2D hit in hitteds)
                    {
                        if (hit.GetComponent<Enemy>() != null)
                        {
                            hit.GetComponent<Enemy>().TakeDamage(WeaponInfo.Damage);
                        }
                    }

                _timeBetweenAttack = _startTimeBetweenAttack;
            }
            else
                _timeBetweenAttack -= Time.deltaTime;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackTriggerPoint.position, _attackRange);
        }
    }
}