using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.PlayerControl.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
                Death();
        }

        private void Death()
        {
        }
    }
}