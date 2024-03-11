using _Game.Scripts.Enums;
using _Game.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.ScriptableObjects.World_Area
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "Items/Ingredient", order = 0)]
    public class IngredientSO : ScriptableObject
    {
        public string Id;
        public string Name;
        public Image Icon;
        public int Point;
        public string Description;
        public bool IsNotice;

        [Tooltip(
            "A dictionary for bonus time if ingredient preparation need more then tool time to process.\nUse for long time preping ingredient line noodle, ... \nCan be NULL.")]
        public BonusIngredientPrepTimeAndState BonusIngredientPrepTimeAndState = new();
        [Tooltip(
            "A dictionary for bonus time if ingredient cooking need more then tool time to process.\nUse for long time cooking ingredient line broth, ... \nCan be NULL.")]
        public BonusIngredientCookTimeAndState BonusIngredientCookTimeAndState = new();
    }

    [System.Serializable]
    public class BonusIngredientPrepTimeAndState : UnitySerializedDictionary<IngredientPrepState, float>
    {
    }

    [System.Serializable]
    public class BonusIngredientCookTimeAndState : UnitySerializedDictionary<IngredientCookState, float>
    {
    }
}