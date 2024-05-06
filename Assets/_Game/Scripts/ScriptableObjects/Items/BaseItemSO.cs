using _Game.Scripts.Enums;
using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.Items
{
    public class BaseItemSO : ScriptableObject
    {
        [Header("Base item fields")] public string ItemId;
        public string ItemName;
        public string ItemDescription;

        public bool IsStackable = true;
        public int MaxStack = 4;

        public ItemType ItemType;

        public float Weight;

        public Sprite ItemIcon;
    }
}