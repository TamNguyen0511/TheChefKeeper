using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.DayTime_System
{
    public class WorldTimeDisplay : MonoBehaviour
    {
        [SerializeField]
        private WorldTime _worldTime;
        public TextMeshProUGUI TimeText;

        private void OnEnable()
        {
            _worldTime.WorldTimeChange += OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            TimeText.text = newTime.ToString(@"hh\:mm");
        }
    }
}