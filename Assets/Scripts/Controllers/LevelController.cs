using System;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [SerializeField] private HealthUI m_healthUI;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private DifficultySettings m_gameDifficulty;

        private float m_time;
        private List<Stone> m_stones;

        private void Update()
        {
            UpdateSpawnTimer();
        }

        private void UpdateSpawnTimer()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_gameDifficulty.SpawnRate)
            {
                SpawnStoneWithEvents();

                m_time = 0;
            }
        }

        private void SpawnStoneWithEvents()
        {
            Stone stone = m_stoneSpawner.Spawn();

            stone.Hit += OnHitStone;
            stone.Missed += OnMissed;

            m_stones.Add(stone);    
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribeStone(stone);
            ScoreManager.Instance?.Hit(1);
        }

        private void OnMissed(Stone stone)
        {
            UnsubscribeStone(stone);

            ScoreManager.Instance?.Miss();
            m_healthUI.DrawHealthPoint(m_gameDifficulty.MaxMissedCount - ScoreManager.Instance.CurrentMissedCount);

            if (ScoreManager.Instance?.CurrentMissedCount >= m_gameDifficulty.MaxMissedCount)
            {
                Finished?.Invoke();

                foreach (var item in m_stones)
                {
                    Destroy(item.gameObject);
                }

                m_stones.Clear();
            }
        }

        private void UnsubscribeStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;
        }

        public void Reset()
        {
            m_stones = new();
            m_healthUI.DrawHealthPoint(m_gameDifficulty.MaxMissedCount);
        }
    }
}
