using UnityEngine;

namespace _Game.Scripts.ScriptableObjects.World_Area
{
    [CreateAssetMenu(fileName = "Counter", menuName = "World/Counter", order = 0)]
    public class CounterSO : ScriptableObject
    {
        public string Id;
        public string CounterName;
        public float ProcessingSpeed;
        /// TODO: add level data for speed of each upgrade
    }
}