using System;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.Items;
using _Game.Scripts.Items.Weapons;
using _Game.Scripts.ScriptableObjects.Items;
using _Game.Scripts.Systems.Drag_and_Drop;
using Sirenix.OdinInspector;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace _Game.Scripts.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;
        public ItemObject ItemToSpawn;
        [ShowInInspector, ReadOnly] private int _selectingSlot = -1;

        public GameObject InventoryItemPrefab;
        public List<InventorySlotUI> InventorySlot = new();

        #region Unity functions

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            ChangeSelectingSlot(0);
        }

        private void Update()
        {
            if (Input.inputString == null) return;
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectingSlot(number - 1);
            }
        }

        #endregion

        private void ChangeSelectingSlot(int newValue)
        {
            if (_selectingSlot >= 0)
                InventorySlot[_selectingSlot].Deselect();

            InventorySlot[newValue].Select();
            _selectingSlot = newValue;
        }

        #region Item handle

        public bool AddItem(Item item)
        {
            /// Find empty slot
            for (int i = 0; i < InventorySlot.Count; i++)
            {
                InventorySlotUI slot = InventorySlot[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

                if (itemInSlot == null)
                {
                    SpawnNewItem(item, slot);
                    return true;
                }

                if (itemInSlot != null
                    && itemInSlot.BaseItemData == item
                    && itemInSlot.BaseItemData.IsStackable
                    && itemInSlot.StackCount < itemInSlot.BaseItemData.MaxStack)
                {
                    itemInSlot.StackCount++;
                    itemInSlot.RefreshCount();

                    return true;
                }
            }

            return false;
        }

        public void SpawnNewItem(Item baseItem, InventorySlotUI slot)
        {
            GameObject newItem = Instantiate(InventoryItemPrefab, slot.transform);
            Item item = newItem.GetComponent<Item>();
            InventoryItem inventoryItem = item as InventoryItem;


            switch (baseItem.BaseItemData.ItemType)
            {
                case ItemType.None:
                    break;
                case ItemType.Ingredient:
                    break;
                case ItemType.Material:
                    break;
                case ItemType.Weapon:
                    newItem.AddComponent<Weapon>();
                    Weapon weaponItem = newItem.GetComponent<Weapon>();
                    weaponItem.Image = inventoryItem.Image;
                    weaponItem.StackTxt = inventoryItem.StackTxt;
                    weaponItem.StackCount = inventoryItem.StackCount;

                    if (weaponItem != null)
                        weaponItem.InitItem(baseItem.BaseItemData);

                    Destroy(newItem.GetComponent<InventoryItem>());
                    break;
                case ItemType.Consumable:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //
            // InventoryItem inventoryItem = item as InventoryItem;
            //
            // if (inventoryItem != null)
            //     inventoryItem.InitItem(baseItem);
        }

        public void SpawnBackToOutsideEnvironment(BaseItemSO baseItem)
        {
            ItemObject newSpawnItem = Instantiate(ItemToSpawn);
            newSpawnItem.SetupItem(baseItem);
        }

        #endregion

        public InventoryItem GetSelectingItem()
        {
            InventorySlotUI slot = InventorySlot[_selectingSlot];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                return itemInSlot;
            }

            return null;
        }
    }
}