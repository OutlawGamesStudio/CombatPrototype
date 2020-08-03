using System;

public enum QualityLevel : byte
{
    Ultra = 0,
    High = 1,
    Medium = 2,
    Low = 3
};

public enum AALevel : byte
{
    x8 = 0,
    x4 = 1,
    x2 = 2,
    Off = 3
};

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
}
