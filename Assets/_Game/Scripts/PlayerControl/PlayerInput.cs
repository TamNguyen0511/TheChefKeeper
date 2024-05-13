using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Game.Scripts.PlayerControl
{
    public class PlayerInput : MonoBehaviour, GameControls.IPlayerActions
    {
        public event UnityAction<Vector2> MovementEvent = delegate { };
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
            throw new System.NotImplementedException();
        }

        public void OnAction(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnToggleInventory(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}