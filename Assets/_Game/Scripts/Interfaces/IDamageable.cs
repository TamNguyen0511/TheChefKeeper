using UnityEngine;

namespace _Game.Scripts.Interfaces
{
    public interface IDamageable
    {
        public bool TakeHit(int damage);
    }
}