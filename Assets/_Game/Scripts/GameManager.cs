using System;
using _Game.Scripts.Inventory;
using _Game.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public UIController UIController;

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
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }
}