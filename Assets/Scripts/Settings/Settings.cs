using System;

namespace ForgottenLegends.Setting
{
    [Serializable]
    public class Settings
    {
        // General settings
        public string language;

        // Graphics Settings
        public AALevel antiAliasing;
        public QualityLevel textureQuality;
        public QualityLevel lodDistance;
        public QualityLevel shadowResolution;
        public QualityLevel shadowDistance;
        public byte vsyncCount;
        public bool softParticles;
        public bool ansioFiltering;
        public bool borderless;
        public bool fullscreen;
        public int width;
        public int height;

        // Audio Settings
        public float masterVolume;
        public float musicVolume;
        public float sfxVolume;
        public float ambienceVolume;

        // Script settings
        public float scriptUpdateInterval;
        public bool enableScriptDebugging;
    }
}