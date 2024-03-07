using _Game.Scripts.Interfaces;
using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.Items;
using UnityEngine;

namespace _Game.Scripts.Cooking.Counters
{
    public abstract class CounterBase : MonoBehaviour, IInteractable, IActionable
    {
        public Item ContainingIngredient;
        #region IInteractable

        public string InteractionPrompt { get; }

        public virtual bool Interact(Interactor interactor)
        {
            return true;
        }

        #endregion

        #region IActionable

        public virtual void Action(Interactor action)
        {
        }

        public virtual void ActionCancel(Interactor action)
        {
        }

        #endregion
    }
}