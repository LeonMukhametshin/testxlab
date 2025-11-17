using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameScoreText : MonoBehaviour
    {
        [SerializeField] private Text m_scoreText;

        [SerializeField] private ScoreManager m_scoreManager;

        private void OnEnable()
        {
            m_scoreManager.ScoreChanged += UpdateScoreText;
        }

        private void OnDisable()
        {
            m_scoreManager.ScoreChanged -= UpdateScoreText;
        }

        private void UpdateScoreText(int score)
        {
            m_scoreText.text = score.ToString();
        }
    }
}