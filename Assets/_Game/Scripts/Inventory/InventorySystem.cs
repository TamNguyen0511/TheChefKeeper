using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Inventory
{
    [System.Serializable]
    public class InventorySystem
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<ItemDataSO, InventoryItem> _itemsDictionary = new();
        [ShowInInspector]
        public List<InventoryItem> Inventory = new();

        public InventoryItem GetInventoryItems(ItemDataSO refData)
        {
            if (_itemsDictionary.TryGetValue(refData, out InventoryItem value))
            {
                return value;
            }

            return null;
        }

        public float GetTotalWeight()
        {
            float total = 0;
            foreach (InventoryItem item in Inventory)
            {
                total += item.StackSize * item.ItemData.Weight;
            }

            return total;
        }

        public void Add(ItemDataSO refData)
        {
            if (_itemsDictionary.TryGetValue(refData, out InventoryItem value))
            {
                value.AddToStack();
            }
            else
            {
                InventoryItem newItem = new InventoryItem(refData);
                Inventory.Add(newItem);
                _itemsDictionary.Add(refData, newItem);
            }
            GameManager.Instance.OnUpdateItem?.Invoke(refData);
        }

        public void Remove(ItemDataSO refData)
        {
            if (!_itemsDictionary.TryGetValue(refData, out InventoryItem value)) return;

            value.RemoveFromStack();

            GameManager.Instance.OnUpdateItem?.Invoke(refData);
            if (value.StackSize > 0) return;
            Inventory.Remove(value);
            _itemsDictionary.Remove(refData);
            GameManager.Instance.OnUpdateItem?.Invoke(refData);
        }
    }
}