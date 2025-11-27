using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameScoreText : MonoBehaviour
    {
        [SerializeField] private Text m_scoreText;
        [SerializeField] private string m_format;

        private void OnEnable()
        {
            ScoreManager.Instance.ScoreChanged += UpdateScoreText;
            UpdateScoreText(ScoreManager.Instance.Score);
        }

        private void OnDisable()
        {
            ScoreManager.Instance.ScoreChanged -= UpdateScoreText;
        }

        private void UpdateScoreText(int score)
        {
            m_format ??= string.Empty;
            m_scoreText.text = string.Format(m_format, score.ToString());
        }
    }
}