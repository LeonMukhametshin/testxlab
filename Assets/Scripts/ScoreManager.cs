using System;

namespace Golf
{
    public class ScoreManager
    {
        public static ScoreManager Instance
        {
            get
            {
                if (m_instance is null)
                {
                    m_instance = new();
                }
                return m_instance;
            }
        }

        public event Action<int> ScoreChanged;

        public int CurrentScore => m_currentScore;
        public int CurrentMissedCount => m_currentMissedCount;

        private static ScoreManager m_instance;

        private int m_currentScore;
        private int m_currentMissedCount; 
        private int m_maxMissedCount = 3;

        private ScoreManager(int currentScore = 0, int currentMissedCount = 0, int maxMissedCount = 3)
        {
            m_currentScore = currentScore;
            m_currentMissedCount = currentMissedCount;
            m_maxMissedCount = maxMissedCount;
        }

        public void Hit()
        {
            m_currentScore++;
            ScoreChanged?.Invoke(m_currentScore);
        }

        public void Miss()
        {
            m_currentMissedCount++;
        }

        public void Clear()
        {
            m_currentScore = 0;
            m_currentMissedCount = m_maxMissedCount;
            ScoreChanged?.Invoke(m_currentScore);
        }
    }
}
