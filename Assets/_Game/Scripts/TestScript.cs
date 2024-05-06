using _Game.Scripts.Inventory;
using _Game.Scripts.ScriptableObjects.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts
{
    public class TestScript : MonoBehaviour
    {
        public InventoryManager InventoryManager;
        public ItemSO[] Items;

        [Button("Add item demo")]
        public void PickupItem(int id)
        {
            // bool result = InventoryManager.AddItem(Items[id]);
            // Debug.Log("Add item success?: " + result);
        }
        [Button("Get item demo")]
        public void GetItem()
        {
            // ItemSO item = InventoryManager.GetSelectingItem();
            // Debug.Log($"Selecting: {item.ItemName}");
        }
    }
}