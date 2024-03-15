using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.Items.Cook;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Cooking.Counters
{
    public class CookingCounter : CounterBase
    {
        [Header("Processable")]
        public List<IngredientObject> CookableIngredients = new();
        public List<RecipeObject> CookableDiskes = new();

        [SerializeField]
        protected float _totalProcessTime;
        [SerializeField, ReadOnly]
        protected float _currentProcessingTime;
        public IngredientPrepState ProcessableIngredientStates;
        public IngredientCookState CookableIngredientStates;

        private bool _isCooking;

        private void Update()
        {
            CookIngredient();
            PlayCookingAnimation();
        }

        private void CookIngredient()
        {
        }

        private void PlayCookingAnimation()
        {
            if (!_isCooking) return;
            /// TODO: Play animation here
        }
    }
}