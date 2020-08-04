using UnityEngine;

namespace ForgottenLegends.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class CombatMusic : CoreMusic
    {
        protected override void Start()
        {
            AudioFolder = "Combat";
            base.Start();
        }

        private void Update()
        {
            if (!FoundEnemy())
            {
                if (m_AudioSource.isPlaying && m_AudioSource.volume > 0)
                {
                    m_AudioSource.volume -= 0.05f;
                    if (m_AudioSource.volume <= 0)
                    {
                        m_AudioSource.volume = 0;
                        m_AudioSource.Stop();
                    }
                }
                return;
            }
            PlayMusic();
        }
    }
}