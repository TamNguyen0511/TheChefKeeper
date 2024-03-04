using Sirenix.OdinInspector;

namespace _Game.Scripts.Inventory
{
    [System.Serializable]
    public class InventoryItem
    {
        [ShowInInspector]
        public ItemDataSO ItemData { get; private set; }
        [ShowInInspector]
        public int StackSize { get; private set; }

        public InventoryItem(ItemDataSO itemData)
        {
            ItemData = itemData;
            AddToStack();
        }

        public void AddToStack(int amount = 1)
        {
            StackSize += amount;
        }

        public void RemoveFromStack(int amount = 1)
        {
            StackSize -= amount;
        }
    }
}