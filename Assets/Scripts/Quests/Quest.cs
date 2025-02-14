﻿using ForgottenLegends.Scripts;
using System;

namespace ForgottenLegends.Quests
{
    [Serializable]
    public struct Quest
    {
        public string QuestName;
        public QuestObjective[] QuestObjectives;
        public bool QuestCompleted;
        public Script QuestScript;
        public QuestType QuestType;
    }
}