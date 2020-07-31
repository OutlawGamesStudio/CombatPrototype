using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct ScriptCallback
{
    public string callbackName;
    public object[] callbackParamaters;
}

public class ScriptManager : Singleton<ScriptManager>
{
    private LuaVM m_LuaVM;
    private LuaVM.VMSettings m_VMSettings;
    public List<Script> m_ScriptFiles = new List<Script>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Script Interpreter...");
        m_VMSettings = LuaVM.VMSettings.AttachAll;
        m_LuaVM = new LuaVM(m_VMSettings);

        // Use forward slashes, even on Windows.
        string scriptPath = Application.streamingAssetsPath + "/Data/Scripts";
        string[] scripts = Directory.GetFiles(scriptPath, "*.lua", SearchOption.AllDirectories);
        foreach(var item in scripts)
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

    public void RunScript(Script script, ScriptCallback[] callbacks = null)
    {
        if (!File.Exists(script.scriptPath))
        {
            Debug.LogError($"Cannot run script {script} as it does not exist.");
            return;
        }

        Debug.Log($"RunScript: {script.scriptName} (Events: {callbacks.Length})");
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
        Debug.Log($"Invoking {eventName} in {m_ScriptFiles.Count} scripts.");
        foreach (var item in m_ScriptFiles)
        {
            RunScript(item, new ScriptCallback[] { scriptCallback } );
        }
    }

    private void Internal_InvokeEvent(string eventName, params object[] paramaters)
    {
        if(m_LuaVM.DoesCallExist(eventName) == true)
        {
            Debug.Log($"Internal_InvokeEvent: {eventName} (Paramaters: {paramaters.Length})");
            m_LuaVM.Call(eventName, paramaters);
        }
    }
}