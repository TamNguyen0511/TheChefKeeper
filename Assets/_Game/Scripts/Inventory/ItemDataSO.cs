using UnityEngine;

namespace _Game.Scripts.Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 0)]
    public class ItemDataSO : ScriptableObject
    {
        public string Id;
        public string Name;
        public float Weight;
        public Sprite Icon;
        public string Description;
        public GameObject ItemPrefab;
    }
}