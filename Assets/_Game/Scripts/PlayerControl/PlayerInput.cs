using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Game.Scripts.PlayerControl
{
    public class PlayerInput : MonoBehaviour, GameControls.IPlayerActions
    {
        public event UnityAction<Vector2> MovementEvent = delegate { };
        public event UnityAction RollEvent = delegate { };
        public event UnityAction RollCancelledEvent = delegate { };
        public event UnityAction<bool> AttackEvent = delegate { };
        private GameControls _playerActions;

        #region Unity functions

        private void OnEnable()
        {
            if (_playerActions == null)
            {
                _playerActions = new GameControls();
                _playerActions.Player.SetCallbacks(this);
            }

            EnableGameplayInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        #endregion

        private void DisableAllInput()
        {
            _playerActions.Player.Disable();
        }

        private void EnableGameplayInput()
        {
            if (_playerActions.Player.enabled) return;

            _playerActions.Player.Enable();
        }

        #region IPlayerActions

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
        }

        public void OnAction(InputAction.CallbackContext context)
        {
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
                AttackEvent?.Invoke(true);
            else if (context.canceled)
                AttackEvent?.Invoke(false);
        }

        public void OnToggleInventory(InputAction.CallbackContext context)
        {
        }

        public void OnRoll(InputAction.CallbackContext context)
        {
            if (context.performed)
                RollEvent?.Invoke();
            if (context.canceled)
                RollCancelledEvent?.Invoke();
        }

        #endregion
    }
}