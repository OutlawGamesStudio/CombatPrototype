using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string DialogueName;
    public string DialogueText;
    public Script DialogueScript;
    public Dialogue[] QuestDialogueChoices;
}
