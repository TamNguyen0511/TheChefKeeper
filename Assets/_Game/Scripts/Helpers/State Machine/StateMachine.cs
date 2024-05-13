using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Helpers.State_Machine
{
    public abstract class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private List<State<T>> _states;
        [Header("DEBUG")] [SerializeField] private bool _debug = true;

        private State<T> _activeState;
        private T _parent;

        #region Unity function

        protected virtual void Awake()
        {
            _parent = GetComponent<T>();
        }

        private void Start()
        {
            if (_states.Count <= 0) return;

            SetState(_states[0]);
        }

        protected virtual void Update()
        {
            _activeState?.Tick(Time.deltaTime);
            _activeState?.ChangeState();
        }

        private void FixedUpdate()
        {
            _activeState?.FixedTick(Time.fixedDeltaTime);
        }

        #endregion

        public void SetState(State<T> newStateType)
        {
            _activeState?.Exit();
            _activeState = newStateType;
            _activeState?.Enter(_parent);
        }

        public void SetState(Type newStateType)
        {
            var newState = _states.FirstOrDefault(s => s.GetType() == newStateType);
            if (newState)
            {
                SetState(newState);
            }
        }

        private void SetAnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            _activeState?.AnimationTriggerEvent(triggerType);
        }

        private void OnGUI()
        {
            if (!_debug) return;

            var content = _activeState != null ? _activeState.name : "(no active state)";
            GUILayout.Label($"<color='black><size=40>{content}</size></color>");
        }
    }
}