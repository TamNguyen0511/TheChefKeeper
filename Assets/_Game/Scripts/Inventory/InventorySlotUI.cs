using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Inventory
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField]
        private Image _itemIcon;
        [SerializeField]
        private TextMeshProUGUI _itemAmount;
        [SerializeField]
        private bool _isUsable = true;

        public void ClearSlot()
        {
            _itemIcon.sprite = null;
            _itemAmount.text = "";
            _isUsable = true;
        }

        public void SetItem(InventoryItem item)
        {
            if (!_isUsable)
                return;

            _itemIcon.sprite = item.ItemData.Icon;
            _itemAmount.text = item.StackSize.ToString();
            _isUsable = false;
        }
    }
}