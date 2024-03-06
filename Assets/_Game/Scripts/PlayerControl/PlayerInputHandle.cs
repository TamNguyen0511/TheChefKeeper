using System;
using _Game.Scripts.Interfaces.InterfaceActors;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game.Scripts.PlayerControl
{
    public class PlayerInputHandle : Interactor
    {
        #region Serializable variable

        public CharacterMovement CharacterMovement;

        [SerializeField]
        private Transform _orbitHolder;

        private Vector2 _moveInput;
        [ShowInInspector, ReadOnly]
        private Vector2 _mousePosition;

        #endregion

        public Action OnAttackPress;

        #region Unity functions

        private void Start()
        {
            if (CharacterMovement == null && GetComponent<CharacterMovement>() != null)
                CharacterMovement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            CharacterMovement.SetInputVector(_moveInput);
            UpdateOrbitRotatePoint(Camera.main.ScreenToWorldPoint(_mousePosition));
        }

        #endregion

        #region Input system functions

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
                    InteractAction();
                    break;
                case InputActionPhase.Canceled:
                    break;
            }
        }

        public void OnAction(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
                    Debug.Log("Action perform");
                    ActionPerform();
                    break;
                case InputActionPhase.Canceled:
                    Debug.Log("Action cancel");
                    ActionCancel();
                    break;
            }
        }

        public void OnMouseMoving(InputAction.CallbackContext context)
        {
            _mousePosition = context.ReadValue<Vector2>();
        }

        public void OnMouseClick(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    break;
                case InputActionPhase.Waiting:
                    break;
                case InputActionPhase.Started:
                    AttackPressed();
                    break;
                case InputActionPhase.Performed:
                    break;
                case InputActionPhase.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnInventoryBtnClick(InputAction.CallbackContext context)
        {
            GameManager.Instance.ToggleInventoryUI();
        }

        #endregion

        #region Local functions

        private void UpdateOrbitRotatePoint(Vector3 target)
        {
            Vector2 lookDirection = target - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            _orbitHolder.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        private void AttackPressed()
        {
            OnAttackPress?.Invoke();
        }

        #endregion
    }
}