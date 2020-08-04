using ForgottenLegends.Scripts;
using UnityEngine;

namespace ForgottenLegends.Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        public string DialogueName;
        public string DialogueText;
        public Script DialogueScript;
        public Dialogue[] QuestDialogueChoices;
    }
}