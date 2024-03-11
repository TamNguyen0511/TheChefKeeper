using System;
using System.Collections.Generic;
using _Game.Scripts.Database;
using _Game.Scripts.Enums;
using _Game.Scripts.Helpers;
using _Game.Scripts.ScriptableObjects.World_Area;
using Redcode.Pools;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class CookingCounterInformationUI : TabGroup
    {
        public IngredientCookState CounterCookState;
        public Transform IngredientAndDiskHolder;
        public CookingSlotUI CookableSlotPrefab;

        [ShowInInspector, ReadOnly]
        private List<CookingSlotUI> _cookSlots = new();
        [ShowInInspector, ReadOnly]
        private Pool<CookingSlotUI> _slotPool;

        private void Start()
        {
        }

        private void SetSlotIngredient(List<IngredientSO> ingredients)
        {
            int ingredientCount = RecipeDatabase.Instance.AllIngredients.Count;

            _slotPool.SetContainer(IngredientAndDiskHolder);
            if (_slotPool.Count < ingredientCount)
                _slotPool = Redcode.Pools.Pool.Create(CookableSlotPrefab, ingredientCount - _slotPool.Count).NonLazy();
            else
            {
                _slotPool.Clear();
            }

            for (int i = 0; i < ingredients.Count; i++)
            {
                var slot = _slotPool.Get();
                slot.SetupSlot(ingredients[i]);
            }
        }
        private void SetSlotDisk(List<RecipeSO> disk)
        {
            int ingredientCount = RecipeDatabase.Instance.AllDiskes.Count;

            _slotPool.SetContainer(IngredientAndDiskHolder);
            if (_slotPool.Count < ingredientCount)
                _slotPool = Redcode.Pools.Pool.Create(CookableSlotPrefab, ingredientCount - _slotPool.Count).NonLazy();
            else
            {
                _slotPool.Clear();
            }

            for (int i = 0; i < disk.Count; i++)
            {
                var slot = _slotPool.Get();
                slot.SetupSlot(disk[i]);
            }
        }
    }
}