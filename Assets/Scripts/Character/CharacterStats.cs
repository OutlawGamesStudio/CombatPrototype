using System;
using UnityEngine;

// Replace this later with a more robust system so we can customise wether an NPC can attack another NPC, etc.
public enum CharacterType
{
    Neutral,
    Enemy
}

[Serializable]
public class CharacterStats
{
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
}
