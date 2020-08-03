using UnityEngine;

public class SettingsScript : Singleton<SettingsScript>
{
    public Settings Settings { get; private set; }

    private void Start()
    {
        if(SettingsController.DoesSettingsFileExist() == true)
        {
            Settings = SettingsController.LoadSettings();
            return;
        }
        DefaultSettings defaultSettings = Resources.Load<DefaultSettings>("DefaultSettings");
        Settings = defaultSettings.Settings;
        SettingsController.SaveSettings(Settings);
    }
}
