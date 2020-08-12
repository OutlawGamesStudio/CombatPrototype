using System;
using UnityEngine;

namespace ForgottenLegends.Quests
{
    [Serializable]
    public struct QuestObjective
    {
        public string ObjectiveName;
        public ObjectiveType ObjectiveType;
        public string ObjectiveNPC;
        public string ObjectiveItem;
        public Vector3 ObjectiveLocation;
    }
}