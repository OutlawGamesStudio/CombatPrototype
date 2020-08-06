using ForgottenLegends.Data;
using ForgottenLegends.Scripts;
using System.IO;
using UnityEngine;

namespace ForgottenLegends.Character
{
    public class Actor : MonoBehaviour
    {
        private const float BASE_HEALTH = 100f;
        public string ActorData;
        protected ActorInfo m_ActorInfo;
        public ActorInfo ActorInfo => m_ActorInfo;

        protected virtual void Start()
        {
            // TODO: We should also get the data from a mod folder inside of "My Documents".
            string actorRoot = $"{Application.streamingAssetsPath}/Data/Actors";
            if(!Directory.Exists(actorRoot))
            {
                throw new System.Exception($"Directory {actorRoot} does not exist.");
            }

            m_ActorInfo = ActorLoader.Load($"{actorRoot}/{ActorData}");
            if(m_ActorInfo == null)
            {
                throw new System.Exception("Cannot find actor as file does not exist or is not readable.");
            }
            if (m_ActorInfo.CharacterStats.Level < 1)
            {
                m_ActorInfo.CharacterStats.Level = 1;
            }
            if (m_ActorInfo.CharacterStats.IsBoss)
            {
                m_ActorInfo.CharacterStats.MaxHealth = BASE_HEALTH * 2.0f * m_ActorInfo.CharacterStats.Level;
            }
            else
            {
                m_ActorInfo.CharacterStats.MaxHealth = BASE_HEALTH * 1.25f * m_ActorInfo.CharacterStats.Level;
            }
            m_ActorInfo.CharacterStats.CurrentHealth = m_ActorInfo.CharacterStats.MaxHealth;
        }

        protected virtual void Update()
        {
            m_ActorInfo.CharacterStats.Position = transform.position;
            m_ActorInfo.CharacterStats.Rotation = transform.rotation;
        }

        public virtual void OnWeaponDamage(float damage)
        {
            if (m_ActorInfo.CharacterStats.IsDead == true)
            {
                return;
            }

            m_ActorInfo.CharacterStats.CurrentHealth -= damage;
            if (m_ActorInfo.CharacterStats.CurrentHealth <= 0)
            {
                ScriptManager.Instance.InvokeEvent("OnActorDeath", m_ActorInfo.CharacterStats.CharacterID);
                m_ActorInfo.CharacterStats.IsDead = true;
            }
        }
    }
}