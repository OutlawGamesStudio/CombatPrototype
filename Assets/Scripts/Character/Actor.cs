using UnityEngine;

public class Actor : MonoBehaviour
{
    private const float BASE_HEALTH = 100f;
    public CharacterStats CharacterStats;

    protected virtual void Start()
    {
        if (CharacterStats.Level < 1)
        {
            CharacterStats.Level = 1;
        }
        if (CharacterStats.IsBoss)
        {
            CharacterStats.MaxHealth = (BASE_HEALTH * 2.0f) * CharacterStats.Level;
        }
        else
        {
            CharacterStats.MaxHealth = (BASE_HEALTH * 1.25f) * CharacterStats.Level;
        }
        CharacterStats.CurrentHealth = CharacterStats.MaxHealth;
    }

    protected virtual void Update()
    {
        CharacterStats.Position = transform.position;
        CharacterStats.Rotation = transform.rotation;
    }

    public virtual void OnWeaponDamage(float damage)
    {
        CharacterStats.CurrentHealth -= damage;
        if (CharacterStats.CurrentHealth <= 0)
        {
            CharacterStats.IsDead = true;
        }
    }
}
