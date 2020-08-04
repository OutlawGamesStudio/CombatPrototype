using UnityEngine;

namespace ForgottenLegends.Core
{
    class DayNightCycle : Singleton<DayNightCycle>
    {
        #region Constants
        public const int GAME_YEAR = 1204;
        #endregion

        #region Properties
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public int Hour;
        public int Minute;
        #endregion

        #region Variables
        private float m_CurrentSecond;
        #endregion

        private void Start()
        {
            if (Day < 1)
            {
                Day = 1;
            }
            if (Year < GAME_YEAR)
            {
                Year = GAME_YEAR;
            }
        }

        private void Update()
        {
            m_CurrentSecond += Time.deltaTime;
            if (m_CurrentSecond > 1)
            {
                m_CurrentSecond = 0;
                Minute++;
                if (Minute > 59)
                {
                    Minute = 0;
                    Hour++;
                    if (Hour > 23)
                    {
                        Hour = 0;
                        Day++;
                        if (Day > 7)
                        {
                            Day = 1;
                        }
                    }
                    UnityEngine.Debug.Log($"Current Time: {Day}/{Month}/{Year} {Hour}:{Minute}");
                }
            }
        }
    }
}