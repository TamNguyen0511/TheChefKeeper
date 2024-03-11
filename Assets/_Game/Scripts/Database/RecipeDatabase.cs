using System;
using System.Collections.Generic;
using _Game.Scripts.ScriptableObjects.World_Area;
using UnityEngine;

namespace _Game.Scripts.Database
{
    public class RecipeDatabase : MonoBehaviour
    {
        public static RecipeDatabase Instance;

        public List<RecipeSO> AllDiskes = new();
        public List<IngredientSO> AllIngredients = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}