﻿using System;
using _Game.Scripts.Inventory;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class DetailItemInforUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _itemNameTxt;
        [SerializeField]
        private TextMeshProUGUI _itemDescriptionTxt;
        [SerializeField]
        private Image _itemImage;

        [SerializeField]
        private Vector3 _offset;
        [SerializeField]
        private Vector3 position;

        private void OnEnable()
        {
        }

        private void Update()
        {
            // if (!gameObject.activeSelf) return;

            position = Input.mousePosition - _offset;
            transform.position = position;
        }
    }
}