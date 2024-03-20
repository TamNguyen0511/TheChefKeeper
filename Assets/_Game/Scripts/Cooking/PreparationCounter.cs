using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Database;
using _Game.Scripts.Enums;
using _Game.Scripts.Inventory;
using _Game.Scripts.Items.Cook;
using _Game.Scripts.ScriptableObjects.Items;
using _Game.Scripts.Systems.Drag_and_Drop;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Cooking
{
    public class PreparationCounter : CookingCounter
    {
        public IngredientPrepState InputIngredientState;
        public IngredientPrepState OutputIngredientState;

        [SerializeField, ReadOnly]
        private IngredientSO _handlingIngredient;

        [SerializeField]
        private List<Button> _controllingBtns = new();

        [ReadOnly]
        private List<IngredientSO> _ingredients = new();

        private float _cookingProcess;
        private float _currentCookingProcess;


        private bool _isCooking;

        #region Unity function

        private void OnEnable()
        {
            ShowPrepableIngredients();
        }

        private void Update()
        {
            if (!_isCooking) return;
            CookingProcess();
        }

        private void OnDisable()
        {
            for (int i = 0; i < _controllingBtns.Count; i++)
            {
                _controllingBtns[i].onClick.RemoveAllListeners();
            }
        }

        #endregion

        private void ShowPrepableIngredients()
        {
            _ingredients.Clear();
            /// Get available ingredients
            foreach (IngredientSO ingredientSo in RecipeDatabase.Instance.AllIngredients)
            {
                if (ingredientSo.IngredientPrepState == InputIngredientState)
                {
                    _ingredients.Add(ingredientSo);
                }
            }

            /// Turn off all buttons
            for (int i = 0; i < _controllingBtns.Count; i++)
            {
                _controllingBtns[i].onClick.RemoveAllListeners();
                _controllingBtns[i].gameObject.SetActive(false);
            }

            /// Set-up btn to ingredients list
            for (int i = 0; i < _ingredients.Count; i++)
            {
                _controllingBtns[i].gameObject.SetActive(true);
                _controllingBtns[i].image.sprite = _ingredients[i].ItemIcon;
                _controllingBtns[i].onClick.AddListener(() => SetupCookingTime(_ingredients[i]));
            }
        }

        public void SetupCookingTime(IngredientSO ingredient)
        {
            _cookingProcess = ingredient.NewCookStateAndTime
                .FirstOrDefault(x => x.Key.IngredientPrepState == OutputIngredientState).Value;
            // ingredient.NewCookStateAndTime.Where(x => x.Key.IngredientPrepState == OutputIngredientState);
            _handlingIngredient = ingredient;
        }

        public void StartCooking()
        {
            _isCooking = true;
        }

        private void CookingProcess()
        {
            _currentCookingProcess += Time.deltaTime;
            if (_currentCookingProcess >= _cookingProcess)
            {
                _isCooking = false;
                _currentCookingProcess = 0;
                InventoryManager.Instance.SpawnBackToOutsideEnvironment(_handlingIngredient.NewCookStateAndTime
                    .FirstOrDefault(x => x.Key.IngredientPrepState == OutputIngredientState).Key);
            }
        }
    }
}