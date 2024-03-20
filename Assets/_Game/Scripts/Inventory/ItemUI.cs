using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game.Scripts.Inventory
{
    public class ItemUI : MonoBehaviour
    {
        [ReadOnly]
        public ItemObject HoldingItem;
        [SerializeField]
        private Image _itemIcon;
        [SerializeField]
        private TextMeshProUGUI _amountTxt;

        public Image ItemIcon => _itemIcon;
        public TextMeshProUGUI AmountTxt => _amountTxt;
    }
}