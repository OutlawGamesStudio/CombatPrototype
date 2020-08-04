using UnityEngine;

public static class MouseCursor
{
    public static bool MouseShown { get; private set; }

    public static void SetMouseVisible(bool visible)
    {
        MouseShown = visible;
        Cursor.visible = visible;
        Cursor.lockState = visible == false ? CursorLockMode.Locked : CursorLockMode.Confined;
    }
}
