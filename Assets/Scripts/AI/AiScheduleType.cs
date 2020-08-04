using ForgottenLegends.Core;
using System;
using UnityEngine;

namespace ForgottenLegends.AI
{
    [Serializable]
    public class AiScheduleType
    {
        /// <summary>
        /// Used for debugging
        /// </summary>
        public string name;

        /// <summary>
        /// Time of Day, ranging from 0 to 23
        /// </summary>
        [Range(-1, 23)] public int timeOfDay;
        [Range(-1, 23)] public int maxTimeOfDay;

        /// <summary>
        /// Day of week, ranging from 0 to 7.<br/>
        /// 0 being any day, and 1 -> 7 being Monday -> Sunday
        /// </summary>
        [Range(0, 7)] public int dayOfWeek;

        public AiState aiState;

        public bool HasMetCondition()
        {
            bool hasMetTime = false, hasMetDay = false;
            if (dayOfWeek == 0 || dayOfWeek == DayNightCycle.Instance.Day)
            {
                hasMetDay = true;
            }
            if (timeOfDay == -1 || timeOfDay == DayNightCycle.Instance.Hour && DayNightCycle.Instance.Hour < maxTimeOfDay)
            {
                hasMetTime = true;
            }
            return hasMetTime == true && hasMetDay == true;
        }
    }
}