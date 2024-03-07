using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.Items;
using _Game.Scripts.Items.Weapons;
using _Game.Scripts.ScriptableObjects.World_Area;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.PlayerControl
{
    [RequireComponent(typeof(PlayerInputHandle))]
    public class CharacterController : Interactor
    {
        
        [ShowInInspector, ReadOnly]
        private PlayerInputHandle _playerInput;

        private void OnEnable()
        {
            _playerInput = GetComponent<PlayerInputHandle>();
            _playerInput.OnAttackPress += Attack;
        }

        private void OnDisable()
        {
            _playerInput.OnAttackPress -= Attack;
        }

        private void Attack()
        {
            if (SelectingItem != null)
            {
                Weapon weapon = SelectingItem as Weapon;
                if (weapon != null)
                {
                    weapon.Attack();
                }
            }
            else InteractAction();
        }
    }
}