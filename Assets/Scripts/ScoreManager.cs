using System;
using UnityEngine;

namespace Golf
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;

        public int CurrentScore => m_currentScore;
        public int CurrentMissedCount => m_currentMissedCount;

        [SerializeField] private int m_maxMissedCount = 3;

        private int m_currentScore;
        private int m_currentMissedCount;

        public void Hit()
        {
            m_currentScore++;
            Debug.Log("Hit");
            ScoreChanged?.Invoke(m_currentScore);
        }

        public void Miss()
        {
            m_currentMissedCount++;
            Debug.Log("Miss");

            if(m_currentMissedCount <= 0)
            {
                // Event GameOver
            }
        }
    }
}
