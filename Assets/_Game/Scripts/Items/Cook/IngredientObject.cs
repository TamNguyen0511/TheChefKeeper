﻿using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.ScriptableObjects.World_Area;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Items.Cook
{
    public class IngredientObject : MonoBehaviour
    {
        public IngredientSO IngredientData;
        public GameObject IngredientPrefab;

        [ReadOnly]
        public IngredientPrepState CurrentPrepState;
        [ReadOnly]
        public IngredientCookState CurrentCookState;

        public List<IngredientPrepState> PrepableState = new();
        public List<IngredientCookState> CookableState = new();
    }
}