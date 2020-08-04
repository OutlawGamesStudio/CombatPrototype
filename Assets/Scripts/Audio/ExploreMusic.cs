using UnityEngine;

namespace ForgottenLegends.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class ExploreMusic : CoreMusic
    {
        protected override void Start()
        {
            AudioFolder = "Explore";
            base.Start();
        }

        private void Update()
        {
            if (FoundEnemy() && m_AudioSource.isPlaying)
            {
                m_AudioSource.Stop();
                return;
            }
            PlayMusic();
        }
    }
}