using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float m_spawnRate = 0.5f;

        [SerializeField] private StoneSpawner m_stoneSpawner;

        private float m_time;

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
        }

        private void OnHitStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;

            ScoreManager.Instance?.Hit();
        }

        private void OnMissed(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;

            ScoreManager.Instance?.Miss();

            if (ScoreManager.Instance?.CurrentMissedCount <= 0)
            {
                // Event GameOver
            }
        }
    }
}
