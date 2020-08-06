using ForgottenLegends.Character;
using UnityEngine;

namespace ForgottenLegends.Audio
{
    public abstract class CoreMusic : MonoBehaviour
    {
        protected string DEFAULT_AUDIO_FOLDER = "None";
        protected string AudioFolder = "None";
        public static bool CombatMusicPlaying { get; protected set; }

        protected AudioSource m_AudioSource = null;
        private Transform m_Player = null;
        [SerializeField] protected AudioClip[] m_AudioClips = null;

        protected virtual void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
            m_Player = Player.Instance.transform;
            m_AudioClips = Resources.LoadAll<AudioClip>($"Audio/Music/{AudioFolder}");
            if (AudioFolder == DEFAULT_AUDIO_FOLDER)
            {
                throw new System.Exception($"You must set the AudioFolder to anything other than {DEFAULT_AUDIO_FOLDER }");
            }
        }

        protected bool FoundEnemy()
        {
            float minDist = 25f;
            NPC[] npcs = FindObjectsOfType<NPC>();
            NPC nearestEnemy = null;
            foreach (var npc in npcs)
            {
                if (npc.ActorInfo.CharacterStats.IsDead == true)
                {
                    continue;
                }

                if (npc.ActorInfo.CharacterStats.CharacterType != CharacterType.Enemy)
                {
                    continue;
                }

                float dist = Vector3.Distance(npc.transform.position, m_Player.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearestEnemy = npc;
                }
            }
            if (nearestEnemy == null)
            {
                return false;
            }
            return true;
        }

        protected void PlayMusic()
        {
            if (!m_AudioSource.isPlaying)
            {
                int index = Random.Range(0, m_AudioClips.Length);
                m_AudioSource.clip = m_AudioClips[index];
                m_AudioSource.volume = 1;
                m_AudioSource.Play();
            }
        }
    }
}