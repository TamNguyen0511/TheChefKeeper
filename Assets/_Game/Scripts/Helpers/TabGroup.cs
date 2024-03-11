using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace _Game.Scripts.Helpers
{
    public class TabGroup : MonoBehaviour
    {
        [Header("Tab control and Tab object")]
        public List<TabButton> TabButtons = new();
        [Tooltip("Tab object must be simulate order to TabButtons list")]
        public List<GameObject> TabObjectToSwap = new();

        [Header("Tab images")]
        public Sprite TabIdle;
        public Sprite TabHover;
        public Sprite Tabactive;

        [ReadOnly]
        public TabButton SelectingTab;

        public void Subcribe(TabButton button)
        {
            if (TabButtons == null)
            {
                TabButtons = new List<TabButton>();
            }

            TabButtons.Add(button);
        }

        public void OnTabEnter(TabButton button)
        {
            ResetTabs();
            if (SelectingTab != null) return;
            if (button != SelectingTab) return;
            button.Background.sprite = TabHover;
        }

        public void OnTabExit(TabButton button)
        {
            ResetTabs();
        }

        public void OnTabSelected(TabButton button)
        {
            if (SelectingTab!=null)
                SelectingTab.Deselect();
            
            SelectingTab = button;
            
            SelectingTab.Select();
            
            ResetTabs();
            button.Background.sprite = Tabactive;
            int index = button.transform.GetSiblingIndex();
            for (int i = 0; i < TabObjectToSwap.Count; i++)
            {
                if (i == index)
                    TabObjectToSwap[i].SetActive(true);
                else TabObjectToSwap[i].SetActive(false);
            }
        }

        public void ResetTabs()
        {
            foreach (TabButton tabButton in TabButtons)
            {
                if (SelectingTab != null && tabButton == SelectingTab)
                {
                    continue;
                }

                tabButton.Background.sprite = TabIdle;
            }
        }
    }
}