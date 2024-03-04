using _Game.Scripts.Interfaces;
using _Game.Scripts.ScriptableObjects.World_Area;
using UnityEngine;

namespace _Game.Scripts.Items.Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public WeaponSO WeaponInfo;
        public Animator WeaponAnim;

        public string AttackAnimTrigger;

        #region IWeapon

        public virtual void Attack()
        {
        }

        public virtual void HoldAttack()
        {
            
        }

        #endregion
    }
}