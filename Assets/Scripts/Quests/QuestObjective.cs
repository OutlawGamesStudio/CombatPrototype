using ForgottenLegends.Character;
using ForgottenLegends.Scripts;
using System;
using UnityEngine;

namespace ForgottenLegends.Quests
{
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
}