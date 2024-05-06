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