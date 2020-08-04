using System.Collections.Generic;
using UnityEngine;

namespace ForgottenLegends.AI
{
    [CreateAssetMenu(fileName = "AiSchedule", menuName = "AI/Schedule")]
    public class AiSchedule : ScriptableObject
    {
        public List<AiScheduleType> aiSchedule;

        public AiState GetNextState()
        {
            if (aiSchedule == null || aiSchedule.Count < 1)
            {
                return null;
            }
            foreach (var item in aiSchedule)
            {
                if (hasMetCondition(item))
                {
                    return item.aiState;
                }
            }
            return null;
        }

        private bool hasMetCondition(AiScheduleType aiSchedule)
        {
            return aiSchedule.HasMetCondition();
        }
    }
}