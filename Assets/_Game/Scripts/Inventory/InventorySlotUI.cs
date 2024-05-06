using _Game.Scripts.Items;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game.Scripts.Inventory
{
    public class InventorySlotUI : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// Alpha will glow on mouse hover object
        [SerializeField] private Image _hoverLayer;

        [SerializeField] private Sprite _selectedSlotSprite;
        [SerializeField, ReadOnly] private Sprite _defaultSprite;

        private void Awake()
        {
            _defaultSprite = _hoverLayer.sprite;
            Deselect();
        }

        public void Select()
        {
            _hoverLayer.sprite = _selectedSlotSprite;
        }

        public void Deselect()
        {
            _hoverLayer.sprite = _defaultSprite;
        }

        #region IPointers

        public void OnPointerEnter(PointerEventData eventData)
        {
            Color glow = new Color(0, 0, 0, 50 / 255f);
            _hoverLayer.color = glow;

            GameManager.Instance.UIController.DetailItemHover(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Color dark = new Color(0, 0, 0, 150 / 255f);
            _hoverLayer.color = dark;

            GameManager.Instance.UIController.DetailItemHover(false);
        }

        #endregion

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            Systems.Drag_and_Drop.InventoryItem item = dropped.GetComponent<Systems.Drag_and_Drop.InventoryItem>();
            item.ParentAfterDrag = transform;
        }
    }
}