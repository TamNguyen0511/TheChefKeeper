using System;
using _Game.Scripts.ScriptableObjects.Items;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.Items
{
    public abstract class Item : MonoBehaviour
    {
        public ItemSO ItemData;
        public LayerMask PlayerLayer;
        public SpriteRenderer ItemSprite;
        [ReadOnly] public CircleCollider2D LootCollider;

        protected virtual void OnEnable()
        {
            LootCollider = GetComponent<CircleCollider2D>();
        }

        public virtual void UseItem()
        {
        }
    }
}