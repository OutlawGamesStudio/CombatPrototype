using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ForgottenLegends.Scripts
{
    public class ScriptManager : Singleton<ScriptManager>
    {
        private LuaVM m_LuaVM;
        private LuaVM.VMSettings m_VMSettings;
        public List<Script> m_ScriptFiles = new List<Script>();
        private float m_CurrentWaitTime;

        [SerializeField] private float m_WaitTime = 0.2f;

        // Start is called before the first frame update
        void Start()
        {
            m_WaitTime = SettingsScript.Instance.Settings.scriptUpdateInterval;
            m_VMSettings = LuaVM.VMSettings.AttachAll;
            m_LuaVM = new LuaVM(m_VMSettings);
            if (m_WaitTime < 0.1f)
            {
                m_WaitTime = 0.1f;
            }

            // Use forward slashes, even on Windows.
            string scriptPath = Application.streamingAssetsPath + "/Data/Scripts";
            string[] scripts = Directory.GetFiles(scriptPath, "*.lua", SearchOption.AllDirectories);
            foreach (var item in scripts)
            {
                Script script = new Script
                {
                    scriptName = Path.GetFileName(item),
                    scriptPath = item
                };
                ScriptCallback scriptCallback = new ScriptCallback();
                scriptCallback.callbackName = "OnStart";
                RunScript(script, new ScriptCallback[] { scriptCallback });
                m_ScriptFiles.Add(script);
            }
        }

        private void Update()
        {
            m_CurrentWaitTime += Time.deltaTime;
            if (m_CurrentWaitTime > m_WaitTime)
            {
                InvokeEvent("OnUpdate");
                m_CurrentWaitTime = 0;
            }
        }

        public void RunScript(Script script, ScriptCallback[] callbacks = null)
        {
            if (!File.Exists(script.scriptPath))
            {
                UnityEngine.Debug.LogError($"Cannot run script {script} as it does not exist.");
                return;
            }

            string scriptSource = File.ReadAllText(script.scriptPath);
            m_LuaVM.ExecuteString(scriptSource);
            if (callbacks != null)
            {
                foreach (var callback in callbacks)
                {
                    Internal_InvokeEvent(callback.callbackName, callback.callbackParamaters);
                }
            }
        }

        public void InvokeEvent(string eventName, params object[] paramaters)
        {
            ScriptCallback scriptCallback = new ScriptCallback();
            scriptCallback.callbackName = eventName;
            scriptCallback.callbackParamaters = paramaters;
            foreach (var item in m_ScriptFiles)
            {
                RunScript(item, new ScriptCallback[] { scriptCallback });
            }
        }

        private void Internal_InvokeEvent(string eventName, params object[] paramaters)
        {
            if (m_LuaVM.DoesCallExist(eventName) == true)
            {
                m_LuaVM.Call(eventName, paramaters);
            }
        }
    }
}