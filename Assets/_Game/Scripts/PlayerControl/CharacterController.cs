using _Game.Scripts.Items.Weapons;
using _Game.Scripts.ScriptableObjects.World_Area;
using UnityEngine;

namespace _Game.Scripts.PlayerControl
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private PlayerInputHandle _playerInputHandle;
        [SerializeField]
        private Weapon _equipingWeapon;

        private void OnEnable()
        {
            if (_playerInputHandle == null && GetComponent<PlayerInputHandle>() != null)
                _playerInputHandle = GetComponent<PlayerInputHandle>();

            _playerInputHandle.OnAttackPress += Attack;
        }

        private void OnDisable()
        {
            _playerInputHandle.OnAttackPress -= Attack;
        }

        private void Attack()
        {
            if (_equipingWeapon != null)
                _equipingWeapon.Attack();
            else _playerInputHandle.InteractAction();
        }
    }
}