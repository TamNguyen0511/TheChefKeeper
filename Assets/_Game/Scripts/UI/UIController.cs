using _Game.Scripts.Enums;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        public DetailItemInforUI DetailItemInforUI;
        public GameObject CookingUI;

        public void DetailItemHover(bool active)
        {
            DetailItemInforUI.gameObject.SetActive(active);
        }

        public void OpenCookCounterUI(IngredientCookState cookCounterType)
        {
            
        }
    }
}