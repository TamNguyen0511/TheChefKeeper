using _Game.Scripts.Enums;
using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.World_Area.Enemy
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "Enemy/EnemySO", order = 0)]
    public class EnemySO : ScriptableObject
    {
        public EnemyType EnemyType;
        public float MaxMoveSpeed;

        public int MaxHP;

        public LayerMask AttackableLayers;

        public int AttackDamage;
        public float AttackRange;
        public float AttackRadius;
        public float AttackSpeed;

        public float Acceleration;
        public float Deacceleration;
    }
}