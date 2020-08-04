using UnityEngine;

namespace ForgottenLegends.Quests
{
    public enum ObjectiveType
    {
        [InspectorName("Kill NPC")] Kill,
        [InspectorName("Fetch Item")] Fetch,
        [InspectorName("Go To Location")] Destination,
        [InspectorName("Talk to NPC")] Talk
    };
}