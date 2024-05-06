using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.Helpers;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.ScriptableObjects.Items
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "Item/Ingredient", order = 0)]
    public class IngredientSO : BaseItemSO
    {
        [Header("Ingredients fields")]
        public IngredientPrepState IngredientPrepState;
        public int IngredientPoint;
        public NewCookStateAndTime NewCookStateAndTime = new();
    }

    [System.Serializable]
    public class NewCookStateAndTime : UnitySerializedDictionary<IngredientSO, float>
    {
        
    }
}