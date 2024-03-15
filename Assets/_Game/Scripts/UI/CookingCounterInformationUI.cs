using _Game.Scripts.Cooking.Counters;
using _Game.Scripts.Database;
using _Game.Scripts.Enums;
using _Game.Scripts.ScriptableObjects.World_Area;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class CookingCounterInformationUI : CounterBase
    {
        [SerializeField]
        private IngredientCookState _cookState;
        [SerializeField]
        private CookingSlotUI _slotPrefab;
        [SerializeField]
        private Transform _slotContainer;

        private void OnEnable()
        {
            OpenCounterUI(CounterData.CounterType);
        }

        private void OpenCounterUI(IngredientCookState cookState)
        {
            /// TODO: set a pool for slot
            foreach (RecipeSO recipe in RecipeDatabase.Instance.AllDiskes)
            {
                if (_cookState == cookState)
                {
                    var slot = Instantiate(_slotPrefab, _slotContainer);
                    slot.SetupSlot(recipe);
                }
            }
        }
    }
}