using ForgottenLegends.Scripts;
using UnityEngine;

namespace ForgottenLegends.Character
{
    public class Actor : MonoBehaviour
    {
        private const float BASE_HEALTH = 100f;
        public ActorData ActorData;

        protected virtual void Start()
        {
            if (ActorData.CharacterStats.Level < 1)
            {
                ActorData.CharacterStats.Level = 1;
            }
            if (ActorData.CharacterStats.IsBoss)
            {
                ActorData.CharacterStats.MaxHealth = BASE_HEALTH * 2.0f * ActorData.CharacterStats.Level;
            }
            else
            {
                ActorData.CharacterStats.MaxHealth = BASE_HEALTH * 1.25f * ActorData.CharacterStats.Level;
            }
            ActorData.CharacterStats.CurrentHealth = ActorData.CharacterStats.MaxHealth;
        }

        protected virtual void Update()
        {
            ActorData.CharacterStats.Position = transform.position;
            ActorData.CharacterStats.Rotation = transform.rotation;
        }

        public virtual void OnWeaponDamage(float damage)
        {
            if (ActorData.CharacterStats.IsDead == true)
            {
                return;
            }

            ActorData.CharacterStats.CurrentHealth -= damage;
            if (ActorData.CharacterStats.CurrentHealth <= 0)
            {
                ScriptManager.Instance.InvokeEvent("OnActorDeath", ActorData.CharacterStats.CharacterID);
                ActorData.CharacterStats.IsDead = true;
            }
        }
    }
}