using UnityEngine;

namespace Golf
{
    public class GameDifficultyManager : MonoBehaviour
    {
        public static GameDifficultyManager Instance { get; private set; }
        public Difficulty CurrentDifficulty { get; private set; }

        [SerializeField] private DifficultySettings[] m_availableDifficulties;
        [SerializeField] private Difficulty m_defaultDifficulty;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public DifficultySettings GetSettingsForDifficulty(Difficulty difficulty)
        {
            int index = (int)difficulty;
            if (index >= 0 && index < m_availableDifficulties.Length)
            {
                return m_availableDifficulties[index];
            }
            return m_availableDifficulties[0];
        }

        public void SaveDifficulty(int difficulty)
        {
            PlayerPrefs.SetInt(GlobalConstans.GameDifficulty, difficulty);
            PlayerPrefs.Save();
        }

        public void LoadDifficulty()
        {
            int savedDifficulty = PlayerPrefs.GetInt(GlobalConstans.GameDifficulty);

            CurrentDifficulty = (Difficulty)savedDifficulty;
        }
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}