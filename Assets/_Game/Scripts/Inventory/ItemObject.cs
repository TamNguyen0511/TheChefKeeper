using _Game.Scripts.Interfaces;
using _Game.Scripts.Interfaces.InterfaceActors;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Inventory
{
    public class ItemObject : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ItemDataSO _itemData;

        #region IInteractable

        public string InteractionPrompt { get; }

        [Button("Add items")]
        public bool Interact(Interactor interactor)
        {
            GameManager.Instance.Inventory.Add(_itemData);
            
            gameObject.SetActive(false);
            return true;
        }

        #endregion
    }
}