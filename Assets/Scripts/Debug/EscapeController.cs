#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeController : MonoBehaviour
{
#if UNITY_DEVELOPMENT || UNITY_EDITOR || DEBUG
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasReleasedThisFrame)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
#endif
}