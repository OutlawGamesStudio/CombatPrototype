using ForgottenLegends.AI;
using ForgottenLegends.Dialogue;
using UnityEngine;

namespace ForgottenLegends.Character
{
    [CreateAssetMenu(fileName = "Actor", menuName = "Actor/Actor Data")]
    public class ActorData : ScriptableObject
    {
        public CharacterStats CharacterStats;
        public ActorDialogue ActorDialogue;
        public AiState ActorState;
    }
}