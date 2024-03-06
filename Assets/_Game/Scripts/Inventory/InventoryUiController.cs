using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.Inventory
{
    public class InventoryUiController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _weightTxt;
        [SerializeField]
        private Transform _slotHolder;
        [ShowInInspector, ReadOnly]
        private List<InventorySlotUI> _inventorySlot = new();

        private void Start()
        {
            foreach (Transform child in _slotHolder)
            {
                _inventorySlot.Add(child.GetComponent<InventorySlotUI>());
            }

            ClearSlot();

            GameManager.Instance.OnUpdateItem += UpdateInventory;
        }

        private void UpdateInventory(ItemDataSO item)
        {
            ClearSlot();
            DrawInventory();
            UpdateTotalWeight();
        }

        private void DrawInventory()
        {
            for (int i = 0; i < GameManager.Instance.Inventory.Inventory.Count; i++)
            {
                AddToInventory(GameManager.Instance.Inventory.Inventory[i], _inventorySlot[i]);
            }

            // foreach (var item in GameManager.Instance.Inventory.Inventory)
            // {
            //     AddToInventory(item);
            // }
        }

        private void AddToInventory(InventoryItem item, InventorySlotUI inventorySlot)
        {
            InventorySlotUI slot = inventorySlot;
            slot.SetItem(item);
        }

        [Button("Clear slots")]
        private void ClearSlot(InventorySlotUI slotToClear = null)
        {
            if (slotToClear == null)
            {
                foreach (InventorySlotUI slotUI in _inventorySlot)
                {
                    slotUI.ClearSlot();
                }
            }
            else
            {
                slotToClear.ClearSlot();
            }
        }

        private void UpdateTotalWeight()
        {
            /// TODO: change max carry weight here
            _weightTxt.text = "Weight: " + GameManager.Instance.Inventory.GetTotalWeight().ToString() + "/100Kg";
        }
    }
}