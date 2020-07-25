using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CombatMusic : MonoBehaviour
{
    private AudioSource m_AudioSource = null;
    private Transform m_Player = null;
    [SerializeField] private AudioClip[] m_CombatAudioClips = null;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_Player = Player.Instance.transform;
        m_CombatAudioClips = Resources.LoadAll<AudioClip>("Audio/Music/Combat");
    }

    private void Update()
    {
        float minDist = 25f;
        NPC[] npcs = GameObject.FindObjectsOfType<NPC>();
        NPC nearestEnemy = null;
        foreach(var npc in npcs)
        {
            if(npc.CharacterStats.IsDead == true)
            {
                continue;
            }

            if(npc.CharacterStats.CharacterType != CharacterType.Enemy)
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

        if(nearestEnemy == null)
        {
            if(m_AudioSource.isPlaying)
            {
                FadeOutAudio();
            }
            return;
        }
        if (!m_AudioSource.isPlaying)
        {
            int index = Random.Range(0, m_CombatAudioClips.Length+1);
            m_AudioSource.clip = m_CombatAudioClips[index];
            m_AudioSource.Play();
            return;
        }
    }

    private void FadeOutAudio()
    {
        StartFade(m_AudioSource);
    }

    public IEnumerator StartFade(AudioSource audioSource)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= 0.1f;
            yield return null;
        }
        audioSource.Stop(); 
        yield break;
    }
}
