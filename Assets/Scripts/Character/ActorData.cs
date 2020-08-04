using UnityEngine;

[CreateAssetMenu(fileName = "Actor", menuName = "Actor/Actor Data")]
public class ActorData : ScriptableObject
{
    public CharacterStats CharacterStats;
    public ActorDialogue ActorDialogue;
}
