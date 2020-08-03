using UnityEngine;

[CreateAssetMenu(fileName = "ActorDialogue", menuName = "Dialogue/Dialogue List")]
public class ActorDialogue : ScriptableObject
{
    public Dialogue StartingDialogue;
    public Dialogue[] Dialogues;
}