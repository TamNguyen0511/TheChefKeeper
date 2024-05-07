using _Game.Scripts.Enums;
using UnityEngine;
using Sirenix.OdinInspector;

namespace _Game.Scripts.ScriptableObjects.Items
{
    public class BaseItemSO : ScriptableObject
    {
        [PreviewField(120), HideLabel] [HorizontalGroup("Split", 120)]
        public Sprite ItemIcon;

        [VerticalGroup("Split/Right"), HorizontalGroup("Split/Right/1stLine")]
        public string ItemId;

        [VerticalGroup("Split/Right"), HorizontalGroup("Split/Right/1stLine"), HideLabel]
        public ItemType ItemType;

        [VerticalGroup("Split/Right")] public string ItemName;

        [VerticalGroup("Split/Right"), MultiLineProperty(4)]
        public string ItemDescription;

        [OnValueChanged("SetMaxStack")]
        [HorizontalGroup("Stack")] public bool IsStackable = true;

        [HorizontalGroup("Stack"), Range(1, 99), 
         DisableIf("IsStackable", false), EnableIf("IsStackable", true)]
        public int MaxStack = 1;

        public float Weight;

        private void SetMaxStack()
        {
            if (!IsStackable)
                MaxStack = 1;
        }
    }
}