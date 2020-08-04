using ForgottenLegends.Combat;
using System;
using UnityEngine;

namespace ForgottenLegends.Character
{
    [Serializable]
    public class CharacterStats
    {
        public uint CharacterID;
        public string Name;
        public bool IsDead;
        public int Level;
        public float MaxHealth;
        public float CurrentHealth;
        public Vector3 Position = new Vector3();
        public Quaternion Rotation = new Quaternion();
        public bool IsBoss;
        public CharacterType CharacterType;
        public bool InCombat;
        public float MaxMana;
        public float CurrentMana;
        public WeaponType CombatStyle;
        public AnimationType AnimationType;
    }
}