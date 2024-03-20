using System;
using _Game.Scripts.Inventory;
using _Game.Scripts.ScriptableObjects.Items;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Game.Scripts.Systems.Drag_and_Drop
{
    public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public ItemSO Item;

        [Header("Object to spawn")]
        public ItemObject ItemObjectToSpawn;
        [Header("UI")]
        public Image Image;
        public TextMeshProUGUI StackTxt;
        [Header("Parameter")]
        public int StackCount = 1;
        [ReadOnly]
        public Transform ParentAfterDrag;

        #region Unity functions

        private void Start()
        {
            InitItem(Item);
        }

        #endregion

        public void InitItem(ItemSO item)
        {
            this.Item = item;
            Image.sprite = item.ItemIcon;
            RefreshCount();
        }

        public void RefreshCount()
        {
            StackTxt.text = StackCount.ToString();
            bool textActive = StackCount > 1;
            StackTxt.gameObject.SetActive(textActive);
        }



        #region I Drags

        public void OnBeginDrag(PointerEventData eventData)
        {
            ParentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            Image.raycastTarget = false;
        }


        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(ParentAfterDrag);
            Image.raycastTarget = true;
        }

        #endregion
    }
}