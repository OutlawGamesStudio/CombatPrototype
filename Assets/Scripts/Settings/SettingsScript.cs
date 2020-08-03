using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public Settings Settings;

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
