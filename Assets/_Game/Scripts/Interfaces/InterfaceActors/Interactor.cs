using _Game.Scripts.Interfaces.InterfaceHelper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Interfaces.InterfaceActors
{
    public class Interactor : MonoBehaviour
    {
                #region Serialize variables

        [SerializeField]
        private Transform _interactionPoint;
        [SerializeField]
        private float _interactionPointRadius = 0.5f;
        [SerializeField]
        private LayerMask _interactableMask;
        [SerializeField]
        private InteractionPromtUI _interactionPromtUI;

        // public PickableItemContainer ItemContainer;

        #endregion

        #region Local variables

        [ReadOnly]
        private int _numFound;

        private readonly Collider[] _colliders = new Collider[3];

        private IInteractable _interactable;
        private IActionable _actionable;

        #endregion

        #region Unity functions

        // TODO: open commented UI promt code

        #endregion

        protected void InteractAction()
        {
            _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
                _interactableMask);

            if (_numFound > 0)
            {
                for (int i = 0; i < _numFound; i++)
                    if (_colliders[i].GetComponent<IInteractable>() != null)
                    {
                        _interactable = _colliders[i].GetComponent<IInteractable>();
                        break;
                    }

                if (_interactable != null)
                {
                    _interactable.Interact(this);
                    Debug.Log($"{gameObject.name} interacted with {_interactable}");
                }
            }
            else
            {
                if (_interactable == null)
                    _interactable = null;
            }
        }

        protected void ActionPerform()
        {
            _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
                _interactableMask);

            if (_numFound > 0)
            {
                for (int i = 0; i < _numFound; i++)
                    if (_colliders[i].GetComponent<IActionable>() != null)
                    {
                        _actionable = _colliders[i].GetComponent<IActionable>();
                        break;
                    }

                if (_actionable != null)
                {
                    Debug.Log($"{_actionable}, {this}");
                    _actionable.Action(this);
                }
            }
            else
            {
                if (_actionable == null)
                    _actionable = null;
            }
        }

        protected void ActionCancel()
        {
            _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
                _interactableMask);

            if (_numFound > 0)
            {
                for (int i = 0; i < _numFound; i++)
                    if (_colliders[i].GetComponent<IActionable>() != null)
                    {
                        _actionable = _colliders[i].GetComponent<IActionable>();
                        break;
                    }

                if (_actionable != null)
                {
                    Debug.Log($"{_actionable}, {this}");
                    _actionable.ActionCancel(this);
                }
            }
            else
            {
                if (_actionable == null)
                    _actionable = null;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
        }
#endif
    }
}