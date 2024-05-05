using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.Scripts.DayTime_System
{
    public class WorldTime : MonoBehaviour
    {
        [Tooltip("Must use second")]
        [SerializeField] private float _dayLength;
        
        private TimeSpan _currentTime;
        public Vector3 CurrentTimeSetter;
        private float _minuteLength => _dayLength / WorldTimeConstant.MinutesInDay;

        public event EventHandler<TimeSpan> WorldTimeChange;

        private void Start()
        {
            StartCoroutine(AddMinuite());
        }

        private IEnumerator AddMinuite()
        {
            _currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChange?.Invoke(this, _currentTime);
            yield return new WaitForSeconds(_minuteLength);
            StartCoroutine(AddMinuite());
        }

        [Button("Set time")]
        private void SetTimeForTest()
        {
            _currentTime = new TimeSpan((int)CurrentTimeSetter.x,(int) CurrentTimeSetter.y,(int) CurrentTimeSetter.z);
        }
    }
}