using System;
using UnityEngine;

namespace _Game.Scripts.DayTime_System
{
    [RequireComponent(typeof(Light))]
    public class WorldLight3D : MonoBehaviour
    {
        private Light _light;

        [SerializeField] private WorldTime _worldTime;
        [SerializeField] private Gradient _gradient;

        private void Awake()
        {
            _light = GetComponent<Light>();
        }

        private void OnEnable()
        {
            _worldTime.WorldTimeChange += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChange -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _light.color = _gradient.Evaluate(PercentOfDay(newTime));
        }

        private float PercentOfDay(TimeSpan timeSpan)
        {
            return (float)timeSpan.TotalMinutes % WorldTimeConstant.MinutesInDay / WorldTimeConstant.MinutesInDay;
        }
    }
}