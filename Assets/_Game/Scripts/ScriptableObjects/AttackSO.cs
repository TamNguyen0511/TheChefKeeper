using _Game.Scripts.Helpers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.World_Area
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Player/Attack", order = 0)]
    public class AttackSO : ScriptableObject
    {
        [Title("Name of animation to use")] public string AttackName;
        [Title("Attack damage radius")] public Bounds AttackBounds;
        [Title("Offset of player")] public Vector3 BoundsOffset;
        [Title("Damage")] public int Damage;
        [Title("Damageable layers")] public LayerMask TargetLayer;
        [HideInInspector] public int NextComboIndex;
        public float ComboAttackTime;

        private Bounds GetBoundsRelativeToPlayer(Transform player, bool isFacingRight)
        {
            var bounds = AttackBounds;
            var xValue = isFacingRight ? 1 : -1;
            var offset = BoundsOffset;

            offset.x *= xValue;
            bounds.center = player.position + offset;

            return bounds;
        }

        public Collider[] Hit(Transform origin, bool isFacingRight)
        {
            var bounds = GetBoundsRelativeToPlayer(origin, isFacingRight);

            bounds.DrawBounds(1);

            return Physics.OverlapBox(bounds.center, bounds.extents / 2f, Quaternion.identity, TargetLayer);
        }
    }
}