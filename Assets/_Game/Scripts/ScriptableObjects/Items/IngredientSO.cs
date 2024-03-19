using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.Items
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "Item/Ingredient", order = 0)]
    public class IngredientSO : ItemSO
    {
        [Header("Ingredients fields")]
        public int IngredientPoint;
    }
}