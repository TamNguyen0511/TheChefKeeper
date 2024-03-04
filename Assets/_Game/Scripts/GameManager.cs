using System;
using _Game.Scripts.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public InventorySystem Inventory = new InventorySystem();

        public GameObject InventoryUI;

        public Action<ItemDataSO> OnUpdateItem;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void ToggleInventoryUI()
        {
            if (InventoryUI.activeSelf)
                InventoryUI.SetActive(false);
            else InventoryUI.SetActive(true);
        }

        [Button("Remove")]
        public void TestRemove(ItemDataSO item)
        {
            Inventory.Remove(item);
        }
    }
}