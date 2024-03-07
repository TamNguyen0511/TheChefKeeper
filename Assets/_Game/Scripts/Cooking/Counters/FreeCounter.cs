using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.Items;
using _Game.Scripts.Items.Cook;
using UnityEngine;

namespace _Game.Scripts.Cooking.Counters
{
    public class FreeCounter : CounterBase
    {
        public override bool Interact(Interactor interactor)
        {
            IngredientObject ingre = interactor.SelectingItem as IngredientObject;

            if (ingre != null)
            {
                ContainingIngredient = ingre;
                ContainingIngredient.transform.SetParent(transform);
                ContainingIngredient.transform.localPosition = Vector3.zero;
            }

            return base.Interact(interactor);
        }
    }
}