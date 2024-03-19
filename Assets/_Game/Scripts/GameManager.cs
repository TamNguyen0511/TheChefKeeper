using System;
using _Game.Scripts.Inventory;
using _Game.Scripts.UI;
using Redcode.Pools;
using UnityEngine;

namespace _Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public PoolManager AllPool;
        
        public UIController UIController;

        public GameObject InventoryUI;

        public Action<ItemDataSO> OnUpdateItem;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            InventoryUI.SetActive(false);
        }

        public void ToggleInventoryUI()
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }
}