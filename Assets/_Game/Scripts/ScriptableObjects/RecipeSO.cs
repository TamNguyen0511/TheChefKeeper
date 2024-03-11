using System.Collections.Generic;
using _Game.Scripts.Enums;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Game.Scripts.ScriptableObjects.World_Area
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Items/Recipe", order = 0)]
    public class RecipeSO : ScriptableObject
    {
        public string Id;
        public string Name;
        public Image Icon;

        public DiskContainerType RequirementContainerType;
        public List<RequirementIngredientAndState> RequirementIngredients = new();
    }

    [System.Serializable]
    public class RequirementIngredientAndState
    {
        public IngredientSO RequiredIngredientData;
        public IngredientPrepState RequiedPrepState;
        public IngredientCookState RequiedCookState;
    }
}