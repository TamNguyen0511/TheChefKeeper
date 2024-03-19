using _Game.Scripts.Interfaces;
using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.Items;
using _Game.Scripts.ScriptableObjects.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Inventory
{
    public class ItemObject : Item, IInteractable
    {
        [SerializeField]
        private ItemSO _itemData;
        [SerializeField]
        private LayerMask _playerLayer;
        [SerializeField]
        private SpriteRenderer _itemSprite;
        [SerializeField, ReadOnly]
        private CircleCollider2D _lootCollider;

        #region IInteractable

        public string InteractionPrompt { get; }

        private void OnEnable()
        {
            InitItem();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Interactor>() && other.gameObject.layer == _playerLayer)
            {
                Interact(other.GetComponent<Interactor>());
            }
        }

        private void InitItem()
        {
            _itemSprite.sprite = _itemData.ItemIcon;
        }

        public bool Interact(Interactor interactor)
        {
            gameObject.SetActive(false);
            _lootCollider.enabled = false;
            InventoryManager.Instance.AddItem(_itemData);
            return true;
        }

        #endregion
    }
}