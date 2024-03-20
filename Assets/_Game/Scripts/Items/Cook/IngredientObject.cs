using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.ScriptableObjects.World_Area;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.Items.Cook
{
    public class IngredientObject : Item
    {
        public IngredientSO IngredientData;
        public IngredientPrepState CurrentIngredientState;
    }
}