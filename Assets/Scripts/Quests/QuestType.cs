using UnityEngine;

namespace ForgottenLegends.Quests
{
    public enum QuestType
    {
        [InspectorName("Main Quest")] Main,
        [InspectorName("Side Quest")] Side,
        [InspectorName("Miscellaneous Quest")] Misc
    };
}