using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExploreMusic : MonoBehaviour
{
    private AudioSource m_AudioSource = null;
    private Transform m_Player = null;
    [SerializeField] private AudioClip[] m_ExploreAudioTracks = null;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_Player = Player.Instance.transform;
        m_ExploreAudioTracks = Resources.LoadAll<AudioClip>("Audio/Music/Explore");
    }

    private void Update()
    {
        float minDist = 25f;
        NPC[] npcs = GameObject.FindObjectsOfType<NPC>();
        NPC nearestEnemy = null;
        foreach (var npc in npcs)
        {
            if (npc.CharacterStats.IsDead == true)
            {
                continue;
            }

            if (npc.CharacterStats.CharacterType != CharacterType.Enemy)
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

        if (CombatMusic.Instance.EnemyFound == true)
        {
            if (m_AudioSource.isPlaying)
            {
                m_AudioSource.Stop();
            }
            return;
        }
        if (!m_AudioSource.isPlaying)
        {
            int index = Random.Range(0, m_ExploreAudioTracks.Length);
            Debug.Log($"Playing explore track {m_ExploreAudioTracks[index].name}");
            m_AudioSource.clip = m_ExploreAudioTracks[index];
            m_AudioSource.volume = 1;
            m_AudioSource.Play();
        }
    }
}
