using ForgottenLegends.AI;
using System;

namespace ForgottenLegends.Character
{
    [Serializable]
    public class ActorInfoAiState
    {
        public StateType ActorStateType;
        public string ActorState;
    }

    [Serializable]
    public class ActorInfo
    {
        public CharacterStats CharacterStats;
        public string ActorDialogue;
        public ActorInfoAiState ActorState;
    }
}
