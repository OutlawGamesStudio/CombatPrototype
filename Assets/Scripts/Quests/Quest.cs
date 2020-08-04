using System;
using UnityEngine;

public enum QuestType
{
    [InspectorName("Main Quest")] Main,
    [InspectorName("Side Quest")] Side,
    [InspectorName("Miscellaneous Quest")] Misc
};

public enum ObjectiveType
{
    [InspectorName("Kill NPC")] Kill,
    [InspectorName("Fetch Item")] Fetch,
    [InspectorName("Go To Location")] Destination,
    [InspectorName("Talk to NPC")] Talk
};

[Serializable]
public struct QuestData
{
    public string QuestName;
    public QuestObjective[] QuestObjectives;
    public bool QuestCompleted;
    public Script QuestScript;
    public QuestType QuestType;
}

[Serializable]
public struct QuestObjective
{
    public string ObjectiveName;
    public ObjectiveType ObjectiveType;
    public ActorData ObjectiveNPC;
    // public Item ObjectiveItem;
    public Vector3 ObjectiveLocation;
    public Script ObjectiveScript;
}

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    public QuestData QuestData;
}
