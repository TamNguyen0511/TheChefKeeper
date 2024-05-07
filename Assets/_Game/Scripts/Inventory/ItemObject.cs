﻿using System;
using _Game.Scripts.Interfaces;
using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.Items;
using _Game.Scripts.ScriptableObjects.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Inventory
{
    /// <summary>
    /// Use only for item in world,
    /// if the item is newly spawn of get throw-out by player will use this script to create Item in the world 
    /// </summary>
    public class ItemObject : Item, IInteractable
    {
        public SpriteRenderer ItemSprite;

        #region IInteractable

        public string InteractionPrompt { get; }

        protected override void OnEnable()
        {
            base.OnEnable();
            InitItem();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Interactor>() && other.gameObject.layer == PlayerLayer)
            {
                Interact(other.GetComponent<Interactor>());
            }
        }

        public override void InitItem()
        {
            ItemSprite.sprite = BaseItemData.ItemIcon;
        }

        public void SetupItem(BaseItemSO baseItem)
        {
            BaseItemData = baseItem;
        }

        public bool Interact(Interactor interactor)
        {
            gameObject.SetActive(false);
            LootCollider.enabled = false;
            InventoryManager.Instance.AddItem(this as Item);
            return true;
        }

        #endregion
    }
}