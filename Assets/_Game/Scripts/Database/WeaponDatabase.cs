using System.Collections.Generic;
using _Game.Scripts.PlayerControl;
using UnityEngine;

namespace _Game.Scripts.Database
{
    public class WeaponDatabase : ScriptableObject
    {
        public List<WeaponDataWithAnimAndAttackPoint> WeaponsData = new();
    }
}