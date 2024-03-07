using _Game.Scripts.Interfaces;
using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Inventory
{
    public class ItemObject : Item, IInteractable
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