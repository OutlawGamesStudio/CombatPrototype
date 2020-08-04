using UnityEngine;

namespace ForgottenLegends.Quests
{
    [CreateAssetMenu(fileName = "Quest", menuName = "Quests/Quest")]
    public class Quest : ScriptableObject
    {
        public QuestData QuestData;
    }
}