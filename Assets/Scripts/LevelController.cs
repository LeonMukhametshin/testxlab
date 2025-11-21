using System;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [SerializeField, Min(0.1f)] private float m_spawnRate = 0.5f;
        [SerializeField] private int m_maxMissedCount = 3;

        [SerializeField] private StoneSpawner m_stoneSpawner;

        private float m_time;
        private List<Stone> m_stones;

        private void Awake()
        {
            m_stones = new();
        }

        private void Update()
        {
            UpdateSpawnTimer();
        }

        private void UpdateSpawnTimer()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
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
            Debug.Log("+++");
            UnsubscribeStone(stone);
            ScoreManager.Instance?.Hit();
        }

        private void OnMissed(Stone stone)
        {
            UnsubscribeStone(stone);

            ScoreManager.Instance?.Miss();

            if (ScoreManager.Instance?.CurrentMissedCount >= m_maxMissedCount)
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
    }
}
