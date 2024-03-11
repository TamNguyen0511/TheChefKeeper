using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game.Scripts.Helpers
{
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public TabGroup TabGroup;

        public Image Background;

        public UnityEvent OnTabSelect;
        public UnityEvent OnTabDeselect;

        private void Start()
        {
            TabGroup.Subcribe(this);
        }

        public void Select()
        {
            OnTabSelect?.Invoke();
        }
        
        public void Deselect()
        {
            OnTabDeselect?.Invoke();
        }

        #region IPointers

        public void OnPointerEnter(PointerEventData eventData)
        {
            TabGroup.OnTabEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TabGroup.OnTabExit(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            TabGroup.OnTabSelected(this);
        }

        #endregion
    }
}