using _Game.Scripts.Enums;
using _Game.Scripts.Items.Weapons;
using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.World_Area
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Items/Weapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        public string WeaponName;
        
        public WeaponType WeaponType;
        public int Damage;
        public LayerMask DamagableLayer;

        public Sprite WeaponIcon;
        public string WeaponDescription;
    }
}