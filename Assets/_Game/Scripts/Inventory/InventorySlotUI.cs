using _Game.Scripts.Interfaces;
using _Game.Scripts.Systems.Drag_and_Drop;
using _Game.Scripts.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game.Scripts.Inventory
{
    public class InventorySlotUI : MonoBehaviour, IDropHandler
    {
        [SerializeField, ReadOnly]
        private InventoryItem _holdingItem;
        [SerializeField]
        private TextMeshProUGUI _itemAmount;
        /// Alpha will glow on mouse hover object
        [SerializeField]
        private Image _hoverLayer;
        [SerializeField]
        private bool _isUsable = true;

        public void ClearSlot()
        {
            _itemAmount.text = "";
            _isUsable = true;
            _holdingItem = null;
        }

        public void SetItem(InventoryItem item)
        {
            if (!_isUsable)
                return;

            _itemAmount.text = item.StackSize.ToString();
            _isUsable = false;
            _holdingItem = item;
        }

        #region IPointers

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_holdingItem == null || _holdingItem.ItemData == null) return;

            Color glow = new Color(0, 0, 0, 50 / 255f);
            _hoverLayer.color = glow;

            GameManager.Instance.UIController.DetailItemInforUI.CurrentReadingItem = _holdingItem;
            GameManager.Instance.UIController.DetailItemHover(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Color dark = new Color(0, 0, 0, 150 / 255f);
            _hoverLayer.color = dark;

            GameManager.Instance.UIController.DetailItemInforUI.CurrentReadingItem = null;
            GameManager.Instance.UIController.DetailItemHover(false);
        }

        #endregion

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem item = dropped.GetComponent<DraggableItem>();
            item.ParentAfterDrag = transform;
        }
    }
}