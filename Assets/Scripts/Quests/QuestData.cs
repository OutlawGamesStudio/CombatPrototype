using System;

namespace ForgottenLegends.Quests
{
    [Serializable]
    public struct QuestData
    {
        public string QuestName;
        public QuestObjective[] QuestObjectives;
        public bool QuestCompleted;
        public Script QuestScript;
        public QuestType QuestType;
    }
}