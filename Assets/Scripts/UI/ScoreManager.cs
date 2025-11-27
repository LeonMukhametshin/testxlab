using System;
using UnityEngine;

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
        public event Action<int> RecordChanged;

        public int Score
        {
            get => m_score;
            private set
            {
                m_score = value;
                ScoreChanged?.Invoke(m_score);
            }
        }

        public int Record
        {
            get => PlayerPrefs.GetInt(GlobalConstans.Record, 0);
            private set
            {
                if (Record <= value)
                {
                    PlayerPrefs.SetInt(GlobalConstans.Record, value);
                    RecordChanged?.Invoke(Record);
                }
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

        public void Hit(int value)
        {
            Score += value;
        }

        public void Miss()
        {
            m_currentMissedCount++;
        }

        public void UpdateRecord() => Record = Score;

        public void Reset()
        {
            Score = 0;
            m_currentMissedCount = 0;
        }
    }
}
