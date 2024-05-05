using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace _Game.Scripts.DayTime_System
{
    public class TimeWorldWatcher : MonoBehaviour
    {
        [SerializeField] private WorldTime _worldTime;
        [SerializeField] private List<Schedule> _schedules = new();

        private void OnEnable()
        {
            _worldTime.WorldTimeChange += CheckSchedule;
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChange -= CheckSchedule;
        }

        private void CheckSchedule(object sender, TimeSpan e)
        {
            var schedule = _schedules.FirstOrDefault(s => s.Hour == e.Hours && s.Minute == e.Minutes);
            schedule?.Action?.Invoke();
        }

        [System.Serializable]
        private class Schedule
        {
            public int Hour;
            public int Minute;
            public UnityEvent Action;
        }
    }
}