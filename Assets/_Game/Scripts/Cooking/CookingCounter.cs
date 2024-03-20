using _Game.Scripts.Interfaces;
using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.ScriptableObjects.World_Area.Cooking;
using UnityEngine;

namespace _Game.Scripts.Cooking
{
    public abstract class CookingCounter : MonoBehaviour, IInteractable
    {
        public CounterSO CounterData;

        public string InteractionPrompt { get; }

        public virtual bool Interact(Interactor interactor)
        {
            /// Open cooking UI base on counter
            GameManager.Instance.UIController.CookingUI.SetActive(true);
            /// Setup UI: Ingredients/Diskes base on what player can do
            /// Click: show conent/information of disk/ingredient
            return true;
        }
    }
}