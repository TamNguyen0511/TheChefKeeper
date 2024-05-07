using _Game.Scripts.Enums;
using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.Items
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon", order = 0)]
    public class WeaponSO : BaseItemSO
    {
        [Header("Weapon fields")] public WeaponType WeaponType;

        public LayerMask DamagableLayer;
        public int BaseDamage;
        public float AttackSpeed;
        public float ReloadSpeed;
    }
}