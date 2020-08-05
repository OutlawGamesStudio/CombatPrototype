using IniParser;
using IniParser.Model;
using System;
using System.IO;
using UnityEngine;

namespace ForgottenLegends.Setting
{
    public static class SettingsController
    {
        public static readonly string SettingsFile = "Settings.ini";

        public static string GetSettingsFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.productName);
        }

        public static string GetSettingsFile()
        {
            return Path.Combine(GetSettingsFolder(), SettingsFile);
        }

        public static bool DoesSettingsFileExist()
        {
            string rootFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.productName, SettingsFile);
            if (File.Exists(rootFile))
            {
                return true;
            }
            return false;
        }

        public static Settings LoadSettings()
        {
            string rootFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.productName, SettingsFile);
            if (!File.Exists(rootFile))
            {
                return null;
            }
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(rootFile);
            string language = data["General"]["language"];
            string updtIntrvl = data["General"]["scriptUpdateInterval"];
            string dbg = data["General"]["enableScriptDebugging"];
            string aaLevel = data["Graphics"]["antiAliasing"];
            string txtrQlty = data["Graphics"]["textureQuality"];
            string lodDist = data["Graphics"]["lodDistance"];
            string shdwRes = data["Graphics"]["shadowResolution"];
            string shdwDist = data["Graphics"]["shadowDistance"];
            string vsync = data["Graphics"]["vsyncCount"];
            string sftPrtcles = data["Graphics"]["softParticles"];
            string ansio = data["Graphics"]["ansioFiltering"];
            string brdrlss = data["Graphics"]["borderless"];
            string fllscrn = data["Graphics"]["fullscreen"];
            string wdth = data["Graphics"]["width"];
            string hght = data["Graphics"]["height"];

            AALevel antialiasing = (AALevel)byte.Parse(aaLevel);
            QualityLevel textureQuality = (QualityLevel)byte.Parse(txtrQlty);
            QualityLevel lodDistance = (QualityLevel)byte.Parse(lodDist);
            QualityLevel shadowResolution = (QualityLevel)byte.Parse(shdwRes);
            QualityLevel shadowDistance = (QualityLevel)byte.Parse(shdwDist);
            byte vsyncCount = byte.Parse(vsync);
            bool softParticles = bool.Parse(sftPrtcles);
            bool ansioFiltering = bool.Parse(ansio);
            bool borderless = bool.Parse(brdrlss);
            bool fullscreen = bool.Parse(fllscrn);
            float updateInterval = float.Parse(updtIntrvl);
            bool debug = bool.Parse(dbg);
            int width = int.Parse(wdth);
            int height = int.Parse(hght);


            Settings settings = new Settings();
            settings.language = language;
            settings.scriptUpdateInterval = updateInterval;
            settings.enableScriptDebugging = debug;
            settings.antiAliasing = antialiasing;
            settings.textureQuality = textureQuality;
            settings.lodDistance = lodDistance;
            settings.shadowResolution = shadowResolution;
            settings.shadowDistance = shadowDistance;
            settings.vsyncCount = vsyncCount;
            settings.softParticles = softParticles;
            settings.ansioFiltering = ansioFiltering;
            settings.borderless = borderless;
            settings.fullscreen = fullscreen;
            settings.width = width;
            settings.height = height;
            return settings;
        }

        public static void SaveSettings(Settings settings)
        {
            string rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.productName);
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }

            string rootFile = Path.Combine(rootFolder, SettingsFile);
            UnityEngine.Debug.Log($"Saving Settings.ini to {rootFolder}");
            if (!File.Exists(rootFile))
            {
                File.Create(rootFile).Dispose();
            }
            var parser = new FileIniDataParser();
            IniData parsedData = new IniData();
            parsedData.Sections.AddSection("General");
            parsedData["General"].AddKey("language", settings.language);
            parsedData["General"].AddKey("scriptUpdateInterval", settings.scriptUpdateInterval.ToString());
            parsedData["General"].AddKey("enableScriptDebugging", settings.enableScriptDebugging.ToString());

            parsedData.Sections.AddSection("Graphics");
            parsedData["Graphics"].AddKey("antiAliasing", settings.antiAliasing.ToString("d"));
            parsedData["Graphics"].AddKey("textureQuality", settings.textureQuality.ToString("d"));
            parsedData["Graphics"].AddKey("lodDistance", settings.lodDistance.ToString("d"));
            parsedData["Graphics"].AddKey("shadowResolution", settings.shadowResolution.ToString("d"));
            parsedData["Graphics"].AddKey("shadowDistance", settings.shadowDistance.ToString("d"));
            parsedData["Graphics"].AddKey("vsyncCount", settings.vsyncCount.ToString("d"));
            parsedData["Graphics"].AddKey("softParticles", settings.softParticles.ToString());
            parsedData["Graphics"].AddKey("ansioFiltering", settings.ansioFiltering.ToString());
            parsedData["Graphics"].AddKey("borderless", settings.borderless.ToString());
            parsedData["Graphics"].AddKey("fullscreen", settings.fullscreen.ToString());
            parsedData["Graphics"].AddKey("width", settings.width.ToString("d"));
            parsedData["Graphics"].AddKey("height", settings.height.ToString("d"));

            parsedData.Sections.AddSection("Audio");
            parsedData["Audio"].AddKey("masterVolume", settings.masterVolume.ToString());
            parsedData["Audio"].AddKey("musicVolume", settings.musicVolume.ToString());
            parsedData["Audio"].AddKey("sfxVolume", settings.sfxVolume.ToString());
            parsedData["Audio"].AddKey("ambienceVolume", settings.ambienceVolume.ToString());

            parser.WriteFile(rootFile, parsedData);
        }
    }
}