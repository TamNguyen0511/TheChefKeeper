using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.Items.Cook;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Cooking.Counters
{
    public class CookingCounter : CounterBase
    {
        /// <summary>
        /// Show a list of cookable disk, if learned disk? yes => check if have enough ingredient in inventory? yes => show glow disk (cookable)
        ///                                                                                                     no  => show dark disk (learned but cannot cook at the moment)
        ///                                                no  => show un-learn disk image
        /// If disk is learned, click this to show: requirement ingredients, basic disk point, a cook button (will become loading bar for cooking on click) 
        /// </summary>
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