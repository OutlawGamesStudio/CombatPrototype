using ForgottenLegends.Setting;
using System;
using System.IO;

namespace ForgottenLegends.Debug
{
    public static class Logging
    {
        public static void Log(string message)
        {
            if(SettingsScript.Instance.Settings.enableScriptDebugging == false)
            {
                return;
            }

            WriteToScriptLog("INFO: " + message);
            UnityEngine.Debug.Log(message);
        }

        public static void LogWarning(string message)
        {
            WriteToScriptLog("WARNING: " + message);
            UnityEngine.Debug.LogWarning(message);
        }

        public static void LogError(string message)
        {
            WriteToScriptLog("ERROR: " + message);
            UnityEngine.Debug.LogError(message);
        }

        private static void WriteToScriptLog(string message)
        {
            string scriptLog = Path.Combine(SettingsController.GetSettingsFolder(), "Script.log");
            if (!File.Exists(scriptLog))
            {
                File.Create(scriptLog).Dispose();
            }
            string logMessage = $"{DateTime.Now.ToString()} {message}{Environment.NewLine}";
            File.AppendAllText(scriptLog, logMessage);
        }
    }
}
