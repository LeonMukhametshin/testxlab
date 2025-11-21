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

        public int Score
        {
            get => m_score;
            private set
            {
                m_score = value;
                ScoreChanged?.Invoke(m_score);
            }
        }

        public int CurrentMissedCount => m_currentMissedCount;

        private static ScoreManager m_instance;

        private int m_score;
        private int m_currentMissedCount; 

        private ScoreManager(int currentScore = 0, int currentMissedCount = 0)
        {
            m_score = currentScore;
            m_currentMissedCount = currentMissedCount;
        }

        public void Hit()
        {
            Score++;
        }

        public void Miss()
        {
            m_currentMissedCount++;
        }

        public void Reset()
        {
            Score = 0;
            m_currentMissedCount = 0;
        }
    }
}
