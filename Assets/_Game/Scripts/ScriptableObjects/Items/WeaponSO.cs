using _Game.Scripts.Enums;
using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.Items
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        [Header("Weapon fields")]
        public WeaponType WeaponType;
        public float BaseDamage;
        public float AttackSpeed;
        public float ReloadSpeed;
    }
}