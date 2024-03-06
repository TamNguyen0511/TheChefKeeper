using UnityEngine;

namespace _Game.Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        public DetailItemInforUI DetailItemInforUI;

        public void DetailItemHover(bool active)
        {
            DetailItemInforUI.gameObject.SetActive(active);
        }
    }
}