using UnityEngine;

namespace Golf
{
    [CreateAssetMenu(fileName = "GameDifficulty", menuName = "Scriptable Objects/GameDifficulty")]
    public class DifficultySettings : ScriptableObject
    {
        public float SpawnRate => m_spawnRate;
        public int MaxMissedCount => m_maxMissedCount;

        [SerializeField] private float m_spawnRate;
        [SerializeField] private int m_maxMissedCount;
    }
}
